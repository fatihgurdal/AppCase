using AppCase.Core.Entities;
using AppCase.Core.Repository;

using System;
using System.Collections.Generic;
using System.Text;

namespace AppCase.EFDataAccess.Repository
{
    public class CountryRepository : EFRepositoryBase<Country, Guid>, ICountryRepository
    {
        public CountryRepository(EFDatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
