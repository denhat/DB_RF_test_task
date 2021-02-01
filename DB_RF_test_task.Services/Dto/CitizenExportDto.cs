using DB_RF_test_task.Repositories.Entities;
using System;
using CsvHelper.Configuration.Attributes;
using System.Globalization;

namespace DB_RF_test_task.Services.Dto
{
    public class CitizenExportDto
    {
        public const string EXPORT_DATETIME_FORMAT = "dd.MM.yyyy HH:mm";

        [Name("Имя")]
        public string FirstName { get; set; }
        [Name("Фамилия")]
        public string LastName { get; set; }
        [Name("Отчество")]
        public string Patronymic { get; set; }
        [Name("ИНН")]
        public string Inn { get; set; }
        [Name("СНИЛС")]
        public string Snils { get; set; }
        [Name("Дата и время рождения")]
        public string BirthDate { get; set; }
        [Name("Дата и время смерти")]
        public string DeathDate { get; set; }

        public static CitizenExportDto FromEntity(CitizenEntity entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new CitizenExportDto
            {
                FirstName = entity.first_name,
                LastName = entity.last_name,
                Patronymic = entity.patronymic,
                Inn = entity.inn,
                Snils = entity.snils,
                BirthDate = entity.birth_date?.ToString(EXPORT_DATETIME_FORMAT),
                DeathDate = entity.death_date?.ToString(EXPORT_DATETIME_FORMAT)
            };
        }

        public static CitizenEntity ToEntity(CitizenExportDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            DateTime birthDate;
            DateTime deathDate;
            var hasBirthDate = DateTime.TryParseExact(dto.BirthDate, EXPORT_DATETIME_FORMAT, CultureInfo.InvariantCulture, DateTimeStyles.None, out birthDate);
            var hasDeathDate = DateTime.TryParseExact(dto.DeathDate, EXPORT_DATETIME_FORMAT, CultureInfo.InvariantCulture, DateTimeStyles.None, out deathDate);

            return new CitizenEntity
            {
                first_name = dto.FirstName,
                last_name = dto.LastName,
                patronymic = dto.Patronymic,
                inn = dto.Inn,
                snils = dto.Snils,
                birth_date = hasBirthDate ? (DateTime?)birthDate : null,
                death_date = hasDeathDate ? (DateTime?)deathDate : null
            };
        }
    }
}
