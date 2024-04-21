using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication008.Models;

namespace WebApplication008.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        [HttpGet]
        public ActionResult Index()
        {
            Session.Clear();
            Session.Abandon();

            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginModel login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    WCFServicioDatos.ServiceClient myCliente = new WCFServicioDatos.ServiceClient();
                    List<WCFServicioDatos.Usuario> usuario = new List<WCFServicioDatos.Usuario>();

                    usuario = myCliente.ListarTodosUsuarios().ToList();

                    var user = (from userlist in usuario.ToList()
                                where userlist.UserName.Trim() == login.UserName && userlist.Password.Trim() == login.Password
                                select new
                                {
                                    userlist.Id,
                                    userlist.UserName
                                }).ToList();
                    if (user.FirstOrDefault() != null)
                    {
                        Session["UserName"] = user.FirstOrDefault().UserName.Trim();
                        Session["UserID"] = user.FirstOrDefault().Id;
                        return Redirect("/Home/Index");
                    }
                    else
                    {
                        //se deben de llamar igual
                        ModelState.AddModelError("mensajeErrorName", "Credenciales Invalidas");
                    }
                }
                return View(login);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("mensajeErrorName", "Error con el WebService");
                return View(login);                
            }
            
        }
    }
}