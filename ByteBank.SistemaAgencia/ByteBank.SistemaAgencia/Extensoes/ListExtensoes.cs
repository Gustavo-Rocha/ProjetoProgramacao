using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia.Extensoes
{
    public static class ListExtensoes
    {

        public static void AdicionarVarios<T>(this List<T> lista,params T [] itens)
        {
            foreach (T item in itens)
            {
                lista.Add(item);
            }
        }




        static void Teste()
        {
            List<int> idades = new List<int>();

            idades.Add(14);
            idades.Add(26);
            idades.Add(60);

            //ListExtensoes<int>.AdicionarVarios(idades, 2, 3, 4);

            List<string> nomes = new List<string>();

            nomes.Add("Guilherme");
            idades.AdicionarVarios<int>(3, 5, 65, 34, 76, 98);
            //ListExtensoes<string>.AdicionarVarios(nomes, "Lucas", "Mariana");

            nomes.AdicionarVarios("Lucas", "Mariana");




        }

    }
}
