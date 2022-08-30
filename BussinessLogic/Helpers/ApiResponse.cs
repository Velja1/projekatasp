using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BussinessLogic.Helpers
{
    public class ApiResponse <T>
    {
        public HttpStatusCode statuscode { get; set; }
        public T data { get; set; }
    }
}
