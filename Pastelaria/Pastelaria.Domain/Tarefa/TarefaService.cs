using Pastelaria.Domain.Tarefra.Dto;
using Pastelaria.Domain.Ususario.Dto;
using System;

namespace Pastelaria.Domain.Tarefa
{
    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository _tarefaRepository;
        


        public TarefaService(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
           
        }

        public void PostTarefa(TarefaDto tarefa)
        {
            UsuarioDto user = _tarefaRepository.GetUsuarioId(tarefa.Num_Usuario);
            Infra.DisparoEmailService.SendEmail(user.Email_Usuario, tarefa.Nom_Tarefa + " está sob sua responsabilidade!", "TarefaCriada");
            _tarefaRepository.Post(tarefa);
            
        }

        public string FinalizaTarefa(int id)
        {
            try
            {
                TarefaDto tarefa = _tarefaRepository.GetTarefaId(id);
                Infra.DisparoEmailService.SendEmail(tarefa.Email_Gerente, "" + tarefa.Nom_Tarefa + " Finalizada", "Tarefa Finalizada");
                _tarefaRepository.FinalizaTarefa(id);
                return "sucesso";
            }
            catch (Exception)
            {
                return "erro";
            }
            
        }


    }
}
