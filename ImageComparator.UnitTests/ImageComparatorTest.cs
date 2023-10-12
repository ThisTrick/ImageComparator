
namespace ImageComparator.UnitTests;

public class ImageComparatorTest
{

    private bool[,] Act(byte[,] img1, byte[,] img2)
    {
        var comparator = new ImageComparator(new PixelComparer(0.00001));
        return comparator.Compare(new MatrixAccessor(img1), new MatrixAccessor(img2));
    }

    private void AssertDiffMap(bool[,] actual, bool[,] expected)
    {
        actual.Should().BeEquivalentTo(expected, opt => opt.WithStrictOrdering());
    }
    
    [Fact]
    public void When_SecondImageWider_Should_ReturnEquivalentDiffMap()
    {

        var img1 = new byte[,]
        {
            { 0, 0 },
            { 0, 0 }
        };
        var img2 = new byte[,]
        {
            { 0, 0, 0, 0 },
            { 0, 0, 0, 0 }
        };

        var expected = new[,]
        {
            {false, false, true, true},
            {false, false, true, true},
        };
        
        var result = Act(img1, img2);

        AssertDiffMap(result, expected);
    }
    
    [Fact]
    public void When_SecondImageHigher_Should_ReturnEquivalentDiffMap()
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
            { 0, 0 },
            { 0, 0 }
        };
        
        var expected = new[,]
        {
            {false, false},
            {false, false},
            {true, true},
            {true, true}
        };
        
        var result = Act(img1, img2);

        AssertDiffMap(result, expected);

    }
    
    [Fact]
    public void When_SecondImageBigger_Should_ReturnEquivalentDiffMap()
    {
        var img1 = new byte[,]
        {
            { 0, 0 },
            { 0, 0 }
        };
        var img2 = new byte[,]
        {
            { 0, 0, 0, 0},
            { 0, 0, 0, 0},
            { 0, 0, 0, 0},
            { 0, 0, 0, 0}
        };
        
        var expected = new[,]
        {
            {false, false, true, true},
            {false, false, true, true},
            {true, true, true, true},
            {true, true, true, true},
        };

        
        var result = Act(img1, img2);

        AssertDiffMap(result, expected);
    }
    
    [Fact]
    public void When_SingleCentre1x1Diff_Should_ReturnEquivalentDiffMap()
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

        var expected = new[,]
        {
            {false, false, false},
            {false, true, false},
            {false, false, false}
        };
        
        
        var result = Act(img1, img2);

        AssertDiffMap(result, expected);
    }
    
    [Fact]
    public void When_Single1x2Diff_Should_ReturnEquivalentDiffMap()
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
        
        var expected = new[,]
        {
            {false, false, false},
            {false, true, true},
            {false, false, false}
        };
        
        var result = Act(img1, img2);

        AssertDiffMap(result, expected);
    }
    
    [Fact]
    public void When_Single2x2Diff_Should_ReturnEquivalentDiffMap()
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
        
        var expected = new[,]
        {
            {false, false, false},
            {false, true, true},
            {false, true, true}
        };
        
        var result = Act(img1, img2);

        AssertDiffMap(result, expected);
    }
    
    [Fact]
    public void When_Two1x1Diff_Should_ReturnEquivalentDiffMap()
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
        var expected = new[,]
        {
            {true, false, false},
            {false, false, false},
            {false, false, true}
        };
        
        var result = Act(img1, img2);

        AssertDiffMap(result, expected);
    }
    
    [Fact]
    public void When_Two1x2Diff_Should_ReturnEquivalentDiffMap()
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
        
        var expected = new[,]
        {
            {true, true, false},
            {false, false, false},
            {false, true, true}
        };
        
        var result = Act(img1, img2);

        AssertDiffMap(result, expected);
    }
    
    [Fact]
    public void When_SingleComplexDiff_Should_ReturnEquivalentDiffMap()
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
            { 0, 1, 0 },
            { 0, 1, 1 }
        };
        
        var expected = new[,]
        {
            {true, true, false},
            {false, true, false},
            {false, true, true}
        };
        
        var result = Act(img1, img2);

        AssertDiffMap(result, expected);
    }
    
}