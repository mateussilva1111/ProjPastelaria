using Pastelaria.Domain.Tarefra.Dto;

namespace Pastelaria.Domain.Tarefa
{
    public interface ITarefaService
    {

        void PostTarefa(TarefaDto tarefa);
        string FinalizaTarefa(int id);
    }
}
