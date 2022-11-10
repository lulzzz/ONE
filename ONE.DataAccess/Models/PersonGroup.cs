using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class PersonGroup
    {
        public PersonGroup()
        {
            People = new HashSet<Person>();
            PersonGroupFahrenheits = new HashSet<PersonGroupFahrenheit>();
            TemperatureTerminalPersonBatchDetails = new HashSet<TemperatureTerminalPersonBatchDetail>();
        }

        public Guid PersonGroupGuid { get; set; }
        public string Name { get; set; }
        public Guid? ParentPersonGroupGuid { get; set; }
        public Guid CustomerLocationGuid { get; set; }
        public bool IsActive { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual CustomerLocation CustomerLocationGu { get; set; }
        public virtual ICollection<Person> People { get; set; }
        public virtual ICollection<PersonGroupFahrenheit> PersonGroupFahrenheits { get; set; }
        public virtual ICollection<TemperatureTerminalPersonBatchDetail> TemperatureTerminalPersonBatchDetails { get; set; }
    }
}
