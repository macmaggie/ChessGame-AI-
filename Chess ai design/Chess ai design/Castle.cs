using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess_ai_design
{
    class Castle:ChessPiece
    {
        public string Name;
        public string PieceImage;
        public string Colour;

        public Castle(string name, string colour)
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
            { PieceImage = @"E:\CAST\Nea Project\ChessGame AI (Github)\Chess Pieces\White Castle.png"; }//--file name--///
            if (Colour == "B")
            { PieceImage = @"E:\CAST\Nea Project\ChessGame AI (Github)\Chess Pieces\Black Castle.png"; }//--file name--///
            return PieceImage;
        }
        public override void ColorButton(ref int x, ref int y, ref Button[,] ChessBoard, ref ChessPiece[,] ChessPieces)
        {
            Program.Files(ref x, ref y, ref ChessBoard, ref ChessPieces);
        }
    }
}
