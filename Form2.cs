using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PayrollGoC
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label2.Text = Form1.SetValueForText1;  //corner emplid

            this.TopMost = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Close();
            Form5 myInfo = new Form5();
            myInfo.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Form3 add = new Form3();
            add.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Form4 update = new Form4();
            update.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Form4 delete = new Form4();
            delete.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            Form8 p_check = new Form8();
            p_check.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}