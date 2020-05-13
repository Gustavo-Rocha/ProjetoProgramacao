using System;
using System.IO;
using System.Text;

namespace ByteBankImportacaoExportacao
{
    partial class Program
    {
        static void CriarArquivo()
        {

            var caminhoNovoArquivo = "contasExportadas.csv";

            using (var fluxoDeArquivo = new FileStream (caminhoNovoArquivo,FileMode.Create))
            {
                var contaComoString = "456,2344,45678.50,Cuscuzinho de ferro";

                var encoding = Encoding.UTF8;

                var bytes = encoding.GetBytes(contaComoString);

                fluxoDeArquivo.Write(bytes, 0, bytes.Length);
            }

        }


        static void CriarArquivoComWriter()
        {
            var caminhoNovoArquivo = "contasExportadas.csv";

            using (var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
            using (var escritor = new StreamWriter(fluxoDeArquivo,Encoding.UTF8)) 
            {
                escritor.Write("324,5687,21321.00,pedro pe de pato");
            }

        }

        static void TestaEscrita()
        {

            var caminhoArquivo = "Teste.txt";

            using (var fluxoArquivo = new FileStream(caminhoArquivo, FileMode.Create))
            using (var escritor = new StreamWriter(fluxoArquivo))
            {
                for(int i=0; i < 100000000; i++)
                {
                    escritor.WriteLine($"Linha {i}");
                    escritor.Flush(); //Despeja o Buffer para o Stream

                    Console.WriteLine($"essa linha {i} foi escrita no arquivo, tecle enter para adicionar mais uma");
                    Console.ReadLine();
                }

                

            }

        }

    }

}