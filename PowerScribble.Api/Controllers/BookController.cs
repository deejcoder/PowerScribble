using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PowerScribble.Api.Application.Features.Books.Queries;
using PowerScribble.Api.Application.Interfaces;
using PowerScribble.Api.Domain.Entities;
using PowerScribble.Api.Domain.Interfaces;
using PowerScribble.Api.Domain.Models;
using PowerScribble.Api.Infrastructure.ModelParsers;

namespace PowerScribble.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {

        IAppContext _appContext;
        IMediator _mediator;

        public BookController(IAppContext appContext, IMediator mediator)
        {
            _appContext = appContext;
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ActionResult<ApiResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse>> GetBooks()
        {
            
            try
            {
                // returns a list of books currently in the system
                List<Book> books = (await _mediator.Send(new GetBooksQuery())).ToList();

                // convert entity models to book models for the client
                List<IModel> models = new BookParser().AsModels(books);
                return new ApiResponse(true, string.Empty, models);
            }
            catch(Exception ex)
            {
                return new ApiResponse(false, ex.Message);
            }
        }
    }
}
