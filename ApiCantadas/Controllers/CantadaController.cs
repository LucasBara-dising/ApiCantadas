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

        // usar swegger


        //importande colocar parametros no BODY
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
            //recebe uma lista, faz um laço para recbe um valor de cada vez
            BdConector db = new BdConector();
            foreach (var item in itens)
            {
                db.adicionaCantada(item);
            }
           
            //fecha banco
            db.Fechar();

            //retorna mensagem de sucesso
            var response = new HttpResponseMessage(HttpStatusCode.Created);
            return response;
        }

        //update
        // PUT: api/Cantada/atualiza/{id}
        //Obs:tem que passar id, txt e categoria no body
        [HttpPut]
        [ActionName("atualiza")]
        public HttpResponseMessage Put(int id, [FromBody] Cantada item)
        {

            if (item == null)
            {
                return new HttpResponseMessage(HttpStatusCode.NotModified);
            }

            BdConector db = new BdConector();
            db.UpdateCantada(item);
            db.Fechar();

            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }

        //Delete
        //api/Cantada/delete?idCant={id}
        [HttpDelete]
        [ActionName("delete")]
        public HttpResponseMessage Delete(int idCant)
        {
            BdConector db = new BdConector();
            db.RemoveCantada(idCant);
            db.Fechar();

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

    }
}