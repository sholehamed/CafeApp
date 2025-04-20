namespace CafeApp.Business.Helpers.Common
{
    public class PagingParameter
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 25;
        public PagingParameter()
        {

        }

        public PagingParameter(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }

        public override string ToString()
        {
            return string.Format("&{0}={1}&{2}={3}", nameof(Page), Page, nameof(PageSize), PageSize);
        }
    }
}
