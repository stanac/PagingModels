# PagingModels 

1-Indexed Data Paging Models

Install from [nuget](https://www.nuget.org/packages/PagingModels):

```
dotnet add package PagingModels
```

---

## Classes

```csharp
// Request for paged data
public class PageRequest
{
    // constructors
    public PageRequest()
    public PageRequest(int pageNumber, int pageSize)

    // properties
    public required int PageNumber { get; set; } // >= 1
    public required int PageSize { get; set; }   // >= 10 and <= 1000

    // methods
    public int GetSkipCount(); // returns skip for paging on data source
}
```

```csharp
// Paging info without actual page
public class PageCountInfo
{
    // constructors
    public PageCountInfo()
    public PageCountInfo(int pageSize, long totalTotalItemsCount)

    // properties
    public required int PageSize { get; set; }
    public required int PageCount { get; set; }
    public required long TotalItemsCount { get; set; }
}
```

```csharp
// Paged collection with related properties
public class PagedCollection<T> : IEnumerable<T>
{
    // constructors
    public PagedCollection()
    public PagedCollection(IReadOnlyList<T> items, PageRequest request, long totalTotalItemsCount)

    // properties
    public required int PageSize { get; set; }
    public required int PageCount { get; set; }
    public required long TotalItemsCount { get; set; }
    public required int PageNumber { get; set; }
    public required IReadOnlyList<T> Items { get; set; }
    public bool IsFirstPage { get; }
    public bool IsLastPage { get; }
    public long ItemsFrom { get; }
    public long ItemsTo { get; }

    // methods
    IEnumerator<T> GetEnumerator()
    IEnumerator IEnumerable.GetEnumerator()
}
```