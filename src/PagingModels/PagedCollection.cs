using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace PagingModels;

/// <summary>
/// Paged collection with related properties
/// </summary>
/// <typeparam name="T">Collection type</typeparam>
public class PagedCollection<T> : PageCountInfo, IEnumerable<T>
{
    /// <summary>
    /// Page number
    /// </summary>
    public required int PageNumber { get; set; }

    /// <summary>
    /// Items in the page
    /// </summary>
    public required IReadOnlyList<T> Items { get; set; }

    /// <summary>
    /// Is this page first page
    /// </summary>
    public bool IsFirstPage => PageNumber <= 1;

    /// <summary>
    /// Is this page last page
    /// </summary>
    public bool IsLastPage => PageNumber == PageCount || TotalItemsCount == 0;

    /// <summary>
    /// First item number in the collection (1-indexed)
    /// </summary>
    public long ItemsFrom
    {
        get
        {
            if (TotalItemsCount == 0) return 0;

            return (PageNumber - 1) * PageSize + 1;
        }
    }

    /// <summary>
    /// Last item number in the collection (1-indexed)
    /// </summary>
    public long ItemsTo
    {
        get
        {
            if (TotalItemsCount == 0) return 0;

            return ItemsFrom + Items.Count - 1;
        }
    }

    /// <summary>
    /// Default constructor
    /// </summary>
    public PagedCollection()
    {
    }
    
    /// <summary>
    /// Constructor that sets all required properties
    /// </summary>
    /// <param name="items"></param>
    /// <param name="request"></param>
    /// <param name="totalTotalItemsCount"></param>
    [SetsRequiredMembers]
    public PagedCollection(IReadOnlyList<T> items, PageRequest request, long totalTotalItemsCount)
        : base(request.PageSize, totalTotalItemsCount)
    {
        PageNumber = request.PageNumber;
        PageSize = request.PageSize;

        PageCount = (int)Math.Ceiling((double)totalTotalItemsCount / PageSize);
        TotalItemsCount = totalTotalItemsCount;

        Items = items;
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach (T item in Items)
        {
            yield return item;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}