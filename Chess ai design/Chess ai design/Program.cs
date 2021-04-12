using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess_ai_design
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Menu());
        }
        public static void Decompress(string Contents, ref ChessPiece[,] ChessPieces, ref Button[,] ChessBoard)
        {
            int x = 0, y = 0, n = 0;
            while (Contents.Length > n) //exception handling
            {
                if (Contents.Substring(n, 1) == ":")
                {
                    y++;
                    n++;
                    x = 0;
                }
                //LoadPieces(Contents, ref ChessPieces, ref ChessBoard, ref n, ref x, ref y);
                n = n + 3;
            }  
        }
        public static void Compress()
        { }
        public static void SaveFile()
        { }

        public static void LoadPieces()
        {
            //ChessBoard[x, y].BackgroundImageLayout = System.Windows.ImageLayout.Stretch;
        
        }
        //these are set public because the "show moves" subroutine isnt connected with the "moves" subroutine. They are accessed by clicking a button
        public static string PositionOne;//intial square of piece
        public static string PositionTwo;//the square the player wants to move to
        public static int x;
        public static int y;
        public static void ShowMoves(ref ChessPiece[,] ChessPieces, ref Button[,] ChessBoard, ref int NumClick)
        {
            x = Convert.ToInt32(PositionOne.Substring(0, 1));
            y = Convert.ToInt32(PositionOne.Substring(1, 1));
            if (ChessPieces[x, y] != null) //this will cause the player to pick a new square if they pressed on a square which is empty
            {
                ChessPieces[x, y].ColorButton(ref x, ref y, ref ChessBoard, ref ChessPieces);
                NumClick = 1; // to know if you have selected a preoccupied square
            
            }
        }
        public static void Move()
        {
            x = Convert.ToInt32(PositionOne.Substring(0, 1));
            y = Convert.ToInt32(PositionOne.Substring(1, 1));
            int new_x = Convert.ToInt32(PositionTwo.Substring(0, 1));
            int new_y = Convert.ToInt32(PositionTwo.Substring(1, 1));
            // @01:33 in vod ending in "1044"

        }
    }
}
