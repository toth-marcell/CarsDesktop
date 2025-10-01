using System.Text.Json;
using CarsDesktop;

ServerConnection server = new("http://localhost:3000/api/");

Console.WriteLine($"Cars: {string.Join(", ", (await server.GetCars()).Select(x => JsonSerializer.Serialize(x)))}");
Console.WriteLine($"Manufacturers: {string.Join(", ", (await server.GetManufacturers()).Select(x => JsonSerializer.Serialize(x)))}");
Console.WriteLine($"Owners: {string.Join(", ", (await server.GetOwners()).Select(x => JsonSerializer.Serialize(x)))}");
//Console.WriteLine(await server.DeleteCar(1));
//Console.WriteLine(await server.CreateManufacturer(new("a", 2000, "Japan")));