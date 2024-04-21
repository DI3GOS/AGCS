﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
[ServiceContract]
public interface IService
{
	#region Empleado

	[OperationContract]
	int InsertarEmpleado(EmployeeDetails empleado); //C

	[OperationContract]
	List<EmployeeDetails> ListarTodosEmpleados(); // R

	[OperationContract]
	EmployeeDetails ObtenerEmpleadoPorId(int empId); // R

	[OperationContract]
	int ModificarEmpleado(EmployeeDetails emp); // U

	[OperationContract]
	int BorrarEmpleadoPorId(int empId); // D

	#endregion

	#region Usuario

	[OperationContract]
	int InsertarUsuario(Usuario usuario); //C

	[OperationContract]
	List<Usuario> ListarTodosUsuarios();   //R

	[OperationContract]
	Usuario ObtenerUsuarioPorId(int id);   //R

	[OperationContract]
	int ModificarUsuario(Usuario user);  //U

	[OperationContract]
	int BorrarUsuarioPorId(int Id);  //D

	#endregion
}

[DataContract]
public class ListarTodosEmpleados
{
	[DataMember]
	public int EmpId { get; set; }
	[DataMember]
	public string Name { get; set; }
	[DataMember]
	public string Address { get; set; }
	[DataMember]
	public Nullable<int> Age { get; set; }
	[DataMember]
	public Nullable<decimal> Salary { get; set; }
	[DataMember]
	public string WorkType { get; set; }
}

[DataContract]
public class ListarTodosUsuarios
{
	[DataMember]
	public int Id { get; set; }
	[DataMember]
	public string UserName { get; set; }
	[DataMember]
	public string Password { get; set; }
	[DataMember]
	public string Nombre { get; set; }
	[DataMember]
	public string Apellido { get; set; }
	[DataMember]
	public string Email { get; set; }
}
