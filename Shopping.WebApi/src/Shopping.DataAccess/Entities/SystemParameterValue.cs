using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.DataAccess.Entities
{
    public class SystemParameterValue :BaseEntity
    {
        public string Value { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public bool IsActive { get; set; }
        public long SystemParameterId { get; set; }
        public virtual SystemParameter SystemParameter { get; set; }
    }
}
