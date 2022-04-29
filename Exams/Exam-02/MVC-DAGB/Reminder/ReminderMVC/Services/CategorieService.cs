using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ReminderMVC.Models;
using RestSharp;
using System;
using System.Collections.Generic;

namespace ReminderMVC.Services
{
    public class CategorieService : ICategorieService
    {

        private readonly RestClient restClient;
        private readonly string baseUrl;

        public CategorieService(IConfiguration configuration)
        {
            baseUrl = configuration.GetSection("ApiConfiguration")["CategoriesApiUrl"];
            restClient = new RestClient(baseUrl);
        }

        public void Add(CategorieModel category)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<CategorieModel> GetAll()
        {
            var request = new RestRequest(string.Empty, Method.Get);
            var response = restClient.GetAsync(request).Result;
            List<CategorieModel> categoriesList = JsonConvert.DeserializeObject<List<CategorieModel>>(response.Content);

            return categoriesList;
        }

        public CategorieModel GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(CategorieModel category)
        {
            var request = new RestRequest(category.Id.ToString(), Method.Put) { RequestFormat = DataFormat.Json };
            request.AddBody(category);
            var response = restClient.ExecuteAsync<CategorieModel>(request);

            Console.WriteLine(response);
        }
    }
}
