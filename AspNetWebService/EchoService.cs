using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;

namespace AspNetWebService
{
    [ServiceContract]
    public class EchoService
    {
        [OperationContract]
        public string Echo(string text)
        {
            return text;
        }
    }
}