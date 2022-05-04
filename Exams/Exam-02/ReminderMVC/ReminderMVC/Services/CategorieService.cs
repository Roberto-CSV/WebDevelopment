using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ReminderMVC.Models;
using RestSharp;
using System;
using System.Collections.Generic;

namespace ReminderMVC.Services
{
    public class CategoryService : ICategorieService
    {
        private readonly RestClient restClient;

        public CategoryService(IConfiguration configuration)
        {
            var baseUrl = configuration.GetSection("ApiConfiguration")["CategoriesApiUrl"];

            restClient = new RestClient(baseUrl);
        }

        public void Add(CategoriesModel category)
        {
            var request = new RestRequest(string.Empty, Method.Post);
            request.AddJsonBody(category);
            restClient.ExecuteAsync<CategoriesModel>(request);
        }

        public void Delete(int id)
        {
            var request = new RestRequest(id.ToString(), Method.Delete);
            restClient.ExecuteAsync(request);
        }

        public IEnumerable<CategoriesModel> Find()
        {
            throw new NotImplementedException();
        }

        public List<CategoriesModel> GetAll()
        {
            var request = new RestRequest(string.Empty, Method.Get);
            var response = restClient.GetAsync(request).Result;
            var categoryList = JsonConvert.DeserializeObject<List<CategoriesModel>>(response.Content);

            return categoryList;
        }

        public CategoriesModel GetById(int id)
        {
            var request = new RestRequest(id.ToString(), Method.Get);
            var response = restClient.GetAsync(request).Result;
            CategoriesModel category = JsonConvert.DeserializeObject<CategoriesModel>(response.Content);

            return category;
        }

        public void Update(int id, CategoriesModel category)
        {
            var request = new RestRequest(id.ToString(), Method.Put);
            request.AddJsonBody(category);
            restClient.ExecuteAsync(request);
        }
        public List<ReminderModel> GetAllByCategoryId(int id)
        {
            var request = new RestRequest("Category/" + id.ToString(), Method.Get);
            var response = restClient.GetAsync<List<ReminderModel>>(request).Result;
            return response;
        }

    }
}