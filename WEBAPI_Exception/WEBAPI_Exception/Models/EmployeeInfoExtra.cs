using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WEBAPI_Exception.Models
{
    [MetadataType(typeof(EmployeeInfoMetadata))]
    public partial class EmployeeInfo
    {
        private class EmployeeInfoMetadata
        {
            public int EmpNo { get; set; }
            [Required(ErrorMessage="Value is Must")]
            public string EmpName { get; set; }
            [Required(ErrorMessage = "Salary is Must")]
            public int Salary { get; set; }
            [Required(ErrorMessage="DeptName is Must")]
            public string DeptName { get; set; }
            [Required(ErrorMessage="Designation is Must")]
            public string Designation { get; set; }
        }
    }
}