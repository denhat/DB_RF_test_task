using DB_RF_test_task.Services.Dto;
using System;

namespace DB_RF_test_task.API.v1.Models
{
    public class SearchModel
    {
        public int[] ids { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string patronymic { get; set; }
        public string inn { get; set; }
        public string snils { get; set; }
        public DateTime[] birth_dates { get; set; }
        public DateTime[] death_dates { get; set; }
        public int? skip { get; set; }
        public int? take { get; set; }

        public static SearchDto ToDto(SearchModel model)
        {
            if (model == null)
            {
                return null;
            }

            return new SearchDto
            {
                Ids = model.ids,
                FirstName = model.first_name,
                LastName = model.last_name,
                Patronymic = model.patronymic,
                Inn = model.inn,
                Snils = model.snils,
                BirthDates = model.birth_dates,
                DeathDates = model.death_dates,
                Skip = model.skip,
                Take = model.take
            };
        }
    }
}
