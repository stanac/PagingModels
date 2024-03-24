using FluentAssertions;

namespace PagingModels.Tests;

public class PageCountInfoTests
{
    [Fact]
    public void Ctor_SetsPropertiesCorrectly()
    {
        PageCountInfo info = new(10, 101);

        info.TotalItemsCount.Should().Be(101);
        info.PageSize.Should().Be(10);
        info.PageCount.Should().Be(11);
    }
}