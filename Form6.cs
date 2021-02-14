using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace PayrollGoC
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form5 myInfo = new Form5();
            myInfo.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //OleDbConnection con1 = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\ieong\Source\Repos\PayrollMS1\payrollSystem.accdb");
            //con1.Open();

            //OleDbDataReader myReader = null;
            //OleDbCommand myCommand = new OleDbCommand("select * from HRView where ID =" + int.Parse(textBox1.Text), con1);


            SetValueForText2 = textBox1.Text;


            this.Close();
            Form7 coworker = new Form7();
            coworker.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                VisitDOL();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open link that was clicked.");
            }
        }

        private void VisitDOL()
        {

            System.Diagnostics.Process.Start("https://www.dol.gov/");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                VisitSSA();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open link that was clicked.");
            }
        }

        private void VisitSSA()
        {

            System.Diagnostics.Process.Start("https://www.ssa.gov/");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                VisitHC();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open link that was clicked.");
            }
        }

        private void VisitHC()
        {

            System.Diagnostics.Process.Start("https://www.healthcare.gov/get-coverage/");
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                VisitNYS();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open link that was clicked.");
            }
        }

        private void VisitNYS()
        {

            System.Diagnostics.Process.Start("https://www.ny.gov/");
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }
    }
}
