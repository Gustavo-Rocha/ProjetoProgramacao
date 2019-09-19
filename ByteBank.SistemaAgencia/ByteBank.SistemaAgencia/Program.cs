﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ByteBank.Modelos;
using ByteBank.Modelos.Funcionarios;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            


            string urlParametros = "http://www.bytebanck.com/cambio?moedaOrigem=real&moedaDestino=dolar&valor=1500";
            ExtratorValorDeArgumentosURL extratorValor = new ExtratorValorDeArgumentosURL(urlParametros);
            string valor= extratorValor.GetValor("moedaOrigem");

            Console.WriteLine("valor de moeda Origem " + valor);

            string valorDestino = extratorValor.GetValor("moedaDestino");

            Console.WriteLine("valor de moeda Destino " + valorDestino);

            Console.WriteLine(extratorValor.GetValor("valor"));


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
    }
}
