using BusinessEntities.Response;
using System.Collections.Generic;

namespace BusinessEntities.Search
{
    public class SearchResponse
    {
        public List<Customer> Customers { get; set; }

        public bool HasMoreThan100 { get; set; }

        public string Message { get; set; }
    }
}
