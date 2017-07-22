using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;
using Proxy.Consumer.ConsoleApp.Example.Dependencies;

namespace Proxy.Consumer.ConsoleApp.Example
{
    public class Program
    {

        static void Main(string[] args)
        {
            Register.Dependencies();
            using (var scope = Register.DIContainer.BeginLifetimeScope())
            {
                var invoke = scope.Resolve<WcfConsumer>();
                Console.WriteLine(invoke.Consume(5));
            }
               
        }
    }
}
