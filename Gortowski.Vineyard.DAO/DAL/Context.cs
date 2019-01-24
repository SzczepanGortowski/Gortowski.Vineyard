using System;
using System.Collections.Generic;
using Gortowski.Vineyard.Interfaces.DAO;
using Gortowski.Vineyard.Interfaces.Entities;

namespace Gortowski.Vineyard.DAO.DAL
{
    public abstract class Context : IDataContext
    {
        private IList<IRegion> _regions;
        private IList<IVine> _vines;
        private bool _isLoaded;
        protected Context()
        {
            _isLoaded = false;
        }

        public IList<IRegion> Regions
        {
            get
            {
                Load();
                return _regions;
            }
            set
            {
                _regions = value;
            }
        }



        public IList<IVine> Vines
        {
            get
            {
                Load();
                return _vines;
            }
            set
            {
                _vines = value;
            }
        }



        protected abstract void LoadContext();
        public abstract void SaveChanges();
        public abstract IList<T> GetContext<T>();
        private void Load()
        {
            if (!_isLoaded)
            {
                LoadContext();
                _isLoaded = true;
            }
        }
        public abstract void AddEntity(IEntity entity);
        public abstract void DeleteEntity(IEntity entity);
        public abstract void UpdateEntity(IEntity entity);

    }

}