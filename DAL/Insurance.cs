//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Insurance
    {
        public int InsuranceID { get; set; }
        public int CustomerID { get; set; }
        public Nullable<int> InsuranceCompanyID { get; set; }
        public Nullable<int> ImportID { get; set; }
        public string SalesAgentCode { get; set; }
        public string ProgramCode { get; set; }
        public string ErikaPolicyCode { get; set; }
        public string CurrencyCode { get; set; }
        public bool IsCAX { get; set; }
        public string DestinationCountryCode { get; set; }
        public string ErikaSubPolicyCodes { get; set; }
        public string Destination { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> ExpireDate { get; set; }
        public Nullable<System.DateTime> PurchaseDate { get; set; }
        public Nullable<decimal> PricePaid { get; set; }
        public string SalesStatus { get; set; }
        public System.DateTime InsertDate { get; set; }
        public int InsertBy { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<int> UpdateBy { get; set; }
        public string TransportModeCode { get; set; }
    
        public virtual Customer Customer { get; set; }
    }
}
