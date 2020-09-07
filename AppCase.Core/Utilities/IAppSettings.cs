using System;
using System.Collections.Generic;
using System.Text;

namespace AppCase.Core.Utilities
{
    public interface IAppSettings
    {
        public string Secret { get; set; }
        public string CurrentCulture { get; set; }
    }
}
