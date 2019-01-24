using Gortowski.Vineyard.Interfaces.Entities;

namespace Gortowski.Vineyard.Interfaces
{
    public interface IViewModel
    {
        void Initialize(IEntity entity, string guid);
    }
}
