using Pastelaria.WEB.Application.Cargo;
using Pastelaria.WEB.Application.Cargo.Model;
using Pastelaria.WEB.Application.Usuario;
using Pastelaria.WEB.Application.Usuario.Model;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;

namespace Pastelaria.WEB.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly CargoApplication _cargoApplication;
        private readonly UsuarioApplication _usuarioApplication;
        public UsuarioController(CargoApplication cargoApplication, UsuarioApplication usuarioApplication)
        {
            _usuarioApplication = usuarioApplication;
            _cargoApplication = cargoApplication;
        }

        public ActionResult Index()
        {
            return View("Index");
        }

        public IEnumerable<UsuarioModel> All()
        {
            var response = _usuarioApplication.GetAllUsers();
            var retorno = response.Content.ReadAsAsync<IEnumerable<UsuarioModel>>().Result;
            return retorno;
        }

        public ActionResult Perfil()
        {
            UsuarioModel user = (UsuarioModel)Request.RequestContext.HttpContext.Session["user"];

            var response = _usuarioApplication.GetUsuarioId(int.Parse(user.Num_Usuario.ToString()));
            var retorno = response.Content.ReadAsAsync<UsuarioModel>().Result;

            return View("Perfil", retorno);
        }

        public ActionResult GerenciarUsuario(int id)
        {
            var response = _usuarioApplication.GetUsuarioId(id);
            var retorno = response.Content.ReadAsAsync<UsuarioModel>().Result;

            return View("FormGerenciarFuncionario", retorno);

        }

        public ActionResult GetCargosUser()
        {
            var response = _cargoApplication.GetCargos();
            var retorno = response.Content.ReadAsAsync<IEnumerable<CargoModel>>().Result;

            Response.StatusCode = 200;
            Response.TrySkipIisCustomErrors = true;
            return Json(retorno, JsonRequestBehavior.AllowGet);

        }

        public ActionResult ListaUsuarios()
        {
            var response = _usuarioApplication.GetAllUsers();
            var retorno = response.Content.ReadAsAsync<IEnumerable<UsuarioModel>>().Result;
            Response.StatusCode = 200;
            Response.TrySkipIisCustomErrors = true;

            return View("Lista", retorno);
        }

        public ActionResult FormUsuario()
        {
            var response = _cargoApplication.GetCargos();
            var retorno = response.Content.ReadAsAsync<CargoModel>().Result;

            Response.StatusCode = 200;
            Response.TrySkipIisCustomErrors = true;

            return View("_FormUsuario", retorno);
        }

        public ActionResult PutUser(UsuarioModel usuario)
        {
            var response = _usuarioApplication.PutUser(usuario);
            if (!response.IsSuccessStatusCode)
            {
                Response.StatusCode = 500;
                Response.TrySkipIisCustomErrors = true;
                return Content(response.Content.ReadAsStringAsync().Result);
            }

            Response.StatusCode = 200;
            Response.TrySkipIisCustomErrors = true;

            return Content("sucesso");
        }

        public ActionResult Put(UsuarioModel usuario)
        {
            var response = _usuarioApplication.Put(usuario);
            if (!response.IsSuccessStatusCode)
            {
                Response.StatusCode = 500;
                Response.TrySkipIisCustomErrors = true;
                return Content(response.Content.ReadAsStringAsync().Result);
            }

            Response.StatusCode = 200;
            Response.TrySkipIisCustomErrors = true;

            return Content("sucesso");
        }


        public ActionResult DeleteUsuario(int id)
        {
            var response = _usuarioApplication.DeleteUsuario(id);
            if (!response.IsSuccessStatusCode)
            {
                Response.StatusCode = 500;
                Response.TrySkipIisCustomErrors = true;
                return Content(response.Content.ReadAsStringAsync().Result);
            }
            Response.StatusCode = 200;
            Response.TrySkipIisCustomErrors = true;

            return Content("sucesso");
        }
    }
}

