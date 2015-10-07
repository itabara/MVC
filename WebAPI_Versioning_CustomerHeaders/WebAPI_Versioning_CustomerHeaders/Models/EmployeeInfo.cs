using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_Versioning_CustomerHeaders.Models
{
    public class EmployeeInfo
    {
        public int EmpNo { get; set; }
        public string EmployeeName { get; set; }

        public decimal Salary { get; set; }

        public string DepartmentName { get; set; }
    }

    public class EmployeeInfoDatabase : List<EmployeeInfo>
    {
        public EmployeeInfoDatabase()
        {
            Add(new EmployeeInfo() { EmpNo = 1, EmployeeName = "SS", Salary = 1900, DepartmentName = "D1" });
            Add(new EmployeeInfo() { EmpNo = 2, EmployeeName = "MP", Salary = 1800, DepartmentName = "D2" });
            Add(new EmployeeInfo() { EmpNo = 3, EmployeeName = "SK", Salary = 1990, DepartmentName = "D3" });
            Add(new EmployeeInfo() { EmpNo = 4, EmployeeName = "MS", Salary = 1960, DepartmentName = "D1" });
            Add(new EmployeeInfo() { EmpNo = 5, EmployeeName = "SP", Salary = 1940, DepartmentName = "D2" });
            Add(new EmployeeInfo() { EmpNo = 6, EmployeeName = "MS", Salary = 1120, DepartmentName = "D3" });
        }
    }

    public class EmployeeInfoDatabaseV1 : List<EmployeeInfo>
    {
        public EmployeeInfoDatabaseV1()
        {
            Add(new EmployeeInfo() { EmpNo = 1, EmployeeName = "SS", Salary = 100, DepartmentName = "D1" });
            Add(new EmployeeInfo() { EmpNo = 2, EmployeeName = "MP", Salary = 800, DepartmentName = "D2" });
            Add(new EmployeeInfo() { EmpNo = 3, EmployeeName = "SK", Salary = 990, DepartmentName = "D3" });
        }
    }

    public class EmployeeInfoDatabaseV2 : List<EmployeeInfo>
    {
        public EmployeeInfoDatabaseV2()
        {
            Add(new EmployeeInfo() { EmpNo = 6, EmployeeName = "S1", Salary = 4900, DepartmentName = "D1" });
            Add(new EmployeeInfo() { EmpNo = 7, EmployeeName = "M2", Salary = 5800, DepartmentName = "D2" });
            Add(new EmployeeInfo() { EmpNo = 8, EmployeeName = "S3", Salary = 6990, DepartmentName = "D3" });
            Add(new EmployeeInfo() { EmpNo = 9, EmployeeName = "M4", Salary = 7960, DepartmentName = "D1" });
        }
    }
}