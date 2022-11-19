using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PowerScribble.Api.Domain.BaseEntities;

namespace PowerScribble.Api.Domain.Entities
{
    public class Book : BaseEntity<Guid>
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<Author> Authors { get; set; } = null!;
    }
}
