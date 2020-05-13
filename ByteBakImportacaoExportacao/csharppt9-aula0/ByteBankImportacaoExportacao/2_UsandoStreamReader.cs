using ByteBankImportacaoExportacao.Modelos;
using System;
using System.IO;

namespace ByteBankImportacaoExportacao
{
    partial class Program
    {

        static void UsandoStreamReader()
        {
            var enderecoDoArquivo = "contas.txt";

            using (var fluxoDeArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
            using (var leitor = new StreamReader(fluxoDeArquivo))
            {
                while (!leitor.EndOfStream)
                {
                    var linha = leitor.ReadLine();
                    var contaCorrente = ConverterStringParaContaCorrente(linha);

                    Console.WriteLine($"{contaCorrente.Titular.Nome} Conta numero {contaCorrente.Numero}, ag.{contaCorrente.Agencia}. Saldo: {contaCorrente.Saldo}");

                }

            }

            Console.ReadLine();
        }

        static ContaCorrente ConverterStringParaContaCorrente(String linha)
        {

            var campos = linha.Split(',');

            var agencia = campos[0];
            var numero = campos[1];
            var saldo = campos[2].Replace(".", ",");
            var nomeTitular = campos[3];

            var agenciaComoInt = int.Parse(agencia);
            var numeroComoInt = int.Parse(numero);
            var saldoComoDouble = Double.Parse(saldo);

            var titular = new Cliente();
            titular.Nome = nomeTitular;


            var resultado = new ContaCorrente(agenciaComoInt, numeroComoInt);
            resultado.Depositar(saldoComoDouble);
            resultado.Titular = titular;


            return resultado;
        }

    }
}