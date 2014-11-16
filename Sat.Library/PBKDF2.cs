using System;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Sat.Library
{

    /// <summary>
    /// 
    /// </summary>
    public class PBKDF2 : ICryptoService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PBKDF2"/> class.
        /// </summary>
        public PBKDF2()
        {
            //Set default salt size and hashiterations
            HashIterations = 1000;
            SaltSize = 16;
            SubkeyLength = 32;
        }

        public int SubkeyLength { get; set; }

        /// <summary>
        /// Gets or sets the number of iterations the hash will go through
        /// </summary>
        public int HashIterations
        { get; set; }

        /// <summary>
        /// Gets or sets the size of salt that will be generated if no Salt was set
        /// </summary>
        public int SaltSize
        { get; set; }

        /// <summary>
        /// Gets or sets the plain text to be hashed
        /// </summary>
        public string PlainText
        { get; set; }

        /// <summary>
        /// Gets the base 64 encoded string of the hashed PlainText
        /// </summary>
        public string HashedText
        { get; private set; }

        /// <summary>
        /// Gets or sets the salt that will be used in computing the HashedText. This contains both Salt and HashIterations.
        /// </summary>
        public string Salt
        { get; set; }


        /// <summary>
        /// Compute the hash
        /// </summary>
        /// <returns>
        /// the computed hash: HashedText
        /// </returns>
        /// <exception cref="System.InvalidOperationException">PlainText cannot be empty</exception>
        public string Compute()
        {
            if (string.IsNullOrEmpty(PlainText)) throw new InvalidOperationException("PlainText cannot be empty");

            //if there is no salt, generate one
            if (string.IsNullOrEmpty(Salt))
                GenerateSalt();

            HashedText = calculateHash(HashIterations);

            return HashedText;
        }


        /// <summary>
        /// Compute the hash using default generated salt. Will Generate a salt if non was assigned
        /// </summary>
        /// <param name="textToHash"></param>
        /// <returns></returns>
        public string Compute(string textToHash)
        {
            PlainText = textToHash;
            //compute the hash
            Compute();
            return HashedText;
        }


        /// <summary>
        /// Compute the hash that will also generate a salt from parameters
        /// </summary>
        /// <param name="textToHash">The text to be hashed</param>
        /// <param name="saltSize">The size of the salt to be generated</param>
        /// <param name="hashIterations"></param>
        /// <returns>
        /// the computed hash: HashedText
        /// </returns>
        public string Compute(string textToHash, int saltSize, int hashIterations)
        {
            PlainText = textToHash;
            //generate the salt
            GenerateSalt(hashIterations, saltSize);
            //compute the hash
            Compute();
            return HashedText;
        }

        /// <summary>
        /// Compute the hash that will utilize the passed salt
        /// </summary>
        /// <param name="textToHash">The text to be hashed</param>
        /// <param name="salt">The salt to be used in the computation</param>
        /// <returns>
        /// the computed hash: HashedText
        /// </returns>
        public string Compute(string textToHash, string salt)
        {
            PlainText = textToHash;
            Salt = salt;
            //expand the salt
            expandSalt();
            Compute();
            return HashedText;
        }

        /// <summary>
        /// Generates a salt with default salt size and iterations
        /// </summary>
        /// <returns>
        /// the generated salt
        /// </returns>
        /// <exception cref="System.InvalidOperationException"></exception>
        public string GenerateSalt()
        {
            if (SaltSize < 1) throw new InvalidOperationException(string.Format("Cannot generate a salt of size {0}, use a value greater than 1, recommended: 16", SaltSize));

            var rand = RandomNumberGenerator.Create();

            var ret = new byte[SaltSize];

            rand.GetBytes(ret);

            //assign the generated salt in the format of {iterations}.{salt}
            Salt = string.Format("{0}.{1}", HashIterations, Convert.ToBase64String(ret));

            return Salt;
        }

        /// <summary>
        /// Generates a salt
        /// </summary>
        /// <param name="hashIterations">the hash iterations to add to the salt</param>
        /// <param name="saltSize">the size of the salt</param>
        /// <returns>
        /// the generated salt
        /// </returns>
        public string GenerateSalt(int hashIterations, int saltSize)
        {
            HashIterations = hashIterations;
            SaltSize = saltSize;
            return GenerateSalt();
        }

        /// <summary>
        /// Get the time in milliseconds it takes to complete the hash for the iterations
        /// </summary>
        /// <param name="iteration"></param>
        /// <returns></returns>
        public int GetElapsedTimeForIteration(int iteration)
        {
            var sw = new Stopwatch();
            sw.Start();
            calculateHash(iteration);
            return (int)sw.ElapsedMilliseconds;
        }


        private string calculateHash(int iteration)
        {
            //convert the salt into a byte array
            byte[] saltBytes = Encoding.UTF8.GetBytes(Salt);

            using (var pbkdf2 = new Rfc2898DeriveBytes(PlainText, saltBytes, iteration))
            {
                var key = pbkdf2.GetBytes(64);
                return Convert.ToBase64String(key);
            }
        }

        private void expandSalt()
        {
            try
            {
                //get the position of the . that splits the string
                var i = Salt.IndexOf('.');

                //Get the hash iteration from the first index
                HashIterations = int.Parse(Salt.Substring(0, i), System.Globalization.NumberStyles.Number);

            }
            catch (Exception)
            {
                throw new FormatException("The salt was not in an expected format of {int}.{string}");
            }
        }

        public  string HashPassword(string password)
        {
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            // Produce a version 0 (see comment above) password hash.
            byte[] salt;
            byte[] subkey;
            using (var deriveBytes = new Rfc2898DeriveBytes(password, SaltSize, HashIterations))
            {
                salt = deriveBytes.Salt;
                subkey = deriveBytes.GetBytes(SubkeyLength);
            }

            byte[] outputBytes = new byte[1 + SaltSize + SubkeyLength];
            Buffer.BlockCopy(salt, 0, outputBytes, 1, SaltSize);
            Buffer.BlockCopy(subkey, 0, outputBytes, 1 + SaltSize, SubkeyLength);
            return Convert.ToBase64String(outputBytes);
        }

        // hashedPassword must be of the format of HashWithPassword (salt + Hash(salt+input)
        public  bool VerifyHashedPassword(string hashedPassword, string password)
        {
            if (hashedPassword == null)
            {
                throw new ArgumentNullException("hashedPassword");
            }
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }

            byte[] hashedPasswordBytes = Convert.FromBase64String(hashedPassword);

            // Verify a version 0 (see comment above) password hash.

            if (hashedPasswordBytes.Length != (1 + SaltSize + SubkeyLength) || hashedPasswordBytes[0] != 0x00)
            {
                // Wrong length or version header.
                return false;
            }

            byte[] salt = new byte[SaltSize];
            Buffer.BlockCopy(hashedPasswordBytes, 1, salt, 0, SaltSize);
            byte[] storedSubkey = new byte[SubkeyLength];
            Buffer.BlockCopy(hashedPasswordBytes, 1 + SaltSize, storedSubkey, 0, SubkeyLength);

            byte[] generatedSubkey;
            using (var deriveBytes = new Rfc2898DeriveBytes(password, salt, HashIterations))
            {
                generatedSubkey = deriveBytes.GetBytes(SubkeyLength);
            }

            return storedSubkey.SequenceEqual(generatedSubkey);
            return ByteArrayCompare(storedSubkey, generatedSubkey);
        }
        static bool ByteArrayCompare(byte[] a1, byte[] a2)
        {
            return StructuralComparisons.StructuralEqualityComparer.Equals(a1, a2);
        }

    }
}
