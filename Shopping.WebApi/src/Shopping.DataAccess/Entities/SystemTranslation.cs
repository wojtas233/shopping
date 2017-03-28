using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.DataAccess.Entities
{
    public class SystemTranslation : BaseEntity
    {
        public string Text { get; set; }
        public long SystemLanguageId { get; set; }
        public virtual SystemLanguage SystemLanguage { get; set; }
        public virtual ICollection<SystemParameter> SystemParameter { get; set; }
    }
}
