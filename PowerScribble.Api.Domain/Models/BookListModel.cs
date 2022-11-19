using PowerScribble.Api.Domain.Entities;
using PowerScribble.Api.Domain.Interfaces;

namespace PowerScribble.Api.Domain.Models
{
    public class BookListModel : IModel
    {
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
