using System.Text.Json.Serialization;

namespace CarsDesktop
{
    internal class Car
    {
        public Car(string model, int power, int year, int wheelSize, int? manufacturerId)
        {
            Model = model;
            Power = power;
            Year = year;
            WheelSize = wheelSize;
            ManufacturerId = manufacturerId;
        }
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("model")]
        public string Model { get; set; }
        [JsonPropertyName("power")]
        public int Power { get; set; }
        [JsonPropertyName("year")]
        public int Year { get; set; }
        [JsonPropertyName("wheelSize")]
        public int WheelSize { get; set; }
        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }
        [JsonPropertyName("updatedAt")]
        public DateTime UpdatedAt { get; set; }
        public int? ManufacturerId { get; set; }
        public Manufacturer? Manufacturer { get; set; }

    }
}
