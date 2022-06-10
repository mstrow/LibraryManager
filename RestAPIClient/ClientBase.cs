using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace RestAPIClient
{
    public abstract class ClientBase
    {
        private readonly IApiConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public IApiConfiguration Configuration { get => _configuration; }

        public ClientBase(IApiConfiguration configuration, HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
            _httpClient.Timeout = TimeSpan.FromSeconds(configuration.Timeout);
            _httpClient.BaseAddress = new Uri(configuration.Url);
        }

        protected async Task<T> GetAsync<T>(string path)
        {
            var response = await _httpClient.GetAsync(path);
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All,
                    NullValueHandling = NullValueHandling.Ignore
                };
                return JsonConvert.DeserializeObject<T>(content, settings);
            }
            else
            {
                throw new Exception(content);
            }
        }

        protected async Task<int> AddAsync(string path, object model)
        {
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                NullValueHandling = NullValueHandling.Ignore
            };
            var json = JsonConvert.SerializeObject(model, settings);
            var jsonContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(path, jsonContent);
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return Convert.ToInt32(content);
            }
            else
            {
                throw new Exception(content);
            }
        }
        protected async Task<int> UpdateAsync(string path, object model)
        {
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                NullValueHandling = NullValueHandling.Ignore
            };
            var json = JsonConvert.SerializeObject(model, settings);
            var jsonContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(path, jsonContent);
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return Convert.ToInt32(content);
            }
            else
            {
                throw new Exception(content);
            }
        }
        protected async void DeleteAsync(string path)
        {
            await _httpClient.DeleteAsync(path);
        }
    }
}
