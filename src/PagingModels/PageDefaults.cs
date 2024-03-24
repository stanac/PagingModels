namespace PagingModels;

internal static class PageDefaults
{
    public const int MinPageSize = 10;
    public const int MaxPageSize = 1000;

    public static void GuardPageSize(int pageSize)
    {
        if (pageSize < MinPageSize) throw new ArgumentOutOfRangeException(nameof(pageSize), $"Value cannot be less than {MinPageSize}");
        if (pageSize > MaxPageSize) throw new ArgumentOutOfRangeException(nameof(pageSize), $"Value cannot be less than {MaxPageSize}");
    }
}