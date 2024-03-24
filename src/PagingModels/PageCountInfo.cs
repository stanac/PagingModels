using System.Diagnostics.CodeAnalysis;

namespace PagingModels;

/// <summary>
/// Page info, contains page size, page count and items count
/// </summary>
public class PageCountInfo
{
    /// <summary>
    /// Default constructor
    /// </summary>
    public PageCountInfo()
    {
    }

    /// <summary>
    /// Constructor which sets all properties
    /// </summary>
    /// <param name="pageSize">Page size</param>
    /// <param name="totalTotalItemsCount">Total number of items in DB or other data source</param>
    [SetsRequiredMembers]
    public PageCountInfo(int pageSize, long totalTotalItemsCount)
    {
        PageDefaults.GuardPageSize(pageSize);

        PageSize = pageSize;
        TotalItemsCount = totalTotalItemsCount;
        PageCount = (int)Math.Ceiling((double)totalTotalItemsCount / pageSize);
    }

    /// <summary>
    /// Page size
    /// </summary>
    public required int PageSize { get; set; }

    /// <summary>
    /// Number of pages, depends on <see cref="PageSize"/>
    /// </summary>
    public required int PageCount { get; set; }
    
    /// <summary>
    /// Total items count in DB or other source
    /// </summary>
    public required long TotalItemsCount { get; set; }
}