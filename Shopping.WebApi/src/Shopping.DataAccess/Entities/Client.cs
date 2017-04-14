using System;

namespace Shopping.DataAccess.Entities
{
    public class Client : BaseEntity
    {
        public string Name
        {
            get;
            set;
        }

        public DateTime Date
        {
            get;
            set;
        }
    }
}
