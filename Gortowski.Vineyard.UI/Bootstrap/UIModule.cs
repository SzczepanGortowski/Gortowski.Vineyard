using Gortowski.Vineyard.BL.Services;
using Gortowski.Vineyard.UI.Services;
using Ninject.Modules;

namespace Gortowski.Vineyard.UI.Bootstrap
{
    public class UIModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDialogService>().To<DialogService>().InSingletonScope();
        }
    }
}
