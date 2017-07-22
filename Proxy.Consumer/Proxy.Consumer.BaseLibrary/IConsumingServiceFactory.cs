using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Proxy.Consumer.BaseLibrary
{
    public interface IConsumingServiceFactory
    {
        TClientB CreateInstance<TClientB, TChannel>(Tuple<Binding, EndpointAddress> endpointData)
            where TChannel : class
            where TClientB : ClientBase<TChannel>, new();
    }
}