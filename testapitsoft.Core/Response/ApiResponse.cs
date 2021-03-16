using System;
using System.Collections.Generic;
using System.Text;

namespace testapitsoft.Core.Response
{
   public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public List<T> Data { get; set; }
    }
}
