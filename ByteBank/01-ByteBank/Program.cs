﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {

            ContaCorrente contaDaGabriela = new ContaCorrente();
            contaDaGabriela.titular = "Gabriela";
            contaDaGabriela.numeroAgencia = 863;
            contaDaGabriela.numero = 863542;
            contaDaGabriela.saldo = 100;


            Console.WriteLine( contaDaGabriela.titular);
            Console.WriteLine("Agencia" + contaDaGabriela.numeroAgencia);
            Console.WriteLine("Numero" + contaDaGabriela.numero);
            Console.WriteLine("Saldo"+contaDaGabriela.saldo);

            contaDaGabriela.saldo += 200;
            Console.WriteLine("Saldo" + contaDaGabriela.saldo);

            Console.ReadLine();

        }
    }
}
