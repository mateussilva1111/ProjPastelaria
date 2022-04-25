using Pastelaria.Domain.Endereco.Dto;
using System;
using System.Web.Http;

namespace Pastelaria.API.Controllers
{
    [RoutePrefix("api/endereco")]
    public class EnderecoController : ApiController
    {

        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoController(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        [HttpGet, Route("ping")]
        public IHttpActionResult Get() => Ok(_enderecoRepository.Get());


        [HttpGet, Route("read")]
        public IHttpActionResult GetEnderecos() => Ok(_enderecoRepository.GetEnderecos());

        [HttpGet, Route("getenderecodid")]
        public IHttpActionResult GetEnderecoId(int id) => Ok(_enderecoRepository.GetEnderecoId(id));


        [HttpPost, Route("insert")]
        public IHttpActionResult Post(EnderecoDto endereco)
        {
            try
            {
                _enderecoRepository.Post(endereco);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

        [HttpPut, Route("update")]
        public IHttpActionResult Put(EnderecoDto entity)
        {
            _enderecoRepository.Put(entity);
            return Ok();
        }

        [HttpDelete, Route("delete")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                _enderecoRepository.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


    }
}