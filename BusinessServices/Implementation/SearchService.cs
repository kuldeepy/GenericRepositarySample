using System;
using BusinessEntities.Search;
using BusinessServices.Interfaces;
using DAL.UnitOfWork;
using System.Linq;
using DAL;
using System.Collections.Generic;
using BusinessEntities.Response;

namespace BusinessServices.Implementation
{
    public class SearchServices : ISearchServices
    {
        #region Private memeber 

        private readonly UnitOfWork _unitOfWork;

        #endregion

        #region Constructor
        public SearchServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion
        public SearchResponse Find(SearchCriteria search)
        {
            var startYear = search.StartDate != null && search.StartDate.Year.HasValue ? search.StartDate.Year.Value.ToString() : null;
            var startMonth = search.StartDate != null && search.StartDate.Month.HasValue ? search.StartDate.Month.Value.ToString() : null;
            var startDay = search.StartDate != null && search.StartDate.Day.HasValue ? search.StartDate.Day.Value.ToString() : null;
            var endYear = search.EndDate != null && search.EndDate.Year.HasValue ? search.EndDate.Year.Value.ToString() : null;
            var endMonth = search.EndDate != null && search.EndDate.Month.HasValue ? search.EndDate.Month.Value.ToString() : null;
            var endDay = search.EndDate != null && search.EndDate.Day.HasValue ? search.EndDate.Day.Value.ToString() : null;
            var dobYear = search.DOB != null && search.DOB.Year.HasValue ? search.DOB.Year.Value.ToString() : null;
            var dobMonth = search.DOB != null && search.DOB.Month.HasValue ? search.DOB.Month.Value.ToString() : null;
            var dobDay = search.DOB != null && search.DOB.Day.HasValue ? search.DOB.Day.Value.ToString() : null;

            var result = _unitOfWork.ExtanetSearch(search.EFSalesRefCode,
                search.LastName,
                search.FirstName,
                startYear,
                startMonth,
                startDay,
                endYear,
                endMonth,
                endDay,
                dobYear,
                dobMonth,
                dobDay,
                search.SalesCountry,
                search.Program,
                search.DestinationCountry,
                search.Policy,
                search.AetnaId);
            SearchResponse response = GetSearchResponse(result);
            return response;
        }

        private SearchResponse GetSearchResponse(List<SearchCustomer_p_Result> result)
        {
            SearchResponse response = new SearchResponse();
            if (result == null)
            {
                response.Message = "No Record found.";
            }
            else if (result.Count > 100)
            {
                response.HasMoreThan100 = true;
                response.Message = "Search result has more than 100 records. Please narrow down your search.";
            }
            else
            {
                response.Customers = new List<BusinessEntities.Response.Customer>();
                var distinctCustomers = result.GroupBy(c => c.CustomerID).Select(g => g.First()).ToList();
                foreach (SearchCustomer_p_Result r in distinctCustomers)
                {
                    response.Customers.Add(new BusinessEntities.Response.Customer
                    {
                        Id = r.CustomerID.HasValue ? r.CustomerID.Value : 0,
                        EFSalesRefCode = r.EFSalesRefCode,
                        Name = new BusinessEntities.Shared.Name { FirstName = r.FirstName, LastName = r.LastName },
                        DOB = r.BirthDate.HasValue ? r.BirthDate.Value : DateTime.Now,
                        Insurances = GetInsurances(r.CustomerID, result),
                        AetnaId = r.AetnaID,
                        RelatedAetnaId = r.RelatedAetnaId
                    });
                }
            }

            return response;
        }

        private List<BusinessEntities.Response.Insurance> GetInsurances(int? customerID, List<SearchCustomer_p_Result> result)
        {
            if (customerID.HasValue)
            {
                var insurancesCustomers = result.Where(c=>c.CustomerID == customerID);
                if (insurancesCustomers != null && insurancesCustomers.Count() > 0)
                {
                    List<BusinessEntities.Response.Insurance> insurances = new List<BusinessEntities.Response.Insurance>();
                    foreach (var c in insurancesCustomers)
                    {
                        insurances.Add(new BusinessEntities.Response.Insurance
                        {
                            Id = c.InsuranceId.HasValue ? c.InsuranceId.Value : 0,
                            Program = c.ProgramCode,
                            Policy = c.ErikaPolicyCode,
                            SubPolicy = c.ErikaSubPolicyCodes,
                            Destination = c.Destination,
                            DestinationCountry = c.DestinationCountryCode,
                            StartDate = c.StartDate.HasValue ? c.StartDate.Value : DateTime.Now,
                            EndDate = c.ExpireDate.HasValue ? c.ExpireDate.Value : DateTime.Now,
                            SalesCountry = c.CountryCode
                        });
                    }

                    return insurances;
                }

            }

            return null;
        }
    }
}
