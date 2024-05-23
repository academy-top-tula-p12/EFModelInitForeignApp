using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFModelInitForeignApp
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Age { get; set; }

        //public Passport? Passport { get; set; }

        //public int CompanyId { get; set; } // foreign key
        //public string? CompanyTitle { get; set; } // foreign principal key
        [Required]
        public Company? Company { get; set; } // navigtion property
    }

    public class Company
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;

        public List<Employee> Employees { get; set; } = new(); // navigtion property
    }

    //public class Passport
    //{
    //    public int Number { get; set; }

    //    public int EmployeeId { get; set; }
    //    public Employee Employee { get; set; }
    //}
}
