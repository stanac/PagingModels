using FluentAssertions;

namespace PagingModels.Tests;

public class PagedCollectionTests
{
    private readonly IEnumerable<int> _dataSource = Enumerable.Range(1, 101);

    [Fact]
    public void ZeroItems_SetsPropertiesToZero()
    {
        PageRequest request = new PageRequest(1, 10);

        PagedCollection<int> c = new(new List<int>(), request, 0);

        c.IsFirstPage.Should().BeTrue();
        c.IsLastPage.Should().BeTrue();

        c.Items.Count.Should().Be(0);
        c.Count().Should().Be(0);

        c.ItemsFrom.Should().Be(0);
        c.ItemsTo.Should().Be(0);

        c.PageNumber.Should().Be(1);
        c.PageSize.Should().Be(10);
    }

    [Fact]
    public void FirstPage_SetsPropertiesCorrectly()
    {
        PageRequest request = new PageRequest(1, 10);

        PagedCollection<int> c = new(GetPage(request), request, _dataSource.Count());

        c.IsFirstPage.Should().BeTrue();
        c.IsLastPage.Should().BeFalse();

        c.Items.Count.Should().Be(10);
        c.Count().Should().Be(10);

        c.ItemsFrom.Should().Be(1);
        c.ItemsTo.Should().Be(10);

        c.PageNumber.Should().Be(1);
        c.PageSize.Should().Be(10);
    }

    [Fact]
    public void SecondPage_SetsPropertiesCorrectly()
    {
        PageRequest request = new PageRequest(2, 10);

        PagedCollection<int> c = new(GetPage(request), request, _dataSource.Count());

        c.IsFirstPage.Should().BeFalse();
        c.IsLastPage.Should().BeFalse();

        c.Items.Count.Should().Be(10);
        c.Count().Should().Be(10);

        c.ItemsFrom.Should().Be(11);
        c.ItemsTo.Should().Be(20);

        c.PageNumber.Should().Be(2);
        c.PageSize.Should().Be(10);
    }

    [Fact]
    public void LastPage_SetsPropertiesCorrectly()
    {
        PageRequest request = new PageRequest(11, 10);

        PagedCollection<int> c = new(GetPage(request), request, _dataSource.Count());

        c.IsFirstPage.Should().BeFalse();
        c.IsLastPage.Should().BeTrue();

        c.Items.Count.Should().Be(1);
        c.Count().Should().Be(1);

        c.ItemsFrom.Should().Be(101);
        c.ItemsTo.Should().Be(101);

        c.PageNumber.Should().Be(11);
        c.PageSize.Should().Be(10);
    }

    private List<int> GetPage(PageRequest request)
    {
        return _dataSource.Skip(request.GetSkipCount()).Take(request.PageSize).ToList();
    }
}