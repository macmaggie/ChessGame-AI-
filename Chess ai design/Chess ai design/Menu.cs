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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void NewGButton_Click(object sender, EventArgs e)
        {
            string Contents = "1WC1WH1WB1WQ1WK1WB1WH1WC:8wP:8--:8--:8--:8--:8BP:1BC1BH1BB1BQ1BK1BB1BH1BC";
            var tableform = new TableForm();
            tableform.Show();
            tableform.AddButtons(Contents);
            //open Table form and close the previous form
            //load from the new game code 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Open Select form to open a note file and close the previous form
            OpenFileDialog PickFile = new OpenFileDialog();
            PickFile.Filter = "Text File|*.txt";
            if (PickFile.ShowDialog() == System.Windows.Forms.DialogResult.OK) // checks if they have chosen and opened a file 
            { }
            //open table form close select form 
            //Load game from load game code
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            //Exits and closes the code
        }
    }
}
