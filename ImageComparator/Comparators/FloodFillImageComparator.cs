using ImageComparator.Assessors;
using ImageComparator.Models;

namespace ImageComparator.Comparators;

/// <summary>
/// Flood Fill algorithm 
/// </summary>
public class FloodFillImageComparator : IImageComparator
{
    private readonly IEqualityComparer<Pixel> _comparer;

    public FloodFillImageComparator(IEqualityComparer<Pixel> comparer)
    {
        _comparer = comparer;
    }
    
    public bool[,] Compare(IImageAccessor img1, IImageAccessor img2)
    {
        var maxHeight = Math.Max(img2.Height, img1.Height);
        var maxWidth = Math.Max(img2.Width, img1.Width);
        var minHeight = Math.Min(img2.Height, img1.Height);
        var minWidth = Math.Min(img2.Width, img1.Width);
        
        var diffMap = new bool[maxHeight, maxWidth];
        var visited = new bool[maxHeight, maxWidth];
        
        if (img2.Width != img1.Width)
        {
            SetDiffMapForNotEqualsWidth(Math.Abs(img2.Width - img1.Width), maxWidth, maxHeight, diffMap, visited);
        }
        
        if (img2.Height != img1.Height)
        {
            SetDiffMapForNotEqualsHeight(Math.Abs(img2.Height - img1.Height), maxHeight, maxWidth, diffMap, visited);
        }

        for (int x = 0; x < minHeight; x++)
        {
            for (int y = 0; y < minWidth; y++)
            {
                SetDiffMapIfHasDiff(img1, img2, x, y, visited, diffMap);

                Flood(img1, img2, y, minWidth, x, minHeight, visited, diffMap);
            }
        }
        
        return diffMap;
    }

    private void SetDiffMapIfHasDiff(IImageAccessor img1, IImageAccessor img2, int x, int y, bool[,] visited,
        bool[,] diffMap)
    {
        if (!HasPixelDiff(visited[x, y], img1.GetPixel(x, y), img2.GetPixel(x, y)))
            return;

        diffMap[x, y] = true;
        visited[x, y] = true;
    }

    private void Flood(IImageAccessor img1, IImageAccessor img2, int y, int minWidth, int x, int minHeight, bool[,] visited,
        bool[,] diffMap)
    {
        for (int floodY = y; floodY < minWidth; floodY++)
        {
            int floodX = floodY == y ? x + 1 : x;
            for (; floodX < minHeight; floodX++)
            {
                SetDiffMapIfHasDiff(img1, img2, x, y, visited, diffMap);
            }
        }
    }
        
    private void SetDiffMapForNotEqualsHeight(int difHeight, int maxHeight, int maxWidth, bool[,] diffMap, bool[,] visited)
    {
        int x = maxHeight - difHeight;
        for (; x < maxHeight; x++)
        {
            for (int y = 0; y < maxWidth; y++)
            {
                diffMap[x, y] = true;
                visited[x, y] = true;
            }
        }
    }

    private void SetDiffMapForNotEqualsWidth(int difWidth, int maxWidth, int maxHeight, bool[,] diffMap, bool[,] visited)
    {
        int y = maxWidth - difWidth;
        for (; y < maxWidth; y++)
        {
            for (int x = 0; x < maxHeight; x++)
            {
                diffMap[x, y] = true;
                visited[x, y] = true;
            }
        }
    }

    private bool HasPixelDiff(bool visited, Pixel pixel1, Pixel pixel2)
        => !visited && _comparer.Equals(pixel1, pixel2);

}