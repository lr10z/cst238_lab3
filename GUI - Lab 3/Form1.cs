using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI___Lab_3
{
    public partial class Form1 : Form
    {
        private Image[] m_flags;
        private string[] m_answers;
        private string[] m_countries;
        private int m_currentIndex;
        private int m_numFlags;
        private int m_numButtons;
        private int m_score;
        private int m_minValue;
        static Random m_rand;
        
        public Form1()
        {
            InitializeComponent();

            m_flags = new Image[10] {   Properties.Resources.Australia, Properties.Resources.Brazil, 
                                        Properties.Resources.Canada, Properties.Resources.Germany,
                                        Properties.Resources.India, Properties.Resources.Japan,
                                        Properties.Resources.Netherlands, Properties.Resources.Singapore,
                                        Properties.Resources.Thailand, Properties.Resources.UnitedStates};

            m_answers = new string[10] {  "Australia", "Brazil", "Canada", "Germany", "India", "Japan", 
                                          "Netherlands", "Singapore", "Thailand", "United States"};

            m_countries = new string[10] {  "Belgium", "Egypt", "Ethiopia", "Lithuania", "Philippines", 
                                            "New Zealand", "Nigeria", "Russia", "Portugal", "Wales"};

            m_currentIndex = 0;
            m_numFlags = 10;
            m_numButtons = 3;
            m_score = 0;
            m_minValue = 0;
            m_rand = new Random();
        }

        private void nextFlag_Click(object sender, EventArgs e)
        {
            int randNum;

            // answer feedback is cleared
            label1.Text = "";

            // generates a random flag and displays it
            randNum = m_rand.Next(m_minValue, m_numFlags);
            m_currentIndex = randNum;
            pictureBox1.Image = m_flags[m_currentIndex];
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            // generates random buttons to display, one of which is the correct answer
            randNum = m_rand.Next(m_minValue, m_numButtons);

            switch(randNum)
            {
                case 1: 
                    button2.Text = m_answers[m_currentIndex];
                    button3.Text = m_countries[m_rand.Next(m_minValue, m_numFlags)];
                    button1.Text = m_countries[m_rand.Next(m_minValue, m_numFlags)];
                    break;

                case 2: 
                    button3.Text = m_answers[m_currentIndex];
                    button1.Text = m_countries[m_rand.Next(m_minValue, m_numFlags)];
                    button2.Text = m_countries[m_rand.Next(m_minValue, m_numFlags)];
                    break;

                default :
                    button1.Text = m_answers[m_currentIndex];
                    button2.Text = m_countries[m_rand.Next(m_minValue, m_numFlags)];
                    button3.Text = m_countries[m_rand.Next(m_minValue, m_numFlags)];
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int randNum;

            // generates a random flag and displays it
            randNum = m_rand.Next(m_minValue, m_numFlags);
            m_currentIndex = randNum;
            pictureBox1.Image = m_flags[m_currentIndex];
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            // generates initial buttons to display, one of which is the correct answer
            button1.Text = m_countries[1];
            button2.Text = m_answers[m_currentIndex];
            button3.Text = m_countries[2];
        }

        private void selection(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            // checks if the button clicked matches flag displayed
            if(btn.Text == m_answers[m_currentIndex])
            {
                label1.Text = "Correct!";
                ++m_score;
                label2.Text = m_score.ToString();
            }
            else
            {
                label1.Text = "Oops! Try again.";
            }
        }
    }
}
