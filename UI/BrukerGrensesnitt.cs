using Terminal.Gui.App;
using Terminal.Gui.ViewBase;
using Terminal.Gui.Views;

class BrukerGrensesnitt
{
    public static void GetUI(Inventory<Guitar> guitars, Inventory<Skateboard> skateboards, Inventory<Camera> cameras)
    {
        using IApplication app = Application.Create ();
        app.Init ();

        using Window window = new () { Title = "Inventory(press esc to exit)" };

        Bar commands = new()
        {
            Orientation = Orientation.Vertical,
        };
        ListView commandView = new()
        {
            Text = "choose command",
            X = 0,
            Y = 0,
            Height = Dim.Fill(),
            Width = Dim.Percent(15)
        };
        Label contentView = new()
        {
            X = Pos.Right(commandView),
            Y = 0,
            Height = Dim.Fill(),
            Width = Dim.Percent(85)
        };

        Button printSkate = new()
        {
            Text = "Print skateboards",
            Y = 2,
            X = 1
        };
        printSkate.Accepted += (_, args) => {contentView.Text = Program.Print(skateboards);};
        commandView.Add(printSkate);

        Button printCameras = new()
        {
            Text = "print cameras",
            Y = 3,
            X = 1  
        };
        printCameras.Accepted += (_, args) => {contentView.Text = Program.Print(cameras);};
        commandView.Add(printCameras);

        Button printGuitars = new()
        {
            Text = "print guitars",
            Y = 4,
            X = 1  
        };
        printGuitars.Accepted += (_, args) => {contentView.Text = Program.Print(guitars);};
        commandView.Add(printGuitars);

        Button printAll = new()
        {
          Text = "Print all",
          Y = 5,
          X = 1
        };
        printAll.Accepted += (_, args) => {contentView.Text = Program.Print(skateboards) + Program.Print(guitars) + Program.Print(cameras);};
        commandView.Add(printAll);

        Button add = new()
        {
            Text = "add",
            Y = 6,
            X = 1
        };
        add.Accepted += (_, args) =>
        {
            
        };
        commandView.Add(add);

        Button remove = new()
        {
          Text = "remove",
            Y = 7,
            X = 1
        };
        remove.Accepted += (_, args) =>
        {
            
        };
        commandView.Add(remove);

        Button find = new()
        {
            Text = "find",
            Y = 8,
            X = 1  
        };
        find.Accepted += (_, args) =>
        {
            
        };
        commandView.Add(find);

        Button sort = new()
        {
            Text = "sort",
            Y = 9,
            X = 1  
        };
        sort.Accepted += (_, args) =>
        {
            
        };
        commandView.Add(sort);        

        window.Add (commandView, contentView);

        app.Run (window);
    }    
}