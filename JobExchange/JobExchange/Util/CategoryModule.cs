using Ninject.Modules;
using JobExchange.BLL.Interfaces;
using JobExchange.BLL.Services;


namespace JobExchange.Util
{
    public class CategoryModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICategoryService>().To<CategoryService>();            
            Bind<ICustomService>().To<CustomerService>();
            Bind<IEmployeeService>().To<EmployeeService>();
            Bind<IResumeService>().To<ResumeService>();
            Bind<IVacancyService>().To<VacancyService>();
        }
    }
}