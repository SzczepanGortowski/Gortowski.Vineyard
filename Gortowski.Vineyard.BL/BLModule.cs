using System;
using System.Collections.Generic;
using System.Text;
using Ninject.Modules;
using Gortowski.Vineyard.BL.Services;
using Gortowski.Vineyard.Interfaces.Services;

namespace Gortowski.Vineyard.BL
{
    public class BLModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IVineService>().To<VineService>();
            Bind<IRegionService>().To<RegionService>();
        }
    }
}

