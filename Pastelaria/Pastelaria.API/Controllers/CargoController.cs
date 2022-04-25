using Pastelaria.Domain.Cargo;
using Pastelaria.Domain.Cargo.Dto;
using System;
using System.Web.Http;

namespace Pastelaria.API.Controllers
{
    [RoutePrefix("api/cargo")]
    public class CargoController : ApiController
    {
        private readonly ICargoRepository _cargoRepository;

        public CargoController(ICargoRepository cargoRepository)
        {
            _cargoRepository = cargoRepository;
        }

        [HttpGet, Route("ping")]
        public IHttpActionResult Get() => Ok(_cargoRepository.Get());


        [HttpGet, Route("read")]
        public IHttpActionResult GetCargos() => Ok(_cargoRepository.GetCargos());


        [HttpPost, Route("insert")]
        public IHttpActionResult Post(CargoDto cargo)
        {
            try
            {
                _cargoRepository.Post(cargo);
                return Ok();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
            
        }

        [HttpPut, Route("update")]
        public IHttpActionResult Put(CargoDto entity)
        {
            _cargoRepository.Put(entity);
            return Ok();
        }

        [HttpDelete, Route("delete")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                _cargoRepository.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet, Route("getcargoid")]
        public IHttpActionResult GetCargoId(int id) => Ok(_cargoRepository.GetCargoId(id));

    }
}
