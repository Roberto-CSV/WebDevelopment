using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ReminderMVC.Models;
using RestSharp;
using System;
using System.Collections.Generic;

namespace ReminderMVC.Services
{
    public class ReminderService : IReminderService
    {

        private readonly RestClient restClient;
        private readonly string baseUrl;

        private readonly ICategorieService _categorieService;

        public ReminderService(IConfiguration configuration, ICategorieService categorieService)
        {
            baseUrl = configuration.GetSection("ApiConfiguration")["RemindersApiUrl"];
            restClient = new RestClient(baseUrl);

            _categorieService = categorieService;
        }

        public void Add(ReminderModel reminder)
        {
            CategorieModel category = _categorieService.GetById(Convert.ToInt32(reminder.CategoryId));
            if (category.Description != null)
            {
                var request = new RestRequest(string.Empty, Method.Post);
                request.AddBody(reminder);
                var response = restClient.ExecuteAsync<ReminderModel>(request);

                Console.WriteLine(response);
            }
            else
            {
                throw new System.ApplicationException("El ID de categoría no es valido.");
            }
        }

        public void Delete(int id)
        {
            var request = new RestRequest(id.ToString(), Method.Delete);
            var response = restClient.ExecuteAsync(request).Result;

            Console.WriteLine(response);
        }

        public List<ReminderModel> GetAll()
        {
            var request = new RestRequest(string.Empty, Method.Get);
            var response = restClient.ExecuteAsync(request).Result;
            List<ReminderModel> remindersList = JsonConvert.DeserializeObject<List<ReminderModel>>(response.Content);

            foreach (ReminderModel reminder in remindersList)
            {
                CategorieModel category = _categorieService.GetById(Convert.ToInt32(reminder.CategoryId));
                if(category.Description != null)
                {
                    reminder.CategoryId = category.Description;
                }
            }
            return remindersList;
        }

        public ReminderModel GetById(int id)
        {
            var request = new RestRequest(id.ToString(), Method.Get);
            var response = restClient.ExecuteAsync(request).Result;
            ReminderModel reminder = JsonConvert.DeserializeObject<ReminderModel>(response.Content);

            return reminder;
        }

        public void Update(ReminderModel reminder)
        {
            CategorieModel category = _categorieService.GetById(Convert.ToInt32(reminder.CategoryId));
            if (category.Description != null)
            {
                var request = new RestRequest(reminder.Id.ToString(), Method.Put);
                request.AddBody(reminder);
                var response = restClient.ExecuteAsync<ReminderModel>(request);

                Console.WriteLine(response);
            }
            else
            {
                throw new System.ApplicationException("El ID de categoría no es valido.");
            }
        }
    }
}
