using Newtonsoft.Json;

namespace EmployeeManagemntWeb.Infrastructure
{
    public class GenericHttpClient : IGenericHttpClient
    {
        private readonly string _baseApiUrl;
        public GenericHttpClient(IConfiguration configuration)
        {               
            this._baseApiUrl =  configuration.GetSection("BaseAPIURL").Value;
        }

        public async Task<TResponse> GetAsync<TResponse>(string url)
        {
            var client = new HttpClient();
            url = this._baseApiUrl + url;
            var response = await client.GetAsync(url);
            return await GetResponseData<TResponse>(response);
        }


        public async Task<TResponse> PostAsync<TRequest, TResponse>(string url, TRequest payload)
        {
            var httpClient = new HttpClient();
            url = this._baseApiUrl + url;
            var response = await httpClient.PostAsJsonAsync(url, payload);
            return await GetResponseData<TResponse>(response);
        }

        public async Task PutAsync<Trequest>(string url, Trequest payload)
        {
            var httpClient = new HttpClient();
            url = this._baseApiUrl + url;
            var response = await httpClient.PutAsJsonAsync(url, payload);
            response.EnsureSuccessStatusCode();
            //return await GetResponseData<TResponse>(response);
        }

        public async Task DeleteAsync(string url)
        {
            var httpClient = new HttpClient();
            url = this._baseApiUrl + url;
            var response = await httpClient.DeleteAsync(url);
            response.EnsureSuccessStatusCode();
        }

        private static async Task<TResponse> GetResponseData<TResponse>(HttpResponseMessage response)
        {
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResponse>(result);
        }
    }
}
