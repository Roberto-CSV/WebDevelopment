﻿using Microsoft.Extensions.Configuration;
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

        public ReminderService(IConfiguration configuration)
        {
            var baseUrl = configuration.GetSection("ApiConfiguration")["ReminderApiUrl"];
            restClient = new RestClient(baseUrl);
        }

        public void Add(ReminderModel reminder)
        {
            var request = new RestRequest(string.Empty, Method.Post);
            request.AddJsonBody(reminder);
            restClient.ExecuteAsync<ReminderModel>(request);
        }

        public void Delete(int id)
        {
            var request = new RestRequest(id.ToString(), Method.Delete);
            var response = restClient.DeleteAsync(request).Result;
            Console.WriteLine(response);
        }

        public void DeleteByCategory(int id)
        {
            var request = new RestRequest("Category/" + id.ToString(), Method.Delete);
            restClient.ExecuteAsync(request);
        }

        public List<ReminderModel> Find(int id)
        {
            var request = new RestRequest("Category/" + id.ToString(), Method.Get) ;
            var response = restClient.GetAsync<List<ReminderModel>> (request).Result;
            return response;
        }
 
        public List<ReminderModel> GetAll() 
        {
            var request = new RestRequest(string.Empty, Method.Get) ;
            var response = restClient.GetAsync(request).Result;
            var categoryList = JsonConvert.DeserializeObject<List<ReminderModel>>(response.Content);

            return categoryList;
        }

        public ReminderModel GetById(int id)
        {
            var request = new RestRequest(id.ToString(), Method.Get);
            var response = restClient.GetAsync(request).Result;
            var reminder = JsonConvert.DeserializeObject<ReminderModel>(response.Content);

            return reminder;
        }

        public void Update(int id, ReminderModel reminder)
        {
            var request = new RestRequest(id.ToString(), Method.Put);
            request.AddJsonBody(reminder);
            restClient.ExecuteAsync(request);
        }
    }
}
