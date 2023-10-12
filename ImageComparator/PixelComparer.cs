namespace ImageComparator;

public class PixelComparer : IEqualityComparer<Pixel>
{
    private readonly double _tolerance;
    private readonly double _maxDiff =  Math.Sqrt(Math.Pow(255, 2) * 4);
    public PixelComparer(double tolerance)
    {
        if (tolerance < 0.0 || tolerance > 1.0)
        {
            throw new ArgumentException("Tolerance must be between 0.0 and 1.0");
        }
        
        _tolerance = tolerance;
    }
    
    
    public bool Equals(Pixel pixel1, Pixel pixel2)
    {
        int diffA = Math.Abs(pixel1.A - pixel2.A);
        int diffR = Math.Abs(pixel1.R - pixel2.R);
        int diffG = Math.Abs(pixel1.G - pixel2.G);
        int diffB = Math.Abs(pixel1.B - pixel2.B);

        double diff = Math.Sqrt(Math.Pow(diffA, 2) + Math.Pow(diffR, 2) + Math.Pow(diffG, 2) + Math.Pow(diffB, 2));
        return diff >= _maxDiff * _tolerance;
    }

    public int GetHashCode(Pixel pixel) => pixel.GetHashCode();
}