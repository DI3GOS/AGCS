using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication008.Models;

namespace WebApplication008.Repository
{
    interface IUsuario
    {
        void InsertUsuario(Usuario usuarioObj); // C
        IEnumerable<Usuario> GetUsuarios(); // R
        Usuario GetUsuarioByID(int UsuarioId); // R
        void UpdateUsuario(Usuario usuarioObj); //U
        void DeleteUsuario(int usuarioId); //D
    }
}
