using FanOutFanInApplication.BulkUpload.Commands;
using MediatR;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace DurableFunctionFanOutFanIn
{
    public class ActivityTrigger
    {
        private readonly IMediator _mediator;

        public ActivityTrigger(IMediator mediator)
        {
            _mediator = mediator;
        }

        [FunctionName("ActivityTrigger")]
        public async Task<int> Activity([ActivityTrigger] int bulkUploadRequestStagingEntryId, ILogger log)
        {
            log.LogInformation($"Started to trigger VerifyBulkUploadRequestActivityTrigger. Processing for bulkUploadRequestStagingEntryId : {bulkUploadRequestStagingEntryId}.");

            var bulkUploadRequestStagingEntryList = await _mediator.Send(new VerifyBulkUploadRequestTaskRunnerCommand()
            {
                BulkUploadRequestStagingEntryId = bulkUploadRequestStagingEntryId
            });

            log.LogInformation($"Completed to trigger VerifyBulkUploadRequestActivityTrigger. Processed for bulkUploadRequestStagingEntryId : {bulkUploadRequestStagingEntryId}.");
            return bulkUploadRequestStagingEntryId;
        }

    }
}
