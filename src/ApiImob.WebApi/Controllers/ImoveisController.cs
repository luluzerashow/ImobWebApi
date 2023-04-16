using ApiImob.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApiImob.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/")]
    public class ImoveisController : ControllerBase
    {
        private readonly ILogger<ImoveisController> _logger;
        private readonly IImoveisAppService _appService;

        public ImoveisController(IImoveisAppService appService, ILogger<ImoveisController> logger)
        {
            _appService = appService;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [Route("ListarTodos")]
        public async Task<IActionResult> ListarTodos()
        {
            try
            {
                return Ok(await _appService.GetAllAsyncImoveis());
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
