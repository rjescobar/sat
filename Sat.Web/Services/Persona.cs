using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Sat.Web.Services
{
    [DataContract]
    public class Persona
    {
        public String NombreCompleto { get; set; }
        public String Nombre { get; set; }
        public String Apellidos { get; set; }
    }
}