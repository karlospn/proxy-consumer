using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;


namespace Proxy.Consumer.BaseLibrary
{
    public abstract class ConsumingServiceReferenceBase<TClientB, TChannel> 
        where TChannel: class
        where TClientB: System.ServiceModel.ClientBase<TChannel>, new()
    {
        private readonly IConsumingServiceFactory _iConsumingServiceFactory;
        private TClientB _client;

        protected virtual TClientB Client
        {
            get
            {
                if (IsNecessaryCreateClient())
                {
                    _client = _iConsumingServiceFactory.CreateInstance<TClientB, TChannel>(EndpointFunction());
                }
                return _client;
            }
        }

        protected ConsumingServiceReferenceBase(IConsumingServiceFactory iConsumingServiceFactory)
        {
            _iConsumingServiceFactory = iConsumingServiceFactory ?? throw new ArgumentNullException(nameof(iConsumingServiceFactory));
        }


        public abstract Tuple<Binding, EndpointAddress> EndpointFunction();

        protected virtual bool IsNecessaryCreateClient()
        {
            if (_client == default(TClientB))
            {
                return true;
            }
            bool result = false;
            switch (_client.State)
            {
                case System.ServiceModel.CommunicationState.Created:
                case System.ServiceModel.CommunicationState.Opening:
                case System.ServiceModel.CommunicationState.Opened:
                    result = false;
                    break;
                case System.ServiceModel.CommunicationState.Closing:
                case System.ServiceModel.CommunicationState.Closed:
                    result = true;
                    break;
                case System.ServiceModel.CommunicationState.Faulted:
                    _client.Abort();
                    result = true;
                    break;
            }
            return result;
        }

        protected TYpeOfOutput CallWebServiceMethod<TYpeOfOutput, TypeOfInput>(
            Func<TypeOfInput, TYpeOfOutput> methodName, TypeOfInput parameters)
        {
            return methodName(parameters);
        }

        protected TYpeOfOutput CallWebServiceMethod<TYpeOfOutput>(Func<TYpeOfOutput> methodName)
        {
            return methodName();
        }
    }
}
