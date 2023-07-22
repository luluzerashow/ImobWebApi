using ApiImob.Domain.Interfaces;
using ApiImob.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Net.Mime;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


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
            var stop = Stopwatch.StartNew();

            try
            {
                _logger.LogInformation("Iniciando Cidades-ListarTodos");

                var lista = await _appService.GetAllAsyncCidades();

                stop.Stop();

                return Ok(new
                {
                    From = "ListarTodos",
                    TempoExecucao = stop.Elapsed,
                    Data = lista
                });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError("Error ao retornar Cidades-ListarTodos", ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Teste de descrição
        /// </summary>
        /// <param name="personFilterDbModel"></param>
        /// <returns></returns>
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType((int)HttpStatusCode.OK)]//200
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]//400
        [ProducesResponseType((int)HttpStatusCode.NotFound)]//404
        [Route("ListarPaginado")]
        public async Task<ActionResult<List<CidadesModel>>> ListarPaginado([FromQuery] CidadesFilterDbModel personFilterDbModel)
        {

            _logger.LogInformation("Iniciando Cidades-ListarPaginado");
            var stop = Stopwatch.StartNew();

            try
            {
                var result = await _appService.GetPagedAsync(personFilterDbModel);
                stop.Stop();
                _logger.LogInformation("Finalizando Cidades-ListarPaginado");
                if (result.TotalRegisters > 0)
                    return Ok(new
                    {
                        From = "Cidades-ListarTodos",
                        TempoExecucao = stop.Elapsed,
                        Data = result
                    });
                return BadRequest(result);

            }
            catch (ArgumentException ex)
            {
                _logger.LogError("Error ao retornar Cidades-ListarTodos", ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
