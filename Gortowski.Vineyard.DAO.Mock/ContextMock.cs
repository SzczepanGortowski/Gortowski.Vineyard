using Gortowski.Vineyard.DAO.DAL;
using Gortowski.Vineyard.DAO.Entities;
using Gortowski.Vineyard.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Gortowski.Vineyard.Core.Enum;


namespace Gortowski.Vineyard.DAO.Mock

{
    public class MockContext : Context
    {
        public override void AddEntity(IEntity entity) { }
        public override void DeleteEntity(IEntity entity) { }
        public override IList<T> GetContext<T>()
        {
            if (typeof(T) == typeof(IRegion))
            {
                return (IList<T>)Regions;
            }
            else if (typeof(T) == typeof(IVine))
            {
                return (IList<T>)Vines;
            }
            else
            {
                throw new Exception("Context ERROR");
            }
        }
        public override void SaveChanges()
        {
            foreach (var region in Regions)
            {
                if (region.Id == 0)
                {
                    region.Id = Regions.Max(x => x.Id) + 1;
                }
            }
            foreach (var vine in Vines)
            {
                if (vine.Id == 0)
                {
                    vine.Id = Vines.Max(x => x.Id) + 1;
                }
            }
        }
        public override void UpdateEntity(IEntity entity) { }
        protected override void LoadContext()

        {
            var regions = new List<Region>
            {
                new Region
                {
                    Id=1,
                    Name="Andaluzja",
                    Country = "Polska"
                },

                new Region
                {
                    Id=2,
                    Name="Bordeaux",
                    Country = "Polska"
                },

                new Region
                {
                    Id=3,
                    Name="Szampania",
                    Country = "Polska"
                },

                new Region
                {
                    Id=4,
                    Name="Canterbury",
                    Country = "Polska"
                },

                new Region
                {
                    Id=5,
                    Name="Nowa Południowa Walia",
                    Country = "Polska"
                }
            };

            var vines = new List<Vine>

            {
                new Vine
                {
                    Id=1,
                    Name="Greas",
                    GrapeType = GrapeType.Ciemnoniebieskie,
                    VineType = VineType.Słodkie,
                    Region = regions[0]
                },

                new Vine

                {
                    Id=2,
                    Name="Cin Cin",
                    GrapeType = GrapeType.Czarny,
                    VineType = VineType.Wytrawne,
                    Region = regions[1]

                }
            };


            Vines = vines.Cast<IVine>().ToList();
            Regions = regions.Cast<IRegion>().ToList();
        }
    }
}