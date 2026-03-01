namespace Application.JOB.Modals.Common;

public class PaginatedResult<T> : Result<List<T>>
{
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int TotalCount { get; set; }
    public int PageSize { get; set; }
    public bool HasPreviousPage => CurrentPage > 1;
    public bool HasNextPage => CurrentPage < TotalPages;

    public PaginatedResult()
    {
    }

    public PaginatedResult(List<T> data)
    {
        Data = data;
    }

    public static PaginatedResult<T> PaginatedData(List<T> data, int count, int page, int pageSize)
    {
        return new PaginatedResult<T>
        {
            Succeded = true,
            Data = data,
            TotalCount = count,
            CurrentPage = page,
            PageSize = pageSize,
            TotalPages = (int)Math.Ceiling(count / (double)pageSize)
        };
    } 
}
