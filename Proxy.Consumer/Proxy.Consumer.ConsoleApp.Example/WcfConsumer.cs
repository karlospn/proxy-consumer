using Proxy.Consumer.BaseLibrary;
using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Proxy.Consumer.ConsoleApp.Example.ProxyConsumerWCFServReference;

namespace Proxy.Consumer.ConsoleApp.Example
{
    public class WcfConsumer : ConsumingServiceReferenceBase<Service1Client, IService1>
    {
        public WcfConsumer(IConsumingServiceFactory iConsumingServiceFactory) : base(iConsumingServiceFactory){ }

        public override Tuple<Binding, EndpointAddress> EndpointFunction()
        {
            return new Tuple<Binding,EndpointAddress>(new BasicHttpBinding(), new EndpointAddress("http://localhost:17283/Service1.svc"));
        }

        public string Consume(int number)
        {
           return Client.GetData(number);
        }
    }
}
