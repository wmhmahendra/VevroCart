using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CART_DataTransfer.Common
{
    public class Pagination
    {
        public int PageSize { get; set; } 
        public int PageNumber { get; set; }
        public int NumberOfPage { get; set; }
        public int Sortby { get; set; }
    }
}
