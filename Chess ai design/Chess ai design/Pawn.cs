using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Chess_ai_design
{
    class Pawn:ChessPiece
    {
        public string Name;
        public string PieceImage;
        public string Colour;
        public int MoveNum = 0;

        public Pawn(string name, string colour)
        {
            Name = name;
            Colour = colour;
        }
        public override string GetData()
        {
            return string.Format(this.Colour);
        }
        public override string GetDataName()
        {
            return Name;
        }
        public override void AddMoveNum(int change, ref ChessPiece[,] ChessPieces, ref Button[,] ChessBoard, int new_x, int new_y)
        {
            if (change == 2)
            { 
                MoveNum = MoveNum + 2; 
            }
            else 
            {
                MoveNum = MoveNum + 1;
            }
            if (MoveNum == 5)
            {
                string name = "Q";
                string colour = Colour;
                ChessPieces[new_x, new_y] = new Queen(name, colour);
                ChessBoard[new_x, new_y].BackgroundImage = Image.FromFile(ChessPieces[new_x, new_y].ColorPiece());
            }
        }
        public override string ColorPiece()
        {
            if (Colour == "W")
            { PieceImage = @"E:\CAST\Nea Project\ChessGame AI (Github)\Chess Pieces\White Pawn.png"; }//--file name--///
            if (Colour == "B")
            { PieceImage = @"E:\CAST\Nea Project\ChessGame AI (Github)\Chess Pieces\Black Pawn.png"; }//--file name--///
            return PieceImage;
        }
        public override void ColorButton(ref int x, ref int y, ref Button[,] ChessBoard, ref ChessPiece[,] ChessPieces)
        {
            
            if (Colour == "W")
            {
                if (ChessPieces[x, y + 1] == null)
                { 
                    ChessBoard[x, y + 1].BackColor = Color.Red;
                }
                if (MoveNum == 0 && ChessPieces[x, y + 2] == null)
                {
                    ChessBoard[x, y + 2].BackColor = Color.Red;
                }
                if (x<7 && ChessPieces[x + 1, y + 1] != null && ChessPieces[x + 1, y + 1].GetData() != this.Colour)
                {
                    ChessBoard[x+1, y + 1].BackColor = Color.Red;
                }
                if (x>0 && ChessPieces[x - 1, y + 1] != null && ChessPieces[x + 1, y + 1].GetData() != this.Colour)
                {
                    ChessBoard[x - 1, y + 1].BackColor = Color.Red;
                }
            }
            else if (Colour == "B")
            {
                if (ChessPieces[x, y - 1] == null)
                { 
                    ChessBoard[x, y - 1].BackColor = Color.Red;
                }
                if (MoveNum == 0 && ChessPieces[x, y - 2] == null)
                {
                    ChessBoard[x, y - 2].BackColor = Color.Red;
                }
                if (x<7 && ChessPieces[x + 1, y - 1] != null && ChessPieces[x + 1, y - 1].GetData() != this.Colour)
                {
                    ChessBoard[x + 1, y - 1].BackColor = Color.Red;
                }
                if (x>0 && ChessPieces[x - 1, y - 1] != null && ChessPieces[x - 1, y - 1].GetData() != this.Colour)
                {
                    ChessBoard[x - 1, y - 1].BackColor = Color.Red;
                }
            }
            //add al pasunt here check if the pawn next to it has move num 1 if yes then it can take that piece overwise it cannot
        }
    }
}
