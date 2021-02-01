using DB_RF_test_task.API.v1.Models;
using DB_RF_test_task.Services;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Threading.Tasks;

namespace DB_RF_test_task.API.v1.Controllers
{
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/citizens")]
    public class CitizensController : ControllerBase
    {
        private readonly ICitizensService _citizensService;

        public CitizensController(
            ICitizensService citizensService)
        {
            _citizensService = citizensService;
        }

        /// <summary>
        /// Get a citizen record by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            try
            {
                if (id <= 0)
                {
                    var errorMessage = $"Citizen ID is invalid. ID = {id}";
                    Log.Error(errorMessage);

                    return StatusCode(422, new ResultModel
                    {
                        is_successed = false,
                        error = errorMessage
                    });
                }

                var resultDto = await _citizensService.GetAsync(id).ConfigureAwait(false);
                var result = GetResultModel.FromDto(resultDto);

                if (!result.is_successed)
                {
                    Log.Error(result.error);
                    return StatusCode(422, result);
                }

                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, string.Empty);
                return StatusCode(500, new ResultModel { error = ex.Message });
            }
        }

        /// <summary>
        /// Search citizens records in DB by filters
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("search")]
        public async Task<IActionResult> SearchAsync([FromBody] SearchModel model)
        {
            try
            {
                if (model == null)
                {
                    var errorMessage = "Incorrect data";
                    Log.Error(errorMessage);

                    return StatusCode(422, new ResultModel
                    {
                        is_successed = false,
                        error = errorMessage
                    });
                }

                var resultDto = await _citizensService.SearchAsync(SearchModel.ToDto(model)).ConfigureAwait(false);
                var result = SearchResultModel.FromDto(resultDto);

                if (!result.is_successed)
                {
                    Log.Error(result.error);
                    return StatusCode(422, result);
                }

                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, string.Empty);
                return StatusCode(500, new ResultModel { error = ex.Message });
            }
        }

        /// <summary>
        /// Create new citizen record in DB
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CitizenModel model)
        {
            try
            {
                if (model == null || !model.IsCorrect())
                {
                    var errorMessage = "Incorrect data";
                    Log.Error(errorMessage);

                    return StatusCode(422, new ResultModel
                    {
                        is_successed = false,
                        error = errorMessage
                    });
                }

                var resultDto = await _citizensService.CreateAsync(CitizenModel.ToDto(model)).ConfigureAwait(false);
                var result = ResultModel.FromDto(resultDto);

                if (!result.is_successed)
                {
                    Log.Error(result.error);
                    return StatusCode(422, result);
                }

                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, string.Empty);
                return StatusCode(500, new ResultModel { error = ex.Message });
            }
        }

        /// <summary>
        /// Update citizen record in DB
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] CitizenModel model)
        {
            try
            {
                if (model == null || !model.IsCorrect())
                {
                    var errorMessage = "Incorrect data";
                    Log.Error(errorMessage);

                    return StatusCode(422, new ResultModel
                    {
                        is_successed = false,
                        error = errorMessage
                    });
                }

                if (model.id <= 0)
                {
                    var errorMessage = $"Citizen ID is invalid. ID = {model.id}";
                    Log.Error(errorMessage);

                    return StatusCode(422, new ResultModel
                    {
                        is_successed = false,
                        error = errorMessage
                    });
                }

                var resultDto = await _citizensService.UpdateAsync(CitizenModel.ToDto(model)).ConfigureAwait(false);
                var result = ResultModel.FromDto(resultDto);

                if (!result.is_successed)
                {
                    Log.Error(result.error);
                    return StatusCode(422, result);
                }

                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, string.Empty);
                return StatusCode(500, new ResultModel { error = ex.Message });
            }
        }

        /// <summary>
        /// Delete citizen record from DB
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                if (id <= 0)
                {
                    var errorMessage = $"Citizen ID is invalid. ID = {id}";
                    Log.Error(errorMessage);

                    return StatusCode(422, new ResultModel
                    {
                        is_successed = false,
                        error = errorMessage
                    });
                }

                var resultDto = await _citizensService.DeleteAsync(id).ConfigureAwait(false);
                var result = ResultModel.FromDto(resultDto);

                if (!result.is_successed)
                {
                    Log.Error(result.error);
                    return StatusCode(422, result);
                }

                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, string.Empty);
                return StatusCode(500, new ResultModel { error = ex.Message });
            }
        }
    }
}
