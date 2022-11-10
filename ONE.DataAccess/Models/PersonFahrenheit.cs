using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class PersonFahrenheit
    {
        public Guid PersonFahrenheitGuid { get; set; }
        public Guid PersonGuid { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid? PossbileDuplicationPersonGuid { get; set; }

        public virtual Person PersonGu { get; set; }
    }
}
