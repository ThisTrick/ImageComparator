namespace ImageComparator.Models;

public record struct Pixel(byte R, byte G, byte B, byte A)
{
    public static Pixel FromInt(int color)
    {
        var ax = (byte)(color % 0xFF);
        var rx = (byte)((color >> 16) % 0xFF);
        var gx = (byte)((color >> 8) % 0xFF);
        var bx = (byte)((color >> 24) % 0xFF);
        return new Pixel(rx, gx, bx, ax);
    }
}