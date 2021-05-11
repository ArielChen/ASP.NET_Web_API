using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_ADO.NET.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }
        public string TitleOfCourtesy { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public int ManagerID { get; set; }
        public string Gender { get; set; }
        public int MonthlyPayment { get; set; }
        public int YearlyPayment { get; set; }
    }
}