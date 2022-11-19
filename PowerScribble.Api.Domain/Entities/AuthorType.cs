using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PowerScribble.Api.Domain.Entities.AuthorType;

namespace PowerScribble.Api.Domain.Entities
{
    public class AuthorType : BaseEntities.BaseEntity<int>
    {

        public enum AuthorTypeIndex
        {
            None = 1,
            User = 2,
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public override int Id { get => base.Id; set => base.Id = value; }
        [Required, MaxLength(100)]
        public string Code { get; set; } = String.Empty;
        [Required, MaxLength(200)]
        public string Description { get; set; } = String.Empty;

        public AuthorType() 
        {
            InitCommon(AuthorTypeIndex.None);
        }

        private AuthorType(AuthorTypeIndex @authorTypeIndex)
        {
            InitCommon(@authorTypeIndex);
        }

        private void InitCommon(AuthorTypeIndex @authorTypeIndex)
        {
            Id = (int)@authorTypeIndex;
            Code = @authorTypeIndex.ToString();
            Description = @authorTypeIndex.ToString();
        }

        public static implicit operator AuthorType(AuthorTypeIndex index) => new(index);
        public static implicit operator AuthorTypeIndex(AuthorType authorType) => (AuthorTypeIndex)authorType.Id;
    }
}
