using ApiImob.Domain.Models.Paginacao;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ApiImob.Infra.Services
{
    public static class PagedBaseResponseHelper
    {
        public static async Task<TResponse> GetResponseAsync<TResponse,T>
            (IQueryable<T> query, PagedBaseRequestModel request, int totalregistros)
            where TResponse : PagedBaseResponseModel<T>, new()
        {
            var response = new TResponse();
            var count = query.Count();
            response.TotalPages = (int)Math.Abs((double)count / request.PageSize);
            if (response.TotalPages == 0)
                response.TotalPages = 1;
            response.TotalRegisters = totalregistros;
            response.TotalRegistersFilters = count;
            response.Page = request.Page;
            response.PageSize = request.PageSize;
            if(string.IsNullOrEmpty(request.OrderByProperty)) 
                response.Result = await query.ToListAsync();
            else
                response.Result = query.OrdeyByDynamic(request.OrderByProperty)
                    .Skip((request.Page - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToList();

            return response;
        }

        private static IEnumerable<T> OrdeyByDynamic<T>(this IEnumerable<T> query, string propertyName)
        {
            return query.OrderBy(x => x.GetType().GetProperty(propertyName).GetValue(x, null));
        }
    }
}
