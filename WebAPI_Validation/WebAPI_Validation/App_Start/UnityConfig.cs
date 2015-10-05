using Microsoft.Practices.Unity;

using System.Web.Http;

using Unity.WebApi;

using WebAPI_Validation.DataAccessRepository;
using WebAPI_Validation.Models;

namespace WebAPI_Validation
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IDataAccessRepository<EmployeeInfo, int>, DataAccessRepositoryImpl>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}