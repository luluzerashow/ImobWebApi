using ApiImob.Domain.Interfaces;
using ApiImob.Domain.Models;

namespace ApiImob.Domain.DomainServices
{
    public class ImoveisDomainService : IImoveisDomainService
    {
        private readonly IImoveisInfraService _infraService;

        public ImoveisDomainService(IImoveisInfraService infraService)
        {
            _infraService = infraService;
        }

        public async Task<List<ImoveisModel>> GetAllAsyncImoveis()
        {
            return await _infraService.GetAllAsyncImoveis();
        }
    }
}
