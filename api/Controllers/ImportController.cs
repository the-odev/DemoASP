using Microsoft.AspNetCore.Mvc;
using Services;

namespace api.Controllers
{
    [ApiController]
    [Route("import")]
    public class ImportController
    {
        private IImportDataService dataService { get; set; }

        public ImportController(IImportDataService dataService)
        {
            this.dataService = dataService;
        }


        [HttpGet]
        [Route("{season}")]
        public IActionResult GetNameOfEpisodes(int season)
        {
            return new OkObjectResult(this.dataService.GetNameOfEpisode(season));
        }
    }
}