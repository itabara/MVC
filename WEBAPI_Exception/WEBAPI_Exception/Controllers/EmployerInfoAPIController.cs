using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WEBAPI_Exception.CustomFilterRepo;
using WEBAPI_Exception.Models;

namespace WEBAPI_Exception.Controllers
{
    public class EmployerInfoAPIController : ApiController
    {
        ApplicationEntities context;

        public EmployerInfoAPIController()
        {
            context = new ApplicationEntities();
        }

        [ResponseType(typeof(EmployeeInfo))]
        public IHttpActionResult Get(int id)
        {
            var emp = context.EmployeeInfoes.Find(id);
            if(emp == null)
            {
                throw new ProcessException("Record not found, it may be removed");
            }
            return Ok(emp);
        }

        [ResponseType(typeof(EmployeeInfo))]
        public IHttpActionResult Post(EmployeeInfo employeeInfo)
        {
            if (!ModelState.IsValid)
            {
                throw new ProcessException("One or more fields are invalid, please check");
            }
            context.EmployeeInfoes.Add(employeeInfo);
            context.SaveChanges();

            return CreatedAtRoute("DefaultAPI", new { id = employeeInfo.EmpNo }, employeeInfo);
        }
    }
}
