using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Proxy.Consumer.BaseLibrary;

namespace Proxy.Consumer.ConsoleApp.Example.Dependencies
{

    public static class Register
    {
        public static IContainer DIContainer { get; set; }

        public static void Dependencies()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ConsumingServiceReferenceFactory>().As<IConsumingServiceFactory>();
            builder.RegisterType<WcfConsumer>().SingleInstance();
            DIContainer = builder.Build();
        }

    }
}
