using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApiApplication.Models
{
    public class PaginatedList<T> : List<T>
    {
        public int pageIndex { get; set; }
        public int totalPage { get; set; }

        public PaginatedList(List<T> items, int count, int pageI, int pageSize)
        {
            pageIndex = pageI;
            totalPage = (int)Math.Ceiling(count / (double)pageSize);
            AddRange(items);
        }

        public static PaginatedList<T> crate(IQueryable<T> source, int pageI, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageI - 1) * pageSize).Take(pageSize).ToList();
            return new PaginatedList<T>(items, count, pageI, pageSize);
        }
    }
}
