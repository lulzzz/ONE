using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class ProductTypeInitiatorTypeProvisionInterpreter
    {
        public int InitiatorTypeCode { get; set; }
        public int ProductTypeIdentifier { get; set; }
        public string ProvisioningInterpreter { get; set; }

        public virtual InitiatorType InitiatorTypeCodeNavigation { get; set; }
    }
}
