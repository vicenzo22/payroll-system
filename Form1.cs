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
using System.Threading;


namespace PayrollGoC
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Select Position View 

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //Enter EmpID

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // Enter Password
            textBox2.PasswordChar = '*';
        }
        private void button1_Click(object sender, EventArgs e)
        {

            SetValueForText1 = textBox1.Text;

            
            if ((textBox1.Text == string.Empty) || (textBox2.Text == string.Empty) || (comboBox1.Text == string.Empty))
            {
                MessageBox.Show("Please enter data in all fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\ieong\Source\Repos\PayrollMS1\payrollSystem.accdb");
                conn.Open();
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from Mastertable where ID=" + textBox1.Text + " and Password='" + textBox2.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    OleDbCommand command = conn.CreateCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = "Select * from Mastertable where ID =" + textBox1.Text + " and (Department = 'Human Resource' or Department = 'human resource' or Department = 'Human resource' or Department = 'HR' or Department = 'hr' or Department = 'Hr')";
                    command.ExecuteNonQuery();
                    DataTable datatable = new DataTable();
                    OleDbDataAdapter dataAdapter = new OleDbDataAdapter(command);
                    dataAdapter.Fill(datatable);
                    int status = Convert.ToInt32(comboBox1.SelectedIndex);
                    textBox1.Clear();
                    textBox2.Clear();
                    if (status == 0 && datatable.Rows.Count == 1)
                    {
                        Form2 frm2 = new Form2();
                        frm2.Show();
                        this.Hide();
                        MessageBox.Show("Login Succeed!");
                    }

                    else if (status == 1 && datatable.Rows.Count == 0)
                    {
                        Form6 frm6 = new Form6();
                        frm6.Show();
                        this.Hide();
                        MessageBox.Show("Login Succeed!");
                    }
                    else
                    {
                        MessageBox.Show("Please choose the right position", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Uncorrect username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
