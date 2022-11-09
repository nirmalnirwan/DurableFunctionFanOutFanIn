using FanOutFanInApplication.BulkUpload.Commands;
using FanOutFanInApplication.Dto;
using MediatR;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DurableFunctionFanOutFanIn
{
    public class RunOrchestrator
    {
        private readonly IMediator _mediator;

        public RunOrchestrator(IMediator mediator)
        {
            _mediator = mediator;
        }

        [FunctionName("RunOrchestrator")]
        public async Task<List<int>> Runner(
         [OrchestrationTrigger] DurableOrchestrationContext context, ILogger log)
        {
            if (!context.IsReplaying) log.LogInformation("RunOrchestrator started");

            var req = context.GetInput<string>();

            BulkUploadQueueRequest bulkUploadQueueRequest = JsonConvert.DeserializeObject<BulkUploadQueueRequest>(req);

            Task<List<BulkUploadRequestStagingEntry>> stagingEntrytask = Task<List<BulkUploadRequestStagingEntry>>.Factory.StartNew(() =>
            {
                return _mediator.Send(new VerifyBulkUploadPendingRequestCommand()
                {
                    BulkUploadQueueRequest = bulkUploadQueueRequest
                }).Result;
            });

            var bulkUploadRequestStagingEntryList = stagingEntrytask.Result;

            var parallelTasks = new List<Task<int>>();

            foreach (var bulkUploadRequestStagingEntry in bulkUploadRequestStagingEntryList)
            {
                Task<int> task = context.CallActivityAsync<int>("VerifyBulkUploadRequestActivityTrigger", bulkUploadRequestStagingEntry.Id);
                parallelTasks.Add(task);
            }

            await Task.WhenAll(parallelTasks);

            return bulkUploadRequestStagingEntryList.Select(x => x.Id).ToList();
        }
    }
}
