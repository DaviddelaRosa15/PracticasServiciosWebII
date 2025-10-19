using System.Text.Json.Serialization;

namespace FileUploaderWebApi.PublicClasses
{
    public class UploadStatus
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public string? fileName { get; set; }
    }
}
