namespace PaciakGeo.WebApi.Models.ViewModels
{
    public class PaciakPagination
    {
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public PaciakPaginationPage Prev { get; set; }
        public PaciakPaginationPage Next { get; set; }
        public PaciakPaginationPage First { get; set; }
        public PaciakPaginationPage Last { get; set; }
    }
}