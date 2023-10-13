using ImageComparator.Assessors;

namespace ImageComparator.Comparators;

public interface IImageComparator
{
    bool[,] Compare(IImageAccessor img1, IImageAccessor img2);
}