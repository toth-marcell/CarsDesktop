using System.Text.Json.Serialization;

namespace CarsDesktop
{
    internal class Owner
    {
        public Owner(string name, string address, int year, int? carId)
        {
            Name = name;
            Address = address;
            Year = year;
            CarId = carId;
        }
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("address")]
        public string Address { get; set; }
        [JsonPropertyName("year")]
        public int Year { get; set; }
        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }
        [JsonPropertyName("updatedAt")]
        public DateTime UpdatedAt { get; set; }
        public int? CarId { get; set; }
        public Car? Car { get; set; }
    }
}
