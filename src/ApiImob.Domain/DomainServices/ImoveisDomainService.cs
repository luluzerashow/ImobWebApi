using ApiImob.Domain.Interfaces;
using ApiImob.Domain.Models;
using Microsoft.Extensions.Logging;

namespace ApiImob.Domain.DomainServices
{
    public class ImoveisDomainService : IImoveisDomainService
    {
        private readonly ILogger<ImoveisDomainService> _logger;
        private readonly IImoveisInfraService _infraService;

        public ImoveisDomainService(IImoveisInfraService infraService, ILogger<ImoveisDomainService> logger)
        {
            _infraService = infraService;
            _logger = logger;
        }

        public async Task<List<ImoveisModel>> GetAllAsyncImoveis()
        {
            return await _infraService.GetAllAsyncImoveis();
        }
    }
}
