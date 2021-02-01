using System;

namespace DB_RF_test_task.Services.Dto
{
    public class SearchResultDto
    {
        public CitizenDto[] Citizens { get; set; }
        public bool IsSuccessed { get; set; }
        public string Message { get; set; }
        public string Error { get; set; }
    }
}
