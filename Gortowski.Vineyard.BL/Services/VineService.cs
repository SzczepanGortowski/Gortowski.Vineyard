using Gortowski.Vineyard.BL.Models;
using Gortowski.Vineyard.Core.Enum;
using Gortowski.Vineyard.Interfaces.DAO;
using Gortowski.Vineyard.Interfaces.Entities;
using Gortowski.Vineyard.Interfaces.Searches;
using Gortowski.Vineyard.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Gortowski.Vineyard.BL.Services
{

    public class VineService : IVineService
    {
        private IWork _uow;

        public IEnumerable<GrapeType> GrapeTypes(bool showAllOptions = false) => Enum.GetValues(typeof(GrapeType)).Cast<GrapeType>().Where(x => x != GrapeType.All || showAllOptions);

        public IEnumerable<VineType> VineTypes(bool showAllOptions = false) => Enum.GetValues(typeof(VineType)).Cast<VineType>().Where(x => x != VineType.All || showAllOptions);

        public VineService(IWork uow)
        {
            _uow = uow;
        }

        public void Delete(int id)
        {
            _uow.Repository<IVine>().Delete(id);
            _uow.SaveChanges();
        }

        public IVine Map(IVine vine, int newGrapeId, VineType newVineType) =>
        new Vine
        {
            Id = vine.Id,
            Name = vine.Name,
        };

        public ObservableCollection<IVine> GetVines() => new ObservableCollection<IVine>(_uow.Repository<IVine>().GetList());

        public void Save(IVine vine)
        {
            if (vine.Id == 0)
            {
                _uow.Repository<IVine>().Insert(vine);
            }

            else
            {
                _uow.Repository<IVine>().Update(vine);
            }
            _uow.SaveChanges();
        }

        public ObservableCollection<IVine> Filter(ISearchVine searchVine)
        {
            return new ObservableCollection<IVine>(
              _uow.Repository<IVine>()
              .GetList
                  (
                    x =>
                    (searchVine.GrapeType == GrapeType.All || x.GrapeType == searchVine.GrapeType)
                    && (searchVine.VineType == VineType.All || x.VineType == searchVine.VineType)
                    && (searchVine.NameVine == null || x.Name.StartsWith(searchVine.NameVine) || searchVine.NameVine.Length == 0)
                    && ( x.Region.Id == searchVine.IdRegion || searchVine.IdRegion == 0)
                  )
              );
        }
    }
}
