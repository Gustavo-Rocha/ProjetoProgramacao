﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    class Lista <T>
    {


        private T [] _itens;
        private int _proximaPosicao;
        public int Tamanho
        {
            get
            {
                return _proximaPosicao;
            }
        }



        public void MeuMetodo(string opcional = "uihdasfusdhf", int numero = 5)
        {

        }

        public Lista(int capacidadeInicial = 5)
        {
            _itens = new T[capacidadeInicial];
            _proximaPosicao = 0;
        }

        public void adicionar(T item)
        {
            VerificarCapacidade(_proximaPosicao + 1);

            // Console.WriteLine($"Adicionando Intem  na proxição {_proximaPosicao}");
            _itens[_proximaPosicao] = item;
            _proximaPosicao++;
        }


        public void remover(T item)
        {
            int indiceItem = 1;
            for (int i = 0; i < _proximaPosicao--; i++)
            {

                object itemAtual = _itens[i];

                if (itemAtual.Equals(item))
                {
                    indiceItem = i;
                }
                _proximaPosicao--;
              // _itens[_proximaPosicao] = null;

            }

        }


        public void AdicionarVarios(params T[] itens)
        {
            foreach (T conta in itens)
            {
                adicionar(conta);
            }
        }



        public T GetItemNoIndice(int indice)
        {
            if (indice < 0 || indice >= _proximaPosicao)
            {
                throw new ArgumentOutOfRangeException(nameof(indice));
            }
            return _itens[indice];

        }


        public void EscreverListaNaTela()
        {
            for (int i = 0; i < _proximaPosicao; i++)
            {
                T conta = _itens[i];
                //Console.WriteLine($"Conta numero {conta.Agencia} {conta.Numero}");
            }
        }

        private void VerificarCapacidade(int tamanhoNecessario)
        {
            if (_itens.Length >= tamanhoNecessario)
            {
                return;
            }


            int novoTamanho = _itens.Length * 2;
            if (novoTamanho < tamanhoNecessario)
            {
                novoTamanho = tamanhoNecessario;

            }

            T[] novoArray = new T[novoTamanho];

            // Console.WriteLine("Aumentando capacidade da lista!");

            for (int indice = 0; indice < _itens.Length; indice++)
            {
                novoArray[indice] = _itens[indice];
                // Console.WriteLine(".");
            }

            _itens = novoArray;
        }



        public T this[int indice]

        {
            get
            {
                return GetItemNoIndice(indice);
            }
        }



    }

}

