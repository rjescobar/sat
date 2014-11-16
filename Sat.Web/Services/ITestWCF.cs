using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Sat.Web.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor"
    //menu to change the interface name "ITestWCF" in both code and config file together.
    [ServiceContract]
    public interface ITestWCF
    {
        [OperationContract]
        String DoWork();

        [OperationContract]
        int Sumar();

        [OperationContract]
        Persona RetornarPersona();
    }
}
