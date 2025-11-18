namespace MovieProject.Application.Contracts.Models
{
    public class ServiceResponse<T>
    {
        public bool IsSuccessful { get; set; }
        public T? Data { get; set; }
        public string? ErrorMessage { get; set; }

        public static ServiceResponse<T> Ok(T data) => new() { IsSuccessful = true, Data = data };
        public static ServiceResponse<T> BadRequest(string error) => new() { IsSuccessful = false, ErrorMessage = error };

    }
}
