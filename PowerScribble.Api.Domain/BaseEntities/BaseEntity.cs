using PowerScribble.Api.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerScribble.Api.Domain.BaseEntities
{
    public class BaseEntity<TKey> : IEntity<TKey>
    {
        public virtual TKey? Id { get; set; }
        public virtual DateTime CreatedDateTime { get; set; }
        public virtual DateTime ModifiedDateTime { get; set; }
        public virtual DateTime DeletedDateTime { get; set; }

    }
}
