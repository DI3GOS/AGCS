using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication008.Models;

namespace WebApplication008.Repository
{
    interface IEmployee
    {
        void InsertEmployee(EmployeeDetails Employee); // C

        IEnumerable<EmployeeDetails> GetEmployees(); // R

        EmployeeDetails GetEmployeeByID(int EmployeeId); // R

        void UpdateEmployee(EmployeeDetails Employee); //U

        void DeleteEmployee(int EmployeeId); //D
    }
}
