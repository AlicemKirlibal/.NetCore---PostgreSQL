using System;
using System.Collections.Generic;
using System.Text;

namespace testapitsoft.Core.Dtos
{
   public class AuthDto
    {
        public int userId { get; set; }
        public string username { get; set; }
        public string token { get; set; }
        public string secretKey { get; set; }
        public string expredationTime { get; set; }
        public string limited { get; set; }
        public string type { get; set; }
        public string tableId { get; set; }

    }
}
