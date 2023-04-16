using ApiImob.Domain.Interfaces;
using ApiImob.Domain.Models;
using ApiImob.Infra.Connections;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ApiImob.Infra.Services
{
    public class CidadesInfraService : ICidadesInfraService
    {
        private readonly ILogger<CidadesInfraService> _logger;

        public CidadesInfraService(IImoveisInfraService infraService, ILogger<CidadesInfraService> logger)
        {
            _logger = logger;
        }

        public async Task<List<CidadesModel>> GetAllAsyncCidades()
        {
            using (var context = new EntityConnectionDB())
            {
                List<CidadesModel> result = await context.CidadesDbSet.ToListAsync();

                return result;
            }
        }
    }
}
