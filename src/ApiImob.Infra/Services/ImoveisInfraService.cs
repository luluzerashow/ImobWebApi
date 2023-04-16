using ApiImob.Domain.Interfaces;
using ApiImob.Domain.Models;
using ApiImob.Infra.Connections;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace ApiImob.Infra.Services
{
    public class ImoveisInfraService : IImoveisInfraService
    {
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
