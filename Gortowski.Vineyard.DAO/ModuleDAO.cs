using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using Gortowski.Vineyard.DAO.DAL;
using Gortowski.Vineyard.Interfaces.DAO;
using Ninject.Modules;

namespace Gortowski.Vineyard.DAO

{
    public class ModuleDAO : NinjectModule

    {
        public override void Load()
        {
            Bind<IDataContext>().ToMethod(_ => CreateContext()).InSingletonScope();
            Bind<IWork>().To<Work>().InSingletonScope();

        }

        private Context CreateContext()
        {

            string exeLocation = Assembly.GetEntryAssembly().Location;
            var config = ConfigurationManager.OpenExeConfiguration(exeLocation);
            string contextSource = config.AppSettings.Settings["TypeContext"].Value;

            if (!Path.IsPathRooted(contextSource))
            {
                contextSource = Path.Combine(Path.GetDirectoryName(exeLocation), contextSource);
            }
            var assembly = Assembly.LoadFile(contextSource);
            var contextType = assembly.GetTypes().Single(t => t.IsSubclassOf(typeof(Context)));
            var context = (Context)Activator.CreateInstance(contextType);
            return context;
        }
    }
}