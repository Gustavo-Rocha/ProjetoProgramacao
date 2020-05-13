using ByteBankImportacaoExportacao.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBankImportacaoExportacao 
{ 
    partial class Program 
    {
        static void Main(string[] args)
        {



            // CriarArquivoComWriter();
            //CriarArquivo();
            //EscritaBinaria();

            // LeituraBinaria();

            // TestaEscrita();

            // UsarStreamDeEntrada();

            Console.WriteLine("Digite seu nome"); //ler a entrada de usuario na console
           var nome = Console.ReadLine();
            Console.WriteLine(nome);

            var linhas = File.ReadAllLines("contas.txt"); // ler todas as linhas do arquivo
            Console.WriteLine(linhas.Length);
            foreach(var linha in linhas)
            {
                Console.WriteLine(linha);
            }
            File.WriteAllText("escrevendoComAClasseFile.txt", "Testando File.WriteAllText");

            Console.WriteLine("Arquivo escrevendoComAClasseFile criado!");

            var bytesArquivo = File.ReadAllBytes("contas.txt");
            Console.WriteLine($"Arquivo contas.txt possui {bytesArquivo.Length} bytes");



            Console.WriteLine("Criou o arquivo MLK doido");
                Console.ReadLine();

           
        }

    }
} 
 