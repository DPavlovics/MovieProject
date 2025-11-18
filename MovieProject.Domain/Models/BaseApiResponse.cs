using System.Net;

namespace MovieProject.Domain.Models
{
    public class BaseApiResponse<TResult>
    {
        public TResult? Result { get; set; }
        public string? ErrorMessage { get; set; } = string.Empty;
        public HttpStatusCode ResponseCode { get; set; }
    }
}
