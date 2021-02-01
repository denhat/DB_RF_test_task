using System;

namespace DB_RF_test_task.Services.Dto
{
    public class FileExportResultDto
    {
        public byte[] FileContent { get; set; }
        public bool IsSuccessed { get; set; }
        public string Message { get; set; }
        public string Error { get; set; }
    }
}
