using Gortowski.Vineyard.BL;
using Gortowski.Vineyard.DAO;
using Ninject.Modules;

namespace Gortowski.Vineyard.Bootstrap

{
    public static class Modules
    {
        public static INinjectModule[] GetModules() => new INinjectModule[] { new ModuleDAO(), new BLModule() };
    }
}
