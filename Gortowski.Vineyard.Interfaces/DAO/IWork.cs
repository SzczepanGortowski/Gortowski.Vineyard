using Gortowski.Vineyard.Interfaces.Entities;



namespace Gortowski.Vineyard.Interfaces.DAO

{

    public interface IWork

    {

        IRepository<T> Repository<T>() where T : class, IEntity;

        void SaveChanges();

    }

}