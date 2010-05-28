using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace SimpleService
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

    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(
                typeof(EchoService),
                new Uri("http://localhost:8081/Echo")))
            {
                host.AddServiceEndpoint(
                    typeof(EchoService),
                    new WSHttpBinding(),
                    "ws");
                host.AddDefaultEndpoints();
                host.Open();

                foreach (var endpoint in host.Description.Endpoints)
                {
                    Console.WriteLine("{0} ({1})",
                        endpoint.Address,
                        endpoint.Binding.Name);
                }

                Console.ReadLine();
            }
        }
    }
}
