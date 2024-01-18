using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Number_Guessing_Game
{
    public partial class Form1 : Form
    {
        Random randomNumber = new Random();

        int number = 0;
        int guesses = 1;

        public Form1()
        {
            InitializeComponent();
            this.textBoxInputAnswer.KeyPress += new KeyPressEventHandler(textBoxInputAnswer_KeyPress);
        }

        private void checkNumber(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(textBoxInputAnswer.Text);

            guesses += 1;
            labelBottom.Text = "Attempt: " + guesses;

            if (i == number)
            {
                MessageBox.Show("You guessed it. Try another.");
                loadQuestions();
                textBoxInputAnswer.Text = "";
                guesses = 0;
                labelBottom.Text = "Attempt: " + guesses;
            }
            else if (i < number)
            {
                MessageBox.Show("Go Higher");
                textBoxInputAnswer.Text = "";
            }
            else
            {
                MessageBox.Show("Go Lower");
                textBoxInputAnswer.Text = "";
            }
        }

        private void loadQuestions()
        {
            number = randomNumber.Next(0, 20);
        }

        private void textBoxInputAnswer_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == 8);
        }
    }
}
