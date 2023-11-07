using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IliasOtsmanConnBBDD.Models
{
    internal class Employee
    {
        private int idEmployee;
        private string firstName;
        private string lastName;
        private string email;
        private string phone;
        private DateTime hireDate;
        private decimal salary;
        private int jobId;
        private int? managerId;
        private int? departmentId;

        public int IdEmployee { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
        public int JobId { get; set; }
        public int? ManagerId { get; set; }
        public int? DepartmentId { get; set; }

        public Employee(int employeeId, string firstName, string lastName, string email, string phoneNumber,
            DateTime hireDate, decimal salary, int jobId, int? managerId, int? departmentID)
        {
            this.idEmployee = employeeId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.phone = phoneNumber;
            this.hireDate = hireDate;
            this.salary = salary;
            this.jobId = jobId;
            this.managerId = managerId;
            this.departmentId = departmentID;
        }

        public override string ToString()
        {
            return $"{firstName} {lastName} - {email} - {phone} - {hireDate} - {salary} - {jobId} - {managerId} - {departmentId}";
        }
    }
}
