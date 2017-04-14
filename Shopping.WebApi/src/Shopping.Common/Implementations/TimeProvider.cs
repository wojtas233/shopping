using System;
using Shopping.Common.Interfaces;

namespace Shopping.Common.Implementations
{
    public class TimeProvider : ITimeProvider
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }
    }
}
