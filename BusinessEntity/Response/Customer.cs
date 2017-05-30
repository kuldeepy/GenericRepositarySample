using BusinessEntities.Shared;
using System;
using System.Collections.Generic;

namespace BusinessEntities.Response
{
    public class Customer
    {
        public int  Id { get; set; }

        public string EFSalesRefCode { get; set; }

        public string SalesRefNumber { get; set; }

        public Name Name { get; set; }

        public Contact Contact { get; set; }

        public Address Address { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime DOB { get; set; }

        public string Gender { get; set; }

        public string Notes { get; set; }

        public string NotesExt { get; set; }

        public bool Reported { get; set; }

        public string AetnaId { get; set; }

        public string RelatedAetnaId { get; set; }

        public Audit Audit { get; set; }

        public List<Insurance> Insurances { get; set; }
    }
}
