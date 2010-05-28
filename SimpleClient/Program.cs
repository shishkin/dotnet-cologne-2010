using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Discovery;

namespace SimpleClient
{
    [ServiceContract]
    public interface EchoService
    {
        [OperationContract]
        string Echo(string text);
    }

    class Program
    {
        static void Main(string[] args)
        {
            var discovery = new DiscoveryClient(
                new UdpDiscoveryEndpoint());
            var criteria = new FindCriteria(typeof(EchoService))
            {
                Duration = TimeSpan.FromSeconds(2)
            };
            var service = discovery.Find(criteria);
            foreach (var endpoint in service.Endpoints)
            {
                Console.WriteLine("{0}", endpoint.Address);
            }

            var channelFactory =
                new ChannelFactory<EchoService>(
                    new BasicHttpBinding(),
                    service.Endpoints.FirstOrDefault().Address);
            var response = channelFactory.CreateChannel().Echo("hello!");
            Console.WriteLine(response);

        }
    }
}
