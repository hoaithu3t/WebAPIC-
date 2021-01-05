using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.WebAPI.Modal
{
    public class Employee
    {
        public Guid CustomerId  { get; set; }
        public string EmployeeCode { get; set; }
        public string FullNamme { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime IdentityDate  { get; set; }
        public string IdentityPlace { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string TaxCode { get; set; }
        public string Salary { get; set; }
        public DateTime JoinDate { get; set; }
        public string WordStatusId { get; set; }
        public string PositionId { get; set; }
        public string DepartmentId { get; set; }

    }
}
