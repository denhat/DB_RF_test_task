using DB_RF_test_task.Services.Dto;
using System;

namespace DB_RF_test_task.API.v1.Models
{
    public class CitizenModel
    {
        public int id { get; set; }
        public DateTime cdate { get; set; }
        public DateTime udate { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string patronymic { get; set; }
        public string inn { get; set; }
        public string snils { get; set; }
        public DateTime? birth_date { get; set; }
        public DateTime? death_date { get; set; }

        public bool IsCorrect()
        {
            return !string.IsNullOrEmpty(first_name)
                && !string.IsNullOrEmpty(last_name)
                && !string.IsNullOrEmpty(inn);
        }

        public static CitizenModel FromDto(CitizenDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new CitizenModel
            {
                id = dto.Id,
                cdate = dto.Cdate,
                udate = dto.Udate,
                first_name = dto.FirstName,
                last_name = dto.LastName,
                patronymic = dto.Patronymic,
                inn = dto.Inn,
                snils = dto.Snils,
                birth_date = dto.BirthDate,
                death_date = dto.DeathDate
            };
        }

        public static CitizenDto ToDto(CitizenModel model)
        {
            if (model == null)
            {
                return null;
            }

            return new CitizenDto
            {
                Id = model.id,
                Cdate = model.cdate,
                Udate = model.udate,
                FirstName = model.first_name,
                LastName = model.last_name,
                Patronymic = model.patronymic,
                Inn = model.inn,
                Snils = model.snils,
                BirthDate = model.birth_date,
                DeathDate = model.death_date
            };
        }
    }
}
