using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess_ai_design
{
    public partial class TableForm : Form
    {
        public int NumClick = 0;
        public Button[,] ChessBoard = new Button[8, 8];
        //public ChessPiece[,] ChessPieces = new ChessPiece[8, 8];
        //public List<ChessPiece>[] DeafeatedWhite = new List<ChessPiece>[16];
        //public List<ChessPiece>[] DeafeatedBlack = new List<ChessPiece>[16];
        public TableForm()
        {
            InitializeComponent();
        }
        public void AddButtons(string Contents)
        {
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    ChessBoard[x, y] = new System.Windows.Forms.Button();
                    ChessBoard[x, y].Name = x.ToString() + y.ToString();
                    ChessBoard[x, y].Width = 50;
                    ChessBoard[x, y].Height = 50;
                    ChessBoard[x, y].Left = x* 50;
                    ChessBoard[x, y].Top = y * 50;
                    ChessBoard[x, y].Click += new System.EventHandler(ClickButton);
                    BoardPanel.Controls.Add(ChessBoard[x, y]);
                }
            }
            //Program.Decompress();
        }
        public void ClickButton(Object sender, System.EventArgs e)
        { }
    }
}
