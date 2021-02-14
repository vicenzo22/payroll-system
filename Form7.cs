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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            MessageBox.Show("Succesfully Logged Out");
            Form1 myInfo = new Form1();
            myInfo.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Form6 myInfo = new Form6();
            myInfo.Show();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            label15.Text = Form1.SetValueForText1;  //corner emplid
            string coworker = Form6.SetValueForText2;   //co-worker emplid

            // this.TopMost = true;

            //database connection
            OleDbConnection con1 = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\ieong\Source\Repos\PayrollMS1\payrollSystem.accdb");
            con1.Open();

            //retrieve info from databse based on empl id
            OleDbDataReader myReader = null;
            OleDbCommand myCommand = new OleDbCommand("select * from HRView where ID =" + coworker, con1);

            myReader = myCommand.ExecuteReader();

            //read data from database into gui form 4:
            while (myReader.Read())
            {

                label6.Text = (myReader["Firstname"].ToString());
                label7.Text = (myReader["Lastname"].ToString());
                label8.Text = (myReader["RoomNo"].ToString());
                label9.Text = (myReader["PhoneNumber"].ToString());
                label10.Text = (myReader["Email"].ToString());

            }

        }
    }
    }

