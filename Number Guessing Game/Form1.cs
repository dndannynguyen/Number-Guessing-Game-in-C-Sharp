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

/// <summary>
/// Number Guessing Game Application
/// Authors: Danny Nguyen and Moarco Poon
/// Date: January, 17, 2024
/// Source: Code based on the tutorial at: https://www.youtube.com/watch?v=S0GPI1mGT_A
/// Source: Support with debug at: https://stackoverflow.com/questions/3752451/enter-key-pressed-event-handler
/// </summary>

{
    public partial class Form1 : Form
    {
        Random randomNumber = new Random();

        int number = 0;
        int guesses = 1;

        /// <summary>
        /// Constructs the `Form1` class.
        /// Initializes the components of the form and sets up event handlers.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            this.textBoxInputAnswer.KeyPress += new KeyPressEventHandler(textBoxInputAnswer_KeyPress);
        }

        /// <summary>
        /// Handles the logic when the player checks a guessed number.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">Event arguments.</param>
        /// </summary>
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

        /// <summary>
        /// Generates a new random number for the player to guess.
        /// </summary>
        private void loadQuestions()
        {
            number = randomNumber.Next(0, 20);
        }

        /// <summary>
        /// Event handler for the `KeyPress` event on the input text box.
        /// Allows only digit input and backspace, blocking other characters.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">Event arguments.</param>
        private void textBoxInputAnswer_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == 8);
        }
    }
}
