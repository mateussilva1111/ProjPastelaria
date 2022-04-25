using Pastelaria.Domain.Tarefa;
using Pastelaria.Domain.Tarefra.Dto;
using Pastelaria.Domain.Ususario.Dto;
using Pastelaria.Repository.Infra;
using System;
using System.Collections.Generic;

namespace Pastelaria.Repository
{
    public class TarefaRepository : BaseRepository, ITarefaRepository
    {
        public string Get()
        {
            return "sucesso";
        }

        public IEnumerable<TarefaDto> GetTarefas()
        {
            var tarefa = new List<TarefaDto>();

            ExecuteProcedure("PTSP_SelTarefa");
            using (var reader = ExecuteReader())
                while (reader.Read())
                    tarefa.Add(new TarefaDto
                    {
                        Num_Tarefa = int.Parse(reader["Num_Tarefa"].ToString()),
                        Cod_Tarefa = int.Parse(reader["Cod_Tarefa"].ToString()),
                        Nome_Usuario = reader["Nome_Usuario"].ToString(),
                        Status_Tarefa = reader["Status_Tarefa"].ToString(),
                        Cod_Usuario = int.Parse(reader["Cod_Usuario"].ToString()),
                        Email_Gerente = reader["Desenvolvedor"].ToString(),
                        Email_Funcionario = reader["Gerente"].ToString(),
                        Nom_Tarefa = reader["Nom_Tarefa"].ToString(),
                        Descr_Tarefa = reader["Descr_Tarefa"].ToString(),
                        Dat_Rgistro = DateTime.Parse(reader["Dat_Rgistro"].ToString()),
                        Dat_Atualizacao = reader["Dat_Atualizacao"] == null ? DateTime.Now : Convert.ToDateTime(reader["Dat_Atualizacao"].ToString()),
                        Dat_Fim = reader["Dat_Fim"] == null ? DateTime.Now : Convert.ToDateTime(reader["Dat_Fim"].ToString()),
                        Num_Usuario = int.Parse(reader["Num_Usuario"].ToString())
                    });
            return tarefa;

        }

        public void Post(TarefaDto tarefa)
        {
            ExecuteProcedure("PTSP_InsTarefa");
            AddParameter("@Cod_Tarefa", tarefa.Cod_Tarefa);
            AddParameter("@Nom_Tarefa", tarefa.Nom_Tarefa);
            AddParameter("@Descr_Tarefa", tarefa.Descr_Tarefa);
            AddParameter("@Status_Tarefa", tarefa.Status_Tarefa);
            AddParameter("@Dat_Rgistro", DateTime.Now);
            AddParameter("@Num_Usuario", tarefa.Num_Usuario);
            AddParameter("@Num_Usuario_Gestor", tarefa.Num_Usuario_Gestor);
            ExecuteNonQuery();

        }

        public void Put(TarefaDto tarefa)
        {
            ExecuteProcedure("PTSP_UpdTarefa");
            AddParameter("@Num_Tarefa", tarefa.Num_Tarefa);
            AddParameter("@Cod_Tarefa", tarefa.Cod_Tarefa);
            AddParameter("@Nom_Tarefa", tarefa.Nom_Tarefa);
            AddParameter("@Descr_Tarefa", tarefa.Descr_Tarefa);
            AddParameter("@Status_Tarefa", tarefa.Status_Tarefa);
            AddParameter("@Num_Usuario", tarefa.Num_Usuario);
            AddParameter("@Num_Usuario_Gestor", tarefa.Num_Usuario_Gestor);
            ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            ExecuteProcedure("PTSP_DelTarefa");
            AddParameter("@Num_Tarefa", id);
            ExecuteNonQuery();
        }


        public void GetTarefasCod(int Cod_Tarefa)
        {
            var tarefa = new List<TarefaDto>();


            ExecuteProcedure("PTSP_SelTarefaCod");
            AddParameter("@Cod_Tarefa", Cod_Tarefa);
            using (var reader = ExecuteReader())
                while (reader.Read())
                {
                    tarefa.Add(new TarefaDto
                    {
                        Nome_Usuario = reader["Nome_Usuario"].ToString(),
                        Nome_UsuarioGestor = reader["Nome_UsuarioGestor"].ToString(),
                        Email_Gerente = reader["Desenvolvedor"].ToString(),
                        Email_Funcionario = reader["Gerente"].ToString(),
                        Nom_Tarefa = reader["Nom_Tarefa"].ToString(),
                        Descr_Tarefa = reader["Descr_Tarefa"].ToString(),
                        Dat_Rgistro = DateTime.Parse(reader["Dat_Rgistro"].ToString()),
                        Dat_Atualizacao = Convert.ToDateTime(reader["Dat_Atualizacao"].ToString()),
                        Dat_Fim = Convert.ToDateTime(reader["Dat_Fim"].ToString())
                    });
                }

        }

        public TarefaDto GetTarefaId(int id)
        {
            ExecuteProcedure("PTSP_SelTarefaId");
            AddParameter("@Num_Tarefa", id);

            using (var reader = ExecuteReader())
                if (reader.Read())
                    return new TarefaDto
                    {
                        Num_Tarefa = int.Parse(reader["Num_Tarefa"].ToString()),
                        Nome_Usuario = reader["Nome_Usuario"].ToString(),
                        Cod_Usuario = int.Parse(reader["Cod_Usuario"].ToString()),
                        Cod_Tarefa = int.Parse(reader["Cod_Tarefa"].ToString()),
                        Email_Gerente = reader["Desenvolvedor"].ToString(),
                        Email_Funcionario = reader["Gerente"].ToString(),
                        Nom_Tarefa = reader["Nom_Tarefa"].ToString(),
                        Status_Tarefa = reader["Status_Tarefa"].ToString(),
                        Descr_Tarefa = reader["Descr_Tarefa"].ToString(),
                        Dat_Rgistro = DateTime.Parse(reader["Dat_Rgistro"].ToString()),
                        Dat_Atualizacao = Convert.ToDateTime(reader["Dat_Atualizacao"].ToString()),
                        Dat_Fim = Convert.ToDateTime(reader["Dat_Fim"].ToString()),
                        Num_Usuario = int.Parse(reader["Num_Usuario"].ToString())
                    };
            return null;
        }

        public IEnumerable<TarefaDto> GetTarefaUser(int id)
        {
            var tarefa = new List<TarefaDto>();

            ExecuteProcedure("PTSP_SelTarefaUsuario");
            AddParameter("@Num_Usuario", id);
            using (var reader = ExecuteReader())
                while (reader.Read())
                    tarefa.Add(new TarefaDto
                    {
                        Num_Tarefa = int.Parse(reader["Num_Tarefa"].ToString()),
                        Cod_Tarefa = int.Parse(reader["Cod_Tarefa"].ToString()),
                        Nome_Usuario = reader["Nome_Usuario"].ToString(),
                        Status_Tarefa = reader["Status_Tarefa"].ToString(),
                        Cod_Usuario = int.Parse(reader["Cod_Usuario"].ToString()),
                        Email_Gerente = reader["Desenvolvedor"].ToString(),
                        Email_Funcionario = reader["Gerente"].ToString(),
                        Nom_Tarefa = reader["Nom_Tarefa"].ToString(),
                        Descr_Tarefa = reader["Descr_Tarefa"].ToString(),
                        Dat_Rgistro = DateTime.Parse(reader["Dat_Rgistro"].ToString()),
                        Dat_Atualizacao = reader["Dat_Atualizacao"] == null ? DateTime.Now : Convert.ToDateTime(reader["Dat_Atualizacao"].ToString()),
                        Dat_Fim = reader["Dat_Fim"] == null ? DateTime.Now : Convert.ToDateTime(reader["Dat_Fim"].ToString()),
                        Num_Usuario = int.Parse(reader["Num_Usuario"].ToString())
                    });
            return tarefa;
        }

        public void FinalizaTarefa(int id)
        {
            ExecuteProcedure("PTSP_FinTarefa");
            AddParameter("@Num_Tarefa", id);
            ExecuteNonQuery();
        }

        public UsuarioDto GetUsuarioId(int id)
        {
            UsuarioDto user;
            ExecuteProcedure("PTSP_SelUsuariosId");
            AddParameter("@Num_Usuario", id);
            using (var reader = ExecuteReader())
                if (reader.Read())
                    return user = new UsuarioDto
                    {
                        Num_Usuario = int.Parse(reader["Num_Usuario"].ToString()),
                        Cod_Usuario = int.Parse(reader["Cod_Usuario"].ToString()),
                        Dat_Atualizacao = DateTime.Parse(reader["Dat_Atualizacao"].ToString()),
                        Nome_Usuario = reader["Nome_Usuario"].ToString(),
                        Dat_Nascimento = DateTime.Parse(reader["Dat_Nascimento"].ToString()),
                        Num_TelFixo = reader["Num_TelFixo"].ToString(),
                        Num_Celular = reader["Num_Celular"].ToString(),
                        Email_Usuario = reader["Email_Usuario"].ToString(),
                        Senha_Usuario = reader["Senha_Usuario"].ToString(),
                        Foto_usuario = reader["Foto_usuario"].ToString()
                    };
            return null;
        }
    }
}
