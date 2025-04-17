﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageEmployeeApp.Models
{
    public class EmployeeSalary
    {
        public int Id { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Title { get; set; }
        public decimal Salary { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
