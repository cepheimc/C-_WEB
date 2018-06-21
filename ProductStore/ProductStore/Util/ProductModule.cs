using Ninject.Modules;
using ProductStore.BLL.Services;
using ProductStore.BLL.Interfaces;

namespace ProductStore.Util
{
    public class ProductModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductService>();
            Bind<IShOrderService>().To<ShOrderService>();
            Bind<IClOrderService>().To<ClOrderService>();
        }
    }
}