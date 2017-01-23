using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cosmo_Dino_Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //TODO: Things to be done when form loads and is ready goes here
            //Centering the title of the game horizontally
            titlePic.Left = (this.ClientSize.Width - titlePic.Width) / 2;
            //Centering the instructions button horizontally
            instBtn.Left = (this.ClientSize.Width - instBtn.Width) / 2;
            //Centering the choose dino label horizontally
            startGameBtn.Left = (this.ClientSize.Width - startGameBtn.Width) / 2;
        }

        private void instBtnClick(object sender, EventArgs e)
        {
            //TODO: Show instructions. Maybe as pop up...
        }

        //Check which dino was selested
        PictureBox dino;

        private void diploClick(object sender, EventArgs e)
        {
            //Diplo selected
            dino = dinoDiplo;
            //Other dinos made invisible
            dinoSteggy.Visible = false;
            dinoParalolo.Visible = false;
        }

        private void steggyClick(object sender, EventArgs e)
        {
            //Steggy selected
            dino = dinoSteggy;
            //Other dinos made invisible
            dinoDiplo.Visible = false;
            dinoParalolo.Visible = false;
        }

        private void paraloloClick(object sender, EventArgs e)
        {
            //Paralolo clicked
            dino = dinoParalolo;
            //Other dinos made invisible
            dinoSteggy.Visible = false;
            dinoDiplo.Visible = false;
        }

        private void startGameBtnClick(object sender, EventArgs e)
        {
            //TODO: handle start game button click
            if (dino != null)
            {
                //Center the dino
                dino.Left = (this.ClientSize.Width - dino.Width) / 2;
                //Make all elements invisible
                titlePic.Visible = false;
                instBtn.Visible = false;
                startGameBtn.Visible = false;
            }               
            else
                //Null reference to the dino Control, user warned to select a dino
                MessageBox.Show("Please select a dino first!");
        }

        //Find out if the dino is facing left
        private bool lTurn = true;

        //ALL THE MAIN CODE FOR THE GAME GOES HERE
        private void moveDinos(object sender, KeyEventArgs e)
        {
            //Checking for left key press and absence of title image
            if (e.KeyCode == Keys.Left && titlePic.Visible == false)
            {
                //If the dino is not facing left, flip the dino on left key press
                if (lTurn != true)
                {
                    dino.Image.RotateFlip(RotateFlipType.Rotate180FlipY);
                    lTurn = true;
                }
                //Else if the dino is facing left, move left. Limit: client's boundary
                else
                {
                    if (dino.Left > 0)
                    {
                        //Sub. 10 pixels from the dino's distance from the left boundary (Moves dino left)
                        dino.Left -= 10;
                    }
                }
            }
            //Checking for right key press and absence of title image
            else if (e.KeyCode == Keys.Right && titlePic.Visible == false)
            {
                //If the dino is facing left, it must now face right on right key press
                if (lTurn == true)
                {
                    dino.Image.RotateFlip(RotateFlipType.Rotate180FlipY);
                    lTurn = false;
                }
                //Else if the dino is already facing the right, move right. Limit: client's boundary
                else
                { 
                    if (dino.Left < this.ClientSize.Width - dino.Width)
                    {
                        //Add 10 pixels to the dino's distance from the left boundary (Moves dino right)
                        dino.Left += 10;
                    }
                        
                }
            }

            //TODO: main code goes here

        }

        ////
        ////WHSP
        ////
    }
}
