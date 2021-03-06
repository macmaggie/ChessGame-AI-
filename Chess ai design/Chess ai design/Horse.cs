using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Chess_ai_design
{
    class Horse:ChessPiece
    {
        public string Name;
        public string PieceImage;
        public string Colour;

        public Horse(string name, string colour)
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
            { PieceImage = @"E:\CAST\Nea Project\ChessGame AI (Github)\Chess Pieces\White Horse.png"; }//--file name--///
            if (Colour == "B")
            { PieceImage = @"E:\CAST\Nea Project\ChessGame AI (Github)\Chess Pieces\Black Horse.png"; }//--file name--///
            return PieceImage;
        }
        public override void ColorButton(ref int x, ref int y, ref Button[,] ChessBoard, ref ChessPiece[,] ChessPieces)
        {
            if(x<=5 && y<=6 && (ChessPieces[x + 2, y + 1] == null || ChessPieces[x + 2, y + 1].GetData() != Colour))
            {
                ChessBoard[x+2, y + 1].BackColor = Color.Red;
            }
            if (x <= 5 && y >= 1 && (ChessPieces[x + 2, y - 1] == null || ChessPieces[x+2, y-1].GetData() != Colour))
            {
                ChessBoard[x+2, y - 1].BackColor = Color.Red;
            }
            if (x<=6 && y<=5 && (ChessPieces[x + 1, y + 2] == null || ChessPieces[x+1, y+2].GetData() != Colour ))
            {
                ChessBoard[x+1, y + 2].BackColor = Color.Red;
            }
            if (x>=1 && y <= 5 && (ChessPieces[x - 1, y + 2]==null||ChessPieces[x-1, y+2].GetData() != Colour))
            {
                ChessBoard[x-1, y + 2].BackColor = Color.Red;
            }
            if (x>=2 && y <= 6 &&(ChessPieces[x - 2, y + 1] ==null || ChessPieces[x-2, y+1].GetData() != Colour))
            {
                ChessBoard[x-2, y + 1].BackColor = Color.Red;
            }
            if (x>=2 && y>=1 && (ChessPieces[x - 2, y - 1] == null || ChessPieces[x-2, y-1].GetData() != Colour))
            {
                ChessBoard[x-2, y - 1].BackColor = Color.Red;
            }
            if (x <= 6 && y >= 2 && (ChessPieces[x + 1, y - 2] == null || ChessPieces[x+1, y-2].GetData() != Colour))
            {
                ChessBoard[x+1, y -2].BackColor = Color.Red;
            }
            if (x>=1 && y>=2 && (ChessPieces[x - 1, y - 2] == null || ChessPieces[x-1, y-2].GetData() != Colour))
            {
                ChessBoard[x -1, y - 2].BackColor = Color.Red;
            }

        }
    }
}
