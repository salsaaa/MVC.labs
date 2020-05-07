using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.ViewModels
{
    public class EmployeeViewModel
    {
        public List<Employee> Employees { get; set; }
        public Employee Employee { get; set; }
    }
}