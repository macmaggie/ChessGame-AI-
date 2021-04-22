using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess_ai_design
{
    public abstract class ChessPiece
    {

        public abstract string GetData();
        public abstract string GetDataName();
        public abstract void AddMoveNum(int change, ref ChessPiece[,] ChessPieces, ref Button[,] ChessBoard, int new_x, int new_y);
        public abstract string ColorPiece();
        public abstract void ColorButton(ref int x, ref int y, ref Button[,] ChessBoard, ref ChessPiece[,] ChessPieces);
    }
}
