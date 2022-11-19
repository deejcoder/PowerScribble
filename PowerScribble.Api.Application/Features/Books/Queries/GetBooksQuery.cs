using MediatR;
using PowerScribble.Api.Domain.Entities;


namespace PowerScribble.Api.Application.Features.Books.Queries
{
    public record GetBooksQuery() : IRequest<IEnumerable<Book>>;
}
