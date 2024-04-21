﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
public class Service : IService
{
	LoginDBEntities DBcontext = new LoginDBEntities();

	#region Empleado

	//CREATE 
	public int InsertarEmpleado(EmployeeDetails empleado)
	{
		int Retval = 0;

		try
		{
			EmployeeDetails newEmp = new EmployeeDetails();

			//newEmp.Id = empleado.Id; //identity
			newEmp.Name = empleado.Name.Trim();
			newEmp.Address = empleado.Address.Trim();
			newEmp.Age  = empleado.Age;
			newEmp.Salary = empleado.Salary;
			newEmp.WorkType = empleado.WorkType.Trim();			

			DBcontext.EmployeeDetails.Add(newEmp);
			Retval = DBcontext.SaveChanges();
			return Retval;
		}
		catch (Exception)
		{
			return Retval;
		}


	}

	//READ ALL EMPLOYEES
	public List<EmployeeDetails> ListarTodosEmpleados()
	{
		List<EmployeeDetails> emplst = new List<EmployeeDetails>();
		try
		{
			var lstEmp = from k in DBcontext.EmployeeDetails select k;

			foreach (var item in lstEmp)
			{
				EmployeeDetails empl = new EmployeeDetails();

				empl.EmpId = item.EmpId;
				empl.Name = item.Name.Trim();				
				empl.Address = item.Address.Trim();
				empl.Age = item.Age;				
				empl.Salary = item.Salary;
				empl.WorkType = item.WorkType.Trim();
				
				emplst.Add(empl);
			}
			return emplst;
		}
		catch (Exception)
		{
			return emplst;
		}
	}

	//READ EMPLOYEE BY empId
	public EmployeeDetails ObtenerEmpleadoPorId(int empId)
	{
		var lstEmp = from k in DBcontext.EmployeeDetails where k.EmpId == empId select k;
		EmployeeDetails empl = new EmployeeDetails();
		try
		{
			foreach (var item in lstEmp)
			{
				empl.EmpId = item.EmpId;
				empl.Name = item.Name.Trim();
				empl.Address = item.Address.Trim();
				empl.Age = item.Age;
				empl.Salary = item.Salary;
				empl.WorkType = item.WorkType.Trim();
			}
			return empl;
		}
		catch (Exception)
		{
			return empl;
		}
	}

	//READ EMPLOYEE BY NameEmployee
	public List<EmployeeDetails> ObtenerEmpleadosPorNombre(string Name)
	{
		var lstEmp = from k in DBcontext.EmployeeDetails where k.Name.Contains(Name.ToString()) select k;		
		List<EmployeeDetails> lstEmpl = new List<EmployeeDetails>();
		try
		{
			foreach (var item in lstEmp)
			{
				EmployeeDetails empl = new EmployeeDetails(); //para que cree el nuevo usuario
				empl.EmpId = item.EmpId;
				empl.Name = item.Name.Trim();
				empl.Address = item.Address.Trim();
				empl.Age = item.Age;
				empl.Salary = item.Salary;
				empl.WorkType = item.WorkType.Trim();
				lstEmpl.Add(empl);
			}
			return lstEmpl;
		}
		catch (Exception)
		{
			return lstEmpl;
		}
	}

	//UPDATE EMPLOYEE BY EMPLOYEE
	public int ModificarEmpleado(EmployeeDetails emp)
	{
		int Retval = 0;
		try
		{
			EmployeeDetails empl = new EmployeeDetails();
			empl.EmpId = emp.EmpId;
			empl.Name = emp.Name.Trim();
			empl.Address = emp.Address.Trim();
			empl.Age = emp.Age;
			empl.Salary = emp.Salary;
			empl.WorkType = emp.WorkType.Trim();

			DBcontext.Entry(empl).State = EntityState.Modified;
			Retval = DBcontext.SaveChanges();
			return Retval;
		}
		catch (Exception)
		{
			return Retval;
		}
	}

	//DELETE EMPLOYEE BY empId
	public int BorrarEmpleadoPorId(int empId)
	{
		int Retval = 0;
		try
		{
			EmployeeDetails empl = new EmployeeDetails();
			empl.EmpId = empId;
			DBcontext.Entry(empl).State = EntityState.Deleted;
			Retval = DBcontext.SaveChanges();
			return Retval;
		}
		catch (Exception)
		{
			return Retval;
		}
	}

	#endregion

	#region Usuario

	//CREATE 
	public int InsertarUsuario(Usuario usuario)
	{
		int Retval = 0;

		try
		{
			var newuser = new Usuario();

			//newuser.Id = 0;  //identity
			newuser.Nombre = usuario.Nombre.Trim();
			newuser.Password = usuario.Password.Trim();
			newuser.UserName = usuario.UserName.Trim();
			newuser.Apellido = usuario.Apellido.Trim();
			newuser.Email = usuario.Email.Trim();

			DBcontext.Usuario.Add(newuser);
			Retval = DBcontext.SaveChanges();
			return Retval;
		}
		catch (Exception)
		{
			return Retval;
		}
	}

	//READ ALL USERS
	public List<Usuario> ListarTodosUsuarios()
	{
		LoginDBEntities tstDb = new LoginDBEntities();
		List<Usuario> userlst = new List<Usuario>();

		var lstUsr = from k in tstDb.Usuario select k;

		foreach (var item in lstUsr)
		{			
			Usuario usr = new Usuario();
			usr.Id = item.Id;
			usr.Nombre = item.Nombre.Trim();
			usr.UserName = item.UserName.Trim();
			usr.Password = item.Password.Trim();
			usr.Apellido = item.Apellido.Trim();
			usr.Email = item.Email.Trim();

			userlst.Add(usr);
		}
		return userlst;
	}

	//READ USER BY ID
	public Usuario ObtenerUsuarioPorId(int id)
	{
		LoginDBEntities tstDb = new LoginDBEntities();

		var lstUsr = from k in tstDb.Usuario where k.Id == id select k;
		Usuario usr = new Usuario();

		foreach (var item in lstUsr)
		{
			usr.Id = item.Id;
			usr.Nombre = item.Nombre.Trim();
			usr.UserName = item.UserName.Trim();
			usr.Password = item.Password.Trim();
			usr.Apellido = item.Apellido.Trim();
			usr.Email = item.Email.Trim();
		}
		return usr;
	}

	//READ USER BY NAME
	public List<Usuario> ObtenerUsuariosPorNombre(string Name)
	{		
		var lstUsr = from k in DBcontext.Usuario where k.Nombre.Contains(Name.ToString()) select k;		
		List<Usuario> lstUser = new List<Usuario>();

		foreach (var item in lstUsr)
		{
			Usuario usr = new Usuario();
			usr.Id = item.Id;
			usr.Nombre = item.Nombre.Trim();
			usr.UserName = item.UserName.Trim();
			usr.Password = item.Password.Trim();
			usr.Apellido = item.Apellido.Trim();
			usr.Email = item.Email.Trim();
			lstUser.Add(usr);
		}
		return lstUser;
	}

	//UPDATE USER BY USER
	public int ModificarUsuario(Usuario user)
	{
		int Retval = 0;
		try
		{
			LoginDBEntities tstDb = new LoginDBEntities();
			Usuario usrdtl = new Usuario();
			usrdtl.Id = user.Id;
			usrdtl.Nombre = user.Nombre.Trim();
			usrdtl.UserName = user.UserName.Trim();
			usrdtl.Password = user.Password.Trim();
			usrdtl.Apellido = user.Apellido.Trim();
			usrdtl.Email = user.Email.Trim();

			tstDb.Entry(usrdtl).State = EntityState.Modified;
			Retval = tstDb.SaveChanges();
			return Retval;
		}
		catch (Exception ex)
		{
			//Cuando se tiene validacion de base de datos longitud saca error .Net
			//El campo Name debe ser un tipo de cadena o matriz con una longitud máxima de '10'.
			return Retval;
		}
	}

	//DELETE USER BY ID
	public int BorrarUsuarioPorId(int userId)
	{
		int Retval = 0;
		try
		{
			Usuario Myuser = new Usuario();
			Myuser.Id = userId;
			DBcontext.Entry(Myuser).State = EntityState.Deleted;
			Retval = DBcontext.SaveChanges();
			return Retval;
		}
		catch (Exception)
		{
			return Retval;
		}
	}

    #endregion

    #region "Usuarios"

	//CREATE Usuarios
    public bool CrearUsuario(Usuarios usuarios)
    {
        int Retval = 0;
		bool bandera = false;

		try
		{
			var newuser = new Usuarios();

			//newuser.Id = 0;  //identity
			newuser.id_usuario = Convert.ToInt32(usuarios.id_usuario.ToString().Trim());
			newuser.nombre = usuarios.nombre.Trim();
			newuser.apellido = usuarios.apellido.Trim();
			newuser.rol = usuarios.rol.Trim();
			newuser.login = usuarios.login.Trim();
            byte[] byteArrayClave = Encoding.ASCII.GetBytes(usuarios.clave.ToString().Trim());
            newuser.clave = byteArrayClave;

            DBcontext.Usuarios.Add(newuser);
            Retval = DBcontext.SaveChanges();
            bandera = Retval == 1 ? true : false;
            return bandera;
        }
        catch (Exception)
        {
            return bandera;
        }
    }

    //UPDATE Usuarios BY USER
    public bool EditarUsuario(Usuarios users)
    {
        int Retval = 0;
        bool bandera = false;
        try
        {
            LoginDBEntities contextDb = new LoginDBEntities();
            Usuarios usrdtl = new Usuarios();
            usrdtl.id_usuario = users.id_usuario;
            usrdtl.nombre = users.nombre.Trim();
            usrdtl.apellido = users.apellido.Trim();
            usrdtl.login = users.login.Trim();
            usrdtl.clave = users.clave;
            usrdtl.rol = users.rol.Trim();

            contextDb.Entry(usrdtl).State = EntityState.Modified;
            Retval = contextDb.SaveChanges();
            bandera = Retval == 1 ? true : false;
            return bandera;
        }
        catch (Exception ex)
        {
            //Cuando se tiene validacion de base de datos longitud saca error .Net
            //El campo Name debe ser un tipo de cadena o matriz con una longitud máxima de '10'.
            return bandera;
        }
    }

    //READ ALL USERS
    public List<Usuarios> ConsultarUsuarios()
    {
        LoginDBEntities contextDb = new LoginDBEntities();
        List<Usuarios> userlist = new List<Usuarios>();

        var lstUsr = from k in contextDb.Usuarios select k;

        foreach (var item in lstUsr)
        {
            Usuarios usr = new Usuarios();
            usr.id_usuario = item.id_usuario;
            usr.nombre = item.nombre.Trim();
            usr.apellido = item.apellido.Trim();
            usr.login = item.login.Trim();
            usr.clave = item.clave;
            usr.rol = item.rol.Trim();

            userlist.Add(usr);
        }
        return userlist;
    }

    //READ USER BY ID
    public Usuarios ConsultarUsuarioPorId(int id)
    {
        LoginDBEntities tstDb = new LoginDBEntities();

        var lstUsr = from k in tstDb.Usuarios where k.id_usuario == id select k;
        Usuarios usr = new Usuarios();

        foreach (var item in lstUsr)
        {
            usr.id_usuario = item.id_usuario;
            usr.nombre = item.nombre.Trim();
            usr.apellido = item.apellido.Trim();
            usr.login = item.login.Trim();
            usr.clave = item.clave;
            usr.rol = item.rol.Trim();
        }
        return usr;
    }

    //READ USER BY NAME
    public List<Usuarios> ConsultarUsuariosPorNombre(string name)
    {
        var lstUsr = from k in DBcontext.Usuarios where k.nombre.Contains(name.ToString()) select k;
        List<Usuarios> listUser = new List<Usuarios>();

        foreach (var item in lstUsr)
        {
            Usuarios usr = new Usuarios();
            usr.id_usuario = item.id_usuario;
            usr.nombre = item.nombre.Trim();
            usr.apellido = item.apellido.Trim();
            usr.login = item.login.Trim();
            usr.clave = item.clave;
            usr.rol = item.rol.Trim();
            listUser.Add(usr);
        }
        return listUser;
    }

    //READ USER BY LOGIN
    public List<Usuarios> ConsultarUsuariosPorLogin(string login)
    {
        var lstUsr = from k in DBcontext.Usuarios where k.login.Contains(login.ToString()) select k;
        List<Usuarios> listUser = new List<Usuarios>();

        foreach (var item in lstUsr)
        {
            Usuarios usr = new Usuarios();
            usr.id_usuario = item.id_usuario;
            usr.nombre = item.nombre.Trim();
            usr.apellido = item.apellido.Trim();
            usr.login = item.login.Trim();
            usr.clave = item.clave;
            usr.rol = item.rol.Trim();
            listUser.Add(usr);
        }
        return listUser;
    }

    //DELETE USER BY ID
    public bool EliminarUsuarioPorId(int userId)
    {
        int Retval = 0;
		bool bandera = false;
        try
        {
            Usuarios Myuser = new Usuarios();
            Myuser.id_usuario = userId;
            DBcontext.Entry(Myuser).State = EntityState.Deleted;
            Retval = DBcontext.SaveChanges();
            bandera = Retval == 1 ? true : false;
            return bandera;
        }
        catch (Exception)
        {
            return bandera;
        }
    }
    #endregion

    #region "Trabajos"

    //CREATE Trabajo
    public bool CrearTrabajo(Trabajos trabajo)
    {
        int Retval = 0;
		bool bandera = false;
        try
        {
            var newtrabajo = new Trabajos();

            //newuser.Id = 0;  //identity
            newtrabajo.id_trabajo = trabajo.id_trabajo;
            newtrabajo.id_materia = trabajo.id_materia;
            newtrabajo.tipo_trabajo = trabajo.tipo_trabajo.Trim();
            newtrabajo.archivo = trabajo.tipo_trabajo.Trim();
            newtrabajo.fecha_entrega = trabajo.fecha_entrega;

            DBcontext.Trabajos.Add(newtrabajo);
            Retval = DBcontext.SaveChanges();
            bandera = Retval == 1 ? true : false;
            return bandera;
        }
        catch (Exception)
        {
            return bandera;
        }
    }

    //UPDATE Trabajos BY Trabajo
    public bool EditarTrabajo(Trabajos trabajo)
    {
        int Retval = 0;
        bool bandera = false;
        try
        {
            LoginDBEntities contextDb = new LoginDBEntities();
            Trabajos trabajodtl = new Trabajos();
            trabajodtl.id_trabajo = trabajo.id_trabajo;
            trabajodtl.id_materia = trabajo.id_materia;
            trabajodtl.tipo_trabajo = trabajo.tipo_trabajo.Trim();
            trabajodtl.id_usuario = trabajo.id_usuario;
            trabajodtl.archivo = trabajo.archivo;
            trabajodtl.fecha_entrega = trabajo.fecha_entrega;

            contextDb.Entry(trabajodtl).State = EntityState.Modified;
            Retval = contextDb.SaveChanges();
            bandera = Retval == 1 ? true : false;
            return bandera;
        }
        catch (Exception)
        {                        
            return bandera;
        }
    }

    //READ ALL Trabajos
    public List<Trabajos> ListarTrabajosPorIdMateria(int id_materia)
    {
        LoginDBEntities contextDb = new LoginDBEntities();
        List<Trabajos> trabajolist = new List<Trabajos>();

        var lstTrabajos = from k in contextDb.Trabajos where k.id_materia == id_materia select k;


        foreach (var item in lstTrabajos)
        {
            Trabajos trabajo = new Trabajos();
            trabajo.id_trabajo	 = item.id_trabajo;
            trabajo.id_usuario = item.id_usuario;
            trabajo.id_materia = item.id_materia;
            trabajo.tipo_trabajo = item.tipo_trabajo.Trim();
            trabajo.archivo = item.archivo.Trim();
            trabajo.fecha_entrega = item.fecha_entrega;

            trabajolist.Add(trabajo);
        }
        return trabajolist;
    }

	#endregion

    #region "Materias"

    #endregion

}