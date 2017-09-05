using System;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Azure.EventHubs;

namespace EventHubPublisher
{
    class Program
    {
        private static EventHubClient eventHubClient;
        static async Task Main(string[] args)
        {
            // Creates an EventHubsConnectionStringBuilder object from the connection string, and sets the EntityPath.
            // Typically, the connection string should have the entity path in it, but for the sake of this simple scenario
            // we are using the connection string from the namespace.
            var eventHubConnectionString = Environment.GetEnvironmentVariable("EventHubConnectionString");
            var eventHubName = Environment.GetEnvironmentVariable("EventHubName");

            var connectionStringBuilder = new EventHubsConnectionStringBuilder(eventHubConnectionString)
            {
                EntityPath = eventHubName
            };

            eventHubClient = EventHubClient.CreateFromConnectionString(connectionStringBuilder.ToString());

            await SendMessagesToEventHub(2);

            await eventHubClient.CloseAsync();
        }

        private static async Task SendMessagesToEventHub(int numMessagesToSend)
        {
            string dateTimeString = DateTime.UtcNow.ToString("yyyy-MM-dd-hh-mm-ss");
            for (var i = 0; i < numMessagesToSend; i++)
            {
                try
                {
                    var message = "{'Name':'Message " + dateTimeString + "', 'Value': " + i + "}";
                    Console.WriteLine($"Sending message: {message}");
                    await eventHubClient.SendAsync(new EventData(Encoding.UTF8.GetBytes(message)));
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"{DateTime.UtcNow} > Exception: {exception.Message}");
                }

                await Task.Delay(10);
            }

            Console.WriteLine($"{numMessagesToSend} messages sent.");
        }
    }
}

