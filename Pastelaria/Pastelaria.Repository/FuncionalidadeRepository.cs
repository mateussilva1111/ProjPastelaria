using Pastelaria.Domain.Funcionalidade;
using Pastelaria.Domain.Funcionalidade.Dto;
using System;
using System.Collections.Generic;

namespace Pastelaria.Repository.Infra
{
    public class FuncionalidadeRepository : BaseRepository, IFuncionalidadeRepository
    {
        

        public string Get()
        {
            return "sucesso";
        }

        public IEnumerable<FuncionalidadeDto> GetFuncionalidades()
        {
            var funcionalidade = new List<FuncionalidadeDto>();

            ExecuteProcedure("PTSP_SelFuncionalidades");
            using (var reader = ExecuteReader())
                while (reader.Read())
                    funcionalidade.Add(new FuncionalidadeDto
                    {
                        Cod_Funcionalidade = int.Parse(reader["Nome_Cargo"].ToString()),
                        Nome_Funcionalidade = reader["Dat_Rgistro"].ToString(),
                        Dat_RgistroFun = Convert.ToDateTime(reader["Dat_Atualizacao"].ToString()),
                        Dat_AtualizacaoFUN = Convert.ToDateTime(reader["Dat_Atualizacao"].ToString())
                    });
            return funcionalidade;
        }

        public void Post(FuncionalidadeDto funcionalidade)
        {
            ExecuteProcedure("PTSP_InsFuncionalidade");
            AddParameter("@Cod_Funcionalidade", funcionalidade.Cod_Funcionalidade);
            AddParameter("@Nome_Funcionalidade", funcionalidade.Nome_Funcionalidade);
            AddParameter("@Dat_RgistroFun", funcionalidade.Dat_RgistroFun);
            AddParameter("@Dat_AtualizacaoFUN", funcionalidade.Dat_AtualizacaoFUN);
            ExecuteNonQuery();
        }

        public void Put(FuncionalidadeDto funcionalidade)
        {
            ExecuteProcedure("PTSP_UpdFuncionalidade");
            AddParameter("@Cod_Funcionalidade", funcionalidade.Cod_Funcionalidade);
            AddParameter("@Nome_Funcionalidade", funcionalidade.Nome_Funcionalidade);
            AddParameter("@Dat_RgistroFun", funcionalidade.Dat_RgistroFun);
            AddParameter("@Dat_AtualizacaoFUN", funcionalidade.Dat_AtualizacaoFUN);
            ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            ExecuteProcedure("PTSP_Delfuncionalidade");
            AddParameter("@Num_Funcionalidade", id);

            ExecuteNonQuery();
        }
    }
}
