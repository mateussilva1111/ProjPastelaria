using Pastelaria.WEB.Application.Infra;
using Pastelaria.WEB.Application.Usuario.Model;
using System.Net.Http;

namespace Pastelaria.WEB.Application.Usuario
{
    public class UsuarioApplication
    {
        public HttpResponseMessage Post(UsuarioModel usuario)
        {
            var response = HttpClientConf.HttpClientConfig("usuario").PostAsync("", HttpClientConf.Content(usuario)).Result;
            return response;
        }

        public HttpResponseMessage PostLogin(UsuarioModel usuario)
        {
            var httpclient = new HttpClient();
            var response = HttpClientConf.HttpClientConfig("usuario").PostAsync("login", HttpClientConf.Content(usuario)).Result;

            return response;
        }

        public HttpResponseMessage GetAllUsers( )
        {
            var httpclient = new HttpClient();
            var response = HttpClientConf.HttpClientConfig("usuario").GetAsync("usuarios").Result;
            return response;
        }

        public HttpResponseMessage GetUsuarioId(int id)
        {
            var httpclient = new HttpClient();


            var response = httpclient.GetAsync(HttpClientConf.HttpClientConfigGet("usuario/getuserid", new { id })).Result;
            return response;

        }

        public HttpResponseMessage PutUser(UsuarioModel usuario)
        {
            var httpclient = new HttpClient();
            var response = HttpClientConf.HttpClientConfig("usuario").PutAsync("putuser", HttpClientConf.Content(usuario)).Result;

            return response;
        }

        public HttpResponseMessage Put(UsuarioModel usuario)
        {
            var httpclient = new HttpClient();
            var response = HttpClientConf.HttpClientConfig("usuario").PutAsync("update", HttpClientConf.Content(usuario)).Result;

            return response;
        }

        public HttpResponseMessage DeleteUsuario(int id)
        {
            var httpclient = new HttpClient();
            var response = httpclient.DeleteAsync(HttpClientConf.HttpClientConfigGet("usuario/delete", new { id })).Result;


            return response;
        }

    }

}
