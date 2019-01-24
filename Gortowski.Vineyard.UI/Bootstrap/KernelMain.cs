using Gortowski.Vineyard.Bootstrap;
using Ninject;
using System.Linq;

namespace Gortowski.Vineyard.UI.Bootstrap
{
    public static class KernelMain
    {
        public static IKernel KernelInstance { get; set; }

        static KernelMain()
        {
            var settings = new NinjectSettings
            {
                InjectNonPublic = true
            };
            var modules = Modules.GetModules().ToList();
            modules.Add(new UIModule());

            KernelInstance = new StandardKernel(settings, modules.ToArray());
        }
    }
}


