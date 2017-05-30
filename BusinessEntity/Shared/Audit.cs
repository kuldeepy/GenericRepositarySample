using System;

namespace BusinessEntities.Shared
{
    public class Audit
    {
        public DateTime Created { get; set; }

        public DateTime? Modified { get; set; }

        public int CreatedBy { get; set; }

        public int ModifiedBy { get; set; }
    }
}
