using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCantadas.Models
{
    internal interface IProductRepository
    {
        IEnumerable<Cantada> GetAll();
        Cantada Get(int id);
        Cantada Add(Cantada item);
        void Remove(int id);
        bool Update(Cantada item);
    }
}
