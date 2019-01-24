using System;
using System.Collections.Generic;
using System.Text;
using Gortowski.Vineyard.Core.Enum;
using Gortowski.Vineyard.Interfaces.Entities;

namespace Gortowski.Vineyard.DAO.Entities
{
    public class Vine : IVine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public GrapeType GrapeType { get; set; }
        public VineType VineType { get; set; }
        public IRegion Region { get; set; }
    }
}


