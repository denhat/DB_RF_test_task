using System;
using System.ComponentModel.DataAnnotations;

namespace DB_RF_test_task.Repositories.Entities
{
    public class CitizenEntity
    {
        [Key]
        public int id { get; set; }
        public DateTime cdate { get; set; }
        public DateTime udate { get; set; }
        [MaxLength(200)]
        public string first_name { get; set; }
        [MaxLength(200)]
        public string last_name { get; set; }
        [MaxLength(200)]
        public string patronymic { get; set; }
        [MaxLength(50)]
        public string inn { get; set; }
        [MaxLength(50)]
        public string snils { get; set; }
        public DateTime? birth_date { get; set; }
        public DateTime? death_date { get; set; }

        public void CopyTo(CitizenEntity entity)
        {
            if (entity == null)
            {
                return;
            }

            entity.id = id;
            entity.cdate = cdate;
            entity.udate = udate;
            entity.first_name = first_name;
            entity.last_name = last_name;
            entity.patronymic = patronymic;
            entity.inn = inn;
            entity.snils = snils;
            entity.birth_date = birth_date;
            entity.death_date = death_date;
        }
    }
}
