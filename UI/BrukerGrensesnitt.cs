using Terminal.Gui.App;
using Terminal.Gui.ViewBase;
using Terminal.Gui.Views;

class BrukerGrensesnitt
{
    // Special display for commands
    private static ListView commandView = new()
    {
        Text = "choose command",
        X = 0,
        Y = 0,
        Height = Dim.Fill(),
        Width = Dim.Percent(15)
    };  

    // Main display for content
    private static View contentView = new()
    {
        X = Pos.Right(commandView),
        Y = 0,
        Height = Dim.Fill(),
        Width = Dim.Percent(85),
        CanFocus = true
    };
    public static void GetUI(Inventory<Guitar> guitars, Inventory<Skateboard> skateboards, Inventory<Camera> cameras)
    {
        // Creates and initializes the app
        using IApplication app = Application.Create ();
        app.Init ();

        // Creates the main application window
        using Window window = new () { Title = "Inventory(press esc to exit)" };

        // Displays all skateboards in the inventory
        Button printSkate = new()
        {
            Text = "Print skateboards",
            Y = 2,
            X = 1
        };
        printSkate.Accepted += (_, args) => {contentView.RemoveAll(); contentView.Text = 
            Program.Print(
                            skateboards, 
                            "Board",
                            item => $"Deck shape: {item.DeckShape}\n" +
                                    $"Wheel hardness: {item.WheelHardness}"
                        );};
        commandView.Add(printSkate);

        // Displays all cameras in the inventory
        Button printCameras = new()
        {
            Text = "print cameras",
            Y = 3,
            X = 1  
        };
        printCameras.Accepted += (_, args) => {ClearContent();; contentView.Text = 
        Program.Print(
                        cameras, 
                        "Camera",
                        item => $"Format: {item.Format}\n" +
                                $"Lens mount: {item.LensMount}"
                    );};
        commandView.Add(printCameras);

        // Displays all guitars in the inventory
        Button printGuitars = new()
        {
            Text = "print guitars",
            Y = 4,
            X = 1  
        };
        printGuitars.Accepted += (_, args) => {ClearContent();; contentView.Text = 
        Program.Print(
                        guitars, 
                        "guitar",
                        item => $"Tuning: {item.Tuning}\n" +
                                $"String gauge: {item.StringGauge}"
                        );};
        commandView.Add(printGuitars);

        // Displays all items from every inventory
        Button printAll = new()
        {
          Text = "Print all",
          Y = 5,
          X = 1
        };
        printAll.Accepted += (_, args) => {ClearContent();; contentView.Text = 
        Program.Print(
                        skateboards, 
                        "Board",
                        item => $"Deck shape: {item.DeckShape}\n" +
                                $"Wheel hardness: {item.WheelHardness}"
                    ) + 
        Program.Print(
                        guitars, 
                        "guitar",
                        item => $"Tuning: {item.Tuning}\n" +
                                $"String gauge: {item.StringGauge}"
                    ) + 
        Program.Print(
                        cameras, 
                        "camera",
                        item => $"Format: {item.Format}\n" +
                                $"Lens mount: {item.LensMount}"
                    );};
        commandView.Add(printAll);


        // Add a new item using text form to the desired inventory
        // Calls the specific methods on button press
        // And adds button to window
        Button add = new()
        {
            Text = "add",
            Y = 6,
            X = 1
        };
        add.Accepted += (_, args) =>
        {
            ClearContent();
            Button addSkateboard = new() { Text = "Skateboard", Y = 2, X = 1 };
            Button addGuitar = new() { Text = "Guitar", Y = 3, X = 1 };
            Button addCamera = new() { Text = "Camera", Y = 4, X = 1 };

            addSkateboard.Accepted += (_, args) =>
            {
                ShowAddForm(
                    skateboards,
                    "Deck shape",
                    "Wheel hardness",
                    (name, shape, hardness) =>
                        new Skateboard(name, shape, int.Parse(hardness))
                );
            };

            addGuitar.Accepted += (_, args) =>
            {
                ShowAddForm(
                    guitars,
                    "Tuning",
                    "String gauge (numbers only)",
                    (name, tuning, gauge) =>
                        new Guitar(name, tuning, ParseIntElseReturnDefault(gauge))
                );
            };

            addCamera.Accepted += (_, args) =>
            {
                ShowAddForm(
                    cameras,
                    "Format",
                    "Lens mount",
                    (name, format, mount) =>
                        new Camera(name, format, mount)
                );
            };
            contentView.Add(addSkateboard, addGuitar, addCamera);
        };
        commandView.Add(add);

        // Creates buttons for removing items from the selected inventory
        // Calls the specific methods on button press
        // And adds button to window
        Button remove = new()
        {
          Text = "remove",
            Y = 7,
            X = 1
        };
        remove.Accepted += (_, args) =>
        {
            ClearContent();

            Button removeSkateboard = new(){Text = "Skateboards", Y = 2, X = 1};

            Button removeGuitar = new(){Text = "Guitars", Y = 3, X = 1};

            Button removeCamera = new(){Text = "Cameras", Y = 4, X = 1};

            removeSkateboard.Accepted += (_, args) =>
                CreateButtonsFromInventory(
                    skateboards,
                    item => $"Delete: {item.Name} (ID {item.Id})",
                    item => skateboards.Remove(item)
                );

            removeGuitar.Accepted += (_, args) =>
                CreateButtonsFromInventory(
                    guitars,
                    item => $"Delete: {item.Name} (ID {item.Id})",
                    item => guitars.Remove(item)
                );

            removeCamera.Accepted += (_, args) =>
                CreateButtonsFromInventory(
                    cameras,
                    item => $"Delete: {item.Name} (ID {item.Id})",
                    item => cameras.Remove(item)
                );

                contentView.Add(
                removeSkateboard,
                removeGuitar,
                removeCamera
            );
        };
        commandView.Add(remove);

        // creates button for finding a specific object in the inventory
        // Calls the specific methods on button press
        // And adds button to window
        Button find = new()
        {
            Text = "find",
            Y = 8,
            X = 1  
        };
        find.Accepted += (_, args) =>
        {
            ClearContent();
            Button findSkateboard = new(){Text = "Find skateboard", Y = 2, X = 1};

            Button findGuitar = new(){Text = "Find guitar", Y = 3, X = 1};

            Button findCamera = new(){Text = "Find camera", Y = 4, X = 1};

            findSkateboard.Accepted += (_, args) => 
                FindItem(skateboards);
            findGuitar.Accepted += (_, args) => 
                FindItem(guitars);
            findCamera.Accepted += (_, args) => 
                FindItem(cameras);
            contentView.Add(
                findSkateboard,
                findGuitar,
                findCamera
            );
        };
        commandView.Add(find);

        // Creates buttons for selecting an inventory to sort
        // Calls the specific methods on button press
        // And adds button to window
        Button sort = new()
        {
            Text = "sort",
            Y = 9,
            X = 1  
        };
        sort.Accepted += (_, args) =>
        {
            ClearContent();
            Button sortSkateboards = new(){Text = "Sort skateboards", Y = 2, X = 1};
            Button sortGuitars = new(){Text = "Sort guitars", Y = 3, X = 1};
            Button sortCameras = new(){Text = "Sort cameras", Y = 4, X = 1};

            sortSkateboards.Accepted += (_, args) =>
                SortItems(skateboards);
            sortGuitars.Accepted += (_, args) =>
                SortItems(guitars);
            sortCameras.Accepted += (_, args) =>
                SortItems(cameras);
            contentView.Add(sortSkateboards, sortGuitars, sortCameras);
        };
        commandView.Add(sort);        

        // Adds both windows to main window and starts the app
        window.Add (commandView, contentView);
        app.Run (window);
    }




 // Helper methods for the user interface




    // Creates a button for each item in the inventory
    public static void CreateButtonsFromInventory<T>(Inventory<T> inventory, Func<T, string> getButtonText, Action<T> action)
    where T : IInventoryItem
    {
        ClearContent();

        List<T> items = inventory.GetAll();

        for(int i = 0; i < items.Count; i++)
        {
            T item = items[i];
            Button button = new()
            {
                Text = getButtonText(item),
                Y = i + 3,
                X = 3  
            };

            button.Accepted += (_, args) => {action(item); contentView.RemoveAll();};

            contentView.Add(button);
        }
    }

    // Creates an item using the supplied factory function
    public static T CreateItem<T>(
    string name,
    Func<string, T> factory)
    where T : IInventoryItem
    {
        return factory(name);
    }

    // Adds the newly created object to the type specific inventory
    public static void AddItem<T>(
    Inventory<T> inventory,
    string name,
    Func<string, T> factory)
    where T : IInventoryItem
    {
        T item = CreateItem(name, factory);
        inventory.Add(item);
    }

    // Create a form for adding new object to inventory
    public static void ShowAddForm<T>(
    Inventory<T> inventory,
    string field2Name,
    string field3Name,
    Func<string, string, string, T> createItem)
    where T : IInventoryItem
    {
        ClearContent();

        TextField nameField = new()
        {
            X = 3,
            Y = 2,
            Width = 25,
            CanFocus = true,
            TabStop = TabBehavior.TabStop
        };

        TextField field2 = new()
        {
            X = 3,
            Y = 5,
            Width = 25,
            CanFocus = true,
            TabStop = TabBehavior.TabStop
        };

        TextField field3 = new()
        {
            X = 3,
            Y = 8,
            Width = 25,
            CanFocus = true,
            TabStop = TabBehavior.TabStop
        };

        Button confirm = new()
        {
            Text = "Create",
            X = 3,
            Y = 10
        };

        contentView.Add(
            new Label { Text = "Name", X = 3, Y = 1 },
            nameField,
            new Label { Text = field2Name, X = 3, Y = 4 },
            field2,
            new Label { Text = field3Name, X = 3, Y = 7 },
            field3,
            confirm
        );
        nameField.SetFocus();

        confirm.Accepted += (_, args) =>
        {
            string name = nameField.Text?.ToString() ?? "";
            string value2 = field2.Text?.ToString() ?? "";
            string value3 = field3.Text?.ToString() ?? "";

            if (string.IsNullOrWhiteSpace(name))
            {
                return;
            }

            T item = createItem(name, value2, value3);
            inventory.Add(item);

            contentView.RemoveAll();
            contentView.Text = $"Created: {item.Name}";
        };
    }

    // Find item in any inventory based on name
    public static void FindItem<T>(Inventory<T> inventory)
    where T : IInventoryItem
    {
        ClearContent();

        TextField searchField = new()
        {
            X = 3,
            Y = 2,
            Width = 25,
            CanFocus = true,
            TabStop = TabBehavior.TabStop
        };

        Button searchButton = new()
        {
            Text = "Search",
            X = 3,
            Y = 4
        };

        contentView.Add(
            new Label { Text = "Name to find:", X = 3, Y = 1 },
            searchField,
            searchButton
        );

        searchField.SetFocus();

        searchButton.Accepted += (_, args) =>
        {
            string name = searchField.Text?.ToString() ?? "";
            T? result = inventory.FindByName(name);

            ClearContent();

            if (result is not null)
            {
                contentView.Add(new Label
                {
                    Text = $"Found: {result.Name} (ID {result.Id})",
                    X = 3,
                    Y = 2
                });
            }
            else
            {
                contentView.Add(new Label
                {
                    Text = $"No item found: {name}",
                    X = 3,
                    Y = 2
                });
            }
        };
    }

   // Sorts the inventory by item name in ascending order
    public static void SortItems<T>(Inventory<T> inventory)
    where T : IInventoryItem
    {
        inventory.Sort(item => item.Name);
        ClearContent();
    }

    // Clear all content from contentView
    public static void ClearContent()
    {
        contentView.Text = "";
        contentView.RemoveAll();
    }

    // Parses an integer or returns 0 if the input is invalid
    static int ParseIntElseReturnDefault(string input)
    {
        if (!int.TryParse(input, out int result))
            return 0;
        return result;
    }
}