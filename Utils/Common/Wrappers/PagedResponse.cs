namespace Common.Wrappers
{
    public class PagedResponse<T>
    {
        public T Data { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPage { get; set; }
        public int TotalRecords { get; set; }
    }
}