using ApiImob.Domain.DomainServices;
using ApiImob.Domain.Interfaces;
using ApiImob.Domain.Models;
using ApiImob.Infra.Connections;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Xml;

namespace ApiImob.Infra.Services
{
    public class ImoveisInfraService : IImoveisInfraService
    {
        private readonly ILogger<ImoveisInfraService> _logger;

        public ImoveisInfraService(ILogger<ImoveisInfraService> logger)
        {
            _logger = logger;
        }

        public async Task<List<ImoveisModel>> GetAllAsyncImoveis()
        {
            using (var context = new EntityConnectionDB())
            {
                List<ImoveisModel> result = await context.ImoveisDbSet.ToListAsync();

                return result;
            }
        }
    }
}
