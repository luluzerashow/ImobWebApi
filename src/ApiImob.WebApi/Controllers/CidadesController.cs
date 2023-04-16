using ApiImob.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;


namespace ApiImob.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/")]
    public class CidadesController : ControllerBase
    {
        private readonly ILogger<CidadesController> _logger;
        private readonly ICidadesAppService _appService;

        public CidadesController(ICidadesAppService appService, ILogger<CidadesController> logger)
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
                _logger.LogInformation("Iniciando Cidades-ListarTodos");
                return Ok(await _appService.GetAllAsyncCidades());
            }
            catch (ArgumentException ex)
            {
                _logger.LogError("Error ao retornar Cidades-ListarTodos", ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
