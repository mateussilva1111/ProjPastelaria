using Pastelaria.Domain.Permissoes;
using Pastelaria.Domain.Permissoes.Dto;
using System;
using System.Web.Http;

namespace Pastelaria.API.Controllers
{
    [RoutePrefix("api/permissao")]
    public class PermissaoController : ApiController
    {
        private readonly IPermissaoRepository _permissaoRepository;

        public PermissaoController(IPermissaoRepository permissaoRepository)
        {
            _permissaoRepository = permissaoRepository;
        }

        [HttpGet, Route("ping")]
        public IHttpActionResult Get() => Ok(_permissaoRepository.Get());


        [HttpGet, Route("read")]
        public IHttpActionResult Getpermissao() => Ok(_permissaoRepository.Getpermissao());


        [HttpPost, Route("insert")]
        public IHttpActionResult Post(PermissaoDto permissao)
        {
            try
            {
                _permissaoRepository.Post(permissao);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

        [HttpPut, Route("update")]
        public IHttpActionResult Put(PermissaoDto permissao)
        {
            _permissaoRepository.Put(permissao);
            return Ok();
        }

        [HttpDelete, Route("delete")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                _permissaoRepository.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

    }
}