using PowerScribble.Api.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerScribble.Api.Domain.BaseModels
{
    public class BaseModel<TKey> : IModel
    {
        public virtual TKey? Id { get; set; }
        public virtual DateTime CreatedDateTime { get; set; }
        public virtual DateTime ModifiedDateTime { get; set; }
        public virtual DateTime DeletedDateTime { get; set; }
    }
}
