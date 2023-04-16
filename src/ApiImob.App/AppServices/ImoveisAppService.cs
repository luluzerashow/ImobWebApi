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
    public class ImoveisAppService : IImoveisAppService
    {
        private readonly ILogger<ImoveisAppService> _logger;
        private readonly IImoveisDomainService _domainService;

        public ImoveisAppService(IImoveisDomainService domainService, ILogger<ImoveisAppService> logger)
        {
            _domainService = domainService;
            _logger = logger;
        }

        public async Task<List<ImoveisModel>> GetAllAsyncImoveis()
        {
            return await _domainService.GetAllAsyncImoveis();
        }
    }
}
