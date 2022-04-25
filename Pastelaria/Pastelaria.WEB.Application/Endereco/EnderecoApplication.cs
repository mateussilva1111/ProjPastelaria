using Pastelaria.WEB.Application.Endereco.Model;
using Pastelaria.WEB.Application.Infra;
using System.Net.Http;

namespace Pastelaria.WEB.Application.Endereco
{
    public class EnderecoApplication
    {

        public HttpResponseMessage GetEnderecoId(int id)
        {
            var httpclient = new HttpClient();

            var response = httpclient.GetAsync(HttpClientConf.HttpClientConfigGet("endereco/getenderecodid", new { id })).Result;
            return response;
        }
        

        public HttpResponseMessage PutEndereco(EnderecoModel endereco)
        {
            var httpclient = new HttpClient();
            var response = HttpClientConf.HttpClientConfig("endereco").PutAsync("update", HttpClientConf.Content(endereco)).Result;
            return response;
        }


        public HttpResponseMessage PostEndereco(EnderecoModel endereco)
        {
            var httpclient = new HttpClient();
            var response = HttpClientConf.HttpClientConfig("endereco").PostAsync("insert", HttpClientConf.Content(endereco)).Result;
            return response;
        }
    }
}
