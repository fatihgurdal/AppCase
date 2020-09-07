using AppCase.Core.Entities.Abstract;

using System;
using System.Collections.Generic;
using System.Text;

namespace AppCase.Core.Entities
{
    public class Country : GuidEntity
    {
        public string Name { get; set; }
        public string Culture { get; set; }
        public string Weekends { get; set; }
    }
}
