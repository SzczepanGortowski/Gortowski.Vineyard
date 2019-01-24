using System;
using System.Collections.Generic;
using System.Text;

namespace Gortowski.Vineyard.Interfaces.Entities
{
    public interface IRegion : IEntity
    {
        string Country { get; set; }
    }
}
