using MediatR;
using PowerScribble.Api.Domain.Entities;


namespace PowerScribble.Api.Application.Features.Books.Commands
{
    public record AddBookCommand(Book Book) : IRequest<Book>;
}
