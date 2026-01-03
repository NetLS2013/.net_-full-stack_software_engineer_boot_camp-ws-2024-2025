namespace OrderLibrary;

public struct ItemDimensions
{
    public double Width { get; }
    public double Height { get; }
    public double Depth { get; }

    public ItemDimensions(double width, double height, double depth)
    {
        Width = width;
        Height = height;
        Depth = depth;
    }

    public double GetVolume()
    {
        return Width * Height * Depth;
    }

    public override string ToString()
    {
        return $"{Width}x{Height}x{Depth} cm";
    }
}