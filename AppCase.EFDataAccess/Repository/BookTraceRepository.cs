using AppCase.Core.Entities;
using AppCase.Core.Repository;

using System;
using System.Collections.Generic;
using System.Text;

namespace AppCase.EFDataAccess.Repository
{
    public class BookTraceRepository : EFRepositoryBase<BookTrace, Guid>, IBookTraceRepository
    {
        public BookTraceRepository(EFDatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
