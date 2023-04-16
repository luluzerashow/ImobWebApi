using ApiImob.Domain.Models;

namespace ApiImob.Domain.Interfaces
{
    public interface IImoveisInfraService
    {
        Task<List<ImoveisModel>> GetAllAsyncImoveis();
    }
}
