using System;
using System.Collections.Generic;
using System.Text;
using Gortowski.Vineyard.Interfaces.Entities;
using Gortowski.Vineyard.Core.Enum;

namespace Gortowski.Vineyard.DAO.Entities
{
    public class Region : IRegion
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
    }
}
