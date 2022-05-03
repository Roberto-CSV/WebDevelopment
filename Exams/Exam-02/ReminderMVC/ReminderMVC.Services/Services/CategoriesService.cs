using Newtonsoft.Json;
using ReminderMVC.Services.Common;
using ReminderMVC.Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ReminderMVC.Services.Services
{
    public class CategoriesService : AppService<CategoryDto>
    {
        public CategoriesService(string baseUrl) : base(baseUrl)
        {
        }

        public new async Task<CategoryDto> AddAsync(CategoryDto entity)
        {
            CategoryDto categoryDtoResponse = null;

            StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");

            // Sending request to find web api REST service resource to Add an User using HttpClient
            HttpResponseMessage response = await _httpClient.PostAsync($"api/v1/categories/", content);

            // Checking the response is successful or not which is sent using HttpClient
            if (response.IsSuccessStatusCode)
            {
                // Storing the content response recieved from web api
                var responseContent = response.Content.ReadAsStringAsync().Result;

                //Deserializing the response recieved from web api and storing into the Employee list
                categoryDtoResponse = JsonConvert.DeserializeObject<CategoryDto>(responseContent);
            }

            return categoryDtoResponse;
        }

        public new async Task<CategoryDto> DeleteAsync(int id)
        {
            CategoryDto categoryDtoResponse = null;

            // Sending request to find web api REST service resource to Delete the User using HttpClient
            HttpResponseMessage response = await _httpClient.DeleteAsync($"api/v1/categories/{id}");

            // Checking the response is successful or not which is sent using HttpClient
            if (response.IsSuccessStatusCode)
            {
                // Storing the content response recieved from web api
                var responseContent = response.Content.ReadAsStringAsync().Result;

                // Deserializing the response recieved from web api
                categoryDtoResponse = JsonConvert.DeserializeObject<CategoryDto>(responseContent);
            }

            return categoryDtoResponse;
        }

        public new async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var categoriesList = new List<CategoryDto>();

            // Sending request to find web api REST service resource to Get All Users using HttpClient
            HttpResponseMessage response = await _httpClient.GetAsync("api/v1/categories");

            // Checking the response is successful or not which is sent using HttpClient
            if (response.IsSuccessStatusCode)
            {
                // Storing the content response recieved from web api
                var responseContent = response.Content.ReadAsStringAsync().Result;

                //Deserializing the response recieved from web api and storing into the Employee list
                categoriesList = JsonConvert.DeserializeObject<List<CategoryDto>>(responseContent);
            }

            return categoriesList;
        }

        public new async Task<CategoryDto> GetByIdAsync(int id)
        {
            CategoryDto category = null;

            // Sending request to find web api REST service resource to Get All Users using HttpClient
            HttpResponseMessage response = await _httpClient.GetAsync($"api/v1/categories/{id}");

            // Checking the response is successful or not which is sent using HttpClient
            if (response.IsSuccessStatusCode)
            {
                // Storing the content response recieved from web api
                var responseContent = response.Content.ReadAsStringAsync().Result;

                //Deserializing the response recieved from web api and storing into the Employee list
                category = JsonConvert.DeserializeObject<CategoryDto>(responseContent);
            }

            return category;
        }

        public new async Task<CategoryDto> UpdateAsync(CategoryDto entity)
        {
            CategoryDto categoryDtoResponse = null;

            StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");

            // Sending request to find web api REST service resource to Add an User using HttpClient
            HttpResponseMessage response = await _httpClient.PutAsync($"api/v1/categories/{entity.Id}", content);

            // Checking the response is successful or not which is sent using HttpClient
            if (response.IsSuccessStatusCode)
            {
                // Storing the content response recieved from web api
                var responseContent = response.Content.ReadAsStringAsync().Result;

                //Deserializing the response recieved from web api
                categoryDtoResponse = JsonConvert.DeserializeObject<CategoryDto>(responseContent);
            }

            return categoryDtoResponse;
        }

    }
}
