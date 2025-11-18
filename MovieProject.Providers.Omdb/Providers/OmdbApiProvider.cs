using Microsoft.AspNetCore.WebUtilities;
using MovieProject.Domain.Enums;
using MovieProject.Domain.IProviders;
using MovieProject.Domain.Models;
using System.Net;
using System.Text.Json;

namespace MovieProject.Providers.Omdb.Providers
{
    public class OmdbApiProvider(string apiKey, string apiUrl) : IOmdbApiProvider
    {
        public async Task<BaseApiResponse<TResult>> ExecuteCall<TResult>(HttpMethodType method, string endpoint, Dictionary<string, string?>? queryParams = null, HttpContent? data = null)
        {
            var apiResponse = new BaseApiResponse<TResult>();

            try
            {
                var httpResponse = await SendRequestAsync(method, queryParams, endpoint, data);
                apiResponse.ResponseCode = httpResponse.StatusCode;

                var responseBody = await httpResponse.Content.ReadAsStringAsync();
                var omdApiResponse = JsonSerializer.Deserialize<OMDbApiResponse>(responseBody);

                if (!httpResponse.IsSuccessStatusCode)
                {
                    apiResponse.ErrorMessage = omdApiResponse?.Error;
                    return apiResponse;
                }                

                if (omdApiResponse?.Error != null || !string.Equals(omdApiResponse?.Response, true.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    apiResponse.ResponseCode = HttpStatusCode.BadRequest;
                    apiResponse.ErrorMessage = omdApiResponse?.Error;
                    return apiResponse;
                }

                if (typeof(TResult) == typeof(string))
                {
                    apiResponse.Result = (TResult)(object)responseBody;
                    return apiResponse;
                }

                apiResponse.Result = JsonSerializer.Deserialize<TResult>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return apiResponse;                
            }
            catch (Exception e)
            {
                apiResponse.ResponseCode = HttpStatusCode.BadRequest;
                apiResponse.ErrorMessage = e.Message;
            }

            return apiResponse;
        }               

        private async Task<HttpResponseMessage> SendRequestAsync(HttpMethodType method, Dictionary<string, string?>? queryParams, string endpoint, HttpContent? data)
        {
            using (var client = new HttpClient())
            {            
                queryParams ??= new Dictionary<string, string?>();
                queryParams[nameof(apiKey)] = apiKey;

                var uri = QueryHelpers.AddQueryString(apiUrl, queryParams);

                client.BaseAddress = new Uri(uri);

                switch (method)
                {
                    case HttpMethodType.Get:
                        return await client.GetAsync(endpoint);
                    case HttpMethodType.Delete:
                        return await client.DeleteAsync(endpoint);
                    case HttpMethodType.Post:
                        return await client.PostAsync(endpoint, data);
                    case HttpMethodType.Patch:
                        var request = new HttpRequestMessage(new HttpMethod("PATCH"), endpoint) { Content = data };
                        return await client.SendAsync(request);
                }
            }

            return new HttpResponseMessage(HttpStatusCode.NotFound);
        }

        private class OMDbApiResponse
        {
            public string Response { get; set; } = string.Empty;
            public string? Error { get; set; }
        }

    }
}
