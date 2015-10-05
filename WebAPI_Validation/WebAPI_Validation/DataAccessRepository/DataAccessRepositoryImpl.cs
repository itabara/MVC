using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI_Validation.Models;
using Microsoft.Practices.Unity;


namespace WebAPI_Validation.DataAccessRepository
{
    public class DataAccessRepositoryImpl : IDataAccessRepository<EmployeeInfo, int>
    {
        [Dependency]
        public ApplicationEntities context { get; set; }

        public IEnumerable<EmployeeInfo> Get()
        {
            return context.EmployeeInfoes.ToList();
        }

        public EmployeeInfo Get(int id)
        {
            return context.EmployeeInfoes.Find(id);
        }

        public void Post(EmployeeInfo entity)
        {
            context.EmployeeInfoes.Add(entity);
            context.SaveChanges();
        }

        public void Put(int id, EmployeeInfo entity)
        {
            var employee = context.EmployeeInfoes.Find(id);
            if (employee != null)
            {
                employee.EmpName = entity.EmpName;
                employee.Designation = entity.Designation;
                employee.DeptName = entity.Designation;
                employee.Salary = entity.Salary;
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var employee = context.EmployeeInfoes.Find(id);
            if (employee != null)
            {
                context.EmployeeInfoes.Remove(employee);
                context.SaveChanges();
            }
        }
    }
}