using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLogic.Helpers
{
    public class PaginationModel
    {
        public string Search { get; set; }
        public int Total { get; set; }
        public int PageNo { get; set; }
        public int PageSize { get; set; }
    }
}
