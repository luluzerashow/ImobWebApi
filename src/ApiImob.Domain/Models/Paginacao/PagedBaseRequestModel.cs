using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiImob.Domain.Models.Paginacao
{
    public class PagedBaseRequestModel
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string OrderByProperty { get; set; }

        public PagedBaseRequestModel()
        {
            Page = 1;
            PageSize = 10;
            OrderByProperty = "Id";
        }
    }
}
