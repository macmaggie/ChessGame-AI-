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
        public ChessPiece[,] ChessPieces = new ChessPiece[8, 8];
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
            //Program.Decompress(Contents, ref ChessPieces, ref ChessBoard);//Loads objects + pictures
        }
        public void ClickButton(Object sender, System.EventArgs e)
        {
            string Location = ((Button)sender).Name; // gets the position of button that was pressed
            Console.WriteLine(NumClick); //----this is for debugging purposes---//
            if (NumClick == 0) //selection click 
            {
                Program.PositionOne = Location;
                Program.ShowMoves(ref ChessPieces, ref ChessBoard, ref NumClick);
            }
            else if (NumClick == 1) //moing click if the squares choosen are valid
            {
                Program.PositionTwo = Location;//get the square you want to move to
                Program
                    //----@ 2:23 in Vod ending in "1044"----//
            }
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            string Contents = null;
            string Name = null;
            NameSave NameSave = new NameSave();
            NameSave.Show();// open namesave form
            //somewhow get the var from namesaveform OR put the rest of this code into the NameSave snippet
            NameSave.Close();//close namesave form
            Program.Compress(ref Contents, Chesspieces);
            Program.SaveFile(Contents, Name);
            TableForm.close();//closes the Table form once it's saved
        }
        public void UpdateDefeatedList()
        { }
    }
}
