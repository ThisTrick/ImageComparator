namespace ImageComparator;

public interface IImageComparator
{
    bool[,] Compare(IImageAccessor img1, IImageAccessor img2);
}