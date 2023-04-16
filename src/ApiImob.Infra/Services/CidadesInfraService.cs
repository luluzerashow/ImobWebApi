using ApiImob.Domain.Models;
using ApiImob.Infra.Connections;
using Microsoft.EntityFrameworkCore;

namespace ApiImob.Infra.Services
{
    public class CidadesInfraService
    {
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
