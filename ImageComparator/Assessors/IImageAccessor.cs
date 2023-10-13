using ImageComparator.Models;

namespace ImageComparator.Assessors;

public interface IImageAccessor
{
    int Width { get; }

    int Height { get; }

    Pixel GetPixel(int x, int y);
}