using DB_RF_test_task.Services.Dto;
using System;

namespace DB_RF_test_task.API.v1.Models
{
    public class GetResultModel
    {
        public CitizenModel citizen { get; set; }
        public bool is_successed { get; set; }
        public string message { get; set; }
        public string error { get; set; }

        public static GetResultModel FromDto(GetResultDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new GetResultModel
            {
                citizen = CitizenModel.FromDto(dto.Citizen),
                is_successed = dto.IsSuccessed,
                message = dto.Message,
                error = dto.Error
            };
        }
    }
}
