using System;

namespace Game
{

    class Program
    {
        static char[] board = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        static char currentPlayer = 'x';

        static void Main(string[] args)
        {
            Play();
                static void Play()
                {
                    bool live = false;
                    while (!live)
                    {
                        Map();
                        int move = movement();
                        board[move] = currentPlayer;

                    if (isWin())
                    {
                        Console.Clear();
                        Console.WriteLine("     ======KÓŁKO KRZYŻYK======");
                        Console.WriteLine("           =============");
                        Console.WriteLine("          || " + board[1] + " | " + board[2] + " | " + board[3] + " ||" + "Tura: " + currentPlayer);
                        Console.WriteLine("          ||---+---+---||");
                        Console.WriteLine("          || " + board[4] + " | " + board[5] + " | " + board[6] + " ||");
                        Console.WriteLine("          ||---+---+---||");
                        Console.WriteLine("          || " + board[7] + " | " + board[8] + " | " + board[9] + " ||");
                        Console.WriteLine("           =============\n");
                        Console.WriteLine("             " + " WYGRAŁ " + currentPlayer + "!");
                        Console.WriteLine("Czy chcesz zagrać ponownie? (T/N)");
                        
                        for (int i=0; i>=0;i++) 
                        {
                            char choice = Console.ReadKey().KeyChar;

                            if (char.ToLower(choice) == 'n') 
                                Environment.Exit(0);
                            else if (char.ToLower(choice) == 't')
                                Reset();
                            else
                                Console.WriteLine("\nNiepoprawny wybór");

                            continue;
                            
                        }
                         
                    }

                    else if (isDraw())
                    {
                        Console.Clear();
                        Console.WriteLine("     ======KÓŁKO KRZYŻYK======");
                        Console.WriteLine("           =============");
                        Console.WriteLine("          || " + board[1] + " | " + board[2] + " | " + board[3] + " ||" + "Tura: " + currentPlayer);
                        Console.WriteLine("          ||---+---+---||");
                        Console.WriteLine("          || " + board[4] + " | " + board[5] + " | " + board[6] + " ||");
                        Console.WriteLine("          ||---+---+---||");
                        Console.WriteLine("          || " + board[7] + " | " + board[8] + " | " + board[9] + " ||");
                        Console.WriteLine("           =============\n");
                        Console.WriteLine("REMIS!");
                        Console.WriteLine("Czy chcesz zagrać ponownie? (T/N)");
                        
                        for (int i = 0; i >= 0; i++)
                        {
                            char choice = Console.ReadKey().KeyChar;

                            if (char.ToLower(choice) == 'n')
                                Environment.Exit(0);
                            else if (char.ToLower(choice) == 't')
                                Reset();
                            else
                                Console.WriteLine("\nNiepoprawny wybór");
                            continue;
                        }

                    }
                    else
                    {
                        currentPlayer = (currentPlayer == 'x') ? 'o' : 'x';
                    }
                    }
            }

            static void Reset() 
            {
                board = new char[] { ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
                currentPlayer = 'x';
                Play();
            }

            Console.WriteLine("\nKONEC GRY");
            Console.ReadLine();
        }
        static void Map()
        {
            Console.Clear();
            Console.WriteLine("     ======KÓŁKO KRZYŻYK======");
            Console.WriteLine("           =============");
            Console.WriteLine("          || " + board[1] + " | " + board[2] + " | " + board[3] + " ||" + "Tura: "+ currentPlayer);
            Console.WriteLine("          ||---+---+---||");
            Console.WriteLine("          || " + board[4] + " | " + board[5] + " | " + board[6] + " ||");
            Console.WriteLine("          ||---+---+---||");
            Console.WriteLine("          || " + board[7] + " | " + board[8] + " | " + board[9] + " ||");
            Console.WriteLine("           =============\n");
        }
        static int movement()
        {
            int move = 0;
            bool trueMove = false;

            while (!trueMove)
            {
                Console.WriteLine("    "+currentPlayer + ", podaj numer pola 1-9!");
                if (int.TryParse(Console.ReadKey().KeyChar.ToString(), out move)
                    && move > 0
                    && move <= 9
                    | board[move] ==' '
                    && board[move] != 'x'
                    && board[move] != 'o')
                {
                    trueMove = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("     ======KÓŁKO KRZYŻYK======");
                    Console.WriteLine("           =============");
                    Console.WriteLine("          || " + board[1] + " | " + board[2] + " | " + board[3] + " ||" + "Tura: " + currentPlayer);
                    Console.WriteLine("          ||---+---+---||");
                    Console.WriteLine("          || " + board[4] + " | " + board[5] + " | " + board[6] + " ||");
                    Console.WriteLine("          ||---+---+---||");
                    Console.WriteLine("          || " + board[7] + " | " + board[8] + " | " + board[9] + " ||");
                    Console.WriteLine("           =============\n");
                    Console.WriteLine(" Niewykonywalny ruch, podaj poprawne pole");
                }
            }
            return move;
        }

        static bool isWin()
        {

            int[,] winningCombinations = {
                 {1, 2, 3}, {4, 5, 6}, {7, 8, 9},
                {1, 4, 7}, {2, 5, 8}, {3, 6, 9},
                {1, 5, 9}, {3, 5, 7}
            };

            for (int i = 0; i < 8; i++)
            {
                int a = winningCombinations[i, 0];
                int b = winningCombinations[i, 1];
                int c = winningCombinations[i, 2];

                if (board[a] != ' '
                   && board[a] == board[b]
                   && board[a] == board[c])
                {
                    return true;
                }
            }

            return false;
        }

        static bool isDraw()
        {
            for (int i = 1; i < 9; i++)
            {
                if (board[i] == ' ')
                {
                    return false;
                }
            }

            return true;
        }
    } 
}


