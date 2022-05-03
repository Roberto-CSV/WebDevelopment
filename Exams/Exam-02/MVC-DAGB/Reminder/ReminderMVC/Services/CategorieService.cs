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
        private readonly RestClient restClientReminder;

        private readonly string baseUrl;
        private readonly string baseUrlReminder;


        public CategorieService(IConfiguration configuration)
        {
            baseUrl = configuration.GetSection("ApiConfiguration")["CategoriesApiUrl"];
            baseUrlReminder = configuration.GetSection("ApiConfiguration")["RemindersApiUrl"];
            
            restClient = new RestClient(baseUrl);
            restClientReminder = new RestClient(baseUrlReminder);

        }

        public void Add(CategorieModel category)
        {
            var request = new RestRequest(string.Empty, Method.Post);
            request.AddBody(category);
            var response = restClient.ExecuteAsync<CategorieModel>(request);

            Console.WriteLine(response);
        }

        public void Delete(int id)
        {
            //Delete Reminders by Category
            var requestGetAllReminder = new RestRequest(string.Empty, Method.Get);
            var responseGetAllReminder = restClientReminder.ExecuteAsync(requestGetAllReminder).Result;
            List<ReminderModel> remindersList = JsonConvert.DeserializeObject<List<ReminderModel>>(responseGetAllReminder.Content);

            foreach (ReminderModel reminder in remindersList)
            {
                if(Convert.ToInt32(reminder.CategoryId) == id)
                {
                    var requestDeleteReminder = new RestRequest(id.ToString(), Method.Delete);
                    var responseDeleteReminder = restClientReminder.ExecuteAsync(requestDeleteReminder).Result;

                    Console.WriteLine(responseDeleteReminder);
                }
            }

            //Delete Category
            var request = new RestRequest(id.ToString(), Method.Delete);
            var response = restClient.ExecuteAsync(request).Result;

            Console.WriteLine(response);
        }

        public List<CategorieModel> GetAll()
        {
            var request = new RestRequest(string.Empty, Method.Get);
            var response = restClient.ExecuteAsync(request).Result;
            List<CategorieModel> categoriesList = JsonConvert.DeserializeObject<List<CategorieModel>>(response.Content);

            return categoriesList;
        }

        public CategorieModel GetById(int id)
        {
            var request = new RestRequest(id.ToString(), Method.Get);
            var response = restClient.ExecuteAsync(request).Result;
            CategorieModel category = JsonConvert.DeserializeObject<CategorieModel>(response.Content);

            return category;
        }

        public void Update(CategorieModel category)
        {
            var request = new RestRequest(category.Id.ToString(), Method.Put);
            request.AddBody(category);
            var response = restClient.ExecuteAsync<CategorieModel>(request);

            Console.WriteLine(response);
        }
    }
}
