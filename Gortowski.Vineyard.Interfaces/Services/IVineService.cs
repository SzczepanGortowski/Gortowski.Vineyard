using Gortowski.Vineyard.Core.Enum;
using Gortowski.Vineyard.Interfaces.Entities;
using Gortowski.Vineyard.Interfaces.Searches;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Gortowski.Vineyard.Interfaces.Services
{
    public interface IVineService
    {
        void Save(IVine vine);

        void Delete(int id);

        IVine Map(IVine filgrape, int newGrapeId, VineType newGrapeType);

        ObservableCollection<IVine> GetVines();

        ObservableCollection<IVine> Filter(ISearchVine searchesGrape);

        IEnumerable<GrapeType> GrapeTypes(bool showAllOptions);

        IEnumerable<VineType> VineTypes(bool showAllOptions);
    }
}
