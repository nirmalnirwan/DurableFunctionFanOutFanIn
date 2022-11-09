using System;

namespace FanOutFanInApplication.Dto
{
    public class BulkUploadRequestStagingEntry
    {
        public int Id { get; set; }
        public int BulkUploadRequestId { get; set; }
        public string VerificationStatus { get; set; }
        public string VerificationLog { get; set; }
        public DateTime? VerificationCompletedDate { get; set; }
        public string EntryStatus { get; set; }
        public string MigrationStatus { get; set; }
        public string MigratedDate { get; set; }
        public string AuditLog { get; set; }
        public int? RowNumber { get; set; }
        public int? PropertyId { get; set; }
        public string PropertyType { get; set; }
        public int? AvailabilityId { get; set; }
        public string AvailabilityHeaderText { get; set; }
    }
}
