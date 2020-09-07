using AppCase.Core.Entities;

using System;
using System.Collections.Generic;
using System.Text;

namespace AppCase.Core.Repository
{
    public interface ICountryRepository : IRepository<Country, Guid>
    {
    }
}
