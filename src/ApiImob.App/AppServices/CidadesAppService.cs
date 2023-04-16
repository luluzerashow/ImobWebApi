using ApiImob.Domain.Interfaces;
using ApiImob.Domain.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiImob.App.AppServices
{
    public class CidadesAppService : ICidadesAppService
    {
        private readonly ILogger<CidadesAppService> _logger;
        private readonly ICidadesDomainService _domainService;

        public CidadesAppService(ICidadesDomainService domainService, ILogger<CidadesAppService> logger)
        {
            _domainService = domainService;
            _logger = logger;
        }

        public async Task<List<CidadesModel>> GetAllAsyncCidades()
        {
            return await _domainService.GetAllAsyncCidades();
        }
    }
}
