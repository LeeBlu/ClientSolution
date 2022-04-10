using ClientSolution.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using  ClientSolution.Web.Enums;

namespace ClientSolution.Web.Service
{
    public class PersonService : IGenericService<Person>
    {
        private readonly HttpClient httpClient;

        public PersonService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<Person>> Delete(int Id)
        {
            var response = await httpClient.DeleteAsync($"api/person/{Id}");
            response.EnsureSuccessStatusCode();
            string responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Person>>(responseContent);
        }

        public async Task<List<Person>> GetAll()
        
        {
            var response = await httpClient.GetAsync("api/person/");
            response.EnsureSuccessStatusCode();
            string responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Person>>(responseContent);
        }

        public async Task<Person> GetById(int Id)
        {
            var response = await httpClient.GetAsync($"api/person/{Id}");
            response.EnsureSuccessStatusCode();
            string responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Person>(responseContent);
        }

        public async Task<List<Person>> Insert(Person value)
        {
            string jsonproduct = System.Text.Json.JsonSerializer.Serialize(value);
            var stringContent = new StringContent(jsonproduct, System.Text.Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync($"api/person/", stringContent);
            var result = response.Content.ReadAsStringAsync();
            var _person = System.Text.Json.JsonSerializer.Deserialize(result.Result, typeof(List<Person>), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return _person as List<Person>;
        }

        public async Task<Person> Update(Person value)
        {
            string jsonproduct = System.Text.Json.JsonSerializer.Serialize(value);
            var stringContent = new StringContent(jsonproduct, System.Text.Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync($"api/address/", stringContent);
            var result = response.Content.ReadAsStringAsync();
            var _person = System.Text.Json.JsonSerializer.Deserialize(result.Result, typeof(Person), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return _person as Person;
        }



    }
}
