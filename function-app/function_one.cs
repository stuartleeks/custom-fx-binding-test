using CustomExtensions;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Azure.WebJobs.ServiceBus;

namespace function_app
{
    public static class function_one
    {

        //[FunctionName("function_one")]
        //public static void Run([EventHubTrigger("custombindings ", Connection = "custombindings_RootManageSharedAccessKey_EVENTHUB")]string myEventHubMessage, TraceWriter log)
        //{
        //    log.Info($"C# Event Hub trigger function processed a message: {myEventHubMessage}");
        //}
        [FunctionName("function_one")]
        public static void Run([EventHubTrigger("custombindings ", Connection = "custombindings_RootManageSharedAccessKey_EVENTHUB")]Test myEventHubMessage, TraceWriter log)
        {
            log.Info($"C# Event Hub trigger function processed a message: '{myEventHubMessage.Name}', Value: {myEventHubMessage.Value}");
        }

    }

}
