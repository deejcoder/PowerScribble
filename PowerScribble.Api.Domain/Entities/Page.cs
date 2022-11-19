using PowerScribble.Api.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerScribble.Api.Domain.Entities
{
    public class Page : BaseEntity<Guid>
    {
        public Book Book { get; set; } = null!;
        public string Heading { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
    }
}
