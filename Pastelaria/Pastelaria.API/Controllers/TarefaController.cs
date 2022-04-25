using Pastelaria.Domain.Tarefa;
using Pastelaria.Domain.Tarefra.Dto;
using System;
using System.Web.Http;

namespace Pastelaria.API.Controllers
{
    [RoutePrefix("api/tarefa")]
    public class TarefaController : ApiController
    {
        private readonly ITarefaRepository _tarefaRepository;
        private readonly ITarefaService _tarefaService;

        public TarefaController(ITarefaRepository tarefaRepository, ITarefaService tarefaService)
        {
            _tarefaRepository = tarefaRepository;
            _tarefaService = tarefaService;
        }


        [HttpGet, Route("ping")]
        public IHttpActionResult Get() => Ok(_tarefaRepository.Get());


        [HttpGet, Route("read")]
        public IHttpActionResult GetTarefas() => Ok(_tarefaRepository.GetTarefas());

        [HttpGet, Route("readforCod")]
        public IHttpActionResult GetTarefasForCod(int cod)
        {
            _tarefaRepository.GetTarefasCod(cod);
            return Ok();
        } 


        [HttpPost, Route("post")]
        public IHttpActionResult Post(TarefaDto tarefa)
        {
            try
            {
                _tarefaService.PostTarefa(tarefa);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

        [HttpPut, Route("update")]
        public IHttpActionResult Put(TarefaDto tarefa)
        {
            _tarefaRepository.Put(tarefa);
            return Ok();
        }

        [HttpDelete, Route("delete")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                _tarefaRepository.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        [HttpGet, Route("gettarefaid")]
        public IHttpActionResult GetTarefaId(int id) => Ok(_tarefaRepository.GetTarefaId(id));

        [HttpGet, Route("gettarefauser")]
        public IHttpActionResult GetTarefaUser(int id) => Ok(_tarefaRepository.GetTarefaUser(id));

        [HttpGet, Route("finalizatarefa")]
        public IHttpActionResult FinalizaTarefa(int id) => Ok(_tarefaService.FinalizaTarefa(id));
        
    }
}