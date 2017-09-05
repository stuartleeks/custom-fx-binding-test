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
    public class TestBindingProvider : IExtensionConfigProvider
    {
        public void Initialize(ExtensionConfigContext context)
        {
            context.AddConverter<string, Test>(s =>
                new Test { Name = "Custom-binding (string): " + s }
            );

            context.AddConverter<EventData, Test>(s =>
                    new Test { Name = "Custom-binding (EventData): " + s.Body }
            );
        }
    }
}
