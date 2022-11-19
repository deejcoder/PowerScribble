using MediatR;
using PowerScribble.Api.Domain.Entities;


namespace PowerScribble.Api.Application.Features.Books.Notifications
{
    public record BookAddedNotification(Book Book) : INotification;
}
