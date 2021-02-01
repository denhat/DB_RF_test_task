using System;

namespace DB_RF_test_task.Repositories.Criteria
{
    public class SearchCriteria
    {
        private string _FirstName;
        private string _LastName;
        private string _Patronymic;
        private string _Inn;
        private string _Snils;

        public int[] Ids { get; set; }
        public string FirstName
        { 
            get => _FirstName?.Trim() ?? string.Empty;
            set => _FirstName = value;
        }
        public string LastName
        {
            get => _LastName?.Trim() ?? string.Empty;
            set => _LastName = value;
        }
        public string Patronymic
        {
            get => _Patronymic?.Trim() ?? string.Empty;
            set => _Patronymic = value;
        }
        public string Inn
        {
            get => _Inn?.Trim() ?? string.Empty;
            set => _Inn = value;
        }
        public string Snils
        {
            get => _Snils?.Trim() ?? string.Empty;
            set => _Snils = value;
        }
        public DateTime[] BirthDates { get; set; }
        public DateTime[] DeathDates { get; set; }
    }
}
