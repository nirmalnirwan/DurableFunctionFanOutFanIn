using FanOutFanInApplication.Dto;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FanOutFanInApplication.BulkUpload.Commands
{
    public class VerifyBulkUploadPendingRequestCommand : IRequest<List<BulkUploadRequestStagingEntry>>
    {
        public BulkUploadQueueRequest BulkUploadQueueRequest { get; set; }

        public class VerifyBulkUploadPendingRequestCommandHandler : IRequestHandler<VerifyBulkUploadPendingRequestCommand, List<BulkUploadRequestStagingEntry>>
        {
            public async Task<List<BulkUploadRequestStagingEntry>> Handle(VerifyBulkUploadPendingRequestCommand request, CancellationToken cancellationToken)
            {
                await Task.Delay(5000);
                return new List<BulkUploadRequestStagingEntry>() 
                { 
                    new BulkUploadRequestStagingEntry() 
                    {
                        Id = 1000 
                    },
                    new BulkUploadRequestStagingEntry() 
                    { 
                        Id = 1001 
                    }, 
                    new BulkUploadRequestStagingEntry() 
                    { 
                        Id = 1002 
                    } 
                };
            }
        }

    }
}
