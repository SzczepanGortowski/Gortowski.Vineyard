using System;
using System.Collections.Generic;
using System.Text;

namespace Gortowski.Vineyard.Interfaces.Entities
{
    public interface IEntity

    {
        int Id { get; set; }
        string Name { get; set; }
    }
}

