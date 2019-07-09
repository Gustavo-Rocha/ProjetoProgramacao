﻿// using _05_ByteBank;

using System;


namespace ByteBank
{
    public class ContaCorrente
    {
        public Cliente Titular { get; set; }

        public static double TaxaOperacao { get; private set; }

        public static int TotalDeContasCriadas { get; private set; }


        private int _agencia;
        public int Agencia
        {
            get
            {
                return _agencia;
            }
            private set
            {
                if (value <= 0)
                {
                    return;
                }

                _agencia = value;
            }
        }

        private readonly int _numero;
        public int Numero {
            get
            {
                return _numero;
            }
                
                
                }

        private double _saldo = 100;

        public double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }

                _saldo = value;
            }
        }


        public ContaCorrente(int agencia, int numero)
        {

            if (agencia <= 0)
            {
                throw new ArgumentException("O argumento agencia deve ser maior que 0.", nameof(agencia));
            }

            if (numero <= 0)
            {
                throw new ArgumentException("O argumento numero deve ser maior que 0.", nameof(numero));
            }


            Agencia = agencia;
            _numero = numero;

            TotalDeContasCriadas++;
            TaxaOperacao = 30 / TotalDeContasCriadas;

           
        }


        public void Sacar(double valor)
        {
            
            if (valor < 0)
            {
                throw new ArgumentException("valor invalido para  sacar", nameof(valor));
            }


            if (_saldo < valor)
            {
                throw new SaldoInsuficienteException(Saldo,valor );
            }

            _saldo -= valor;
            
        }

        public void Depositar(double valor)
        {
            _saldo += valor;
        }


        public void Transferir(double valor, ContaCorrente contaDestino)
        {

            if (valor < 0)
            {
                throw new ArgumentException("valor invalido para  a transferencia", nameof(valor));
            }

            Sacar(valor);
          
            contaDestino.Depositar(valor);
           
        }
    }
}
