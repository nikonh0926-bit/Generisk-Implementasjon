
public class GetNewId
{
    public static int CreatedCount { get; private set; }    
    public static int NewId()
    {
        return CreatedCount++;
    }
}
public interface IInventoryItem
{
    string Name { get; }
    int Id { get; }
    
}
public class Skateboard : IInventoryItem
{
    public string Name { get; set; }
    public int Id { get; set; }

    public string DeckShape { get; set; }
    public int WheelHardness { get; set; }

    public Skateboard(string name, string deckShape, int wheelHardness)
    {
        Name = name;
        Id = GetNewId.NewId();
        DeckShape = deckShape;
        WheelHardness = wheelHardness;
    }
}
public class Guitar : IInventoryItem
{
    public string Name { get; set; }
    public int Id { get; set; }

    public string Tuning { get; set; }
    public int StringGauge { get; set; }

    public Guitar(string name, string tuning, int stringGauge)
    {
        Name = name;
        Id = GetNewId.NewId();
        Tuning = tuning;
        StringGauge = stringGauge;
    }
}

public class Camera :IInventoryItem
{
    public string Name { get; set; }
    public int Id { get; set; }
    
    public string Format { get; set; }
    public string LensMount { get; set; }

    public Camera(string name, string format, string lensMount)
    {
        Name = name;
        Id = GetNewId.NewId();
        Format = format;
        LensMount = lensMount;
    }
}