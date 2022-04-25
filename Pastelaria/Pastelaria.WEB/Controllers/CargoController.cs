using Pastelaria.WEB.Application.Cargo;
using Pastelaria.WEB.Application.Cargo.Model;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;

namespace Pastelaria.WEB.Controllers
{
    public class CargoController : Controller
    {

        private readonly CargoApplication _cargoApplication;
        public CargoController(CargoApplication cargoApplication)
        {
            _cargoApplication = cargoApplication;
        }

        public ActionResult Index()
        {
            return View("index");
        }

        public ActionResult PostCargo(CargoModel cargo)
        {
            var response = _cargoApplication.PostCargo(cargo);
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
        public ActionResult FormCadCargo()
        {
            return PartialView("FormCadCargo");
        }



        public ActionResult GetCargos()
        {
            var response = _cargoApplication.GetCargos();
            var retorno = response.Content.ReadAsAsync<IEnumerable<CargoModel>>().Result;

            Response.StatusCode = 200;
            Response.TrySkipIisCustomErrors = true;
            return View("Index", retorno);
        }

        public ActionResult GetCargoId(int id)
        {
            var response = _cargoApplication.GetCargoId(id);
            var retorno = response.Content.ReadAsAsync<CargoModel>().Result;

            Response.StatusCode = 200;
            Response.TrySkipIisCustomErrors = true;
            return View("UpdCargo", retorno);
        }

        public ActionResult PutCargo(CargoModel cargo)
        {
            var response = _cargoApplication.PutCargo(cargo);
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

        public ActionResult DeleteCargo(int id)
        {
            var response = _cargoApplication.DeleteCargo(id);
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