using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiImob.Domain.Models.Paginacao;

namespace ApiImob.Domain.Models
{
    public class CidadesFilterDbModel : PagedBaseRequestModel
    {
        public string? Nome { get; set; }
    }
}
