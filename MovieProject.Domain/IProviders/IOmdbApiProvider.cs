using MovieProject.Domain.Enums;
using MovieProject.Domain.Models;

namespace MovieProject.Domain.IProviders
{
    public interface IOmdbApiProvider
    {
        Task<BaseApiResponse<TResult>> ExecuteCall<TResult>(HttpMethodType method, string endpoint, Dictionary<string, string?>? queryParams = null, HttpContent? data = null);
    }
}
