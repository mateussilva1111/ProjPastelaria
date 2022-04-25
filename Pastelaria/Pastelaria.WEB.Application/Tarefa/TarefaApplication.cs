using Pastelaria.WEB.Application.Infra;
using System.Net.Http;

namespace Pastelaria.WEB.Application.Tarefa
{
    public class TarefaApplication
    {
        public HttpResponseMessage PostTarefa(TarefaModel tarefa)
        {
            var httpclient = new HttpClient();
            var response = HttpClientConf.HttpClientConfig("tarefa").PostAsync("post", HttpClientConf.Content(tarefa)).Result;
            return response;
        }

        public HttpResponseMessage GetTarefas()
        {
            var httpclient = new HttpClient();
            var response = HttpClientConf.HttpClientConfig("tarefa").GetAsync("read").Result;
            return response;
        }

        public HttpResponseMessage GetTarefaId(int id)
        {
            var httpclient = new HttpClient();

            var response = httpclient.GetAsync(HttpClientConf.HttpClientConfigGet("tarefa/gettarefaid", new { id })).Result;
            return response;
        }

        public HttpResponseMessage GetTarefaUser(int id)
        {
            var httpclient = new HttpClient();

            var response = httpclient.GetAsync(HttpClientConf.HttpClientConfigGet("tarefa/gettarefauser", new { id })).Result;
            return response;
        }


        public HttpResponseMessage PutTarefa(TarefaModel tarefa)
        {
            var httpclient = new HttpClient();
            var response = HttpClientConf.HttpClientConfig("tarefa").PutAsync("update", HttpClientConf.Content(tarefa)).Result;
            return response;
        }

        public HttpResponseMessage DeleteTarefa(int id)
        {
            var httpclient = new HttpClient();
            var response = httpclient.DeleteAsync(HttpClientConf.HttpClientConfigGet("tarefa/delete", new { id })).Result;

            
            return response;
        }

        public HttpResponseMessage FinalizaTarefa(int id)
        {
            var httpclient = new HttpClient();
            //var response = HttpClientConf.HttpClientConfig("tarefa").PutAsync("finalizatarefa", HttpClientConf.Content(id)).Result;
            var response = httpclient.GetAsync(HttpClientConf.HttpClientConfigGet("tarefa/finalizatarefa", new { id })).Result;
            return response;
        }
    }
}
