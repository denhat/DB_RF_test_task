using DB_RF_test_task.Repositories.Entities;
using System;

namespace DB_RF_test_task.Services.Dto
{
    public class CitizenDto
    {
        public int Id { get; set; }
        public DateTime Cdate { get; set; }
        public DateTime Udate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string Inn { get; set; }
        public string Snils { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }

        public static CitizenDto FromEntity(CitizenEntity entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new CitizenDto
            {
                Id = entity.id,
                Cdate = entity.cdate,
                Udate = entity.udate,
                FirstName = entity.first_name,
                LastName = entity.last_name,
                Patronymic = entity.patronymic,
                Inn = entity.inn,
                Snils = entity.snils,
                BirthDate = entity.birth_date,
                DeathDate = entity.death_date
            };
        }

        public static CitizenEntity ToEntity(CitizenDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new CitizenEntity
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
    }
}
