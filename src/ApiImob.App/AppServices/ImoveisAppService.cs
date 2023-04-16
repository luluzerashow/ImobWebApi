using ApiImob.Domain.Interfaces;
using ApiImob.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiImob.App.AppServices
{
    public class ImoveisAppService : IImoveisAppService
    {
        private readonly IImoveisDomainService _domainService;

        public ImoveisAppService(IImoveisDomainService domainService)
        {
            _domainService = domainService;
        }

        public async Task<List<ImoveisModel>> GetAllAsyncImoveis()
        {
            return await _domainService.GetAllAsyncImoveis();
        }
    }
}
