using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Form1 : Form
    {
        static int gridDim = 20;
        static int buttonDim = 30;
        static int mines;
        PictureBox[,] grid = new PictureBox[gridDim, gridDim];
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        void Common_MouseDown(object sender, MouseEventArgs e) // click handler for all the cell buttons
        {
            var box = (sender as PictureBox);
            if (e.Button == MouseButtons.Left) // left click
            {
                box.BorderStyle = BorderStyle.FixedSingle;
                box.BackColor = Color.White;
                if (box.Tag.ToString() == "mine")
                {
                    box.Image = Minesweeper.Properties.Resources.mine;
                    GameOver();
                }
                else
                {
                    switch (box.Tag)
                    {
                        case 1:
                            box.Image = Minesweeper.Properties.Resources.one;
                            break;
                        case 2:
                            box.Image = Minesweeper.Properties.Resources.two;
                            break;
                        case 3:
                            box.Image = Minesweeper.Properties.Resources.three;
                            break;
                        case 4:
                            box.Image = Minesweeper.Properties.Resources.four;
                            break;
                        case 5:
                            box.Image = Minesweeper.Properties.Resources.five;
                            break;
                        case 6:
                            box.Image = Minesweeper.Properties.Resources.six;
                            break;
                        case 7:
                            box.Image = Minesweeper.Properties.Resources.seven;
                            break;
                        case 8:
                            box.Image = Minesweeper.Properties.Resources.eight;
                            break;
                        default:
                            expand();
                            break;

                    }
                }
                
            }



            if (e.Button == MouseButtons.Right) //right click
            {
                if (box.Image == Minesweeper.Properties.Resources.mineFlag)
                {
                    MessageBox.Show("in here");
                    box.Image = Minesweeper.Properties.Resources.blank;
                }
                else
                { box.Image = Minesweeper.Properties.Resources.mineFlag; }
               
            }
        }
        private void Neighbors() //count how many neighbours are mines
        {

            for (int i = 0; i < gridDim; i = i + 1)
            {
                for (int j = 0; j < gridDim; j = j + 1)
                {
                    int countNeighbours = 0;
                    int xl = i - 1;
                    if (xl == -1) { xl = 0; }
                    int xr = i + 1;
                    if (xr == gridDim) { xr = gridDim-1; }
                    int yd = j - 1;
                    if (yd == -1) { yd = 0; }
                    int yu = j + 1;
                    if (yu == gridDim) { yu = gridDim - 1; }
                    // count the neighbours that are mines
                    if (grid[xl, yu].Tag.ToString() == "mine") { countNeighbours++; }
                    if (grid[xl, j].Tag.ToString() == "mine") { countNeighbours++; }
                    if (grid[xl, yd].Tag.ToString() == "mine") { countNeighbours++; }
                    if (grid[i, yu].Tag.ToString() == "mine") { countNeighbours++; }
                    if (grid[i, yd].Tag.ToString() == "mine") { countNeighbours++; }
                    if (grid[xr, yu].Tag.ToString() == "mine") { countNeighbours++; }
                    if (grid[xr, j].Tag.ToString() == "mine") { countNeighbours++; }
                    if (grid[xr, yd].Tag.ToString() == "mine") { countNeighbours++; }

                    if (grid[i, j].Tag.ToString() != "mine")
                    {
                        grid[i, j].Tag = countNeighbours;
                    }
                }
            }
        }

        private void expand() // go here and show all blanks and boundaries
        {
            //go up and right
            for (int i = 0; i < gridDim; i = i + 1)
            {
                for (int j = 0; j < gridDim; j = j + 1)
                {
                    int xl = i - 1;
                    if (xl == -1) { xl = 0; } 
                    int xr = i + 1;
                    if (xr == gridDim) { xr = gridDim-1; }
                    int yd = j - 1;
                    if (yd == -1) { yd = 0; }
                    int yu = j + 1;
                    if (yu == gridDim) { yu = gridDim-1; }
                    // show the neighbours to a white square
                    if (grid[i, j].Tag.ToString() == "0" && grid[i, j].BackColor == Color.White && grid[xl, yu].Tag.ToString() != "mine") {ShowTag(grid[xl, yu]); }
                    if (grid[i, j].Tag.ToString() == "0" && grid[i, j].BackColor == Color.White && grid[xl, j].Tag.ToString() != "mine") { ShowTag(grid[xl, j]); }
                    if (grid[i, j].Tag.ToString() == "0" && grid[i, j].BackColor == Color.White && grid[xl, yd].Tag.ToString() != "mine") { ShowTag(grid[xl, yd]); }
                    if (grid[i, j].Tag.ToString() == "0" && grid[i, j].BackColor == Color.White && grid[i, yu].Tag.ToString() != "mine") { ShowTag(grid[i, yu]); }
                    if (grid[i, j].Tag.ToString() == "0" && grid[i, j].BackColor == Color.White && grid[i, yd].Tag.ToString() != "mine") { ShowTag(grid[i, yd]); }
                    if (grid[i, j].Tag.ToString() == "0" && grid[i, j].BackColor == Color.White && grid[xr, yu].Tag.ToString() != "mine") { ShowTag(grid[xr, yu]); }
                    if (grid[i, j].Tag.ToString() == "0" && grid[i, j].BackColor == Color.White && grid[xr, j].Tag.ToString() != "mine") { ShowTag(grid[xr, j]); }
                    if (grid[i, j].Tag.ToString() == "0" && grid[i, j].BackColor == Color.White && grid[xr, yd].Tag.ToString() != "mine") { ShowTag(grid[xr, yd]); }

                    
                }
            }
            //go left and down
            for (int i = gridDim -1; i > 0; i = i - 1)
            {
                for (int j = gridDim-1; j > 0; j = j - 1)
                {
                    int xl = i - 1;
                    if (xl == -1) { xl = 0; } 
                    int xr = i + 1;
                    if (xr == gridDim) { xr = gridDim - 1; }
                    int yd = j - 1;
                    if (yd == -1) { yd = 0; }
                    int yu = j + 1;
                    if (yu == gridDim) { yu = gridDim - 1; }
                    // show the neighbours to a white square
                    if (grid[i, j].Tag.ToString() == "0" && grid[i, j].BackColor == Color.White && grid[xl, yu].Tag.ToString() != "mine") { ShowTag(grid[xl, yu]); }
                    if (grid[i, j].Tag.ToString() == "0" && grid[i, j].BackColor == Color.White && grid[xl, j].Tag.ToString() != "mine") { ShowTag(grid[xl, j]); }
                    if (grid[i, j].Tag.ToString() == "0" && grid[i, j].BackColor == Color.White && grid[xl, yd].Tag.ToString() != "mine") { ShowTag(grid[xl, yd]); }
                    if (grid[i, j].Tag.ToString() == "0" && grid[i, j].BackColor == Color.White && grid[i, yu].Tag.ToString() != "mine") { ShowTag(grid[i, yu]); }
                    if (grid[i, j].Tag.ToString() == "0" && grid[i, j].BackColor == Color.White && grid[i, yd].Tag.ToString() != "mine") { ShowTag(grid[i, yd]); }
                    if (grid[i, j].Tag.ToString() == "0" && grid[i, j].BackColor == Color.White && grid[xr, yu].Tag.ToString() != "mine") { ShowTag(grid[xr, yu]); }
                    if (grid[i, j].Tag.ToString() == "0" && grid[i, j].BackColor == Color.White && grid[xr, j].Tag.ToString() != "mine") { ShowTag(grid[xr, j]); }
                    if (grid[i, j].Tag.ToString() == "0" && grid[i, j].BackColor == Color.White && grid[xr, yd].Tag.ToString() != "mine") { ShowTag(grid[xr, yd]); }


                }
            }
        }
       
        private void ShowTag(PictureBox box)
        {
            box.BorderStyle = BorderStyle.FixedSingle;
            box.BackColor = Color.White;
            switch (box.Tag)
            {
                case 1:
                    box.Image = Minesweeper.Properties.Resources.one;
                    break;
                case 2:
                    box.Image = Minesweeper.Properties.Resources.two;
                    break;
                case 3:
                    box.Image = Minesweeper.Properties.Resources.three;
                    break;
                case 4:
                    box.Image = Minesweeper.Properties.Resources.four;
                    break;
                case 5:
                    box.Image = Minesweeper.Properties.Resources.five;
                    break;
                case 6:
                    box.Image = Minesweeper.Properties.Resources.six;
                    break;
                case 7:
                    box.Image = Minesweeper.Properties.Resources.seven;
                    break;
                case 8:
                    box.Image = Minesweeper.Properties.Resources.eight;
                    break;
                default:
                    //expand();//causes stack over flow due to the unconstrained recursion
                    break;

            }
        }
        private void GameOver()
        {
            MessageBox.Show("GAME OVER"); //temperary game over routine
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Size = new Size(800, 800);
            this.CenterToScreen();
            int x = 0;
            int y = 0;
            mines =Decimal.ToInt32( numericUpDown1.Value);

            for (int i = 0; i < gridDim; i = i + 1)
            {
                for (int j = 0; j < gridDim; j = j + 1)
                {
                    grid[i, j] = new PictureBox
                    {

                        Size = new Size(buttonDim, buttonDim),
                        Location = new Point(y, x),
                        BorderStyle = BorderStyle.FixedSingle,
                        BackColor = Color.LightGreen,
                        Tag = "",
                        SizeMode = PictureBoxSizeMode.StretchImage
                    };
                    (grid[i, j]).MouseDown += new MouseEventHandler(Common_MouseDown);
                    this.Controls.Add(grid[i, j]);

                    x += buttonDim;
                }
                y += buttonDim;
                x = 0;
            }
            //load up random bombs
            for (int i = 0; i < mines; i++)
            {
                Random rnd = new Random(Guid.NewGuid().GetHashCode());
                int mineX = rnd.Next(0, gridDim - 1);
                int mineY = rnd.Next(0, gridDim - 1);
                grid[mineX, mineY].Tag = "mine";
            }
            // count and tag neighbours
            Neighbors();
        }
    }
    
}




