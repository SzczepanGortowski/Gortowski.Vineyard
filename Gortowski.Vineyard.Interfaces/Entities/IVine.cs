using Gortowski.Vineyard.Core.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gortowski.Vineyard.Interfaces.Entities
{
    public interface IVine : IEntity
    {
        GrapeType GrapeType { get; set; }

        VineType VineType { get; set; }

        IRegion Region { get; set; }

    }
}
