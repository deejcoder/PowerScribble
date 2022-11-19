using PowerScribble.Api.Domain.Entities;
using PowerScribble.Api.Domain.Interfaces;
using PowerScribble.Api.Domain.Models;

namespace PowerScribble.Api.Infrastructure.ModelParsers
{
    public class BookParser : BaseParser<Guid>
    {
        public BookParser() { }

        /// <summary>
        /// Converts a Book Entity into a Book Model
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public override IModel AsModel(IEntity<Guid> entity)
        {
            if (!(entity is Book book)) throw new ArgumentException("Invalid entity");

            return new BookModel()
            {
                Id = entity.Id,
                Title = book.Title,
                Description = book.Description,
                Authors = book.Authors,
                CreatedDateTime = book.CreatedDateTime,
                ModifiedDateTime = book.ModifiedDateTime,
                DeletedDateTime = book.DeletedDateTime,
            };
        }

        /// <summary>
        /// Converts a Book Model into a Book Entity
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public override IEntity<Guid> AsEntity(IModel model)
        {
            if (!(model is BookModel bookModel)) throw new ArgumentException("Invalid model");

            return new Book()
            {
                Id = bookModel.Id,
                Title = bookModel.Title,
                Description = bookModel.Description,
                Authors = bookModel.Authors,
                CreatedDateTime = bookModel.CreatedDateTime,
                ModifiedDateTime = bookModel.ModifiedDateTime,
                DeletedDateTime = bookModel.DeletedDateTime,
            };
        }

    }
}
