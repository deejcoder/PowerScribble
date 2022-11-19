using MediatR;
using PowerScribble.Api.Domain.Entities;
using PowerScribble.Api.Application.Interfaces;
using PowerScribble.Api.Application.Features.Books.Queries;
using Microsoft.EntityFrameworkCore;

namespace PowerScribble.Api.Application.Features.Books.Handlers
{
    public class GetBooksHandler : IRequestHandler<GetBooksQuery, IEnumerable<Book>>
    {
        private readonly IAppContext _appContext;

        public GetBooksHandler(IAppContext appContext) => _appContext = appContext;

        public async Task<IEnumerable<Book>> Handle(GetBooksQuery request, CancellationToken cancellationToken) 
        {
            return await _appContext.Db.Books.ToListAsync(cancellationToken);
        }
    }
}
