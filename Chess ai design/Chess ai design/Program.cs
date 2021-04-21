using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

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
        public static void Move(ref ChessPiece[,] ChessPieces, ref Button[,] ChessBoard, ref int NumClick, ref List<ChessPiece>[] DefeatedWhite, ref List<ChessPiece>[] DefeatedBlack)
        {
            x = Convert.ToInt32(PositionOne.Substring(0, 1));
            y = Convert.ToInt32(PositionOne.Substring(1, 1));
            int new_x = Convert.ToInt32(PositionTwo.Substring(0, 1));
            int new_y = Convert.ToInt32(PositionTwo.Substring(1, 1));
            if (ChessBoard[new_x, new_y].BackColor == Color.Red) //Checks if the selected square is a moveable sqaure (which is coloured red)
            {
                //sends the piece thats being attacked into the defeated list for display
                if (ChessPieces[new_x, new_y] is object)
                {
                    if (ChessPieces[new_x, new_y].GetData() == "W")//figures what colour the piece is to put in the right list
                    {
                        DefeatedWhite.Add(ChessPieces[new_x, new_y]); // adds the piece that going to be removed into the whitelist 
                    }
                    else if (ChessPieces[new_x, new_y].GetData() == "B")
                    {
                        DefeatedBlack.Add(ChessPieces[new_x, new_y]);
                    }
                }
                //set piece into new location 
                ChessPieces[new_x, new_y] = ChessPieces[x, y];
                ChessPieces[x, y] = null;
                ChessBoard[x, y].BackgroundImage = null;
                int change = new_y - y;
                ChessPieces[new_x, new_y].AddMoveNum(change, ref ChessPieces, ref ChessBoard, new_x, new_y);
                //this checks how far forward a piece is, this is very important for pawns to change them into a different piece at the end of the board
                ChessBoard[new_x, new_y].BackgroundImage = Image.FromFile(ChessPieces[new_x, new_y].Contents());
                //set the background for the new position into the piece put there

            }
            // @01:33 in vod ending in "1044"
            //check

        }
    }
}
