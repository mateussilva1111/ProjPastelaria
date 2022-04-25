using Pastelaria.Domain.Cargo;
using Pastelaria.Domain.Cargo.Dto;
using Pastelaria.Repository.Infra;
using System;
using System.Collections.Generic;

namespace Pastelaria.Repository
{
    public class CargoRepository : BaseRepository, ICargoRepository
    {
        public string Get()
        {
            return "sucesso";
        }

        public void Post(CargoDto cargo)
        {
            ExecuteProcedure("PTSP_InsCargo");
            AddParameter("@Nome_Cargo", cargo.Nome_Cargo);
            AddParameter("@Dat_Rgistro", DateTime.Now);
            AddParameter("@Dat_Atualizacao", DateTime.Now);
            ExecuteNonQuery();
        }

        public IEnumerable<CargoDto> GetCargos()
        {
            var cargos = new List<CargoDto>();

            ExecuteProcedure("PTSP_SelCargo");
            using (var reader = ExecuteReader())
                while (reader.Read())
                    cargos.Add(new CargoDto
                    {
                        Num_Cargo = int.Parse(reader["Num_Cargo"].ToString()),
                        Nome_Cargo = reader["Nome_Cargo"].ToString(),
                        Dat_Rgistro = DateTime.Parse(reader["Dat_Rgistro"].ToString()),
                        Dat_Atualizacao = Convert.ToDateTime(reader["Dat_Atualizacao"].ToString())
                    }); 
            return cargos;
        }

        public void Put(CargoDto cargo)
        {
            ExecuteProcedure("PTSP_UpdCargo");
            AddParameter("@Num_Cargo", cargo.Num_Cargo);
            AddParameter("@Nome_Cargo", cargo.Nome_Cargo);
            AddParameter("@Dat_Atualizacao", DateTime.Now);
            ExecuteNonQuery();

        }

        public void Delete(int id)
        {
            ExecuteProcedure("PTSP_DelCargo");
            AddParameter("@Num_Cargo", id);

            ExecuteNonQuery();

        }

        public CargoDto GetCargoId(int id)
        {
            ExecuteProcedure("PTSP_SelCargoId");
            AddParameter("@Num_Cargo", id);
            using (var reader = ExecuteReader())
                while (reader.Read())
                    return new CargoDto
                    {
                        Num_Cargo = int.Parse(reader["Num_Cargo"].ToString()),
                        Nome_Cargo = reader["Nome_Cargo"].ToString(),
                        Dat_Rgistro = DateTime.Parse(reader["Dat_Rgistro"].ToString()),
                        Dat_Atualizacao = Convert.ToDateTime(reader["Dat_Atualizacao"].ToString())
                    };
            return null;

        }
    }
}
