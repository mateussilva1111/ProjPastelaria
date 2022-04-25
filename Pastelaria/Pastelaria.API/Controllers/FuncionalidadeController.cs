using Pastelaria.Domain.Funcionalidade;
using Pastelaria.Domain.Funcionalidade.Dto;
using System;
using System.Web.Http;

namespace Pastelaria.API.Controllers
{
    [RoutePrefix("api/funcionalidade")]
    public class FuncionalidadeController : ApiController
    {
        private readonly IFuncionalidadeRepository _funcionalidadeRepository;

        public FuncionalidadeController(IFuncionalidadeRepository funcionalidadeRepository)
        {
            _funcionalidadeRepository = funcionalidadeRepository;
        }

        [HttpGet, Route("ping")]
        public IHttpActionResult Get() => Ok(_funcionalidadeRepository.Get());


        [HttpGet, Route("read")]
        public IHttpActionResult GetFuncionalidades() => Ok(_funcionalidadeRepository.GetFuncionalidades());

        [HttpPost, Route("insert")]
        public IHttpActionResult Post(FuncionalidadeDto funcionalidade)
        {
            try
            {
                _funcionalidadeRepository.Post(funcionalidade);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

        [HttpPut, Route("update")]
        public IHttpActionResult Put(FuncionalidadeDto funcionalidade)
        {
            _funcionalidadeRepository.Put(funcionalidade);
            return Ok();
        }

        [HttpDelete, Route("delete")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                _funcionalidadeRepository.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


    }
}