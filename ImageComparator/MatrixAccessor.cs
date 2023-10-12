namespace ImageComparator;

public class MatrixAccessor : IImageAccessor
{
    private readonly byte[,] _matrix;
    public int Width { get; }
    public int Height { get; }

    public MatrixAccessor(byte[,] image)
    {
        _matrix = image;
        Width = image.GetLength(1);
        Height = image.GetLength(0);
    }
    
    public Pixel GetPixel(int x, int y)
        => Pixel.FromInt(_matrix[x, y]);
}