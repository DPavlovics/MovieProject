using MovieProject.Application.Contracts.Models;

namespace MovieProject.Application.Services.Base
{
    public abstract class BaseService
    {
        protected ServiceResponse<T> Ok<T>(T data) => ServiceResponse<T>.Ok(data);
        protected ServiceResponse<T> BadRequest<T>(string errorMessage) => ServiceResponse<T>.BadRequest(errorMessage);
    }
}
