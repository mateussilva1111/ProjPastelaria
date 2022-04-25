using Pastelaria.WEB.Application.Endereco;
using Pastelaria.WEB.Application.Endereco.Model;
using Pastelaria.WEB.Application.Usuario.Model;
using System.Net.Http;
using System.Web.Mvc;

namespace Pastelaria.WEB.Controllers
{
    public class EnderecoController : Controller
    {
        private readonly EnderecoApplication _enderecoApplication;
        public EnderecoController(EnderecoApplication enderecoApplication)
        {
            _enderecoApplication = enderecoApplication;
        }

        // GET: Endereco
        public ActionResult Index()
        {
            UsuarioModel user = (UsuarioModel)Request.RequestContext.HttpContext.Session["user"];

            var response = _enderecoApplication.GetEnderecoId(int.Parse(user.Num_Usuario.ToString()));
            var retorno = response.Content.ReadAsAsync<EnderecoModel>().Result;

            return View("Endereco", retorno);
        }

        public ActionResult PutEndereco(EnderecoModel endereco)
        {
            var response = _enderecoApplication.PutEndereco(endereco);
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

        public ActionResult PostEndereco(EnderecoModel endereco)
        {
            UsuarioModel user = (UsuarioModel)Request.RequestContext.HttpContext.Session["user"];
            endereco.Num_Usuario = int.Parse(user.Num_Usuario.ToString());


            var response = _enderecoApplication.PostEndereco(endereco);
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