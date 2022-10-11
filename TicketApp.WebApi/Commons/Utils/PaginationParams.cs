namespace TicketApp.WebApi.Commons.Utils
{
    public class PaginationParams
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }

        public int SkipCount() 
            => (PageIndex - 1) * PageSize;
    }
}
