using System.Collections.Generic;
using System.Linq;
using APIService.Models;

using Microsoft.Practices.Unity;

namespace APIService.DataAccessRepository
{
    public class DataAccessRepositoryImpl : IDataAccessRepository<EmployeeInfo, int>
    {
        [Dependency]
        public ApplicationEntities context {get;set;} // EF DB access context

        /// <summary>
        /// Get all Employees
        /// </summary>
        /// <returns></returns>
        public IEnumerable<EmployeeInfo> Get()
        {
            return context.EmployeeInfoes.ToList();
        }

        /// <summary>
        /// Get Specific Employee based on Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public EmployeeInfo Get(int id)
        {
            return context.EmployeeInfoes.Find(id);
        }

        /// <summary>
        /// Create a new Employee
        /// </summary>
        /// <param name="entity"></param>
        public void Post(EmployeeInfo entity)
        {
            context.EmployeeInfoes.Add(entity);
            context.SaveChanges();
        }

        /// <summary>
        /// Update existing employee
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        public void Put(int id, EmployeeInfo entity)
        {
            var emp = context.EmployeeInfoes.Find(id);
            if (emp != null)
            {
                emp.EmpName = entity.EmpName;
                emp.DeptName = entity.DeptName;
                emp.Designation = entity.Designation;
                emp.Salary = entity.Salary;
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Delete an Employee based on Id
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            var emp = context.EmployeeInfoes.Find(id);
            if (emp != null)
            {
                context.EmployeeInfoes.Remove(emp);
                context.SaveChanges();
            }
        }
    }
}