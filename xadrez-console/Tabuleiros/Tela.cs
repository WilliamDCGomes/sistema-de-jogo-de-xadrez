﻿using System;
using System.Collections.Generic;
using Tabuleiros;
using Xadrez;
namespace xadrez_console.Tabuleiros {
    class Tela {
        public static void ImprimirPartida(PartidaDeXadrez partida) {
            ImprimirTabuleiro(partida.Tab);
            Console.WriteLine();
            ImprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine($"Turno {partida.Turno}");
            if (!partida.Terminada) {
                Console.WriteLine($"Aguardando jogada: {partida.JogadorAtual}");
                if (partida.Xeque) {
                    Console.WriteLine("XEQUE!");
                }
            }
            else {
                Console.WriteLine();
                Console.WriteLine("XEQUEMATE!");
                Console.WriteLine($"Vencedor: {partida.JogadorAtual}");
            }
        }
        public static void ImprimirPecasCapturadas(PartidaDeXadrez partida) {
            Console.WriteLine("Peças capturadas:");
            Console.Write("Brancas: ");
            ImprimirConjunto(partida.PecasCapturadas(Cor.Branca));
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Pretas: ");
            ImprimirConjunto(partida.PecasCapturadas(Cor.Preta));
            Console.ForegroundColor = aux;
        }
        public static void ImprimirConjunto(HashSet<Peca> conjunto) {
            Console.Write("[");
            foreach(Peca x in conjunto) {
                Console.Write($"{x} ");
            }
            Console.WriteLine("]");
        }
        public static void ImprimirTabuleiro(Tabuleiro tab) {
            for (int i= 0;i< tab.Linhas; i++){
                Console.Write($"{8 - i} ");
                for(int j = 0; j < tab.Colunas; j++) {
                    ImprimirPeca(tab.Peca(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }
        public static void ImprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis) {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;
            for (int i = 0; i < tab.Linhas; i++) {
                Console.Write($"{8 - i} ");
                for (int j = 0; j < tab.Colunas; j++) {
                    if(posicoesPossiveis[i, j]) {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    ImprimirPeca(tab.Peca(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = fundoOriginal;
        }
        public static PosicaoXadrez LerPosicaoXadrez() {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1].ToString());
            return new PosicaoXadrez(coluna, linha);
        }
        public static void ImprimirPeca(Peca peca) {
            if (peca == null) {
                Console.Write("-");
            }
            else {
                if (peca.Cor == Cor.Branca) {
                    Console.Write(peca);
                }
                else {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
            }
            Console.Write(" ");
        }
    }
}
