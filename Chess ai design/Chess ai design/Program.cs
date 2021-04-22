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

        public static void LoadPieces(string Contents, ref ChessPiece[,] ChessPieces, ref Button[,] ChessBoard, ref int n, ref int x, ref int y)
        {
            string colour;
            string name;
            for (int r = 0; r < Convert.ToInt32(Contents.Substring(n, 1)); r++)
            {
                colour = Contents.Substring(n + 1, 1);
                switch (Contents.Substring(n + 2, 1))
                {
                    case "P":
                        name = "P";
                        ChessPieces[x, y] = new Pawn(name, colour);
                        break;
                    case "C":
                        break;
                    case "H":
                        break;
                    case "B":
                        break;
                    case "Q":
                        break;
                    case "K":
                        break;
                }
            }
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
            // @06:22 in vod ending in "3c7"
            //check
            
        }
        public static void Diagonal(ref int x, ref int y, ref Button[,] ChessBoard, ref ChessPiece[,] ChessPieces)
        {
            //calculate all the squares that are good to move to (for bishop and queen)
            int new_x, new_y;
            for (int d = 0; d < 4; d++)
            {
                new_x = x;
                new_y = y;
                switch(d)
                {
                    case (0): //(Top Right)
                        new_x = new_x + 1;
                        new_y = new_y + 1;
                        while (new_x <= 7 && new_y <= 7 && ChessPieces[new_x, new_y] == null) //checks only real squares and squares that are free
                        {
                            ChessBoard[new_x, new_y].BackColor = Color.Red;
                            new_x = new_x + 1;
                            new_y = new_y + 1;
                        }
                        break;
                    case (1): //(Bottom Left)
                        new_x = new_x - 1;
                        new_y = new_y - 1;
                        while (new_x >= 0 && new_y >= 0 && ChessPieces[new_x, new_y] == null)
                        {
                            ChessBoard[new_x, new_y].BackColor = Color.Red;
                            new_x = new_x - 1;
                            new_y = new_y - 1;
                        }
                        break;
                    case (2): //(Top Left)
                        new_x = new_x + 1;
                        new_y = new_y - 1;
                        while (new_x <= 7 && new_y >= 0 && ChessPieces[new_x, new_y] == null)
                        {
                            ChessBoard[new_x, new_y].BackColor = Color.Red;
                            new_x = new_x + 1;
                            new_y = new_y - 1;
                        }
                        break;
                    case (3): //(Bottom Right)
                        new_x = new_x - 1;
                        new_y = new_y + 1;
                        while (new_x >= 0 && new_y <= 7 && ChessPieces[new_x, new_y] == null) 
                        {
                            ChessBoard[new_x, new_y].BackColor = Color.Red;
                            new_x = new_x - 1;
                            new_y = new_y + 1;
                        }
                        break;
                }
                //Checks the final square if in bounds of array, if it has an object, and if its the opposition.
                //if true then square is moveable (coloured red)
                
                if (new_x <= 7 && new_y <= 7 && new_x >= 0 && new_y >= 0 && ChessPieces[new_x, new_y] != null && ChessPieces[new_x,new_y].GetData()!= ChessPieces[x,y].GetData()) 
                {//checks only real squares and squares that are free
                    ChessBoard[new_x, new_y].BackColor = Color.Red;
                }
               
            }
        }
        public static void Files(ref int x, ref int y, ref Button[,] ChessBoard, ref ChessPiece[,] ChessPieces)
        {//calculates all moves in a file (for Castles and Queens)
            //similar to Diagondal Subroutine
            int new_x, new_y;
            for (int d = 0; d < 4; d++)
            {
                new_x = x;
                new_y = y;
                switch (d)
                {
                    case (0): //(Right)
                        new_x = new_x + 1;
                        while (new_x <= 7 && ChessPieces[new_x, new_y] == null) //checks only real squares and squares that are free
                        {
                            ChessBoard[new_x, new_y].BackColor = Color.Red;
                            new_x = new_x + 1;
                        }
                        break;
                    case (1): //(Left)
                        new_x = new_x - 1;
                        while (new_x >= 0 && ChessPieces[new_x, new_y] == null) //checks only real squares and squares that are free
                        {
                            ChessBoard[new_x, new_y].BackColor = Color.Red;
                            new_x = new_x - 1;
                        }
                        break;
                    case (3): //(Top)
                        new_y = new_y + 1;
                        while (new_y <= 7 && ChessPieces[new_x, new_y] == null) //checks only real squares and squares that are free
                        {
                            ChessBoard[new_x, new_y].BackColor = Color.Red;
                            new_y = new_y + 1;
                        }
                        break;
                    case (2): //(Down)
                        new_y = new_y - 1;
                        while (new_y >= 0 && ChessPieces[new_x, new_y] == null) //checks only real squares and squares that are free
                        {
                            ChessBoard[new_x, new_y].BackColor = Color.Red;
                            new_y = new_y - 1;
                        }
                        break;
                }
                //Handles the last square if opposition piece is there then color moveable (red) 
                if (new_x <= 7 && new_y <= 7 && new_x >= 0 && new_y >= 0 && ChessPieces[new_x, new_y] != null && ChessPieces[new_x, new_y].GetData() != ChessPieces[x, y].GetData()) //---unknown parameter in vod ending in 3c7---//
                {//checks only real squares and squares that are free
                    ChessBoard[new_x, new_y].BackColor = Color.Red;
                }

            }
        }
    }
}
