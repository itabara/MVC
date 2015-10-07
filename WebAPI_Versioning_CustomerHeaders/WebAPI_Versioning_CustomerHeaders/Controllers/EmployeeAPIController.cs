using System.Collections.Generic;
using System.Web.Http;
using WebAPI_Versioning_CustomerHeaders.Models;

namespace WebAPI_Versioning_CustomerHeaders.Controllers
{
    public class EmployeeAPIController : ApiController
    {
        public List<EmployeeInfo> Get(int id = 0)
        {
            return new EmployeeInfoDatabase();
        }
    }
}
