using System;

namespace Pastelaria.Domain.Funcionalidade.Dto
{
    public class FuncionalidadeDto
    {
        public FuncionalidadeDto()
        {
        }
        public int Cod_Funcionalidade { get; set; }
        public string Nome_Funcionalidade { get; set; }
        public DateTime Dat_RgistroFun { get; set; }
        public DateTime Dat_AtualizacaoFUN { get; set; }
    }
}
