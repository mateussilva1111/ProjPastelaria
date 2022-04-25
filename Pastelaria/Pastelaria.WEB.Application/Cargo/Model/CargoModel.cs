using System;

namespace Pastelaria.WEB.Application.Cargo.Model
{
    public class CargoModel
    {
        public int Num_Cargo { get; set; }
        public string Nome_Cargo { get; set; }
        public DateTime? Dat_Rgistro { get; set; }
        public DateTime? Dat_Atualizacao { get; set; }
    }
}
