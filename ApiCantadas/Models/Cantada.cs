using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiCantadas.Models
{
    public class Cantada
    {
        public Cantada()
        {

        }

        public Cantada(int idCantada, string txtCantada, string catCantada)
        {
            IdCantada = idCantada;
            TxtCantada = txtCantada;
            CatCantada = catCantada;
        }

        public int IdCantada { get; set; }
        public string TxtCantada { get; set; }
        public string CatCantada { get; set; }


    }
}