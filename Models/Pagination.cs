using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalDoAluno.Models
{
    public class Pagination<T> : List<T>
    {
        public int Index { get; set; }        

        public int TotalPages { get; set; }        

        public Pagination(IEnumerable<T> items, int count, int itemsPerPage, int pageIndex)
        {                        
            Index = pageIndex;
            TotalPages = (int) Math.Ceiling((double) ( count / itemsPerPage));

            // substitui a necessidade de criar uma propriedade IEnumerable que contenha a lista!
            this.AddRange(items);
        }

        public bool HasPrevious() => Index > 1;

        public bool HasNext() => Index <= TotalPages;

        
        public static async Task<Pagination<T>> CreateAsync(IQueryable<T> source, int itemsPerPage, int pageIndex)
        {
            var count = await source.CountAsync();
            int pastItems = (pageIndex - 1) * itemsPerPage;
            var items = await source.Skip<T>(pastItems).Take(itemsPerPage).ToListAsync();

            return new Pagination<T>(items, count, itemsPerPage, pageIndex);
        } 
            
       
        

    }
}
