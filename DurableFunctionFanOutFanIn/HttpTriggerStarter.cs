using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Threading.Tasks;

namespace DurableFunctionFanOutFanIn
{
    public static class HttpTriggerStarter
    {
        [FunctionName("HttpTriggerStarter")]
        public static async Task<HttpResponseMessage> HttpStart(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestMessage req,
           [OrchestrationClient] DurableOrchestrationClient client,
            ILogger log)
        {
            string instanceId = await client.StartNewAsync("RunOrchestrator", null);

            log.LogInformation($"Started orchestration with ID = '{instanceId}'.");

            return client.CreateCheckStatusResponse(req, instanceId);
        }
    }
}