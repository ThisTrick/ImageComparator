namespace ImageComparator;

public interface IImageAccessor
{
    int Width { get; }

    int Height { get; }

    Pixel GetPixel(int x, int y);
}