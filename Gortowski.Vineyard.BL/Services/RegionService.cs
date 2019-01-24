using Gortowski.Vineyard.BL.Models;
using Gortowski.Vineyard.Interfaces.DAO;
using Gortowski.Vineyard.Interfaces.Entities;
using Gortowski.Vineyard.Interfaces.Searches;
using Gortowski.Vineyard.Interfaces.Services;
using System.Collections.ObjectModel;

namespace Gortowski.Vineyard.BL.Services
{
    public class RegionService : IRegionService
    {
        private IWork _uow;

        public RegionService(IWork uow)
        {
            _uow = uow;
        }

        public void Delete(int id)
        {
            _uow.Repository<IRegion>().Delete(id);
            _uow.SaveChanges();
        }

        public ObservableCollection<IRegion> GetRegions(bool showAllOptions = false)
        {
            var regions = new ObservableCollection<IRegion>(_uow.Repository<IRegion>().GetList());
            if (showAllOptions)
            {
                regions.Add(
                    new Region
                    {
                        Id = 0,
                        Name = "Wszystkie"
                    }
                    );
            }

            return regions;
        }

        public void Save(IRegion region)
        {
            if (region.Id == 0)
            {
                _uow.Repository<IRegion>().Insert(region);
            }
            else
            {
                _uow.Repository<IRegion>().Update(region);
            }
            _uow.SaveChanges();
        }
    }
}