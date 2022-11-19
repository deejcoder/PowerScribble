using PowerScribble.Api.Domain.Interfaces;

namespace PowerScribble.Api.Domain.Models
{
    public class ApiResponse : IModel
    {
        public bool Ok { get; set; } = false;
        public string Message { get; set; } = string.Empty;

        public object? Data { get; set; } = null;

        public ApiResponse() { }

        public ApiResponse(bool isOk, string message) 
        { 
            Ok = isOk;
            Message = message;
        }

        public ApiResponse(bool ok, string message, object? data) : this(ok, message)
        {
            Data = data;
        }

        public ApiResponse(Exception ex) : this(false, ex.Message) { }
    }
}
