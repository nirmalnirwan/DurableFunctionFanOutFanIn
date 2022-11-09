using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace DurableFunctionFanOutFanIn
{
    public class QueueTriggerStarter
    {
        [FunctionName("QueueTriggerStarter")]
        public async Task Run([QueueTrigger("bulk-upload-request-queue-test", Connection = "AzureStorageConnectionString")] string requestQueueItem, ILogger log,
            [OrchestrationClient] DurableOrchestrationClient client)
        {
            log.LogInformation($"C# Queue trigger function processed: {requestQueueItem}");
            await client.StartNewAsync("RunOrchestrator", requestQueueItem);
        }
    }
}
