using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiImob.Domain.Models.Paginacao
{
    public class PagedBaseResponseModel<T>
    {
        public int TotalPages { get; set; }
        public int TotalRegisters { get; set; }
        public int TotalRegistersFilters { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public List<T> Result { get; set; }
    }
}
