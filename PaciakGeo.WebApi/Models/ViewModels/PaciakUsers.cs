using System.Collections.Generic;

namespace PaciakGeo.WebApi.Models.ViewModels
{
    public class PaciakUsers
    {
        public IEnumerable<PaciakUser> Users { get; set; }
        public PaciakPagination Pagination { get; set; }
        public int UserCount { get; set; }
    }
}