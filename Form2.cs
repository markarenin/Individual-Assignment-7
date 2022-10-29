using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Individual_Assignment_7
{
    public partial class Form2 : Form
    {
        public Form2(int correctnum, int incorrectnum, List<int> incorrectnumbersofquestions)
        {
            InitializeComponent();
            label1.Text = "Correcty answered: " + correctnum;
            label2.Text = "Incorrectly answered: " + incorrectnum;
            foreach (int item in incorrectnumbersofquestions)
            {
                label4.Text += item + ".\n";
            }
        }
    }
}
