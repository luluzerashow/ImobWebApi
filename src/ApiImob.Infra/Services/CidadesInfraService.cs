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

        public CidadesInfraService(ILogger<CidadesInfraService> logger)
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

        //trocar para viewmodel?
        public async Task<bool> CreateAsync(CidadesModel dados)
        {
            using (var context = new EntityConnectionDB())
            {
                try
                {
                    var cidadeModel = new CidadesModel();

                    cidadeModel.Nome = dados.Nome.ToString();
                    cidadeModel.DataCriacao = DateTime.Now;
                    cidadeModel.DataAtualizacao = DateTime.Now;

                    await context.CidadesDbSet.AddAsync(cidadeModel);
                    await context.SaveChangesAsync();

                    return true;
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
        }
    }
}
