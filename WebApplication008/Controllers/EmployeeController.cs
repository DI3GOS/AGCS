using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication008.Models;
using WebApplication008.Repository;

namespace WebApplication008.Controllers
{   
    public class EmployeeController : Controller
    {
        //variable Empleado
        //private IEmployee Iemp;

        /// <summary>
        /// Constructor EmployssController
        /// </summary>
        //public EmployeeController()
        //{
        //    this.Iemp = new EmployeeRepository(new LoginDBEntities1());
        //}

        // GET: Employee
        public ActionResult Index()
        {
            //var list = Iemp.GetEmployees().ToList();
            //return View(list);
            
            WCFServicioDatos.ServiceClient myCliente = new WCFServicioDatos.ServiceClient();
            List<EmployeesModel> lstEmployees = new List<EmployeesModel>();
            var myListEmployess = myCliente.ListarTodosEmpleados();

            foreach (var item in myListEmployess)
            {
                EmployeesModel empl = new EmployeesModel();

                empl.EmpId = item.EmpId;
                empl.Name = item.Name.Trim();
                empl.Address = item.Address.Trim();
                empl.Age = item.Age;
                empl.Salary = item.Salary;
                empl.WorkType = item.WorkType;
                lstEmployees.Add(empl);
            }

            //Si no esta logeado mandarlo al Login
            if (Session["UserName"] != null)
            {
                return View(lstEmployees.ToList());
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }            
        }

        [HttpPost]
        public ActionResult Index(string inputBuscar)  //debe tener el nombre del input text igual
        {
            WCFServicioDatos.ServiceClient myCliente = new WCFServicioDatos.ServiceClient();

            if (inputBuscar.Length > 0)
            {
                //filtra los resultados por el nombre
                List<EmployeesModel> lstEmployees = new List<EmployeesModel>();
                var myListEmployess = myCliente.ObtenerEmpleadosPorNombre(inputBuscar);

                foreach (var item in myListEmployess)
                {
                    EmployeesModel empl = new EmployeesModel();

                    empl.EmpId = item.EmpId;
                    empl.Name = item.Name.Trim();
                    empl.Address = item.Address.Trim();
                    empl.Age = item.Age;
                    empl.Salary = item.Salary;
                    empl.WorkType = item.WorkType;
                    lstEmployees.Add(empl);
                }

                return View(lstEmployees.ToList());
            }
            else
            {
                //trae todos los datos
                List<EmployeesModel> lstEmployees = new List<EmployeesModel>();
                var myListEmployess = myCliente.ListarTodosEmpleados();

                foreach (var item in myListEmployess)
                {
                    EmployeesModel empl = new EmployeesModel();

                    empl.EmpId = item.EmpId;
                    empl.Name = item.Name.Trim();
                    empl.Address = item.Address.Trim();
                    empl.Age = item.Age;
                    empl.Salary = item.Salary;
                    empl.WorkType = item.WorkType;
                    lstEmployees.Add(empl);
                }

                return View(lstEmployees.ToList());
            }
        }

        public ActionResult Details(int id)
        {
            //var objemp = Iemp.GetEmployeeByID(id);

            WCFServicioDatos.ServiceClient myCliente = new WCFServicioDatos.ServiceClient();
            var objemp = myCliente.ObtenerEmpleadoPorId(id);

            var Employee = new EmployeeDetails();

            Employee.EmpId = id;

            Employee.Name = objemp.Name;

            Employee.Salary = objemp.Salary;

            Employee.Age = objemp.Age;

            Employee.Address = objemp.Address;

            Employee.WorkType = objemp.WorkType;

            //Si no esta logeado mandarlo al Login
            if (Session["UserName"] != null)
            {
                return View(Employee);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }            
        }
        
        // GET: Employee/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new EmployeesModel());
        }
        
        [HttpPost]        
        public ActionResult Create(FormCollection collection, EmployeesModel objemp)
        {
            WCFServicioDatos.ServiceClient myCliente = new WCFServicioDatos.ServiceClient();

            try
            {
                WCFServicioDatos.EmployeeDetails TblEmpleado = new WCFServicioDatos.EmployeeDetails();

                if (ModelState.IsValid)
                {
                    //TblEmpleado.EmpId = objemp.EmpId;
                    TblEmpleado.Name = objemp.Name.Trim();
                    TblEmpleado.Salary = objemp.Salary;
                    TblEmpleado.Age = objemp.Age;
                    TblEmpleado.Address = objemp.Address.Trim();
                    TblEmpleado.WorkType = objemp.WorkType.Trim();

                    //Iemp.InsertEmployee(Employee); //Agrego el empleado Passing data to InsertEmployee of EmployeeRepository
                    int Resval = myCliente.InsertarEmpleado(TblEmpleado);                    

                    if (Session["UserName"] != null)
                    {
                        return RedirectToAction("Index");                        
                    }
                    else
                    {
                        return RedirectToAction("Index", "Login");
                    }
                }
                else
                {
                    return RedirectToAction("Index");
                }                
            }
            catch(Exception ex)
            {
                return RedirectToAction("Index");
            }            
        }

        public ActionResult Edit(int id)
        {

            WCFServicioDatos.ServiceClient myCliente = new WCFServicioDatos.ServiceClient();
            var objemp = myCliente.ObtenerEmpleadoPorId(id);

            //var objemp = Iemp.GetEmployeeByID(id); // getting records by id GetEmployeeByID(ID)
            var Employee = new EmployeeDetails();
            Employee.EmpId = id;
            Employee.Name = objemp.Name;
            Employee.Salary = objemp.Salary;
            Employee.Age = objemp.Age;
            Employee.Address = objemp.Address;
            Employee.WorkType = objemp.WorkType;

            //Si no esta logeado mandarlo al Login
            if (Session["UserName"] != null)
            {
                return View(Employee);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }            
        }

        // POST: /Emp/Edit/1
        [HttpPost]
        public ActionResult Edit(FormCollection collection, EmployeeDetails objemp)
        {
            WCFServicioDatos.ServiceClient myCliente = new WCFServicioDatos.ServiceClient();            

            try
            {
                if (ModelState.IsValid)
                {
                    WCFServicioDatos.EmployeeDetails empl = new WCFServicioDatos.EmployeeDetails();
                    empl.EmpId = objemp.EmpId;
                    empl.Name = objemp.Name.Trim();
                    empl.Salary = objemp.Salary;
                    empl.Age = objemp.Age;
                    empl.Address = objemp.Address.Trim();
                    empl.WorkType = objemp.WorkType.Trim();

                    int result = myCliente.ModificarEmpleado(empl);
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }            
        }

        // GET: Employee/Delete/1
        [HttpGet] 
        public ActionResult Delete(int id)
        {
            //var objemp = Iemp.GetEmployeeByID(id); // calling GetEmployeeByID method of EmployeeRepository
            //return View(objemp);
            WCFServicioDatos.ServiceClient myCliente = new WCFServicioDatos.ServiceClient();
            var objemp = myCliente.ObtenerEmpleadoPorId(id);
                        
            var Employee = new EmployeeDetails();
            Employee.EmpId = id;
            Employee.Name = objemp.Name;
            Employee.Salary = objemp.Salary;
            Employee.Age = objemp.Age;
            Employee.Address = objemp.Address;
            Employee.WorkType = objemp.WorkType;

            //Si no esta logeado mandarlo al Login
            if (Session["UserName"] != null)
            {
                return View(Employee);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }            
        }

        [HttpPost]
        public ActionResult Delete(int id, EmployeeDetails objemp)
        {
            try
            {
                WCFServicioDatos.ServiceClient myCliente = new WCFServicioDatos.ServiceClient();
                int Rev = myCliente.BorrarEmpleadoPorId(id);                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}