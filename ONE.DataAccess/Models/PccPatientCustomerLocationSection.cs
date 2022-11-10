using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class PccPatientCustomerLocationSection
    {
        public Guid PccPatientCustomerLocationSectionGuid { get; set; }
        public Guid CustomerLocationSectionGuid { get; set; }
        public int PccPatientId { get; set; }

        public virtual CustomerLocationSection CustomerLocationSectionGu { get; set; }
    }
}
