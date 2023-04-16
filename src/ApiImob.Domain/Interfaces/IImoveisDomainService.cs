using ApiImob.Domain.Models;

namespace ApiImob.Domain.Interfaces
{
    public interface IImoveisDomainService
    {
        Task<List<ImoveisModel>> GetAllAsyncImoveis();
    }
}
