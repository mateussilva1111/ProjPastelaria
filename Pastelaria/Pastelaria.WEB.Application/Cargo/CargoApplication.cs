using Pastelaria.WEB.Application.Cargo.Model;
using Pastelaria.WEB.Application.Infra;
using System.Net.Http;

namespace Pastelaria.WEB.Application.Cargo
{
    public class CargoApplication
    {
        public HttpResponseMessage PostCargo(CargoModel cargo)
        {
            var response = HttpClientConf.HttpClientConfig("cargo").PostAsync("insert", HttpClientConf.Content(cargo)).Result;
            return response;
        }

        public HttpResponseMessage GetCargos()
        {
            var httpclient = new HttpClient();
            var response = HttpClientConf.HttpClientConfig("cargo").GetAsync("read").Result;
            return response;

        }

        public HttpResponseMessage PutCargo(CargoModel cargo)
        {
            var httpclient = new HttpClient();
            var response = HttpClientConf.HttpClientConfig("cargo").PutAsync("update", HttpClientConf.Content(cargo)).Result;
            return response;
        }

        public HttpResponseMessage DeleteCargo(int id)
        {
            var httpclient = new HttpClient();
            var response = httpclient.DeleteAsync(HttpClientConf.HttpClientConfigGet("cargo/delete", new { id })).Result;
            return response;
        }

        
        public HttpResponseMessage GetCargoId(int id)
        {
            var httpclient = new HttpClient();

            var response = httpclient.GetAsync(HttpClientConf.HttpClientConfigGet("cargo/getcargoid", new { id })).Result;
            return response;
        }
    }
}
