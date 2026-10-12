public static class Program
{
    public static void Main(string[] args)
    {
        // initialize inventory
        var guitars = new Inventory<Guitar>();
        var cameras = new Inventory<Camera>();
        var skateboards = new Inventory<Skateboard>();

        // seed data
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

        // initialize vizualisation of data
        BrukerGrensesnitt.GetUI(guitars, skateboards, cameras);
    }

    // print data from a specific generic item inventory
    public static string Print<T>(Inventory<T> inventory)
        where T : IInventoryItem
    {
        var list = inventory.GetAll();
        string output = "";
        foreach (var item in list)
        {
                output += $"Board name: {item.Name}\nId: {item.Id}\n";
        }
        return output;
    }
}