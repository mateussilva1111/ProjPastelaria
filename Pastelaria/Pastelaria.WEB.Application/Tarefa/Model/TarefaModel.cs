using System;

namespace Pastelaria.WEB.Application.Tarefa
{
    public class TarefaModel
    {
        public int Num_Tarefa { get; set; }
        public int Cod_Tarefa { get; set; }
        public string Nom_Tarefa { get; set; }
        public string Nome_UsuarioGestor { get; set; }
        public string Descr_Tarefa { get; set; }
        public string Status_Tarefa { get; set; }
        public DateTime? Dat_Rgistro { get; set; }
        public DateTime? Dat_Atualizacao { get; set; }
        public DateTime? Dat_Fim { get; set; }
        public int Num_Usuario { get; set; }
        public int Num_Usuario_Gestor { get; set; }
        public string Nome_Usuario { get; set; }
        public int Cod_Usuario { get; set; }
        public string Email_Gerente { get; set; }
        public string Email_Funcionario { get; set; }
    }
}
