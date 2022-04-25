using Pastelaria.Domain.Tarefra.Dto;
using Pastelaria.Domain.Ususario.Dto;
using System.Collections.Generic;

namespace Pastelaria.Domain.Tarefa
{
    public interface ITarefaRepository
    {
        string Get();
        IEnumerable<TarefaDto> GetTarefas();
        IEnumerable<TarefaDto> GetTarefaUser(int id);
        void GetTarefasCod(int Cod_Tarefa);
        void Post(TarefaDto tarefa);
        void Put(TarefaDto tarefa);
        void Delete(int id);
        void FinalizaTarefa(int id);
        TarefaDto GetTarefaId(int Cod_Tarefa);
        UsuarioDto GetUsuarioId(int id);
    }
}
