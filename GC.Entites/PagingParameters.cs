using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GC.Entites
{
    public record PagingParameters
    {
        public int Page { get; set; }  = 0;
        public int PageSize { get; set; } = 10;

        public void Normalize()
        {
            if (Page < 0)
            {
                Page = 0;
            }
            if (PageSize < 1 || PageSize > 20)
            {
                PageSize = 10;
            }
        }
    }
}
