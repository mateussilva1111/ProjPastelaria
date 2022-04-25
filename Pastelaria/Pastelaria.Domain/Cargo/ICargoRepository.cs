using Pastelaria.Domain.Cargo.Dto;
using System.Collections.Generic;

namespace Pastelaria.Domain.Cargo
{
    public interface ICargoRepository
    {
        string Get();
        IEnumerable<CargoDto> GetCargos();
        CargoDto GetCargoId(int id);
        void Post(CargoDto cargo);
        void Put(CargoDto cargo);
        void Delete(int id);
    }
}
