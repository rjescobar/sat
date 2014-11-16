using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Data
{
    public partial class Empleados
    {
        public override string ToString()
        {
            return string.Format("{0} {1}", this.nombres, this.apellidos);
        }

        public String NombreCompleto
        {
            get
            {
                return string.Format("{0} {1}", this.nombres, this.apellidos);
            }
        }
    }
}
