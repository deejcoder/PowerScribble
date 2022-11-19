using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PowerScribble.Api.Domain.BaseEntities;

namespace PowerScribble.Api.Domain.Entities
{
    public class ApiConfigItem : BaseEntity<Guid>
    {
        public string Key { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }
}
