using ApiImob.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiImob.Domain.Interfaces
{
    public interface ICidadesDomainService
    {
        Task<List<CidadesModel>> GetAllAsyncCidades();
    }
}
