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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            label15.Text = Form1.SetValueForText1;

            this.TopMost = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //firstname
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //lastname
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //date of birth
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //female
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //male
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //employee department
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //employee position
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {


        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {   

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            // gross income
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            // hourly income
        }
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            //date hired
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Health 
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Dental 
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Vision
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int overtimeHour = GrossIncome.CalculateOvertimeHour(int.Parse(textBox13.Text));
            double overtimePay = GrossIncome.CalculateOvertimePay(overtimeHour, Convert.ToDouble(textBox6.Text));
            double grossIncome = GrossIncome.CalculateGrossIncome(int.Parse(textBox13.Text), overtimePay, Convert.ToDouble(textBox6.Text));
            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\ieong\Source\Repos\PayrollMS1\payrollSystem.accdb");
            conn.Open();
            //to choose gender radio button:
            string gendertext = "";
            if (radioButton1.Checked)
            {
                gendertext = radioButton1.Text;
            }
            else if (radioButton2.Checked)
            {
                gendertext = radioButton2.Text;
            }
            if (radioButton3.Checked)
            {
                string typetext = radioButton3.Text;
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO Economictable (ID, Firstname, Lastname, Occupation, Weeklygrosspay, Paytime, [Password], DateofBirth, Age, Gender, Department, Datehired, Email, PhoneNumber, Address, Address2, Zipcode) VALUES ('" + int.Parse(textBox15.Text) + "', '" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox4.Text + "', '" + Convert.ToDouble(textBox5.Text) + "', '" + typetext  + "', '" + textBox14.Text + "', '" + dateTimePicker1.Value + "', '" + int.Parse(textBox12.Text) + "', '" + gendertext + "', '" 
                    + textBox3.Text + "', '" + dateTimePicker2.Value + "', '" + textBox7.Text + "', '" + textBox8.Text + "', '" + textBox9.Text + "', '" + textBox10.Text + "', '" + textBox11.Text + "')";
                cmd.ExecuteNonQuery();
            }
            else if (radioButton4.Checked)
            {
                string typetext = radioButton4.Text;
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO Economictable (ID, Firstname, Lastname, Occupation, Hours, OvertimeHours, Overtimepay, Weeklygrosspay, HourlyPay, Paytime, [Password], DateofBirth, Age, Gender, Department, Datehired, Email, PhoneNumber, Address, Address2, Zipcode) VALUES ('" + int.Parse(textBox15.Text) + "', '" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox4.Text + "', '" + (int.Parse(textBox13.Text) - overtimeHour) + "', '" + overtimeHour + "', '" + overtimePay + "', '" + grossIncome + "', '" 
                    + Convert.ToDouble(textBox6.Text) + "', '" + typetext + "', '" + textBox14.Text + "', '" + dateTimePicker1.Value + "', '" + int.Parse(textBox12.Text) + "', '" + gendertext + "', '" + textBox3.Text + "', '" + dateTimePicker2.Value + "', '" + textBox7.Text + "', '" + textBox8.Text + "', '" + textBox9.Text + "', '" + textBox10.Text + "', '" + textBox11.Text + "')";
                cmd.ExecuteNonQuery();
            }
            OleDbCommand addCommand = conn.CreateCommand();
            addCommand.CommandType = CommandType.Text;
            addCommand.CommandText = "INSERT INTO HRView (ID, [Password], Status, Firstname, Lastname, DateofBirth, Age, Gender, Department, Occupation, Datehired, HealthPlan, DentalCoverage, VisionCoverage, Email, PhoneNumber, Address, Address2, ZipCode, SSN, State) VALUES ('" +
                int.Parse(textBox15.Text) + "', '" + textBox14.Text + "', 'Active', '" + textBox1.Text + "', '" + textBox2.Text + "', '" + dateTimePicker1.Value + "', '" + int.Parse(textBox12.Text) + "', '" + gendertext + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + dateTimePicker2.Value + "', '" + comboBox1.Text +
                "', '" + comboBox2.Text + "', '" + comboBox3.Text + "', '" + textBox7.Text + "', '" + textBox8.Text + "', '" + textBox9.Text + "', '" + textBox10.Text + "', '" + textBox11.Text + "', '" + textBox16.Text + "', '" + comboBox4.Text + "')";
            addCommand.ExecuteNonQuery();
            if (radioButton3.Checked)
            {
                string typetext = radioButton3.Text;
                OleDbCommand command = conn.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT INTO Mastertable (ID, [Password], Weeklygrosspay, Paytime, Firstname, Lastname, DateofBirth, Age, Gender,Department, Occupation, Datehired, HealthPlan, DentalCoverage, VisionCoverage, Email, PhoneNumber, Address, Address2, Zipcode, SSN, State) VALUES ('"
                    + int.Parse(textBox15.Text) + "', '" + textBox14.Text + "', '" + Convert.ToDouble(textBox5.Text) + "', '" + typetext + "', '" + textBox1.Text + "', '" + textBox2.Text + "', '" + dateTimePicker1.Value + "', '" +
                    int.Parse(textBox12.Text) + "', '" + gendertext + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + dateTimePicker2.Value + "', '" + comboBox1.Text + "', '"
                    + comboBox2.Text + "', '" + comboBox3.Text + "', '" + textBox7.Text + "', '" + textBox8.Text + "', '" + textBox9.Text + "', '" + textBox10.Text + "', '" + textBox11.Text + "', '" + textBox16.Text + "', '" + comboBox4.Text + "')";
                command.ExecuteNonQuery();
            }
            else if (radioButton4.Checked)
            {
                string typetext = radioButton4.Text;
                OleDbCommand command = conn.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT INTO Mastertable (ID, [Password], Hours, OvertimeHours, Overtimepay, Weeklygrosspay, HourlyPay, Paytime, Firstname, Lastname, DateofBirth, Age, Gender,Department, Occupation, Datehired, HealthPlan, DentalCoverage, VisionCoverage, Email, PhoneNumber, Address, Address2, Zipcode, SSN, State) VALUES ('"
                    + int.Parse(textBox15.Text) + "', '" + textBox14.Text + "', '" + (int.Parse(textBox13.Text) - overtimeHour) + "', '" + overtimeHour + "', '" + overtimePay + "', '" + grossIncome + "', '" + Convert.ToDouble(textBox6.Text) + "', '" + typetext + "', '" + textBox1.Text + "', '" + textBox2.Text + "', '" + dateTimePicker1.Value + "', '" +
                    int.Parse(textBox12.Text) + "', '" + gendertext + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + dateTimePicker2.Value + "', '" + comboBox1.Text + "', '"
                    + comboBox2.Text + "', '" + comboBox3.Text + "', '" + textBox7.Text + "', '" + textBox8.Text + "', '" + textBox9.Text + "', '" + textBox10.Text + "', '" + textBox11.Text + "', '" + textBox16.Text + "', '" + comboBox4.Text + "')";
                command.ExecuteNonQuery();
            }
            conn.Close();
            MessageBox.Show("Add Succeed!");
            this.Close();
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Form2 hr = new Form2();
            hr.Show();
        }
    }
}