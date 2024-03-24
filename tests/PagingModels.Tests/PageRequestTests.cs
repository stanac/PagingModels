using FluentAssertions;

namespace PagingModels.Tests;

public class PageRequestTests
{
    [Fact]
    public void SetPageNumberLessThanMin_SetsPageNumberToOne()
    {
        PageRequest request1 = new()
        {
            PageNumber = 0,
            PageSize = 10
        };

        request1.PageNumber.Should().Be(1);

        PageRequest request2 = new()
        {
            PageNumber = -1,
            PageSize = 10
        };

        request2.PageNumber.Should().Be(1);
    }

    [Fact]
    public void SetPageSizeLessThanMin_SetsPageSizeToMin()
    {
        PageRequest request1 = new()
        {
            PageNumber = 1,
            PageSize = PageDefaults.MinPageSize - 1
        };

        request1.PageSize.Should().Be(PageDefaults.MinPageSize);
    }

    [Fact]
    public void SetPageSizeGreaterThanMax_SetsPageSizeToMax()
    {
        PageRequest request1 = new()
        {
            PageNumber = 1,
            PageSize = PageDefaults.MaxPageSize + 1
        };

        request1.PageSize.Should().Be(PageDefaults.MaxPageSize);
    }

    [Fact]
    public void SetValuesInRange_SetsValuesInRange()
    {
        int pageNumber = 2;
        int pageSize = PageDefaults.MaxPageSize / 2;

        PageRequest request1 = new()
        {
            PageNumber = pageNumber,
            PageSize = pageSize
        };

        request1.PageNumber.Should().Be(pageNumber);
        request1.PageSize.Should().Be(pageSize);
    }

    [Fact]
    public void GetSkipValue_ReturnsExpectedValue()
    {
        PageRequest request1 = new()
        {
            PageNumber = 1,
            PageSize = 10
        };

        request1.GetSkipCount().Should().Be(0);

        request1.PageNumber = 2;

        request1.GetSkipCount().Should().Be(10);

        request1.PageNumber = 3;

        request1.GetSkipCount().Should().Be(20);
    }
}