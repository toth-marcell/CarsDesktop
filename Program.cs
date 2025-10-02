using System.Text.Json;
using CarsDesktop;

ServerConnection server = new("http://localhost:3000/api/");

// the following breaks the visual studio formatter....
MenuOption[] menuOptions = [
        new("List cars", async () => { Console.WriteLine($"Cars:\n{string.Join(",\n", (await server.GetCars()).Select(x => JsonSerializer.Serialize(x)))}"); }),
        new("List manufacturers", async () => { Console.WriteLine($"Manufacturers:\n{string.Join(",\n", (await server.GetManufacturers()).Select(x => JsonSerializer.Serialize(x)))}"); }),
        new("List owners", async () => { Console.WriteLine($"Owners:\n{string.Join(",\n", (await server.GetOwners()).Select(x => JsonSerializer.Serialize(x)))}"); }),
        new("Delete car", async () => { Console.WriteLine(await server.DeleteCar(RequestNumber("Car id to delete"))); }),
        new("Delete manufacturer", async () => { Console.WriteLine(await server.DeleteManufacturer(RequestNumber("Manufacturer id to delete"))); }),
        new("Delete owner", async () => { Console.WriteLine(await server.DeleteOwner(RequestNumber("Owner id to delete"))); }),
        new("Create new car", async () => {
            Console.WriteLine(await server.CreateCar(new Car(RequestString("Model"),RequestNumber("Power"),RequestNumber("Year"),RequestNumber("Wheel size"),RequestNumber("Manufacturer id"))));
        }),
        new("Create new manufacturer", async () => {
            Console.WriteLine(await server.CreateManufacturer(new Manufacturer(RequestString("Name"),RequestNumber("Founding year"),RequestString("Country"))));
        }),
        new("Create new owner", async () => {
            Console.WriteLine(await server.CreateOwner(new Owner(RequestString("Name"),RequestString("Address"),RequestNumber("Birth year"),RequestNumber("Car id"))));
        }),
        new("Exit", () => { Environment.Exit(0); return Task.CompletedTask; })
];

while (true) await ShowMenu();

async Task ShowMenu()
{
    for (int i = 0; i < menuOptions.Length; i++)
    {
        Console.WriteLine($"{i + 1}. {menuOptions[i].Name}");
    }
    await menuOptions[RequestNumber("Choose a number") - 1].Execute();
    Console.WriteLine();
}


int RequestNumber(string prompt)
{
    int number;
    do Console.Write(prompt + ": ");
    while (!int.TryParse(Console.ReadLine(), out number));
    return number;
}

string RequestString(string prompt)
{
    string? input;
    do
    {
        Console.Write(prompt + ": ");
        input = Console.ReadLine();
    }
    while (input == null || input == "");
    return input;
}

struct MenuOption(string name, Func<Task> execute)
{
    public string Name { get; set; } = name;
    public Func<Task> Execute { get; set; } = execute;
}
