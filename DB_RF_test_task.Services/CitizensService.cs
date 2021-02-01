using DB_RF_test_task.Repositories.Repositories;
using DB_RF_test_task.Services.Dto;
using System.Linq;
using System.Threading.Tasks;

namespace DB_RF_test_task.Services
{
    public interface ICitizensService
    {
        Task<GetResultDto> GetAsync(int id);
        Task<SearchResultDto> SearchAsync(SearchDto search);
        Task<ResultDto> CreateAsync(CitizenDto citizen);
        Task<ResultDto> UpdateAsync(CitizenDto citizenDto);
        Task<ResultDto> DeleteAsync(int id);
    }

    public class CitizensService : ICitizensService
    {
        private readonly ICitizensRepository _repository;

        public CitizensService(ICitizensRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetResultDto> GetAsync(int id)
        {
            var entity = await _repository.GetAsync(id).ConfigureAwait(false);

            return new GetResultDto
            {
                Citizen = CitizenDto.FromEntity(entity),
                IsSuccessed = true,
                Message = null,
                Error = null
            };
        }

        public async Task<SearchResultDto> SearchAsync(SearchDto search)
        {
            var entities = await _repository.SearchAsync(SearchDto.ToCriteria(search), search.Skip, search.Take).ConfigureAwait(false);

            return new SearchResultDto
            {
                Citizens = entities?.Select(a => CitizenDto.FromEntity(a)).ToArray(),
                IsSuccessed = true,
                Message = null,
                Error = null
            };
        }

        public async Task<ResultDto> CreateAsync(CitizenDto citizen)
        {
            await _repository.CreateAsync(new[] { CitizenDto.ToEntity(citizen) }).ConfigureAwait(false);

            return new ResultDto
            {
                IsSuccessed = true,
                Message = "New citizen has been created",
                Error = null
            };
        }

        public async Task<ResultDto> UpdateAsync(CitizenDto citizen)
        {
            await _repository.UpdateAsync(new[] { CitizenDto.ToEntity(citizen) }).ConfigureAwait(false);

            return new ResultDto
            {
                IsSuccessed = true,
                Message = "Citizen has been updated",
                Error = null
            };
        }

        public async Task<ResultDto> DeleteAsync(int id)
        {
            await _repository.DeleteAsync(new[] { id }).ConfigureAwait(false);

            return new ResultDto
            {
                IsSuccessed = true,
                Message = "Citizen has been deleted",
                Error = null
            };
        }
    }
}
