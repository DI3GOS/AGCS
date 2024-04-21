using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication008.Models;

namespace WebApplication008.Repository
{
    public class EmployeeRepository
    {
        ////Creo el contexto de la bd
        //private LoginDBEntities DBcontext;

        ////Constructor de la clase
        //public EmployeeRepository(LoginDBEntities objempcontext)
        //{
        //    this.DBcontext = objempcontext;

        //}

        ////Create                        
        //public void InsertEmployee(Models.EmployeeDetails Employee)
        //{
        //    DBcontext.EmployeeDetails.Add(Employee);
        //    DBcontext.SaveChanges();
        //}

        ////Read
        //public IEnumerable<Models.EmployeeDetails> GetEmployees()
        //{
        //    return DBcontext.EmployeeDetails.ToList();
        //}

        ////Read one Employee
        //public Models.EmployeeDetails GetEmployeeByID(int EmployeeId)
        //{
        //    return DBcontext.EmployeeDetails.Find(EmployeeId);
        //}

        ////Update one Employee
        //public void UpdateEmployee(Models.EmployeeDetails Employee)
        //{

        //    DBcontext.Entry(Employee).State = EntityState.Modified;
        //    DBcontext.SaveChanges();
        //}

        ////Delete Employee
        //public void DeleteEmployee(int EmployeeId)
        //{
        //    EmployeeDetails user = DBcontext.EmployeeDetails.Find(EmployeeId);
        //    DBcontext.EmployeeDetails.Remove(user);
        //    DBcontext.SaveChanges();
        //}
    }
}