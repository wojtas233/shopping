using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.DataAccess.Entities
{
    public class SystemParameter : BaseEntity
    {
        public string Code { get; set; }

        public long SystemTranslationId { get; set; }
        public virtual SystemTranslation SystemTranslation { get; set; }
        public virtual ICollection<SystemParameterValue> SystemParameterValue { get; set; }

    }
}
