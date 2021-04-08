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
            Application.Run(new Form1());
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
                LoadPieces(Contents, ref ChessPieces, ref ChessBoard, ref n, ref x, ref y);
                n = n + 3;
            }  
        }
        public static void Compress()
        { }
        public static void SaveFile()
        { }

        public static void LoadPieces()
        {
            ChessBoard[x, y].BackgroundImageLayout = System.Windows.ImageLayout.Stretch;
        
        }
        public static void ShowMoves()
        { }
        public static void Move()
        { }
    }
}
