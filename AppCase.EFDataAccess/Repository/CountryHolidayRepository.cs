using AppCase.Core.Entities;
using AppCase.Core.Repository;

using System;
using System.Collections.Generic;
using System.Text;

namespace AppCase.EFDataAccess.Repository
{
    public class CountryHolidayRepository : EFRepositoryBase<CountryHoliday, Guid>, ICountryHolidayRepository
    {
        public CountryHolidayRepository(EFDatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
