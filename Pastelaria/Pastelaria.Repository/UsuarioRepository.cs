using Pastelaria.Domain.Ususario;
using Pastelaria.Domain.Ususario.Dto;
using Pastelaria.Repository.Infra;
using System;
using System.Collections.Generic;

namespace Pastelaria.Repository
{
    public class UsuarioRepository : BaseRepository, IUsuarioRepository
    {

        public string Get()
        {
            return "sucesso";
        }

        public IEnumerable<UsuarioDto> GetUsuario()
        {
            var usuarios = new List<UsuarioDto>();

            ExecuteProcedure("PTSP_SelUsuarios");
            using (var reader = ExecuteReader())
                while (reader.Read())
                    usuarios.Add(new UsuarioDto
                    {
                        Num_Usuario = int.Parse(reader["Num_Usuario"].ToString()),
                        Nome_Cargo = reader["Nome_Cargo"].ToString(),
                        Nome_Usuario = reader["Nome_Usuario"].ToString(),
                        Dat_Nascimento = DateTime.Parse(reader["Dat_Nascimento"].ToString()),
                        Num_TelFixo = reader["Num_TelFixo"].ToString(),
                        Num_Celular = reader["Num_Celular"].ToString(),
                        Email_Usuario = reader["Email_Usuario"].ToString(),
                        Senha_Usuario = reader["Senha_Usuario"].ToString(),
                        Foto_usuario = reader["Foto_usuario"].ToString(),
                        Num_Cargo = int.Parse(reader["Num_Cargo"].ToString())

                    });
            return usuarios;
            //

        }

        public void Post(UsuarioDto usuario)
        {
            DateTime date = DateTime.Parse(usuario.Dat_Nascimento.ToString());
            ExecuteProcedure("PTSP_InsUsuario");
            AddParameter("@Cod_Usuario", usuario.Cod_Usuario);
            AddParameter("@Dat_Rgistro", DateTime.Now);
            AddParameter("@Nome_Usuario", usuario.Nome_Usuario);
            AddParameter("@Dat_Nascimento", date.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss"));
            AddParameter("@Num_TelFixo", usuario.Num_TelFixo);
            AddParameter("@Num_Celular", usuario.Num_Celular);
            AddParameter("@Email_Usuario", usuario.Email_Usuario);
            AddParameter("@Senha_Usuario", usuario.Senha_Usuario);
            AddParameter("@Foto_usuario", usuario.Foto_usuario);
            AddParameter("@Num_Cargo", 2);
            ExecuteNonQuery();

        }

        public void Put(UsuarioDto usuario)
        {
            ExecuteProcedure("PTSP_UpdUsuario");
            AddParameter("@Num_Usuario", usuario.Num_Usuario);
            AddParameter("@Nome_Usuario", usuario.Nome_Usuario);
            AddParameter("@Dat_Nascimento", usuario.Dat_Nascimento);
            AddParameter("@Num_TelFixo", usuario.Num_TelFixo);
            AddParameter("@Num_Celular", usuario.Num_Celular);
            AddParameter("@Email_Usuario", usuario.Email_Usuario);
            AddParameter("@Senha_Usuario", usuario.Senha_Usuario);
            AddParameter("@Foto_usuario", usuario.Foto_usuario);
            AddParameter("@Num_Cargo", usuario.Num_Cargo);
            ExecuteNonQuery();

        }

        public void Delete(int id)
        {
            ExecuteProcedure("PTSP_DelUsuario");
            AddParameter("@Num_Usuario", id);
            ExecuteNonQuery();
        }


        public UsuarioDto PostLogin(UsuarioDto usuario)
        {
            ExecuteProcedure("PTSP_Login");
            AddParameter("@Email_Usuario", usuario.Email_Usuario);
            AddParameter("@Senha_Usuario", usuario.Senha_Usuario);
            using (var reader = ExecuteReader())
                if (reader.Read())
                    return new UsuarioDto
                    {
                        Num_Usuario = int.Parse(reader["Num_Usuario"].ToString()),
                        Cod_Usuario = int.Parse(reader["Cod_Usuario"].ToString()),
                        Nome_Usuario = reader["Nome_Usuario"].ToString(),
                        Dat_Nascimento = DateTime.Parse(reader["Dat_Nascimento"].ToString()),
                        Num_TelFixo = reader["Num_TelFixo"].ToString(),
                        Num_Celular = reader["Num_Celular"].ToString(),
                        Email_Usuario = reader["Email_Usuario"].ToString(),
                        Senha_Usuario = reader["Senha_Usuario"].ToString(),
                        Foto_usuario = reader["Foto_usuario"].ToString(),
                        Num_Cargo = int.Parse(reader["Num_Cargo"].ToString()),
                        Permissoes = null
                    };

            return null;
        }


        public UsuarioDto GetUsuarioId(int id)
        {
            UsuarioDto user;
            ExecuteProcedure("PTSP_SelUsuariosId");
            AddParameter("@Num_Usuario", id);
            using (var reader = ExecuteReader())
                if (reader.Read())
                    return user = new UsuarioDto
                {
                    Num_Usuario = int.Parse(reader["Num_Usuario"].ToString()),
                    Cod_Usuario = int.Parse(reader["Cod_Usuario"].ToString()),
                    Nome_Usuario = reader["Nome_Usuario"].ToString(),
                    Dat_Nascimento = DateTime.Parse(reader["Dat_Nascimento"].ToString()),
                    Num_TelFixo = reader["Num_TelFixo"].ToString(),
                    Num_Celular = reader["Num_Celular"].ToString(),
                    Email_Usuario = reader["Email_Usuario"].ToString(),
                    Senha_Usuario = reader["Senha_Usuario"].ToString(),
                    Foto_usuario = reader["Foto_usuario"].ToString()
                };
            return null;
        }

        public void PutUser(UsuarioDto usuario)
        {
            ExecuteProcedure("PTSP_UpdUsuarioPerfil");
            AddParameter("@Num_Usuario", usuario.Num_Usuario);
            AddParameter("@Nome_Usuario", usuario.Nome_Usuario);
            AddParameter("@Dat_Nascimento", usuario.Dat_Nascimento);
            AddParameter("@Num_TelFixo", usuario.Num_TelFixo);
            AddParameter("@Num_Celular", usuario.Num_Celular);
            AddParameter("@Email_Usuario", usuario.Email_Usuario);
            AddParameter("@Senha_Usuario", usuario.Senha_Usuario);
            AddParameter("@Foto_usuario", usuario.Foto_usuario);
            ExecuteNonQuery();
        }
    }
}
