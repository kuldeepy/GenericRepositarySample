using BusinessEntities.Shared;
using System;

namespace BusinessEntities.Response
{
    public class Insurance
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int CompanyId { get; set; }

        public int ImportId { get; set; }

        public string SalesAgent { get; set; }

        public string Program { get; set; }

        public string Policy { get; set; }

        public string Currency { get; set; }

        public bool IsCanceled { get; set; }

        public string DestinationCountry { get; set; }

        public string Destination { get; set; }

        public string SubPolicy { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime? PurchaseDate { get; set; }

        public decimal Price { get; set; }

        public string Status { get; set; }

        public string TransportMode { get; set; }

        public string SalesCountry { get; set; }

        public Audit Audit { get; set; }
    }
}
