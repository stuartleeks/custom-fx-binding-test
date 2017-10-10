using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Azure.WebJobs.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomExtensions
{
    public class MyMessageExtensionConfigProvider : IExtensionConfigProvider
    {
        public void Initialize(ExtensionConfigContext context)
        {
            context.Trace.Info($"In {nameof(MyMessageExtensionConfigProvider)}.{nameof(Initialize)}");

            context.AddConverter<string, MyMessage>(s =>
                new MyMessage { Name = "Custom-binding (string): " + s }
            );

            context.AddConverter<EventData, MyMessage>(s =>
                    {
                        //var body = Encoding.UTF8.GetString(s.GetBytes());
                        //return new MyMessage { Name = "Custom-binding (EventData): " + body };
                        return new MyMessage { Name = "Custom-binding (EventData): " + s.ToString() };
                    }
            );
        }
    }
}
