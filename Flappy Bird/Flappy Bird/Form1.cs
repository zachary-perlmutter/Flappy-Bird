using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Bird
{
    public partial class flappyBirdGame : Form
    {
        int pipeSpeed = 8;
        int gravity = 5;
        int score = 0;
        public flappyBirdGame()
        {
            InitializeComponent();
        }

        private void gameKeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 4;
            }
        }

        private void gameKeyIsDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                gravity = -8;
            }
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            scoreLabel.Text = "Score: " + score;

            if(pipeBottom.Left < -50)
            {
                pipeBottom.Left = 725;
                score++;
            }
            if(pipeTop.Left < -40)
            {
                pipeTop.Left = 815;
                score++;
            }

            if(flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) || 
               flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
               flappyBird.Bounds.IntersectsWith(ground.Bounds) ||
               flappyBird.Top < -25)
            { 
                endGame();
            }

            if((score > 29) && ((score % 30) == 0))
            {
                pipeSpeed++;
            }

        }

        private void endGame()
        {
            gameTimer.Stop();
            scoreLabel.Text += " GAME OVER!";
        }   

    }
}
