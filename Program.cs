using System;

namespace NavalBattle
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            String letras = "ABCDEF";

            char[,] tabuleiro = new char[6, 6];
            char[,] jogadas = new char[6, 6];

            int quantBarcos = 0;

            for (int linha = 0; linha < 6; linha++)
            {
                for (int coluna = 0; coluna < 6; coluna++)
                {
                    int barco = random.Next(0, 3);
                    if (barco == 1)
                    {
                        tabuleiro[linha, coluna] = 'X';
                        quantBarcos++;
                    }
                }
            }

            int totalNaviosAtingidos = 0;
            do
            {
                Console.WriteLine("   A B C D E F");
                for (int linha = 0; linha < 6; linha++)
                {
                    Console.Write(letras[linha] + " |");
                    for (int coluna = 0; coluna < 6; coluna++)
                    {
                        if (jogadas[linha, coluna] != 'X')
                        {
                            Console.Write(" |");
                        }
                        else
                        {
                            Console.Write("X|");
                        }
                    }
                    Console.WriteLine();
                }

                Console.WriteLine("Informe uma posição para atacar: ");
                String ataques = Console.ReadLine();
                char[] ataque = ataques.ToCharArray();

                int linhaPos = letras.IndexOf(ataque[0]);
                int colunaPos = letras.IndexOf(ataque[2]);

                if(linhaPos == -1 || colunaPos == -1)
                {
                    Console.WriteLine("Jogada inválida, por favor informe posições de A a F. Pressione qualquer tecla...");
                }
                else
                {
                    if (jogadas[linhaPos, colunaPos].Equals('X'))
                    {
                        Console.WriteLine("Você já jogou esta posição antes. Pressione qualquer tecla...");
                    }
                    else
                    {
                        if (tabuleiro[linhaPos, colunaPos].Equals('X'))
                        {
                            Console.WriteLine("Você atingiu um navio");
                            totalNaviosAtingidos++;
                        }
                        else
                        {
                            Console.WriteLine("Você atingiu a água");
                        }

                        Console.WriteLine("Você acertou " + totalNaviosAtingidos + " de " + quantBarcos + " navios. Pressione qualquer tecla...");
                    }

                    jogadas[linhaPos, colunaPos] = 'X';
                }

                Console.ReadLine();
                Console.Clear();

            } while (totalNaviosAtingidos < quantBarcos);
        }
    }
}
