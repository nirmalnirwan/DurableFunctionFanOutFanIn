namespace FanOutFanInApplication.Dto
{
    public class BulkUploadQueueRequest
    {
        public int BulkUploadRequestId { get; set; }
        public string RequestType { get; set; }
        public int BulkUploadRequestStagingEntryId { get; set; }
        public bool HasPendingStagingEntries { get; set; }
    }
}
