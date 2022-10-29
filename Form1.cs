using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Individual_Assignment_7
{
    public partial class Form1 : Form
    {
        private String[] questions;
        private String[] answers;
        private int current_question = 0;

        private List<Button> answer_buttons = new List<Button>();
        private bool is_finished=false;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            answer_buttons.Add(button2);
            answer_buttons.Add(button3);
            answer_buttons.Add(button4);
            answer_buttons.Add(button5);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string data = File.ReadAllText("questions.json");

            questions = data.Split(':');
            answers = new String[questions.Length];
            label1.Text = (current_question + 1).ToString() + ". Question";

            if (is_finished)
            {
                Application.Exit();
            }
            button1.Hide();

            foreach (Button item in answer_buttons)
            {
                item.Visible = true;
            }

        }
        private void answer_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            answers[current_question] = button.Text;
            current_question++;
            label1.Text = (current_question + 1).ToString() + ". Question";

            if (questions.Length == current_question)
            {
                finish_exam();
                return;
            }
        }

        private void finish_exam()
        {
            button1.Show();
            button1.Text = "Exit";
            List<int> wronganswers = new List<int>();
            for (int i = 0; i < questions.Length; i++)
            {
                if (questions[i] != answers[i])
                {
                    wronganswers.Add(i+1);
                }
            }
            if (wronganswers.Count > 5)
            {
                label1.Text = "Exam failed";
                label1.ForeColor = Color.Red;
            } else
            {
                label1.Text = "Exam passed";
                label1.ForeColor = Color.Green;
            }
            foreach (Button item in answer_buttons)
            {
                item.Visible = false;
            }
            is_finished = true; 
            Form2 form = new Form2(questions.Length - wronganswers.Count, wronganswers.Count, wronganswers);
            form.Show();
        }
    }
}
