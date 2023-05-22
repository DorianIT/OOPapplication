using System;
using System.Data;
using System.Security.Principal;

namespace game 
{

    class apl
    {
        static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static char currentPlayer = 'x';

        static void Main(string[] args) {
            bool live = false;

            while (!live) 
            {

                Map();
                int move = Movement();
                board[move] = currentPlayer;

                if (isWin())
                {
                    Map();
                    Console.WriteLine(currentPlayer + "WYGRAŁ !");
                    live = true;
                }

                else if (isDraw()) 
                {
                    Map();
                    Console.WriteLine("REMIS");
                    live = true;
                }
                else
                {
                    currentPlayer = (currentPlayer == 'x') ? 'o' : 'x';
                }
            }
            Console.WriteLine("GAME OVER");
            Console.ReadLine(); 
        }
    static void Map()
        {
            Console.Clear();
            Console.WriteLine("-----------");
            Console.WriteLine("" + board[0] + " | " + board[1] + " | " + board[2] + " ");
            Console.WriteLine("---+---+---");
            Console.WriteLine("" + board[3] + " | " + board[4] + " | " + board[5] + " ");
            Console.WriteLine("---+---+---");
            Console.WriteLine("" + board[6] + " | " + board[7] + " | " + board[8] + " ");
            Console.WriteLine("-----------");
        }
        static int Movement() 
        {

            int move = -1;
            bool trueMove = false;

            while (!trueMove) 
            {
            
                Console.WriteLine(currentPlayer + ", podaj numer pola 1-9!");
                if (int.TryParse(Console.ReadLine(), out move) 
                    && move >= 0 
                    && move < 9
                    && board[move] == '1'
                    && board[move] == '2'
                    && board[move] == '3'
                    && board[move] == '4'
                    && board[move] == '5'
                    && board[move] == '6'
                    && board[move] == '7'
                    && board[move] == '8'
                    && board[move] == '9') 
                {
                    trueMove = true;
                }
                else
                {
                     Console.WriteLine("Niewykonywalny ruch, podaj poprawne pole");
                }
            }
            return move;
        }
        static bool isWin() 
        {
            int[,] win = {
            {0,1,2}, {3,4,5}, {6,7,8},
            {0,3,8}, {1,4,7}, {2,5,8},
            {0,4,8}, {2,4,6}
            };

            for (int i = 0; i < 8; i++)
            {
                int a = win[i, 0];
                int b = win[i, 1];
                int c = win[i, 2];

                if (board[a] != '1'
                    && board[a] != '2'
                    && board[a] != '3'
                    && board[a] != '4'
                    && board[a] != '5'
                    && board[a] != '6'
                    && board[a] != '7'
                    && board[a] != '8'
                    && board[a] != '9'
                    && board[a] == board[b] 
                    && board[a] == board[c])
                    {
                    return true;   
                    }

                static bool isDraw() 
                {
                    for (int i = 0; i < 9; i++) 
                    {
                        if (&& board[i] == '1'
                        && board[i] == '2'
                        && board[i] == '3'
                        && board[i] == '4'
                        && board[i] == '5'
                        && board[i] == '6'
                        && board[i] == '7'
                        && board[i] == '8'
                        && board[i] == '9') 
                        {
                        return false;  
                        }
                    }
                }
            }
        }
    }
}
