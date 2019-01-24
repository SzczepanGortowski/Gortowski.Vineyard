using System;
using System.Collections.Generic;
using System.Text;
using Gortowski.Vineyard.Interfaces.Entities;

namespace Gortowski.Vineyard.Interfaces.DAO
{

    public interface IDataContext

    {
        IList<IVine> Vines { get; }
        IList<IRegion> Regions { get; }
        void SaveChanges();
        IList<T> GetContext<T>();
        void AddEntity(IEntity entity);
        void DeleteEntity(IEntity entity);
        void UpdateEntity(IEntity entity);

    }
}
