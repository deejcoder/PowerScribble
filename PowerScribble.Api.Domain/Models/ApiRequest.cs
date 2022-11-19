using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerScribble.Api.Domain.Models
{
    public class ApiRequest
    {
        public bool Ok { get; set; } = false;
        public string Message { get; set; } = string.Empty;

        public object? Data { get; set; } = null;
    }
}
