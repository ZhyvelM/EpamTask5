using BL.Elements;
using BL.Interfaces;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpamTask5.Util
{
    public class WebModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ISaleService>().To<SaleService>();
        }
    }
}