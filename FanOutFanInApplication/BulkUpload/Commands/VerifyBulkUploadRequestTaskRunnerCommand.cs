using FanOutFanInApplication.Dto;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FanOutFanInApplication.BulkUpload.Commands
{
    public class VerifyBulkUploadRequestTaskRunnerCommand : IRequest<BulkUploadQueueRequest>
    {
        public int? BulkUploadRequestStagingEntryId { get; set; }

        public class VerifyBulkUploadRequestTaskRunnerCommandHandler : IRequestHandler<VerifyBulkUploadRequestTaskRunnerCommand, BulkUploadQueueRequest>
        {
            public async Task<BulkUploadQueueRequest> Handle(VerifyBulkUploadRequestTaskRunnerCommand request, CancellationToken cancellationToken)
            {
                //do bulk upload file verify
                await Task.Delay(5000);
                return new BulkUploadQueueRequest() { BulkUploadRequestStagingEntryId = request.BulkUploadRequestStagingEntryId.HasValue ? request.BulkUploadRequestStagingEntryId.Value : 0 };
            }
        }
    }
}
