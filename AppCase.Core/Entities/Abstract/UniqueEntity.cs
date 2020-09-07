using System;
using System.Collections.Generic;
using System.Text;

namespace AppCase.Core.Entities.Abstract
{
    public class UniqueEntity<T> : IDBEntity
    {
        public virtual T Id { get; set; }
    }
}
