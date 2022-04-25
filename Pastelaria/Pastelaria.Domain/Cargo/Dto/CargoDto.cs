using System;

namespace Pastelaria.Domain.Cargo.Dto
{
    public class CargoDto
    {
        public int Num_Cargo { get; set; }
        public string Nome_Cargo { get; set; }
        public DateTime? Dat_Rgistro { get; set; }
        public DateTime? Dat_Atualizacao { get; set; }
    }

   
}
