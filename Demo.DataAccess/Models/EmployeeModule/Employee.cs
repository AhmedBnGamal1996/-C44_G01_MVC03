using Demo.DataAccess.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Models.EmployeeModule
{
    public class Employee : BaseEntity 
    {
        public string Name { get; set; } = null !;

        public int Age { get; set; }

        public string? Address { get; set; } 

        public decimal Salary { get; set; }

        public bool IsActive { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public DateOnly HiringDate { get; set; }


        // Gender ==> Enum [ Female , Male ] 

        // EmployeeType ==> [ FullTimeEmployee , PartTimeEmployee  ]

        public EmployeeType EmployeeType { get; set; }

        public Gender Gender { get; set; }





    }
}
