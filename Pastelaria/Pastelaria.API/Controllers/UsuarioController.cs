using Pastelaria.Domain.Ususario;
using Pastelaria.Domain.Ususario.Dto;
using System;
using System.Web.Http;

namespace Pastelaria.API.Controllers
{
    [RoutePrefix("api/usuario")]
    public class UsuarioController : ApiController
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUsuarioService _usuarioService;

        

        public UsuarioController(IUsuarioRepository usuarioRepository, IUsuarioService usuarioService)
        {
            _usuarioRepository = usuarioRepository;
            _usuarioService = usuarioService;
        }


        [HttpGet, Route("ping")]
        public IHttpActionResult Get() => Ok(_usuarioRepository.Get());


        [HttpGet, Route("usuarios")]
        public IHttpActionResult GetUsuario() => Ok(_usuarioRepository.GetUsuario());



        [HttpPost, Route("")]
        public IHttpActionResult Post(UsuarioDto usuario)
        {
            _usuarioRepository.Post(usuario);
            return Ok();
        }

        [HttpPost, Route("login")]
        public IHttpActionResult PostLogin(UsuarioDto usuario)
        {
            try
            {
                return Ok(_usuarioService.PostLogin(usuario));
            }
            catch(Exception e)
            {
                return BadRequest(e.ToString());
            }
            
        }

        [HttpPut, Route("update")]
        public IHttpActionResult Put(UsuarioDto usuario)
        {
            _usuarioRepository.Put(usuario);
            return Ok();
        }

        [HttpDelete, Route("delete")]
        public IHttpActionResult Delete(int id)
        {
            _usuarioRepository.Delete(id);
            return Ok();
        }


        [HttpGet, Route("getuserid")]
        public IHttpActionResult GetUsuarioId(int id) => Ok(_usuarioRepository.GetUsuarioId(id));

        [HttpPut, Route("putuser")]
        public IHttpActionResult PutUser(UsuarioDto usuario)
        {
            _usuarioRepository.PutUser(usuario);
            return Ok();
        }

       

    }
}