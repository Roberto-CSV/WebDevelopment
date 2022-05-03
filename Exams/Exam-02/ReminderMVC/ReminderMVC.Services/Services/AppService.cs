using Newtonsoft.Json;
using ReminderMVC.Services.Common;
using ReminderMVC.Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ReminderMVC.Services
{
    public class AppService<T> : IAppService<T> where T : EntityBase
    {
        protected string BaseUrl { get; }
        protected HttpClient _httpClient;

        public AppService(string baseUrl)
        {
            BaseUrl = baseUrl;
            _httpClient = new HttpClient();
            SetupHttpConnection(_httpClient, baseUrl);
        }

        protected void SetupHttpConnection(HttpClient httpClient, string baseUrl)
        {
            //Passing service base url  
            httpClient.BaseAddress = new Uri(baseUrl);

            httpClient.DefaultRequestHeaders.Clear();

            //Define request data format  
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public Task<T> AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
