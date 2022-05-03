using Newtonsoft.Json;
using ReminderMVC.Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ReminderMVC.Services.Services
{
    public class RemindersService : AppService<ReminderDto>
    {
        public RemindersService(string baseUrl) : base(baseUrl)
        {
        }

        public new async Task<ReminderDto> AddAsync(ReminderDto entity)
        {
            ReminderDto reminderDtoResponse = null;

            StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");

            // Sending request to find web api REST service resource to Add an User using HttpClient
            HttpResponseMessage response = await _httpClient.PostAsync($"api/v1/reminders/", content);

            // Checking the response is successful or not which is sent using HttpClient
            if (response.IsSuccessStatusCode)
            {
                // Storing the content response recieved from web api
                var responseContent = response.Content.ReadAsStringAsync().Result;

                //Deserializing the response recieved from web api and storing into the Employee list
                reminderDtoResponse = JsonConvert.DeserializeObject<ReminderDto>(responseContent);
            }

            return reminderDtoResponse;
        }

        public new async Task<ReminderDto> DeleteAsync(int id)
        {
            ReminderDto reminderDtoResponse = null;

            // Sending request to find web api REST service resource to Delete the User using HttpClient
            HttpResponseMessage response = await _httpClient.DeleteAsync($"api/v1/reminders/{id}");

            // Checking the response is successful or not which is sent using HttpClient
            if (response.IsSuccessStatusCode)
            {
                // Storing the content response recieved from web api
                var responseContent = response.Content.ReadAsStringAsync().Result;

                // Deserializing the response recieved from web api
                reminderDtoResponse = JsonConvert.DeserializeObject<ReminderDto>(responseContent);
            }

            return reminderDtoResponse;
        }

        public new async Task<IEnumerable<ReminderDto>> GetAllAsync()
        {
            var remindersList = new List<ReminderDto>();

            // Sending request to find web api REST service resource to Get All Users using HttpClient
            HttpResponseMessage response = await _httpClient.GetAsync("api/v1/reminders");

            // Checking the response is successful or not which is sent using HttpClient
            if (response.IsSuccessStatusCode)
            {
                // Storing the content response recieved from web api
                var responseContent = response.Content.ReadAsStringAsync().Result;

                //Deserializing the response recieved from web api and storing into the Employee list
                remindersList = JsonConvert.DeserializeObject<List<ReminderDto>>(responseContent);
            }

            return remindersList;
        }

        public new async Task<ReminderDto> GetByIdAsync(int id)
        {
            ReminderDto reminder = null;

            // Sending request to find web api REST service resource to Get All Users using HttpClient
            HttpResponseMessage response = await _httpClient.GetAsync($"api/v1/reminders/{id}");

            // Checking the response is successful or not which is sent using HttpClient
            if (response.IsSuccessStatusCode)
            {
                // Storing the content response recieved from web api
                var responseContent = response.Content.ReadAsStringAsync().Result;

                //Deserializing the response recieved from web api and storing into the Employee list
                reminder = JsonConvert.DeserializeObject<ReminderDto>(responseContent);
            }

            return reminder;
        }

        public new async Task<ReminderDto> UpdateAsync(ReminderDto entity)
        {
            ReminderDto reminderDtoResponse = null;

            StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");

            // Sending request to find web api REST service resource to Add an User using HttpClient
            HttpResponseMessage response = await _httpClient.PutAsync($"api/v1/reminders/{entity.Id}", content);

            // Checking the response is successful or not which is sent using HttpClient
            if (response.IsSuccessStatusCode)
            {
                // Storing the content response recieved from web api
                var responseContent = response.Content.ReadAsStringAsync().Result;

                //Deserializing the response recieved from web api
                reminderDtoResponse = JsonConvert.DeserializeObject<ReminderDto>(responseContent);
            }

            return reminderDtoResponse;
        }

        public async Task<IEnumerable<ReminderDto>> GetAllByCategoryId(int categoryId)
        {
            var remindersList = new List<ReminderDto>();

            // Sending request to find web api REST service resource to Get All Users using HttpClient
            HttpResponseMessage response = await _httpClient.GetAsync($"api/v1/reminders/category/{categoryId}");

            // Checking the response is successful or not which is sent using HttpClient
            if (response.IsSuccessStatusCode)
            {
                // Storing the content response recieved from web api
                var responseContent = response.Content.ReadAsStringAsync().Result;

                //Deserializing the response recieved from web api and storing into the Employee list
                remindersList = JsonConvert.DeserializeObject<List<ReminderDto>>(responseContent);
            }

            return remindersList;
        }

        public async Task<IEnumerable<ReminderDto>> DeleteByCategoryIdAsync(int categoryId)
        {
            var reminderDtoResponse = new List<ReminderDto>();

            // Sending request to find web api REST service resource to Delete the User using HttpClient
            HttpResponseMessage response = await _httpClient.DeleteAsync($"api/v1/reminders/category/{categoryId}");

            // Checking the response is successful or not which is sent using HttpClient
            if (response.IsSuccessStatusCode)
            {
                // Storing the content response recieved from web api
                var responseContent = response.Content.ReadAsStringAsync().Result;

                // Deserializing the response recieved from web api
                reminderDtoResponse = JsonConvert.DeserializeObject<List<ReminderDto>>(responseContent);
            }

            return reminderDtoResponse;
        }
    }
}
