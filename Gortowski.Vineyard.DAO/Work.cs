using System;
using Gortowski.Vineyard.Interfaces.DAO;
using Gortowski.Vineyard.Interfaces.Entities;
using System.Collections.Generic;

namespace Gortowski.Vineyard.DAO

{

    internal class Work : IWork

    {
        private IDataContext _db;
        public Work(IDataContext db)

        {

            _db = db;
        }
        private Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

        public IRepository<T> Repository<T>() where T : class, IEntity

        {

            if (_repositories.ContainsKey(typeof(T)))

            {

                return _repositories[typeof(T)] as IRepository<T>;

            }



            var repo = new Repository<T>(_db);

            _repositories.Add(typeof(T), repo);

            return repo;

        }

        public void SaveChanges()

        {

            _db.SaveChanges();

        }



    }

}
