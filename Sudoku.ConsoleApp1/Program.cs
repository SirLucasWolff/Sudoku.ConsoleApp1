using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.ConsoleApp1
{
    class Program
    {
        private static string sudoku;
        private static object linha;
        private static int aux;
        private static string[,] colunasSudoku;
        private static int y;

        static void Main(string[] args)
        {

            string sudokuValido = @"1 3 2 5 7 9 4 6 8 
                                   4 9 8 2 6 1 3 7 5 
                                   7 5 6 3 8 4 2 1 9 
                                   6 4 3 1 5 8 7 9 2 
                                   5 2 1 7 9 3 8 4 6 
                                   9 8 7 4 2 6 5 3 1 
                                   2 1 4 9 3 5 6 8 7 
                                   3 6 5 8 1 7 9 2 4 
                                   8 7 9 6 4 2 1 5 3";

            Validacao(sudokuValido);
        }

        private static void Validacao(string sudokuValido)
        {
            string[,] linhasSudoku = LeituraDeLinhas(sudokuValido);

            string[,] colunasSudoku = LerColunas(linhasSudoku);

            string[,] blocosSudoku = LeituraDeBlocos(linhasSudoku);

            bool sudokoEhValido =
                ValidarSudoko(linhasSudoku) &&
                ValidarSudoko(colunasSudoku) &&
                ValidarSudoko(blocosSudoku);

            Console.WriteLine(sudokoEhValido ? "SIM" : "NÃO");
        }

        private static bool ValidarSudoko(string[,] matrizSudoku)
        {
            int numeroDuplicados = 0;

            for (int k = 0; k < matrizSudoku.GetLength(0); k++)
            {
                for (int i = 0; i < matrizSudoku.GetLength(1); i++)
                {
                    for (int j = i + 1; j < matrizSudoku.GetLength(1); j++)
                    {
                        string numeroSelecionado = matrizSudoku[k, i];

                        string numeroComparado = matrizSudoku[k, j];

                        if (numeroSelecionado == numeroComparado)
                        {
                            numeroDuplicados++;
                        }
                    }
                }
            }

            return numeroDuplicados == 0; 
        }

        private static string[,] LeituraDeBlocos(string[,] linhasSudoku)
        {
            string[,] blocosSudoko = new string[9, 9];

            for (int posicaoXBloco = 0; posicaoXBloco < blocosSudoko.GetLength(0); posicaoXBloco++)
            {
                int posicaoYBloco = 0;

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        int restoDivisao = posicaoXBloco % 3;

                        int posicaoXLinhas = i + (restoDivisao * 3);

                        int resultadoDivisao = posicaoXBloco / 3;

                        int posicaoYLinhas = j + (resultadoDivisao * 3);

                        string valor = linhasSudoku[posicaoXLinhas, posicaoYLinhas];

                        blocosSudoko[posicaoXBloco, posicaoYBloco] = valor;

                        posicaoYBloco++;
                    }
                }

            }

            return blocosSudoko;
        }

        //Colunas Sudoku
        private static string[,] LerColunas(string[,] linhasSudoku)
        {
            int auxLinhas = 0;
            bool linhaTrue;

            for (int x = 0; y < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {

                    auxLinhas++;
                }

                verificarLinha(linha);
            }


            aux = 0;

            {
                for (int f = 0; f < 3; f++)
                {

                    aux++;
                }
            }

            return colunasSudoku;
        }

        private static void verificarLinha(object linha)
        {
            throw new NotImplementedException();
        }

        //Linhas Sudoku
        private static string[,] LeituraDeLinhas(string sudokuValido)
        {
            string[,] linhasSudoku = new string[9, 9];

            using (StringReader sudokuReader = new StringReader(sudokuValido))
            {
                string linhaSudoku = "";

                for (int x = 0, x < 9; x++)
                {
                    for (int y = 0; y < 9; y++)
                    {
                        Console.WriteLine("Linha " + x + " Coluna " );
                    }
                }
            }

            return linhasSudoku;
        }

        //Conversão
        private static void ConversãoParaMatriz(string[,] matrizSudoku)
        {
            using (StringReader sudokuReader = new StringReader(sudoku))
            {
                string linhaSudoku = "";

                for (int x = 0; x < 9; x++)
                {
                    linhaSudoku = sudokuReader.ReadLine();

                    string[] valores = linhaSudoku.Trim().Split();

                    for (int y = 0; y < matrizSudoku.GetLength(1); y++)
                    {
                        string valor = matrizSudoku[x, y];

                        Console.WriteLine($"x:{x}; y:{y}; {valor}");
                    }
                }
            }

            Console.WriteLine($"Número de itens: {matrizSudoku.Length}");
        }


    }
}


