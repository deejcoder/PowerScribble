using PowerScribble.Api.Domain.BaseModels;
using PowerScribble.Api.Domain.Entities;
using PowerScribble.Api.Domain.Interfaces;

namespace PowerScribble.Api.Domain.Models
{
    public class BookModel : BaseModel<Guid>
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<Author> Authors { get; set; } = null!;
    }
}
