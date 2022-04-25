using Pastelaria.WEB.Application.Tarefa;
using Pastelaria.WEB.Application.Usuario;
using Pastelaria.WEB.Application.Usuario.Model;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;

namespace Pastelaria.WEB.Controllers
{
    public class TarefaController : Controller
    {
        private readonly TarefaApplication _tarefaApplication;
        private readonly UsuarioApplication _usuarioApplication;
        public TarefaController(TarefaApplication tarefaApplication, UsuarioApplication usuarioApplication)
        {
            _tarefaApplication = tarefaApplication;
            _usuarioApplication = usuarioApplication;
        }

        // GET: Tarefa
        public ActionResult Index()
        {
            UsuarioModel user = (UsuarioModel)Request.RequestContext.HttpContext.Session["user"];

            var response = _tarefaApplication.GetTarefaUser(int.Parse(user.Num_Usuario.ToString()));
            var retorno = response.Content.ReadAsAsync<IEnumerable<TarefaModel>>().Result;
            if (!response.IsSuccessStatusCode)
            {
                Response.StatusCode = 500;
                Response.TrySkipIisCustomErrors = true;
                return Content(response.Content.ReadAsStringAsync().Result);
            }

            Response.StatusCode = 200;
            Response.TrySkipIisCustomErrors = true;

            return View("Index", retorno);
        }

        public ActionResult GetTarefa()
        {
            var response = _tarefaApplication.GetTarefas();
            var retorno = response.Content.ReadAsAsync<IEnumerable<TarefaModel>>().Result;

            Response.StatusCode = 200;
            Response.TrySkipIisCustomErrors = true;
            return View("GerenciamentoTarefas", retorno);
        }

        public ActionResult CadTarefa()
        {
            return PartialView("FormCadTarefa");
        }


        public ActionResult PostTarefa(TarefaModel tarefa)
        {
            var response = _tarefaApplication.PostTarefa(tarefa);
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

        public ActionResult GetTarefas( int? idGerente, int? idFuncionario)
        {

            var response = _tarefaApplication.GetTarefas();
            var retorno = response.Content.ReadAsAsync<IEnumerable<TarefaModel>>().Result;

            Response.StatusCode = 200;
            Response.TrySkipIisCustomErrors = true;
            return Json(retorno, JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetUsers()
        {
            var response = _usuarioApplication.GetAllUsers();
            var retorno = response.Content.ReadAsAsync<IEnumerable<UsuarioModel>>().Result;

            Response.StatusCode = 200;
            Response.TrySkipIisCustomErrors = true;
            return View("FormTarefa", retorno);
        }

        public ActionResult GetTarefaId(int id)
        {
            var response = _tarefaApplication.GetTarefaId(id);
            var retorno = response.Content.ReadAsAsync<TarefaModel>().Result;
            if (!response.IsSuccessStatusCode)
            {
                Response.StatusCode = 500;
                Response.TrySkipIisCustomErrors = true;
                return Content(response.Content.ReadAsStringAsync().Result);
            }

            Response.StatusCode = 200;
            Response.TrySkipIisCustomErrors = true;

            return PartialView("_GridUpdTarefa", retorno);
        }

        public ActionResult Users()
        {
            var response = _usuarioApplication.GetAllUsers();
            var retorno = response.Content.ReadAsAsync<IEnumerable<UsuarioModel>>().Result;
            return Json(retorno, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PutTarefa(TarefaModel tarefa)
        {
            var response = _tarefaApplication.PutTarefa(tarefa);
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

        public ActionResult DeleteTarefa(int id)
        {
            var response = _tarefaApplication.DeleteTarefa(id);
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

        

        public ActionResult FinalizaTarefa(int id)
        {
            var response = _tarefaApplication.FinalizaTarefa(id);
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
