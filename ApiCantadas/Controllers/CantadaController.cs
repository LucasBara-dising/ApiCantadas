using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using ApiCantadas.Models;
using System.Net.Http;
using System.Data.Common;

namespace ApiCantadas.Controllers
{
    public class CantadaController : ApiController
    {
        List<Cantada> cantada = new List<Cantada>();

        //exemplo de método com busca em Banco de dados

        // api/Cantada/MostraTodas
        [HttpGet]
        //Pode mudar o nome que vai ser usado na Url
        [ActionName("MostraTodas")]
        public IEnumerable<Cantada> GetAllLivros()
        {
            //tenta conectar ao banco
            try
            {
                BdConector db = new BdConector();
                var cants = db.BuscaTodos();
                db.Fechar();
                return cants;
            }
            catch (Exception e)
            {
                //se der erado o banco retorna erro de desautorizado 
                var resp = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                throw new HttpResponseException(resp);
            }
        }

        //------------------não funcioa ainda-----------
        // usar swegger


        //importande colopocar parametros no BODY
        // POST: api/Cantada/addCantada
        [HttpPost]
        [ActionName("addCantada")]
        public HttpResponseMessage Post([FromBody] List<Cantada> itens)
        {
            if (itens == null)
            {
                return new HttpResponseMessage(HttpStatusCode.NotModified);
            }
            //manda adicionar o item 
            BdConector db = new BdConector();
            cantada.AddRange(itens);
            //retorna mensagem de sucesso
            var response = new HttpResponseMessage(HttpStatusCode.Created);
            return response;
        }

        //update
        // PUT: api/Livro/5
        [HttpPut]
        [ActionName("updateItem")]
        public HttpResponseMessage Put(int id, [FromBody] Cantada item)
        {

            if (item == null)
            {
                return new HttpResponseMessage(HttpStatusCode.NotModified);
            }

            int index = cantada.IndexOf((Cantada)cantada.Where((p) => p.IdCantada == id).FirstOrDefault());
            cantada[index] = item;

            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }


        [HttpDelete]
        [ActionName("delete")]
        public HttpResponseMessage Delete(int id)
        {
            Cantada cant = (Cantada)cantada.Where((p) => p.IdCantada == id);
            int index = cantada.IndexOf(cant);
            cantada.RemoveAt(index);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

    }
}