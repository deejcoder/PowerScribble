using Microsoft.EntityFrameworkCore;
using PowerScribble.Api.Domain.BaseEntities;

namespace PowerScribble.Api.Domain.Entities
{
    [Index(nameof(UserName), IsUnique = true)]
    public class User : BaseUserEntity
    {
        public override string? UserName { get => base.UserName; set => base.UserName = value; }
    }
}
