namespace codechemist.Data.RequestHelpers
{
    public class ContentParams : PaginationParams
    {
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public string Gengre { get; set; }

    }
}
