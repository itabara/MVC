using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_Validation.Models;
using WebAPI_Validation.DataAccessRepository;
using System.Web.Http.Description;
using System.Web.Http.Cors;

namespace WebAPI_Validation.Controllers
{
    [EnableCors("*","*","*")]
    public class EmployeeInfoAPIController : ApiController
    {
        private IDataAccessRepository<EmployeeInfo, int> repository;

        /// <summary>
        /// Inject the DataAccessRepository using Constructor Injection
        /// </summary>
        /// <param name="repository"></param>
        public EmployeeInfoAPIController(IDataAccessRepository<EmployeeInfo, int> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<EmployeeInfo> Get()
        {
            return repository.Get();
        }

        [ResponseType(typeof(EmployeeInfo))]
        public IHttpActionResult Get(int id)
        {
            return Ok(repository.Get(id));
        }

        [ResponseType(typeof(EmployeeInfo))]
        public IHttpActionResult Post(EmployeeInfo emp)
        {
            repository.Post(emp);
            return Ok(emp);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, EmployeeInfo emp)
        {
            repository.Put(id, emp);
            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult Delete(int id)
        {
            repository.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
