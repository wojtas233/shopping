using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Common.Interfaces
{
    public interface ITimeProvider
    {
        DateTime Now();
    }
}
