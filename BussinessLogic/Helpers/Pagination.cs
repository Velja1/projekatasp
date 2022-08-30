using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLogic.Helpers
{
    public class Pagination<T>
    {
        public T data { get; set; }
        public int Count { get; set; }
    }
}
