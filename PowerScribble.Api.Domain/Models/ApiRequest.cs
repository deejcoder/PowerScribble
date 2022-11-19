using PowerScribble.Api.Domain.Interfaces;

namespace PowerScribble.Api.Domain.Models
{
    public class ApiRequest : IModel
    {
        public bool Ok { get; set; } = false;
        public string Message { get; set; } = string.Empty;

        public object? Data { get; set; } = null;
    }
}
