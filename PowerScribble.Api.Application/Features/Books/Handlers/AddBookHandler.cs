using MediatR;
using PowerScribble.Api.Application.Features.Books.Commands;
using PowerScribble.Api.Application.Interfaces;
using PowerScribble.Api.Domain.Entities;


namespace PowerScribble.Api.Application.Features.Books.Handlers
{
    public class AddBookHandler : IRequestHandler<AddBookCommand, Book>
    {
        private readonly IAppContext _appContext;

        public AddBookHandler(IAppContext appContext) => _appContext = appContext;

        public async Task<Book> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            await _appContext.Db.Books.AddAsync(request.Book, cancellationToken);

            return request.Book;
        }
    }
}
