using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Chess_ai_design
{
    class King:ChessPiece
    {
        public string Name;
        public string PieceImage;
        public string Colour;

        public King(string name, string colour)
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
            { PieceImage = @"E:\CAST\Nea Project\ChessGame AI (Github)\Chess Pieces\White King.png"; }//--file name--///
            if (Colour == "B")
            { PieceImage = @"E:\CAST\Nea Project\ChessGame AI (Github)\Chess Pieces\Black King.png"; }//--file name--///
            return PieceImage;
        }
        public override void ColorButton(ref int x, ref int y, ref Button[,] ChessBoard, ref ChessPiece[,] ChessPieces)
        {
            if (x >= 1 && y >= 1 && (ChessPieces[x - 1, y - 1] == null || ChessPieces[x -1, y - 1].GetData() != Colour))
            {
                ChessBoard[x - 1, y - 1].BackColor = Color.Red;
            }
            if (x >= 0 && y >= 1 && (ChessPieces[x, y - 1] == null || ChessPieces[x, y - 1].GetData() != Colour))
            {
                ChessBoard[x, y - 1].BackColor = Color.Red;
            }
            if (x >= 1 && y >= 0 && (ChessPieces[x -1, y] == null || ChessPieces[x -1, y].GetData() != Colour))
            {
                ChessBoard[x - 1, y].BackColor = Color.Red;
            }
            if (x <= 6 && y <= 6 && (ChessPieces[x + 1, y + 1] == null || ChessPieces[x + 1, y + 1].GetData() != Colour))
            {
                ChessBoard[x + 1, y + 1].BackColor = Color.Red;
            }
            if (x <= 7 && y <= 6 && (ChessPieces[x, y + 1] == null || ChessPieces[x, y + 1].GetData() != Colour))
            {
                ChessBoard[x, y + 1].BackColor = Color.Red;
            }
            if (x <= 6 && y <= 7 && (ChessPieces[x + 1, y] == null || ChessPieces[x + 1, y].GetData() != Colour))
            {
                ChessBoard[x + 1, y].BackColor = Color.Red;
            }
            if (x >= 1 && y <= 6 && (ChessPieces[x -1, y + 1] == null || ChessPieces[x -1, y + 1].GetData() != Colour))
            {
                ChessBoard[x - 1, y + 1].BackColor = Color.Red;
            }
            if (x <= 6 && y >= 1 && (ChessPieces[x + 1, y - 1] == null || ChessPieces[x + 1, y - 1].GetData() != Colour))
            {
                ChessBoard[x + 1, y - 1].BackColor = Color.Red;
            }
        }

    }
}
