
namespace codechemist.Data.RequestHelpers
{
    public class PaginationParams
    {
        public const int MaxPagaSize = 50;
        public int PageNumber { get; set; } = 1;
        public int _pageSize = 30;


        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > MaxPagaSize ? MaxPagaSize : value;


        }



    }
}
