using DB_RF_test_task.Repositories.Criteria;
using System;

namespace DB_RF_test_task.Services.Dto
{
    public class SearchDto
    {
        public int[] Ids { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string Inn { get; set; }
        public string Snils { get; set; }
        public DateTime[] BirthDates { get; set; }
        public DateTime[] DeathDates { get; set; }
        public int? Skip { get; set; }
        public int? Take { get; set; }

        public static SearchCriteria ToCriteria(SearchDto dto)
        {
            if (dto == null)
            {
                return new SearchCriteria();
            }

            return new SearchCriteria
            {
                Ids = dto.Ids,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Patronymic = dto.Patronymic,
                Inn = dto.Inn,
                Snils = dto.Snils,
                BirthDates = dto.BirthDates,
                DeathDates = dto.DeathDates
            };
        }
    }
}
