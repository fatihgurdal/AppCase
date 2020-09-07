using System;
using System.Collections.Generic;
using System.Text;

namespace AppCase.Core.Entities.Abstract
{
    public abstract class GuidEntity: UniqueEntity<Guid>
    {
        public Guid Id { get; set; }
    }
}
