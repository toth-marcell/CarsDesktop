using System.Text.Json.Serialization;

namespace CarsDesktop
{
    internal class Manufacturer
    {
        public Manufacturer(string name, int foundingYear, string country)
        {
            Name = name;
            FoundingYear = foundingYear;
            Country = country;
        }
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("foundingYear")]
        public int FoundingYear { get; set; }
        [JsonPropertyName("country")]
        public string Country { get; set; }
        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }
        [JsonPropertyName("updatedAt")]
        public DateTime UpdatedAt { get; set; }
    }
}
