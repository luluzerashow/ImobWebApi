using ApiImob.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApiImob.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/")]
    public class ImoveisController : ControllerBase
    {
        private readonly IImoveisAppService _appService;

        public ImoveisController(IImoveisAppService appService)
        {
            _appService = appService;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [Route("Imoveis")]
        public async Task<IActionResult> Listar()
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
