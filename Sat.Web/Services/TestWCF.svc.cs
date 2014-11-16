using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Sat.Web.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TestWCF" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TestWCF.svc or TestWCF.svc.cs at the Solution Explorer and start debugging.
    public class TestWCF : ITestWCF
    {
        public String DoWork()
        {
            return "Hello World";
        }

        public int Sumar()
        {
            throw new NotImplementedException();
        }

        public Persona RetornarPersona()
        {
            return new Persona();
        }
    }
}
