using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web
{
    public class Catalogo : ICatalogo
    {
        public List<Livro> GetLivros()
        {
            var livros = new List<Livro>();
            livros.Add(new Livro("001", "quem mexeu na minha query", 12.00m));
            livros.Add(new Livro("002", "As aventuras de neco", 14.00m));
            livros.Add(new Livro("003", "Estudos de .NetCore", 34.00m));
            return livros;
        }
    }
}
