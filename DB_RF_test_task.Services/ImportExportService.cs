using CsvHelper;
using CsvHelper.Configuration;
using DB_RF_test_task.Repositories.Criteria;
using DB_RF_test_task.Repositories.Repositories;
using DB_RF_test_task.Services.Dto;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DB_RF_test_task.Services
{
    public interface IImportExportService
    {
        Task<byte[]> CsvExportAsync(SearchDto search);
        Task<ResultDto> CsvImportAsync(byte[] fileContent);
    }

    public class ImportExportService : IImportExportService
    {
        private readonly ICitizensRepository _repository;

        public ImportExportService(ICitizensRepository repository)
        {
            _repository = repository;
        }

        public async Task<byte[]> CsvExportAsync(SearchDto search)
        {
            var citizens = (await _repository.SearchAsync(SearchDto.ToCriteria(search), null, null).ConfigureAwait(false))
                            .Select(a => CitizenExportDto.FromEntity(a)).ToArray();
            var fileContent = await GetCsvFromDataAsync(citizens).ConfigureAwait(false);

            return fileContent;
        }

        public async Task<ResultDto> CsvImportAsync(byte[] fileContent)
        {
            var citizens = await GetDataFromCsvAsync(fileContent).ConfigureAwait(false);
            await _repository.CreateAsync(citizens?.Select(a => CitizenExportDto.ToEntity(a)).ToArray()).ConfigureAwait(false);

            return new ResultDto 
            {
                IsSuccessed = true,
                Message = "Data has been imported",
                Error = null
            };
        }

        private async Task<byte[]> GetCsvFromDataAsync(CitizenExportDto[] citizens)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var writer = new StreamWriter(memoryStream))
                using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture) { HasHeaderRecord = false }))
                {
                    csv.WriteRecords(citizens);
                }

                return memoryStream.ToArray();
            }
        }

        private async Task<CitizenExportDto[]> GetDataFromCsvAsync(byte[] fileContent)
        {
            using (var memoryStream = new MemoryStream(fileContent))
            using (var reader = new StreamReader(memoryStream))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return csv.GetRecords<CitizenExportDto>().ToArray();
            }
        }
    }
}
