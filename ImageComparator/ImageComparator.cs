namespace ImageComparator;


public record DifferentRectangle(int Left, int Top, int Width, int Height);

public class ImageComparator
{
    public List<DifferentRectangle> Compare(IImageAccessor img1, IImageAccessor img2)
    {
        throw new NotImplementedException();
    }
}