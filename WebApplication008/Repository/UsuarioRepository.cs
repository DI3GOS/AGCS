using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication008.Models;

namespace WebApplication008.Repository
{
    public class UsuarioRepository
    {
        //Creo el contexto de la bd
        //private LoginDBEntities DBcontext;

        ////Constructor de la clase
        //public UsuarioRepository(LoginDBEntities objusucontext)
        //{
        //    this.DBcontext = objusucontext;
        //}

        ////Create
        //public void InsertUsuario(Models.Usuario usuario)
        //{
        //    DBcontext.Usuario.Add(usuario);
        //    DBcontext.SaveChanges();
        //}

        ////Read
        //public IEnumerable<Models.Usuario> GetUsuarios()
        //{
        //    return DBcontext.Usuario.ToList();
        //}

        ////Read one Usuario
        //public Models.Usuario GetUsuarioByID(int UserId)
        //{
        //    return DBcontext.Usuario.Find(UserId);
        //}

        ////Update one Usuario    
        //public void UpdateUsuario(Models.Usuario usuario)
        //{
        //    DBcontext.Entry(usuario).State = EntityState.Modified;
        //    DBcontext.SaveChanges();
        //}
              
        ////Delete Usuario
        //public void DeleteUsuario(int UserId)
        //{
        //    Usuario user = DBcontext.Usuario.Find(UserId);
        //    DBcontext.Usuario.Remove(user);
        //    DBcontext.SaveChanges();
        //}
    }
}