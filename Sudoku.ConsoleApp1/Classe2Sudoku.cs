using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.ConsoleApp1
{
    class Classe2Sudoku
    {
        static void Main(string[] args)
        {
            string sudokuValido =
                            @"1 3 2 5 7 9 4 6 8 
                              4 9 8 2 6 1 3 7 5 
                              7 5 6 3 8 4 2 1 9 
                              6 4 3 1 5 8 7 9 2 
                              5 2 1 7 9 3 8 4 6 
                              9 8 7 4 2 6 5 3 1 
                              2 1 4 9 3 5 6 8 7 
                              3 6 5 8 1 7 9 2 4 
                              8 7 9 6 4 2 1 5 3";

            string sudokuColunaInvalida =
                            @"4 3 2 5 7 9 4 6 8 
                              4 9 8 2 6 1 3 7 5 
                              7 5 6 3 8 4 2 1 9 
                              6 4 3 1 5 8 7 9 2 
                              5 2 1 7 9 3 8 4 6 
                              9 8 7 4 2 6 5 3 1 
                              2 1 4 9 3 5 6 8 7 
                              3 6 5 8 1 7 9 2 4 
                              8 7 9 6 4 2 1 5 3";

            string sudokuLinhaInvalida =
                            @"1 1 2 5 7 9 4 6 8 
                              4 9 8 2 6 1 3 7 5 
                              7 5 6 3 8 4 2 1 9 
                              6 4 3 1 5 8 7 9 2 
                              5 2 1 7 9 3 8 4 6 
                              9 8 7 4 2 6 5 3 1 
                              2 1 4 9 3 5 6 8 7 
                              3 6 5 8 1 7 9 2 4 
                              8 7 9 6 4 2 1 5 3";

            string sudokuBlocoInvalido =
                            @"1 3 2 5 7 9 4 6 8 
                              4 9 8 2 6 1 3 7 5 
                              7 5 1 3 8 4 2 1 9 
                              6 4 3 1 5 8 7 9 2 
                              5 2 1 7 9 3 8 4 6 
                              9 8 7 4 2 6 5 3 1 
                              2 1 4 9 3 5 6 8 7 
                              3 6 5 8 1 7 9 2 4 
                              8 7 9 6 4 2 1 5 3";

            string[,] linhasSudoku = new string[9, 9];

            using (StringReader sudokuReader = new StringReader(sudokuValido))
            {
                string linhaSudoku = "";

                for (int x = 0; x < linhasSudoku.GetLength(0); x++)
                {
                    linhaSudoku = sudokuReader.ReadLine();

                    string[] valores = linhaSudoku.Trim().Split();

                    for (int y = 0; y < linhasSudoku.GetLength(1); y++)
                    {
                        linhasSudoku[x, y] = valores[y];
                    }
                }
            }

            string[,] colunasSudoku = new string[9, 9];

            for (int y = 0; y < colunasSudoku.GetLength(0); y++)
            {
                for (int x = 0; x < colunasSudoku.GetLength(1); x++)
                {
                    string valor = linhasSudoku[x, y];
                    colunasSudoku[y, x] = valor;
                }
            }

            string[,] blocosSudoku = new string[9, 9];

            for (int posicaoXBloco = 0; posicaoXBloco < blocosSudoku.GetLength(0); posicaoXBloco++)
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

                        blocosSudoku[posicaoXBloco, posicaoYBloco] = valor;

                        posicaoYBloco++;
                    }
                }
            }

            int contadorDuplicado = 0;
            int quantidadeNumerosDuplicados = 0;

            for (int k = 0; k < linhasSudoku.GetLength(0); k++)
            {
                for (int i = 0; i < linhasSudoku.GetLength(1); i++)
                {
                    for (int j = i + 1; j < linhasSudoku.GetLength(1); j++)
                    {
                        string numeroSelecionado = linhasSudoku[k, i];

                        string numeroComparado = linhasSudoku[k, j];

                        if (numeroSelecionado == numeroComparado)
                        {
                            contadorDuplicado++;
                            quantidadeNumerosDuplicados++;
                        }
                    }
                }
            }

            for (int k = 0; k < colunasSudoku.GetLength(0); k++)
            {
                for (int i = 0; i < colunasSudoku.GetLength(1); i++)
                {
                    for (int j = i + 1; j < colunasSudoku.GetLength(1); j++)
                    {
                        string numeroSelecionado = colunasSudoku[k, i];

                        string numeroComparado = colunasSudoku[k, j];

                        if (numeroSelecionado == numeroComparado)
                        {
                            contadorDuplicado++;
                            quantidadeNumerosDuplicados++;
                        }
                    }
                }
            }

            for (int k = 0; k < blocosSudoku.GetLength(0); k++)
            {
                for (int i = 0; i < blocosSudoku.GetLength(1); i++)
                {
                    for (int j = i + 1; j < blocosSudoku.GetLength(1); j++)
                    {
                        string numeroSelecionado = blocosSudoku[k, i];

                        string numeroComparado = blocosSudoku[k, j];

                        if (numeroSelecionado == numeroComparado)
                        {
                            contadorDuplicado++;
                            quantidadeNumerosDuplicados++;
                        }
                    }
                }
            }

            bool temDuplicado = false;

            if (contadorDuplicado > 1)
                temDuplicado = true;

            if (temDuplicado)
                Console.WriteLine("NÃO");
            else
                Console.WriteLine("SIM");
        }
    }
}
