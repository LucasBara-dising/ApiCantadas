using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiCantadas.Models
{
    public class CantadaRepository : IProductRepository
    {
        private List<Cantada> cantadas= new List<Cantada>();
        private int nextId = 1;


        //Adiconndo dados a api
        public CantadaRepository()
        {
            //o ideal que seja um banco de dados
            Add(new Cantada { TxtCantada = "oi gata" });
            Add(new Cantada { TxtCantada = "oi gata, Quer uma flor" });
            Add(new Cantada { TxtCantada = "me responde" });
        }
        public Cantada Add(Cantada item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            item.IdCantada = nextId++;
            cantadas.Add(item);
            return item;
        }

        public Cantada Get(int id)
        {
            return cantadas.Find(p=>p.IdCantada==id);
        }

        public IEnumerable<Cantada> GetAll()
        {
            return cantadas;
        }

        public void Remove(int id)
        {
            cantadas.RemoveAll(p => p.IdCantada == id);
        }

        public bool Update(Cantada item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            int index= cantadas.FindIndex(p=>p.IdCantada==item.IdCantada);
            if (index == -1)
            {
                return false;
            }
            cantadas.RemoveAt(index);
            cantadas.Add(item);
            return true;
        }
    }
}