using Microsoft.AspNetCore.Identity;
using PowerScribble.Api.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PowerScribble.Api.Domain.BaseEntities
{
    public class BaseUserEntity : IdentityUser<Guid>, IEntity<Guid>
    {
        public override Guid Id { get => base.Id; set => base.Id = value; }
        public virtual DateTime CreatedDateTime { get; set; }
        public virtual DateTime ModifiedDateTime { get; set; }
        public virtual DateTime DeletedDateTime { get; set; }
    }
}
