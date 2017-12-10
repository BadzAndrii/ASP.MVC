using System.Collections.Generic;

namespace Lab2Server.Models
{
    public class PaginationModel<TModel>
    {
        public int Total { get; set; }
        public int Current { get; set; }

        public IEnumerable<TModel> PageItems { get; set; }
    }
}