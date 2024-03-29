﻿using ApiImob.Domain.Interfaces;
using ApiImob.Domain.Models;
using ApiImob.Domain.Models.Paginacao;
using ApiImob.Domain.ViewModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiImob.Domain.DomainServices
{
    public class CidadesDomainService : ICidadesDomainService
    {
        private readonly ILogger<CidadesDomainService> _logger;
        private readonly ICidadesInfraService _infraService;

        public CidadesDomainService(ICidadesInfraService infraService, ILogger<CidadesDomainService> logger)
        {
            _infraService = infraService;
            _logger = logger;
        }

        public async Task<List<CidadesModel>> GetAllAsyncCidades()
        {
            return await _infraService.GetAllAsyncCidades();
        }

        public async Task<bool> CreateAsync(CidadesViewModel cidade)
        {
            var cidadeModel = new CidadesModel()
            {
                Nome = cidade.Nome,
                DataAtualizacao = DateTime.Now,
                DataCriacao = DateTime.Now,
            };

            return await _infraService.CreateAsync(cidadeModel);
        }

        public async Task<PagedBaseResponseModel<CidadesModel>> GetPagedAsync(CidadesFilterDbModel personFilterDbModel) 
        {
            var result = await _infraService.GetPagedAsync(personFilterDbModel);

            return result;
        }
    }
}
