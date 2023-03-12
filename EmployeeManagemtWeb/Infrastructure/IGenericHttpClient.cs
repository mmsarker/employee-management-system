
namespace EmployeeManagemntWeb.Infrastructure
{
    public interface IGenericHttpClient
    {
        Task DeleteAsync(string url);
        Task<TResponse> GetAsync<TResponse>(string url);
        Task<TResponse> PostAsync<TRequest, TResponse>(string url, TRequest payload);
        Task<TResponse> PutAsync<Trequest, TResponse>(string url, Trequest payload);
    }
}