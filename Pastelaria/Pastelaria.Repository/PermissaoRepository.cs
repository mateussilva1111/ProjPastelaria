using Pastelaria.Domain.Permissoes;
using Pastelaria.Domain.Permissoes.Dto;
using System;
using System.Collections.Generic;

namespace Pastelaria.Repository.Infra
{
    public class PermissaoRepository : BaseRepository, IPermissaoRepository
    {
       

        public string Get()
        {
            return "sucesso";
        }

        public IEnumerable<PermissaoDto> Getpermissao()
        {
            var permissao = new List<PermissaoDto>();

            ExecuteProcedure("PTSP_SelPermicoes");
            using (var reader = ExecuteReader())
                while (reader.Read())
                    permissao.Add(new PermissaoDto
                    {
                        Nome_Cargo = reader["Nome_Cargo"].ToString(),
                        Nome_Funcionalidade = reader["Nome_Funcionalidade"].ToString(),
                        Dat_Rgistro = DateTime.Parse(reader["Dat_Rgistro"].ToString()),
                        Dat_Atualizacao = Convert.ToDateTime(reader["Dat_Atualizacao"].ToString()),
                    });
            return permissao;
        }




        public void Post(PermissaoDto permissao)
        {
            ExecuteProcedure("PTSP_InsPermicao");
            AddParameter("@Cod_Permicao", permissao.Cod_Permicao);
            AddParameter("@Num_Cargo", permissao.Num_Cargo);
            AddParameter("@Num_Funcionalidade", permissao.Num_Funcionalidade);
            AddParameter("@Dat_Rgistro", DateTime.Now);
            AddParameter("@Dat_Atualizacao", DateTime.Now);
            ExecuteNonQuery();
        }

        public void Put(PermissaoDto permissao)
        {
            ExecuteProcedure("PTSP_UpdPermicao");
            AddParameter("@Num_Permicao", permissao.Num_Permicao);
            AddParameter("@Cod_Permicao", permissao.Cod_Permicao);
            AddParameter("@Num_Cargo", permissao.Num_Cargo);
            AddParameter("@Num_Funcionalidade", permissao.Num_Funcionalidade);
            AddParameter("@Dat_Atualizacao", DateTime.Now);
            ExecuteNonQuery();

        }

        public void Delete(int id)
        {
            ExecuteProcedure("PTSP_DelPermicao");
            AddParameter("@Num_Permicao", id);
            ExecuteNonQuery();
        }

        public List<PermissaoDto> GetpermissaoUser(int id)
        {
            var permissao = new List<PermissaoDto>();

            ExecuteProcedure("PTSP_SelPermissoesUsuario");
            AddParameter("@Num_usuario", id);
            using (var reader = ExecuteReader())
                while (reader.Read())
                    permissao.Add(new PermissaoDto
                    {
                        Nome_Funcionalidade = reader["Nome_Funcionalidade"].ToString(),
                        Num_Funcionalidade = int.Parse(reader["Num_Funcionalidade"].ToString())
                    });
            return permissao;
        }


    }
}
