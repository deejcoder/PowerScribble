using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerScribble.Api.Domain.Entities
{
    public class Author : BaseEntities.BaseEntity<Guid>
    {

        public AuthorType AuthorType { get; set; } = null!;
        public Guid EntityId { get; set; } = Guid.NewGuid();

    }
}
