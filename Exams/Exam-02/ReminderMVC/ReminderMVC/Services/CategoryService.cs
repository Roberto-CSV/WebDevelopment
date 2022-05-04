using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ReminderMVC.Models;
using RestSharp;
using System;
using System.Collections.Generic;

namespace ReminderMVC.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly RestClient restClient;

        public CategoryService(IConfiguration configuration)
        {
            var baseUrl = configuration.GetSection("ApiConfiguration")["CategoryApiUrl"];
   
            restClient = new RestClient(baseUrl);
        }

        public void Add(CategoryModel category)
        {
            var request = new RestRequest(string.Empty, Method.Post);
            request.AddJsonBody(category);
            restClient.ExecuteAsync<CategoryModel>(request);   
        }

        public void Delete(int id)
        {
            var request = new RestRequest(id.ToString(), Method.Delete);
            restClient.ExecuteAsync<CategoryModel>(request);
        }

        public IEnumerable<CategoryModel> Find()
        {
            throw new NotImplementedException();
        }

        public List<CategoryModel> GetAll()
        {
            var request = new RestRequest(string.Empty, Method.Get);
            var response = restClient.GetAsync(request).Result;
            var categoryList = JsonConvert.DeserializeObject<List<CategoryModel>>(response.Content);

            return categoryList;
        }

        public CategoryModel GetById(int id)
        {
            var request = new RestRequest(id.ToString(), Method.Get);
            var response = restClient.GetAsync(request).Result;
            CategoryModel category = JsonConvert.DeserializeObject<CategoryModel>(response.Content);

            return category;
        }

        public void Update(int id, CategoryModel category)
        {
            var request = new RestRequest(id.ToString(), Method.Put);
            request.AddJsonBody(category);
            restClient.ExecuteAsync(request);
        }

    }
}
