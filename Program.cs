﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraTabajara
{
    class Program
    {
        #region Requisito Funcional 01 [OK]
        //Nossa calculadora deve ter a possibilidade de somar dois números
        #endregion

        #region Requisito Funcional 02 [OK]
        //Nossa calculadora deve ter a possibilidade fazer várias operações de soma
        #endregion

        #region Requisito Funcional 03 [OK]
        //Nossa calculadora deve ter a possibilidade fazer várias operações de soma e de subtração
        #endregion

        #region Requisito Funcional 04 [OK]
        //Nossa calculadora deve ter a possibilidade fazer as quatro operações básicas da matemática
        #endregion

        #region Requisito Funcional 05 [OK]
        //Nossa calculadora deve validar a opções do menu [OK]
        #endregion

        #region BUG 01 [OK]
        //Nossa calculadora deve realizar as operações com "0"
        #endregion

        #region Requisito Funcional 06 [OK]
        /** Nossa calculadora deve permitir visualizar as operações já realizadas
         *  Critérios:
         *      1 - A descrição da operação realizada deve aparecer assim, exemplo:
         *          2 + 2 = 4
         *          10 - 5 = 5
         *      2 - Caso nenhuma operação foi realizada, mostrar a mensagem
         *          nenhuma operação foi realizada!
         */
        #endregion

        #region Requisito Não Funcional
        //Melhoramento do código.
        #endregion

        static void Main(string[] args)
        {
            string[] operacoesRealizadas = new string[100];
            string opcao = "";
            int contadorOperacoesRealizadas = 0;

            while (true)
            {
                MostrarMenu();

                opcao = Console.ReadLine();

                if (OpcaoInvalida(opcao)) //AND 
                {

                    MostrarMsg("Opção inválida!Tente novamente");

                    continue;
                }

                if (OpcaoVisualizacao(opcao))
                {
                    if (contadorOperacoesRealizadas == 0)
                        MostrarMsg("Nenhuma operação foi realizada ainda. Tente novamente");
                    else

                        MostrarOperacaoesRealizadas(operacoesRealizadas);

                    Console.ReadLine();

                    Console.Clear();

                    continue;
                }

                if (OpcaoSair(opcao))
                    break;

                double primeiroNumero, segundoNumero;

                primeiroNumero = ObterNumero("primeiro");

                do
                {
                    segundoNumero = ObterNumero("segundo");

                    if (SegundoNumeroInvalido(opcao, segundoNumero))

                        MostrarMsg("Segundo número inválido! Tente novamente");


                } while (SegundoNumeroInvalido(opcao, segundoNumero));

                double resultado = (double) CalcularResultado(opcao, primeiroNumero, segundoNumero);

                string simboloOperacao = ObterSimbolo(opcao); 


                string operacaoRealizada = $"{primeiroNumero} {simboloOperacao} {segundoNumero} = {resultado}";

                operacoesRealizadas[contadorOperacoesRealizadas] = operacaoRealizada;
                contadorOperacoesRealizadas++;
                Console.WriteLine(resultado);

                Console.WriteLine();

                Console.WriteLine(operacaoRealizada);

                Console.ReadLine();

                Console.Clear();

            }
        }

        private static string ObterSimbolo(string opcao)
        {
            string simboloOperacao = "";

            switch (opcao)
            {
                case "1": simboloOperacao = "+"; break;

                case "2": simboloOperacao = "-"; break;

                case "3": simboloOperacao = "*"; break;

                case "4": simboloOperacao = "/"; break;

                default:
                    break;
            }
            return simboloOperacao;
        }
        private static object CalcularResultado(string opcao, double primeiroNumero, double segundoNumero)
        {
            double resultado = 0;

            switch (opcao)
            {
                case "1": resultado = primeiroNumero + segundoNumero; break;

                case "2": resultado = primeiroNumero - segundoNumero; break;

                case "3": resultado = primeiroNumero * segundoNumero; break;

                case "4": resultado = primeiroNumero / segundoNumero; break;

                default:
                    break;
            }
            return resultado;
        }

        private static bool SegundoNumeroInvalido(string opcao, double segundoNumero)
        {
            return opcao == "4" && segundoNumero == 0;
        }

        private static double ObterNumero(string ordem)
        {
            Console.Write($"Digite o {ordem} número: ");

            double numero = Convert.ToDouble(Console.ReadLine());

            return numero;
        }

        private static bool OpcaoSair(string opcao)
        {
            return opcao.Equals("s", StringComparison.OrdinalIgnoreCase);
        }

        private static void MostrarOperacaoesRealizadas(string[] operacoesRealizadas)
        {
            for (int i = 0; i < operacoesRealizadas.Length; i++)
            {
                if (operacoesRealizadas[i] != null)
                    Console.WriteLine(operacoesRealizadas[i]);
            }
        }

        private static bool OpcaoVisualizacao(string opcao)
        {
            return opcao == "5";
        }

        private static void MostrarMsg(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("Opção inválida! Tente novamente");

            Console.ResetColor();

            Console.ReadLine();

            Console.Clear();
        }

        private static bool OpcaoInvalida(string opcao)
        {
            return opcao != "1" && opcao != "2" && opcao != "3"
                                && opcao != "4" && opcao != "5"
                                && opcao != "S" && opcao != "s";

        }

        private static void MostrarMenu()
        {
            Console.WriteLine("Calculadora Tabajara 1.7.1");

            Console.WriteLine();

            Console.WriteLine("Digite 1 para somar");

            Console.WriteLine("Digite 2 para subtrair");

            Console.WriteLine("Digite 3 para multiplicação");

            Console.WriteLine("Digite 4 para divisão");

            Console.WriteLine("Digite 5 para visualizar as operações realizadas");

            Console.WriteLine();

            Console.WriteLine("Digite S para sair");
        }
    }
}


