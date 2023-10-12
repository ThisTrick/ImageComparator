
namespace ImageComparator.UnitTests;

public class ImageComparatorTest
{

    private List<DifferentRectangle> Act(byte[,] img1, byte[,] img2)
    {
        var comparator = new ImageComparator();
        return comparator.Compare(new MatrixAccessor(img1), new MatrixAccessor(img2));
    }
    
    [Fact]
    public void When_SecondImageWider_Should_ReturnOneDiffRect()
    {

        var img1 = new byte[,]
        {
            { 0, 0 },
            { 0, 0 }
        };
        var img2 = new byte[,]
        {
            { 0, 0, 0 },
            { 0, 0, 0 }
        };
        
        var result = Act(img1, img2);

        result.Should().HaveCount(1)
            .And.ContainSingle(x => x.Left == 2 && x.Top == 0 && x.Width == 1 && x.Height == 2);

    }
    
    [Fact]
    public void When_SecondImageHigher_Should_ReturnOneDiffRect()
    {

        var img1 = new byte[,]
        {
            { 0, 0 },
            { 0, 0 }
        };
        var img2 = new byte[,]
        {
            { 0, 0 },
            { 0, 0 },
            { 0, 0 }
        };
        
        var result = Act(img1, img2);

        result.Should().HaveCount(1)
            .And.ContainSingle(x => x.Left == 0 && x.Top == 1 && x.Width == 2 && x.Height == 1);

    }
    
    [Fact]
    public void When_SecondImageBigger_Should_ReturnOneDiffRect()
    {
        var img1 = new byte[,]
        {
            { 0, 0 },
            { 0, 0 }
        };
        var img2 = new byte[,]
        {
            { 0, 0, 0 },
            { 0, 0, 0 },
            { 0, 0, 0 }
        };
        
        var result = Act(img1, img2);

        result.Should().HaveCount(2)
            .And.ContainSingle(x => x.Left == 0 && x.Top == 1 && x.Width == 2 && x.Height == 1)
            .And.ContainSingle(x => x.Left == 2 && x.Top == 0 && x.Width == 1 && x.Height == 2);
    }
    
    [Fact]
    public void When_SingleDiff_Should_ReturnOne1x1DiffRect()
    {
        var img1 = new byte[,]
        {
            { 0, 0, 0 },
            { 0, 0, 0 },
            { 0, 0, 0 }
        };
        var img2 = new byte[,]
        {
            { 0, 0, 0 },
            { 0, 1, 0 },
            { 0, 0, 0 }
        };
        
        var result = Act(img1, img2);

        result.Should().HaveCount(1)
            .And.ContainSingle(x => x.Left == 1 && x.Top == 1 && x.Width == 1 && x.Height == 1);
    }
    
    [Fact]
    public void When_SingleDiff_Should_ReturnOne1x2DiffRect()
    {
        var img1 = new byte[,]
        {
            { 0, 0, 0 },
            { 0, 0, 0 },
            { 0, 0, 0 }
        };
        var img2 = new byte[,]
        {
            { 0, 0, 0 },
            { 0, 1, 1 },
            { 0, 0, 0 }
        };
        
        var result = Act(img1, img2);

        result.Should().HaveCount(1)
            .And.ContainSingle(x => x.Left == 1 && x.Top == 1 && x.Width == 2 && x.Height == 1);
    }
    
    [Fact]
    public void When_SingleDiff_Should_ReturnOne2x2DiffRect()
    {
        var img1 = new byte[,]
        {
            { 0, 0, 0 },
            { 0, 0, 0 },
            { 0, 0, 0 }
        };
        var img2 = new byte[,]
        {
            { 0, 0, 0 },
            { 0, 1, 1 },
            { 0, 1, 1 }
        };
        
        var result = Act(img1, img2);

        result.Should().HaveCount(1)
            .And.ContainSingle(x => x.Left == 1 && x.Top == 1 && x.Width == 2 && x.Height == 2);
    }
    
    [Fact]
    public void When_2Diff_Should_Return2DiffRect()
    {
        var img1 = new byte[,]
        {
            { 0, 0, 0 },
            { 0, 0, 0 },
            { 0, 0, 0 }
        };
        var img2 = new byte[,]
        {
            { 1, 0, 0 },
            { 0, 0, 0 },
            { 0, 0, 1 }
        };
        
        var result = Act(img1, img2);

        result.Should().HaveCount(2)
            .And.ContainSingle(x => x.Left == 0 && x.Top == 0 && x.Width == 1 && x.Height == 1)
            .And.ContainSingle(x => x.Left == 2 && x.Top == 2 && x.Width == 1 && x.Height == 1);
    }
    
    [Fact]
    public void When_2Diff_Should_ReturnTwo1x2DiffRect()
    {
        var img1 = new byte[,]
        {
            { 0, 0, 0 },
            { 0, 0, 0 },
            { 0, 0, 0 }
        };
        var img2 = new byte[,]
        {
            { 1, 1, 0 },
            { 0, 0, 0 },
            { 0, 1, 1 }
        };
        
        var result = Act(img1, img2);

        result.Should().HaveCount(2)
            .And.ContainSingle(x => x.Left == 0 && x.Top == 0 && x.Width == 2 && x.Height == 1)
            .And.ContainSingle(x => x.Left == 1 && x.Top == 1 && x.Width == 2 && x.Height == 1);
    }
    
}