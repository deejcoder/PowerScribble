using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerScribble.Api.Domain.Interfaces
{
    public interface IEntity<TKey>
    {
        [Key]
        public TKey? Id { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime ModifiedDateTime { get; set; }
        public DateTime DeletedDateTime { get; set; }
    }
}
