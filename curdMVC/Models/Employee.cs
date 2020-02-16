using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace curdMVC.Models
{
    public class Employee
    {
        public int empid { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        public string Pin_code { get; set; }
        public string Designation { get; set; }
    }
}