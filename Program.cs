public static class Program
{
    public static void Main(string[] args)
    {
        // Initialize inventory
        var guitars = new Inventory<Guitar>();
        var cameras = new Inventory<Camera>();
        var skateboards = new Inventory<Skateboard>();

        // Seed data
        var lesPaulStudio = new Guitar("Les Paul Studio", "D#", 11);
        var morello = new Guitar("Fender Tom Morello stratocaster", "Drop D", 9);
        guitars.Add(lesPaulStudio);
        guitars.Add(morello);

        var revueAC4 = new Camera("Revue AC4", "35mm", "Pentax k");
        var pentaxKX = new Camera("Pentax KX", "aps-c sensor", "Pentax K");
        cameras.Add(revueAC4);
        cameras.Add(pentaxKX);

        var kennyMcormak = new Skateboard("Zero x Kanaan: Kenny MCormak", "popsicle", 99);
        var cruiser = new Skateboard("Zero cruiser", "Popsicle", 77);
        skateboards.Add(kennyMcormak);
        skateboards.Add(cruiser);



        // Start main app for visualizing data
        BrukerGrensesnitt.GetUI(guitars, skateboards, cameras);
    }

    // Prints data from a item inventory
    // Uses Func<T, string> formatDetails to gather item specific data during call of method
    public static string Print<T>(Inventory<T> inventory, string typeName, Func<T, string> formatDetails)
        where T : IInventoryItem
    {
        string output = "";

    foreach (var item in inventory.GetAll())
    {
        output += $"Type: {typeName}\n";
        output += $"Name: {item.Name}\n";
        output += $"ID: {item.Id}\n";
        output += formatDetails(item);
        output += "\n\n";
    }
        return output;
    }
}