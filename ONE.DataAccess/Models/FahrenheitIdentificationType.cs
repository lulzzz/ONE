using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class FahrenheitIdentificationType
    {
        public FahrenheitIdentificationType()
        {
            PersonGroupFahrenheits = new HashSet<PersonGroupFahrenheit>();
        }

        public int FahrenheitIdentificationTypeCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string EnumName { get; set; }

        public virtual ICollection<PersonGroupFahrenheit> PersonGroupFahrenheits { get; set; }
    }
}
