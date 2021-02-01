using DB_RF_test_task.API.v1.Models;
using DB_RF_test_task.Services;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Threading.Tasks;

namespace DB_RF_test_task.API.v1.Controllers
{
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/ie")]
    public class ImportExportController : ControllerBase
    {
        private readonly IImportExportService _importExportService;

        public ImportExportController(
            IImportExportService importExportService)
        {
            _importExportService = importExportService;
        }

        /// <summary>
        /// Export citizens records to CSV
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("csv/export")]
        public async Task<IActionResult> ExportAsync([FromBody] SearchModel model)
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

                var fileContent = await _importExportService.CsvExportAsync(SearchModel.ToDto(model)).ConfigureAwait(false);
                var fileName = $"citizens_{DateTime.UtcNow.ToString("yyyy-MM-dd_HH_mm_ss")}.csv";

                return File(fileContent, "text/csv", fileName);
            }
            catch (Exception ex)
            {
                Log.Error(ex, string.Empty);
                return StatusCode(500, new ResultModel { error = ex.Message });
            }
        }

        /// <summary>
        /// Import citizens records from CSV
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("csv/import")]
        public async Task<IActionResult> ImportAsync([FromBody] byte[] fileContent)
        {
            try
            {
                if (fileContent == null || fileContent.Length == 0)
                {
                    var errorMessage = "Incorrect data";
                    Log.Error(errorMessage);

                    return StatusCode(422, new ResultModel
                    {
                        is_successed = false,
                        error = errorMessage
                    });
                }

                var resultDto = await _importExportService.CsvImportAsync(fileContent).ConfigureAwait(false);
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
