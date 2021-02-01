using DB_RF_test_task.Services.Dto;
using System;

namespace DB_RF_test_task.API.v1.Models
{
    public class ResultModel
    {
        public bool is_successed { get; set; }
        public string message { get; set; }
        public string error { get; set; }

        public static ResultModel FromDto(ResultDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new ResultModel
            {
                is_successed = dto.IsSuccessed,
                message = dto.Message,
                error = dto.Error
            };
        }
    }
}
