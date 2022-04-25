using System;

namespace Pastelaria.Domain.Permissoes.Dto
{
    public class PermissaoDto
    {
        public PermissaoDto()
        {
        }
        public int Cod_Permicao { get; set; }
        public int Num_Cargo { get; set; }
        public int Num_Funcionalidade { get; set; }
        public DateTime Dat_Rgistro { get; set; }
        public DateTime Dat_Atualizacao { get; set; }
        public string Nome_Cargo { get; set; }
        public string Nome_Funcionalidade { get; set; }
        public int Num_Permicao { get; set; }
    }
}
