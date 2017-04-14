using Shopping.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.DataAccess.Repositories.Interfaces
{
    public interface ISystemParameterRepository
    {
        T GetValue<T>(string code);
        SaveResult AddValue<T>(string code, T value, string description, DateTime? validFrom, DateTime? validTo, bool isActive = true);
    }
}
