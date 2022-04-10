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
using ClientSolution.Web.IService;

namespace ClientSolution.Web.Service
{
    public class AddressService : IPersonAddressService
    {
        private readonly HttpClient httpClient;

        public AddressService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<Address>> Delete(int Id)
        {
            var response = await httpClient.DeleteAsync($"api/address/{Id}");
            response.EnsureSuccessStatusCode();
            string responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Address>>(responseContent);
        }

        public async Task<List<Address>> GetAddressByPersonId(int Id)
        {
            var response = await httpClient.GetAsync($"api/address/GetAddressByPersonId/{Id}");
            response.EnsureSuccessStatusCode();
            string responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Address>>(responseContent);
        }

        public async Task<List<Address>> GetAll()
        {
            var response = await httpClient.GetAsync("api/address/");
            response.EnsureSuccessStatusCode();
            string responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Address>>(responseContent);
        }

        public async Task<Address> GetById(int Id)
        {
            var response = await httpClient.GetAsync($"api/address/{Id}");
            response.EnsureSuccessStatusCode();
            string responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Address>(responseContent);
        }

        public async Task<List<Address>> Insert(Address value)
        {
            string jsonproduct = System.Text.Json.JsonSerializer.Serialize(value);
            var stringContent = new StringContent(jsonproduct, System.Text.Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync($"api/address/", stringContent);
            var result = response.Content.ReadAsStringAsync();
            var _address = System.Text.Json.JsonSerializer.Deserialize(result.Result, typeof(List<Address>), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return _address as List<Address>;
        }

        public async Task<Address> Update(Address value)
        {
            string jsonproduct = System.Text.Json.JsonSerializer.Serialize(value);
            var stringContent = new StringContent(jsonproduct, System.Text.Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync($"api/address/", stringContent);
            var result = response.Content.ReadAsStringAsync();
            var _address = System.Text.Json.JsonSerializer.Deserialize(result.Result, typeof(Address), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return _address as Address;
        }
        //public void Export(List<Address> value)
        //{
        //    string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        //    // Write the string array to a new file named "WriteLines.txt".
        //    using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "WriteLines.txt")))
        //    {
        //        foreach (var item in value)
        //        {

        //            string line = (AddressType)item.AddressTypeId + "," +(Province)item.ProvinceId + "," + item.Town +","+item.StreetName;

        //            outputFile.WriteLine(line);
        //        }
        //    }
        //}
    }
}
