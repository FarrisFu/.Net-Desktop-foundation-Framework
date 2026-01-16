using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCF.Domain.Shared.Exceptions
{
    public class ErrorResponse
    {
        public string TraceId { get; set; } = default!;
        public int StatusCode { get; set; }
        public string Message { get; set; } = default!;
        public string? Detail { get; set; }
    }
}
