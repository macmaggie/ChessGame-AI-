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
        { }
        public override string ColorPiece()
        {
            if (Colour == "W")
            { PieceImage = @"Desktop\Chess Game Ai\ChessGame-AI-\Chess Pieces\White Pawn"; }//--file name--///
            if (Colour == "B")
            { PieceImage = @"Desktop\Chess Game Ai\ChessGame-AI-\Chess Pieces\Black Pawn"; }//--file name--///
            return PieceImage;
        }
        public override void ColorButton(ref int x, ref int y, ref Button[,] ChessBoard, ref ChessPiece[,] ChessPieces)
        {
            if (ChessPieces[x, y + 1] == null)
            { 
                ChessBoard[x, y + 1].BackColor = Color.Red;
            }
            if (ChessPieces[x + 1, y + 1] != null)
            {
                ChessBoard[x+1, y + 1].BackColor = Color.Red;
            }
            if (ChessPieces[x - 1, y + 1] != null)
            {
                ChessBoard[x - 1, y + 1].BackColor = Color.Red;
            }
            //add al pasunt here check if the pawn next to it has move num 1 if yes then it can take that piece overwise it cannot
        }
    }
}
