using BusinessEntities.Shared;
using System;

namespace BusinessEntities.Search
{
    /// <summary>
    /// This class is used for the search parameters for customer search.
    /// </summary>
    public class SearchCriteria
    {
        /// <summary>
        /// EfSalesRefId search parameter
        /// </summary>
        public string EFSalesRefCode { get; set; }

        /// <summary> 
        /// LastName search parameter
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// FirstName search parameter
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// StartDate search parameter
        /// </summary>
        public DatePart StartDate { get; set; }

        /// <summary>
        /// EndDate search parameter
        /// </summary>
        public DatePart EndDate { get; set; }

        /// <summary>
        /// Date of birth search parameter
        /// </summary>
        public DatePart DOB { get; set; }

        /// <summary>
        /// Sales country search parameter
        /// </summary>
        public string SalesCountry { get; set; }

        /// <summary>
        /// Program search parameter
        /// </summary>
        public string Program { get; set; }

        /// <summary>
        /// Destination Country search parameter
        /// </summary>
        public string DestinationCountry { get; set; }

        /// <summary>
        /// Policy search parameter
        /// </summary>
        public string Policy { get; set; }

        /// <summary>
        /// AetnaId search parameter
        /// </summary>
        public string AetnaId { get; set; }

    }
}
