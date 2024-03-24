// ReSharper disable InconsistentNaming

using System.Diagnostics.CodeAnalysis;

namespace PagingModels;

/// <summary>
/// Page request
/// </summary>
public class PageRequest
{
    private int _pageNumber;
    private int _pageSize;

    public PageRequest()
    {
    }

    [SetsRequiredMembers]
    public PageRequest(int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }

    /// <summary>
    /// Page Number, 1-indexed, min value is 1
    /// </summary>
    public required int PageNumber
    {
        get => _pageNumber;
        set
        {
            if (value < 1)
            {
                value = 1;
            }

            _pageNumber = value;
        }
    }

    /// <summary>
    /// Page Size, by default value must be greater than or equal to 10 and less than or equal to 1000
    /// </summary>
    public required int PageSize
    {
        get => _pageSize;
        set
        {
            if (value < PageDefaults.MinPageSize)
            {
                value = PageDefaults.MinPageSize;
            }

            if (value > PageDefaults.MaxPageSize)
            {
                value = PageDefaults.MaxPageSize;
            }

            _pageSize = value;
        }
    }

    /// <summary>
    /// Return number of items to skip for data source when fetching this page number
    /// </summary>
    public int GetSkipCount()
    {
        return (_pageNumber -1) * _pageSize;
    }
}
