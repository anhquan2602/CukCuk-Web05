﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WEB05.CUKCUK.NAQUAN.Domain.Entities.DTO
{
    public class CukCukResponse
    {
        public int StatusCode { get; set; }
        public string? DevCode { get; set; }

        public string? DevMessage { get; set; }

        public string? MoreInfo { get; set; }

        public DateTime Timestamp { get; set; }

        public string? StackTrace { get; set; }

        public Exception? InnerException { get; set; }

        public List<string>? ListErrors { get; set; }
    }
}
