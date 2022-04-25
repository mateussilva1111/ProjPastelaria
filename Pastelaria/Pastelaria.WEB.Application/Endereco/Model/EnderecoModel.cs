using System;

namespace Pastelaria.WEB.Application.Endereco.Model
{
    public class EnderecoModel
    {
        public int Num_Endereco { get; set; }
        public string CEP_Usuario { get; set; }
        public string Est_Usuario { get; set; }
        public string Cid_Usuario { get; set; }
        public int Cod_CidUsuario { get; set; }
        public string Tp_LogradouroUsuario { get; set; }
        public string Nome_Logradouro { get; set; }
        public string Bairro_Usuario { get; set; }
        public int Num_Residencia { get; set; }
        public string Compl_Endereco { get; set; }
        public DateTime? Dat_RgistroEnd { get; set; }
        public DateTime? Dat_AtualizacaoEnd { get; set; }
        public int Num_Usuario { get; set; }
    }
}
