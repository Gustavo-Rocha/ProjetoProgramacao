using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ByteBank.Modelos;
using ByteBank.Modelos.Funcionarios;
using ByteBank.SistemaAgencia.Comparadores;
using ByteBank.SistemaAgencia.Extensoes;


namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            //------------------------------- CURSO DE ARRAY ---------------------------------------------------------//

            var contas = new List<ContaCorrente>()
            {
                new ContaCorrente(6235,2),
                null,
                null,
                null,
                new ContaCorrente(6235,1),
                new ContaCorrente(6235,999999),
                new ContaCorrente(0897,657576),
                new ContaCorrente(650,657576),
                null,
                new ContaCorrente(9329,432432)
            };


            // contas.Sort(); ~>  chamar a implementação dada em Icomparable

            // contas.Sort(new ComparadorContaCorrentePorAgencia());


           //  IEnumerable<ContaCorrente> contasNaoNulas = contas.Where(conta => conta != null);

            IOrderedEnumerable<ContaCorrente> contasaOrdenadas = contas.Where(conta => conta != null)
                .OrderBy(conta => conta.Numero); 

            foreach (var conta in contasaOrdenadas)
            {
                Console.WriteLine($"Conta número {conta.Numero}, ag. {conta.Agencia}");
            }

            Console.ReadLine();
        }

        public  static void TestaSort()
        {
            var nomes = new List<string>()
            {
                "Guilherme",
                "Gustavo",
                "ana",
                "Larissa"
            };
            nomes.Sort();

            foreach (var nome in nomes)
            {
                Console.WriteLine(nome);
            }

            var idades = new List<int>();

            idades.Add(1);
            idades.Add(5);
            idades.Add(14);
            idades.Add(25);
            idades.Add(38);
            idades.Add(61);

            idades.Remove(5);
            idades.AdicionarVarios(6, 3, 5, 7, -1, 99);

            idades.Sort();

           for (int i = 0; i < idades.Count; i++)
            {
                int iddadeAtua = idades[i];
                Console.WriteLine(idades[i]);
            }

            Console.WriteLine(SomarVarios(1, 3, 45, 76, 98, 097, 45, 43543, 342));


        }

        static void testaListaDeObject()
            {
                ListaDeObject listaDeIdades = new ListaDeObject();
                listaDeIdades.adicionar(60);
                listaDeIdades.adicionar(60);
                listaDeIdades.adicionar(60);
                listaDeIdades.AdicionarVarios(4, 98, 65);
                listaDeIdades.adicionar(60);

                for (int i = 0; i < listaDeIdades.Tamanho; i++)
                {
                    int idade = (int)listaDeIdades[i];
                    Console.WriteLine($"Idade no indice {i}: {idade}");
                }
            }


        //------------------------------- CURSO DE STRINGS ---------------------------------------------------------//


        static void testaStrings()
        { 
            Cliente carlos_1 = new Cliente();
            carlos_1.Nome = "Carlos";
            carlos_1.CPF = "458.623.120-03";
            carlos_1.Profissao = "Designer";

            Cliente carlos_2 = new Cliente();
            carlos_2.Nome = "Carlos";
            carlos_2.CPF = "458.623.120-03";
            carlos_2.Profissao = "Designer";

            if (carlos_1.Equals(carlos_2))
            {
                Console.WriteLine("São iguais!");
            }
            else
            {
                Console.WriteLine("Não são iguais!");
            }

            Console.ReadLine();




            Console.ReadLine();

            Console.WriteLine("Olá, mundo!");
            Console.WriteLine(123);
            Console.WriteLine(10.5);
            Console.WriteLine(true);

            object conta = new ContaCorrente(456, 687876);
            object desenvolvedor = new Desenvolvedor("121351");

            string contaToString = conta.ToString();


            Console.WriteLine("Resultado" + contaToString);
            Console.WriteLine(conta);


            Console.ReadLine();
        }

        static void TestaArrayDeContaCorrente()

        {


            ContaCorrente[] contas = new ContaCorrente[3];
            contas[0] = new ContaCorrente(874, 5679787);
            contas[1] = new ContaCorrente(874, 4456668);
            contas[2] = new ContaCorrente(874, 7781438);

            for (int indice = 0; indice < contas.Length; indice++)
            {
                ContaCorrente contaAtual = contas[indice];
                Console.WriteLine($"Conta {indice} {contaAtual.Numero}");
            }



        }

        static void TestaString()
            {
            // Olá, meu nome é Guilherme e você pode entrar em contato comigo
            // através do número 8457-4456!

            // Meu nome é Guilherme, me ligue em 4784-4546

            // string padrao = "[0123456789][0123456789][0123456789][0123456789][-][0123456789][0123456789][0123456789][0123456789]";
            // string padrao = "[0-9][0-9][0-9][0-9][-][0-9][0-9][0-9][0-9]";
            // string padrao = "[0-9]{4,5}[-][0-9]{4}";
            // string padrao = "[0-9]{4,5}[-]{0,1}[0-9]{4}";
            // string padrao = "[0-9]{4,5}-{0,1}[0-9]{4}";
            string padrao = "[0-9]{4,5}-?[0-9]{4}";
            string textoDeTeste = "Meu nome é Guilherme, me ligue em 47844546";


            Match resultado = Regex.Match(textoDeTeste, padrao);
            Console.WriteLine(resultado.Value);

            Console.WriteLine(Regex.IsMatch(textoDeTeste, padrao));
            Console.ReadLine();




            string URLTeste = "http://www.bytebank.com/cambio";
            int indiceByteBank = URLTeste.IndexOf("http://www.bytebank.com");
            Console.WriteLine(indiceByteBank >= 0);

            Console.WriteLine(URLTeste.StartsWith("http://www.bytebank.com"));
            Console.WriteLine(URLTeste.EndsWith("cambio/"));
            Console.WriteLine(URLTeste.Contains("bytebank"));
            Console.ReadLine();






            string urlParametros = "http://www.bytebanck.com/cambio?moedaOrigem=real&moedaDestino=dolar&valor=1500";
            ExtratorValorDeArgumentosURL extratorValor = new ExtratorValorDeArgumentosURL(urlParametros);
            string valor = extratorValor.GetValor("moedaOrigem");

            Console.WriteLine("valor de moeda Origem " + valor);

            string valorDestino = extratorValor.GetValor("moedaDestino");

            Console.WriteLine("valor de moeda Destino " + valorDestino);

            Console.WriteLine(extratorValor.GetValor("VALOR"));


            Console.ReadLine();



            //testando toLower/toUPPER
            string mensagemOrigem = "PALAVRA";
            string termoBusca = "ra";

            Console.WriteLine(termoBusca.ToUpper());


            //trestando replace

            termoBusca = termoBusca.Replace('r', 'R');
            Console.WriteLine(termoBusca);

            termoBusca = termoBusca.Replace('a', 'A');

            Console.WriteLine(termoBusca);

            Console.WriteLine(mensagemOrigem.IndexOf(termoBusca));
            Console.ReadLine();






            //testando o metodo remove 
            string testeRemocao = "PrimeiraParte&123456";
            int indiceEComercial = testeRemocao.IndexOf('&');
            Console.WriteLine(testeRemocao.Remove(indiceEComercial, 4));
            Console.ReadLine();


            /* string palavra = "moedaOrigem=moedaDestino&moedaDestino=dolar";
             string nomeArgumento = "moedaDestino=";
             int indice = palavra.IndexOf(nomeArgumento);


             Console.WriteLine(indice);

             Console.WriteLine("tamanho da String nomeArgumento " + nomeArgumento.Length);

             Console.WriteLine(palavra.Substring(indice));
             Console.WriteLine(palavra.Substring(indice+nomeArgumento.Length));
             Console.ReadLine();*/



            //testando isNullOrEmpty


            string textoVazio = "";
            string textoNulo = null;
            string textoQualquer = "dnjdsbfdsfdsf";

            Console.WriteLine(string.IsNullOrEmpty(textoVazio));
            Console.WriteLine(string.IsNullOrEmpty(textoNulo));
            Console.WriteLine(string.IsNullOrEmpty(textoQualquer));
            Console.ReadLine();




            string url = "pagina?moedaOrigem=real&moedaDestino=dolar";

            // int indiceInterrogacao = url.IndexOf('?');

            // Console.WriteLine(indiceInterrogacao);

            Console.WriteLine(url);
            //string argumentos = url.Substring(indiceInterrogacao);
            Console.WriteLine(string.IsNullOrEmpty(textoVazio));
            Console.ReadLine();




        }





        static void TestaArrayInt()
        {

            int[] idades = new int[5];

            idades[0] = 15;
            idades[1] = 28;
            idades[2] = 35;
            idades[3] = 50;
            idades[4] = 28;

            int acumulador = 0;
            for (int indice = 0; indice < idades.Length; indice++)
            {
                int idade = idades[indice];

                Console.WriteLine($"Acessando o array idades no índice {indice}");
                Console.WriteLine($"Valor de idades[{indice}] = {idade}");

                acumulador += idade;
            }

            int media = acumulador / idades.Length;
            Console.WriteLine($"Média de idades = {media}");

            Console.ReadLine();


        }


        static void TestaListaDeContaCorrente()
        {

            ListaDeContaCorrente lista = new ListaDeContaCorrente();
            lista.MeuMetodo(numero: 5);

            ContaCorrente contaDoGui = new ContaCorrente(1111, 222222);
            lista.adicionar(contaDoGui);



            lista.adicionar(new ContaCorrente(874, 567945));
            lista.adicionar(new ContaCorrente(874, 567945));

            //adicionando objetos num array
            ContaCorrente[] contas = new ContaCorrente[]
            {
                contaDoGui,
                new ContaCorrente(874, 567945),
                new ContaCorrente(874, 567945)
            };



            lista.AdicionarVarios(contas);



            // usando params
            lista.AdicionarVarios(contaDoGui,
                new ContaCorrente(874, 567945),
                new ContaCorrente(874, 567945));




            for (int i = 0; i < lista.Tamanho; i++)
            {

                ContaCorrente itemAtual = lista[i];
                Console.WriteLine($"Item na posição {i} = Conta {itemAtual.Numero}/{itemAtual.Agencia}");
            }




            //lista.remover(contaDoGui);

            Console.WriteLine("Apos remover o item");
        }


        static int SomarVarios(params int[] numeros)
        {
            int acumulador = 0;
            foreach (int numero in numeros)
            {
                acumulador += numero;
            }
            return acumulador;
        }

    }
}


