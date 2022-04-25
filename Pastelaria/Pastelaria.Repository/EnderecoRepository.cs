using Pastelaria.Domain.Endereco.Dto;
using System;
using System.Collections.Generic;

namespace Pastelaria.Repository.Infra
{
    public class EnderecoRepository : BaseRepository, IEnderecoRepository
    {
        public string Get()
        {
            return "sucesso";
        }

        public IEnumerable<EnderecoDto> GetEnderecos()
        {
            var enderecos = new List<EnderecoDto>();

            ExecuteProcedure("PTSP_SelEndereco");
            using (var reader = ExecuteReader())
                while (reader.Read())
                    enderecos.Add(new EnderecoDto
                    {
                        Num_Endereco = int.Parse(reader["Num_Endereco"].ToString()),
                        CEP_Usuario = reader["CEP_Usuario"].ToString(),
                        Est_Usuario = reader["Est_Usuario"].ToString(),
                        Cid_Usuario = reader["Cid_Usuario"].ToString(),
                        Cod_CidUsuario = int.Parse(reader["Cod_CidUsuario"].ToString()),
                        Tp_LogradouroUsuario = reader["Tp_LogradouroUsuario"].ToString(),
                        Nome_Logradouro = reader["Nome_Logradouro"].ToString(),
                        Bairro_Usuario = reader["Bairro_Usuario"].ToString(),
                        Num_Residencia = int.Parse(reader["Num_Residencia"].ToString()),
                        Compl_Endereco = reader["Compl_Endereco"].ToString(),
                        Dat_RgistroEnd = DateTime.Parse(reader["Dat_RgistroEnd"].ToString()),
                        Dat_AtualizacaoEnd = DateTime.Parse(reader["Dat_AtualizacaoEnd"].ToString())
                    });
            return enderecos;
        }

        public void Post(EnderecoDto endereco)
        {
            ExecuteProcedure("PTSP_InsEndereco");
            AddParameter("@CEP_Usuario", endereco.CEP_Usuario);
            AddParameter("@Est_Usuario", endereco.Est_Usuario);
            AddParameter("@Cid_Usuario", endereco.Cid_Usuario);
            AddParameter("@Cod_CidUsuario", endereco.Cod_CidUsuario);
            AddParameter("@Tp_LogradouroUsuario", endereco.Tp_LogradouroUsuario);
            AddParameter("@Nome_Logradouro", endereco.Nome_Logradouro);
            AddParameter("@Bairro_Usuario", endereco.Bairro_Usuario);
            AddParameter("@Num_Residencia", endereco.Num_Residencia);
            AddParameter("@Compl_Endereco", endereco.Compl_Endereco);
            AddParameter("@Num_Usuario", endereco.Num_Usuario);
            ExecuteNonQuery();

        }

        public void Put(EnderecoDto endereco)
        {
            ExecuteProcedure("PTSP_Updendereco");
            AddParameter("@Num_Endereco", endereco.Num_Endereco);
            AddParameter("@CEP_Usuario", endereco.CEP_Usuario);
            AddParameter("@Est_Usuario", endereco.Est_Usuario);
            AddParameter("@Cid_Usuario", endereco.Cid_Usuario);
            AddParameter("@Cod_CidUsuario", endereco.Cod_CidUsuario);
            AddParameter("@Tp_LogradouroUsuario", endereco.Tp_LogradouroUsuario);
            AddParameter("@Nome_Logradouro", endereco.Nome_Logradouro);
            AddParameter("@Bairro_Usuario", endereco.Bairro_Usuario);
            AddParameter("@Num_Residencia", endereco.Num_Residencia);
            AddParameter("@Compl_Endereco", endereco.Compl_Endereco);
           
            ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            ExecuteProcedure("PTSP_DelEndereco");
            AddParameter("@Num_Endereco", id);
            ExecuteNonQuery();
        }

        public EnderecoDto GetEnderecoId(int id)
        {
            ExecuteProcedure("PTSP_SelEnderecoId");
            AddParameter("@Num_Usuario", id);
            using (var reader = ExecuteReader())
                if (reader.Read())
                    return new EnderecoDto
                    {
                        Num_Endereco = int.Parse(reader["Num_Endereco"].ToString()),
                        CEP_Usuario = reader["CEP_Usuario"].ToString(),
                        Est_Usuario = reader["Est_Usuario"].ToString(),
                        Cid_Usuario = reader["Cid_Usuario"].ToString(),
                        Cod_CidUsuario = int.Parse(reader["Cod_CidUsuario"].ToString()),
                        Tp_LogradouroUsuario = reader["Tp_LogradouroUsuario"].ToString(),
                        Nome_Logradouro = reader["Nome_Logradouro"].ToString(),
                        Bairro_Usuario = reader["Bairro_Usuario"].ToString(),
                        Num_Residencia = int.Parse(reader["Num_Residencia"].ToString()),
                        Compl_Endereco = reader["Compl_Endereco"].ToString(),
                        Dat_RgistroEnd = DateTime.Parse(reader["Dat_RgistroEnd"].ToString()),
                        Dat_AtualizacaoEnd = DateTime.Parse(reader["Dat_AtualizacaoEnd"].ToString())
                    };
            return null;
        }
    }
}
