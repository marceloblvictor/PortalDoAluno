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

        
        public static Pagination<T> Create(IEnumerable<T> source, int count, int itemsPerPage, int pageIndex)
        {
            
            int pastItems = (pageIndex - 1) * itemsPerPage;
            var items = source.Skip<T>(pastItems).Take(itemsPerPage);

            return new Pagination<T>(items, count, itemsPerPage, pageIndex);
        } 
            
       
        

    }
}
