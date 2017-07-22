using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;

namespace Proxy.Consumer.BaseLibrary
{
    public sealed class ConsumingServiceReferenceFactory : IConsumingServiceFactory
    {
        public TClientB CreateInstance<TClientB, TChannel>(Tuple<Binding, EndpointAddress> endpointData) 
            where TClientB : ClientBase<TChannel>, new()
            where TChannel : class
        {
            var client = new TClientB();
            client.Endpoint.Binding = endpointData.Item1;
            client.Endpoint.Address = endpointData.Item2;
            return client;
        }
    }
}
