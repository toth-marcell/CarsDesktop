using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CarsDesktop
{
    internal class ServerConnection(string url)
    {
        readonly HttpClient HTTP = new() { BaseAddress = new Uri(url) };
        public async Task<List<Car>> GetCars()
        {
            HttpResponseMessage result = await HTTP.GetAsync("cars");
            string body = await result.Content.ReadAsStringAsync();
            List<Car> items = JsonSerializer.Deserialize<List<Car>>(body) ?? [];
            return items;
        }
        public async Task<List<Manufacturer>> GetManufacturers()
        {
            HttpResponseMessage result = await HTTP.GetAsync("manufacturers");
            string body = await result.Content.ReadAsStringAsync();
            List<Manufacturer> items = JsonSerializer.Deserialize<List<Manufacturer>>(body) ?? [];
            return items;
        }
        public async Task<List<Owner>> GetOwners()
        {
            HttpResponseMessage result = await HTTP.GetAsync("owners");
            string body = await result.Content.ReadAsStringAsync();
            List<Owner> items = JsonSerializer.Deserialize<List<Owner>>(body) ?? [];
            return items;
        }
        public async Task<string> DeleteCar(int id)
        {
            try
            {
                HttpResponseMessage result = await HTTP.DeleteAsync("cars/" + id);
                string body = await result.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Message>(body).Content;
            }
            catch (Exception e) { return e.Message; }
        }
        public async Task<string> DeleteManufacturer(int id)
        {
            try
            {
                HttpResponseMessage result = await HTTP.DeleteAsync("manufacturers/" + id);
                string body = await result.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Message>(body).Content;
            }
            catch (Exception e) { return e.Message; }
        }
        public async Task<string> DeleteOwner(int id)
        {
            try
            {
                HttpResponseMessage result = await HTTP.DeleteAsync("owners/" + id);
                string body = await result.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Message>(body).Content;
            }
            catch (Exception e) { return e.Message; }
        }
        public async Task<string> CreateManufacturer(Manufacturer manufacturer)
        {
            try
            {
                HttpContent content = new StringContent(JsonSerializer.Serialize(manufacturer), Encoding.UTF8, "application/json");
                HttpResponseMessage result = await HTTP.PostAsync("manufacturers", content);
                string body = await result.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Message>(body).Content;
            }
            catch (Exception e) { return e.Message; }
        }
        public async Task<string> CreateOwner(Owner owner)
        {
            try
            {
                HttpContent content = new StringContent(JsonSerializer.Serialize(owner), Encoding.UTF8, "application/json");
                HttpResponseMessage result = await HTTP.PostAsync("owners", content);
                string body = await result.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Message>(body).Content;
            }
            catch (Exception e) { return e.Message; }
        }
        public async Task<string> CreateCar(Car car)
        {
            try
            {
                HttpContent content = new StringContent(JsonSerializer.Serialize(car), Encoding.UTF8, "application/json");
                HttpResponseMessage result = await HTTP.PostAsync("cars", content);
                string body = await result.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Message>(body).Content;
            }
            catch (Exception e) { return e.Message; }
        }
    }
    struct Message(string content)
    {
        [JsonPropertyName("msg")]
        public string Content { get; set; } = content;
    }
}
