using Pastelaria.WEB.Application.Usuario;
using Pastelaria.WEB.Application.Usuario.Model;
using System.Net.Http;
using System.Web.Mvc;

namespace Pastelaria.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly UsuarioApplication _usuarioApplication;
        public HomeController(UsuarioApplication usuarioApplication)
        {
            _usuarioApplication = usuarioApplication;
        }

        public ActionResult Index()
        {
            return View("Login");
        }

        public ActionResult Registrar()
        {
            return PartialView("FormCadastroUsuario");
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }


        public ActionResult PostLogin(UsuarioModel usuario)
        {
            
            var response = _usuarioApplication.PostLogin(usuario);
            if (!response.IsSuccessStatusCode)
            {
                Response.StatusCode = 400;
                Response.TrySkipIisCustomErrors = true;
                return Content(response.Content.ReadAsStringAsync().Result);
            }


            var user = response.Content.ReadAsAsync<UsuarioModel>().Result;

            System.Web.HttpContext.Current.Session["user"] = user;
            Session.Add("cargo", user.Num_Cargo);


            Response.StatusCode = 200;
            Response.TrySkipIisCustomErrors = true;
            return Json(user, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Cadastro(UsuarioModel usuario)
        {
            var response = _usuarioApplication.Post(usuario);
            if (!response.IsSuccessStatusCode)
            {
                Response.StatusCode = 400;
                Response.TrySkipIisCustomErrors = true;
                return Content(response.Content.ReadAsStringAsync().Result);
            }

            Response.StatusCode = 200;
            Response.TrySkipIisCustomErrors = true;
            return Json(JsonRequestBehavior.AllowGet);
        }



        public ActionResult Logout()
        {
            Session.Abandon();
            Session.Clear();
            return View("Login");
        }


    }
}
