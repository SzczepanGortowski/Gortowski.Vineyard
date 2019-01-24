using Gortowski.Vineyard.Interfaces.Entities;
using Gortowski.Vineyard.Interfaces.Searches;
using System.Collections.ObjectModel;

namespace Gortowski.Vineyard.Interfaces.Services
{
    public interface IRegionService
    {
        void Save(IRegion region);
        void Delete(int id);
        ObservableCollection<IRegion> GetRegions(bool showAllOptions = false);
    }
}