using Microsoft.Azure.EventHubs;
using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Azure.WebJobs.ServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomExtensions
{
    public class MyMessageBindingProvider : IExtensionConfigProvider
    {
        public void Initialize(ExtensionConfigContext context)
        {
            context.Trace.Info("In MyMessageBindingProvider.Initialize");

            context.AddConverter<string, MyMessage>(s =>
                new MyMessage { Name = "Custom-binding (string): " + s }
            );

            context.AddConverter<EventData, MyMessage>(s =>
                    new MyMessage { Name = "Custom-binding (EventData): " + s.Body }
            );
        }
    }
}
