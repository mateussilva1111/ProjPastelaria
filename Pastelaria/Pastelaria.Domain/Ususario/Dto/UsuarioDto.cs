using Pastelaria.Domain.Permissoes.Dto;
using System;
using System.Collections.Generic;

namespace Pastelaria.Domain.Ususario.Dto
{
    public class UsuarioDto
    {
        public int Cod_Usuario { get; set; }
        public string Nome_Cargo { get; set; }
        public DateTime? Dat_Rgistro { get; set; }
        public DateTime? Dat_Atualizacao { get; set; }
        public string Nome_Usuario { get; set; }
        public DateTime? Dat_Nascimento { get; set; }
        public string Num_TelFixo { get; set; }
        public string Num_Celular { get; set; }
        public string Email_Usuario { get; set; }
        public string Senha_Usuario { get; set; }
        public string Foto_usuario { get; set; }
        public int Num_Cargo { get; set; }
        public int Num_Usuario { get; set; }
        public List<PermissaoDto> Permissoes { get; set; }
    }
}
