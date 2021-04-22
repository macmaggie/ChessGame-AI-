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
        public List<ChessPiece>[] DefeatedWhite = new List<ChessPiece>[16];
        public List<ChessPiece>[] DefeatedBlack = new List<ChessPiece>[16];
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
            Program.Decompress(Contents, ref ChessPieces, ref ChessBoard);//Loads objects + pictures
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
                Program.Move(ref ChessPieces, ref ChessBoard, ref NumClick, ref DefeatedWhite, ref DefeatedBlack);
                UpdateDefeatedList();
                for (int x = 0; x < 8; x++)
                {
                    for (int y = 0; y < 8; y++)
                    {
                        ChessBoard[x, y].BackColor = Color.Transparent;//removes the visable moveable colour 
                    }
                }
                NumClick = 0;//sets back t9o select button
                    
            }
        }
        private void SaveBtn_Click(object sender, EventArgs e) //button to savefile
        {
            string Contents = null;
            string Name = null;
            NameSave NameSave = new NameSave();
            NameSave.Show();// open namesave form
            //somewhow get the var from namesaveform OR put the rest of this code into the NameSave snippet
            NameSave.Close();//close namesave form
            Program.Compress(ref Contents, ChessPieces);
            Program.SaveFile(Contents, Name);
            //TableForm.Close();//closes the Table form once it's saved
        }
        public void UpdateDefeatedList()
        {
            WhiteList.Controls.Clear();
            BlackList.Controls.Clear();
            //clears buttons from panels
            int i = 0; //counter
            foreach (ChessPiece dead in DefeatedWhite)//white defeated pieces panel
            {
                Button WhiteObject = new System.Windows.Forms.Button(); //sets button dimentions and positioning on the panel
                WhiteObject.Width = 50;
                WhiteObject.Height = 50;
                if (i < 8)
                {
                    WhiteObject.Left = 0;
                    WhiteObject.Top = i * 50;
                }
                else 
                {
                    WhiteObject.Left = 50;
                    WhiteObject.Top = (i - 8) * 50;
                }
                //end of setting button
                //setting the defeated peice's picture and aesthetics
                WhiteObject.BackgroundImage = Image.FromFile(DefeatedWhite[i].ColorPiece());
                WhiteObject.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                WhiteObject.FlatStyle = FlatStyle.Flat;
                WhiteObject.BackColor = System.Drawing.Color.Transparent;
                WhiteList.Controls.Add(WhiteObject);//add the button to the panel for white
                i = i + 1;
            }
            i = 0;
            foreach (ChessPiece dead in DefeatedBlack)//white defeated pieces panel
            {
                Button BlackObject = new System.Windows.Forms.Button(); //sets button dimentions and positioning on the panel
                BlackObject.Width = 50;
                BlackObject.Height = 50;
                if (i < 8)
                {
                    BlackObject.Left = 0;
                    BlackObject.Top = i * 50;
                }
                else
                {
                    BlackObject.Left = 50;
                    BlackObject.Top = (i - 8) * 50;
                }
                //end of setting button
                //setting the defeated peice's picture and aesthetics
                BlackObject.BackgroundImage = Image.FromFile(DefeatedWhite[i].ColorPiece());
                BlackObject.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                BlackObject.FlatStyle = FlatStyle.Flat;
                BlackObject.BackColor = System.Drawing.Color.Transparent;
                BlackList.Controls.Add(BlackObject);//add the button to the panel for white
                i = i + 1;
            }
        }
    }
}
