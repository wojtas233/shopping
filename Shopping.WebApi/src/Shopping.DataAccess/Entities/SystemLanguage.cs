using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.DataAccess.Entities
{
    public class SystemLanguage : BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public virtual ICollection<SystemTranslation> SystemTranslation { get; set; }
    }
}
