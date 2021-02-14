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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            label3.Text = Form1.SetValueForText1;

            this.TopMost = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {



        }

        private void button4_Click(object sender, EventArgs e)
        {
            // DELETE EMP RECORD 
            int overtimeHour = GrossIncome.CalculateOvertimeHour(int.Parse(textBox2.Text));
            double overtimePay = GrossIncome.CalculateOvertimePay(overtimeHour, Convert.ToDouble(textBox6.Text));
            string message = "Confirm Deleting Employee Record";
            string title = "Delete Record";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                // Delete Record
                OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\ieong\Source\Repos\PayrollMS1\payrollSystem.accdb");
                conn.Open();
                OleDbCommand command = conn.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT INTO Leftcompany (ID, Firstname, Lastname, Occupation, Department, DateofBirth, Gender, Email, PhoneNumber, Address, Address2, Zipcode, DentalCoverage, VisionCoverage, Hours, OvertimeHours, Overtimepay, HourlyPay, WeeklyGrosspay, Status) VALUES ('" +
                    int.Parse(textBox1.Text) + "', '" + label16.Text + "', '" + label20.Text + "', '" + textBox4.Text + "', '" + textBox3.Text + "', '" + label21.Text + "', '" + label22.Text + "', '" + textBox7.Text + "', '" + textBox8.Text + "', '" +
                    textBox9.Text + "', '" + textBox10.Text + "', '" + textBox11.Text + "', '" + label32.Text + "', '" + label31.Text + "', '" + int.Parse(textBox2.Text) + "', '" + overtimeHour + "', '" + overtimePay + "', '" + Convert.ToDouble(textBox5.Text) + "', '" + Convert.ToDouble(textBox6.Text) + "', '" + textBox12.Text + "')";
                command.ExecuteNonQuery();
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM Economictable WHERE ID = " + int.Parse(textBox1.Text);
                cmd.ExecuteNonQuery();
                OleDbCommand cmd1 = conn.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "DELETE FROM HRView WHERE ID = " + int.Parse(textBox1.Text);
                cmd1.ExecuteNonQuery();
                OleDbCommand cmd2 = conn.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "DELETE FROM Mastertable WHERE ID = " + int.Parse(textBox1.Text);
                cmd2.ExecuteNonQuery();
                conn.Close();
                this.Close();
                MessageBox.Show("Employee Record Deleted");
            }
            else
            {
                this.Close();
            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //if filled up change database
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //if filled up!!! change database 
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            //updated gross income
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            //updated hourly income
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //change health benefit
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //change dental benefit
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //change vision benefit
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //sql connection
            OleDbConnection con1 = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\ieong\Source\Repos\PayrollMS1\payrollSystem.accdb");
            con1.Open();
            //check if the employee id is found:
            //data from HRView:
            OleDbDataReader myReader = null;
            OleDbCommand myCommand = new OleDbCommand("select * from HRView where ID =" + int.Parse(textBox1.Text), con1);
            //DataTable dt = new DataTable();
            //OleDbDataAdapter da = new OleDbDataAdapter(myCommand);
            //da.Fill(dt);
            //if (dt.Rows.Count == 1)
            //{
            myReader = myCommand.ExecuteReader();

            //read data from database into gui form 4:
            while (myReader.Read())
            {
                label16.Text = (myReader["Firstname"].ToString());
                label20.Text = (myReader["Lastname"].ToString());
                label21.Text = (myReader["DateofBirth"].ToString());
                label22.Text = (myReader["Gender"].ToString());
                textBox7.Text = (myReader["Email"].ToString());
                textBox8.Text = (myReader["PhoneNumber"].ToString());
                textBox9.Text = (myReader["Address"].ToString());
                textBox10.Text = (myReader["Address2"].ToString());
                textBox11.Text = (myReader["ZipCode"].ToString());
                textBox3.Text = (myReader["Department"].ToString());
                textBox4.Text = (myReader["Position"].ToString());
                label33.Text = (myReader["HealthPlan"].ToString());
                label32.Text = (myReader["DentalCoverage"].ToString());
                label31.Text = (myReader["VisionCoverage"].ToString());
                textBox12.Text = (myReader["Status"].ToString());


            }
            //else
            //{
            //    MessageBox.Show("The ID you inputted did not exist in the database");
            //}
            OleDbCommand myCommand1 = new OleDbCommand("select * from Economictable where ID =" + int.Parse(textBox1.Text), con1);
            //DataTable dt1 = new DataTable();
            //OleDbDataAdapter da1 = new OleDbDataAdapter(myCommand);
            //da1.Fill(dt1);
            //if (dt.Rows.Count == 1)
            //{
            myReader = myCommand1.ExecuteReader();

            //read data from database into gui form 4:
            while (myReader.Read())
            {
                textBox2.Text = (myReader["Hours"].ToString());
                textBox5.Text = (myReader["Weeklygrosspay"].ToString());
                textBox6.Text = (myReader["HourlyPay"].ToString());
            }
            //else
            //{
            //    MessageBox.Show("The ID you inputted did not exist in the database");
            //}
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            // Save New Info to database 


            //string message = "Confirm Updating Employee Record";
            //string title = "Update Record";
            //MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            //DialogResult result = MessageBox.Show(message, title, buttons);
            //if (result == DialogResult.Yes)
            //{
            // Update Record
            //sql connection
            int overtimeHour = GrossIncome.CalculateOvertimeHour(int.Parse(textBox2.Text));
            double overtimePay = GrossIncome.CalculateOvertimePay(overtimeHour, Convert.ToDouble(textBox6.Text));
            double grossIncome = GrossIncome.CalculateGrossIncome(int.Parse(textBox2.Text), overtimePay, Convert.ToDouble(textBox6.Text));
            OleDbConnection con1 = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\ieong\Source\Repos\PayrollMS1\payrollSystem.accdb");
            con1.Open();


            //OleDbCommand cmd = new OleDbCommand("UPDATE HRView SET [Email] = @Email, [PhoneNumber] = @PhoneNumber, [Address] = @Address, [Address2] =  @Address2, [ZipCode] = @ZipCode, [Department]= @Department, [Position] = @Position where ID =" + int.Parse(textBox1.Text), con1);
            OleDbCommand cmd = new OleDbCommand("UPDATE HRView SET [Email] = @Email, [PhoneNumber] = @PhoneNumber, [Address] = @Address, [Address2] =  @Address2, [ZipCode] = @ZipCode, [Department]= @Department, [Position] = @Position, [HealthPlan] = @HealthPlan, [DentalCoverage] = @DentalCoverage, [VisionCoverage] = @VisionCoverage WHERE ID =" + int.Parse(textBox1.Text), con1);


            //to save the updates to database:
            cmd.Parameters.AddWithValue("@Email", textBox7.Text);
            cmd.Parameters.AddWithValue("@PhoneNumber", textBox8.Text);
            cmd.Parameters.AddWithValue("@Address", textBox9.Text);
            cmd.Parameters.AddWithValue("@Address2", textBox10.Text);
            cmd.Parameters.AddWithValue("@ZipCode", textBox11.Text);
            cmd.Parameters.AddWithValue("@Department", textBox3.Text);
            cmd.Parameters.AddWithValue("@Position", textBox4.Text);
            cmd.Parameters.AddWithValue("@HealthPlan", comboBox1.Text);
            cmd.Parameters.AddWithValue("@DentalCoverage", comboBox2.Text);
            cmd.Parameters.AddWithValue("@VisionCoverage", comboBox3.Text);
            cmd.ExecuteNonQuery();

            if (textBox6.Text == "0.00")
            {
                OleDbCommand cmd1 = new OleDbCommand("UPDATE Economictable SET [Weeklygrosspay] = @Weeklygrosspay, [Occupation] = @Occupation, [Email] = @Email, [PhoneNumber] = @PhoneNumber, [Address] = @Address, [Address2] =  @Address2, [Zipcode] = @Zipcode, [Department]= @Department where ID =" + int.Parse(textBox1.Text), con1);
                cmd1.Parameters.AddWithValue("@Occupation", textBox4.Text);
                cmd1.Parameters.AddWithValue("@Weeklygrosspay", Convert.ToDouble(textBox5.Text));
                cmd1.Parameters.AddWithValue("@Email", textBox7.Text);
                cmd1.Parameters.AddWithValue("@PhoneNumber", textBox8.Text);
                cmd1.Parameters.AddWithValue("@Address", textBox9.Text);
                cmd1.Parameters.AddWithValue("@Address2", textBox10.Text);
                cmd1.Parameters.AddWithValue("@Zipcode", textBox11.Text);
                cmd1.Parameters.AddWithValue("@Department", textBox3.Text);
                cmd1.ExecuteNonQuery();
            }
            else
            {
                OleDbCommand cmd2 = new OleDbCommand("UPDATE Economictable SET [Hours] = @Hours, [OvertimeHours] = @OvertimeHours, [Overtimepay] = @Overtimepay, [Weeklygrosspay] = @Weeklygrosspay, [Occupation] = @Occupation, [Email] = @Email, [PhoneNumber] = @PhoneNumber, [Address] = @Address, [Address2] =  @Address2, [Zipcode] = @Zipcode, [Department]= @Department where ID =" + int.Parse(textBox1.Text), con1);
                cmd2.Parameters.AddWithValue("@Hours", (int.Parse(textBox2.Text) - overtimeHour));
                cmd2.Parameters.AddWithValue("@OvertimeHours", overtimeHour);
                cmd2.Parameters.AddWithValue("@Overtimepay", overtimePay);
                cmd2.Parameters.AddWithValue("@Weeklygrosspay", grossIncome);
                cmd2.Parameters.AddWithValue("@Occupation", textBox4.Text);
                cmd2.Parameters.AddWithValue("@Email", textBox7.Text);
                cmd2.Parameters.AddWithValue("@PhoneNumber", textBox8.Text);
                cmd2.Parameters.AddWithValue("@Address", textBox9.Text);
                cmd2.Parameters.AddWithValue("@Address2", textBox10.Text);
                cmd2.Parameters.AddWithValue("@Zipcode", textBox11.Text);
                cmd2.Parameters.AddWithValue("@Department", textBox3.Text);
                cmd2.ExecuteNonQuery();
            }

            if (textBox6.Text == "0.00")
            {
                OleDbCommand cmd3 = new OleDbCommand("UPDATE Mastertable SET [Weeklygrosspay] = @Weeklygrosspay, [Occupation] = @Occupation, [Email] = @Email, [PhoneNumber] = @PhoneNumber, [Address] = @Address, [Address2] =  @Address2, [ZipCode] = @ZipCode, [Department]= @Department, [HealthPlan] = @HealthPlan, [DentalCoverage] = @DentalCoverage, [VisionCoverage] = @VisionCoverage where ID =" + int.Parse(textBox1.Text), con1);
                cmd3.Parameters.AddWithValue("@Occupation", textBox4.Text);
                cmd3.Parameters.AddWithValue("@Weeklygrosspay", Convert.ToDouble(textBox5.Text));
                cmd3.Parameters.AddWithValue("@Email", textBox7.Text);
                cmd3.Parameters.AddWithValue("@PhoneNumber", textBox8.Text);
                cmd3.Parameters.AddWithValue("@Address", textBox9.Text);
                cmd3.Parameters.AddWithValue("@Address2", textBox10.Text);
                cmd3.Parameters.AddWithValue("@ZipCode", textBox11.Text);
                cmd3.Parameters.AddWithValue("@Department", textBox3.Text);
                cmd3.Parameters.AddWithValue("@HealthPlan", comboBox1.Text);
                cmd3.Parameters.AddWithValue("@DentalCoverage", comboBox2.Text);
                cmd3.Parameters.AddWithValue("@VisionCoverage", comboBox3.Text);
                cmd3.ExecuteNonQuery();
            }
            else
            {
                OleDbCommand cmd4 = new OleDbCommand("UPDATE Mastertable SET [Hours] = @Hours, [OvertimeHours] = @OvertimeHours, [Overtimepay] = @Overtimepay, [Weeklygrosspay] = @Weeklygrosspay, [Occupation] = @Occupation, [Email] = @Email, [PhoneNumber] = @PhoneNumber, [Address] = @Address, [Address2] =  @Address2, [ZipCode] = @ZipCode, [Department]= @Department, [HealthPlan] = @HealthPlan, [DentalCoverage] = @DentalCoverage, [VisionCoverage] = @VisionCoverage where ID =" + int.Parse(textBox1.Text), con1);
                cmd4.Parameters.AddWithValue("@Hours", (int.Parse(textBox2.Text) - overtimeHour));
                cmd4.Parameters.AddWithValue("@OvertimeHours", overtimeHour);
                cmd4.Parameters.AddWithValue("@Overtimepay", overtimePay);
                cmd4.Parameters.AddWithValue("@Weeklygrosspay", grossIncome);
                cmd4.Parameters.AddWithValue("@Occupation", textBox4.Text);
                cmd4.Parameters.AddWithValue("@Email", textBox7.Text);
                cmd4.Parameters.AddWithValue("@PhoneNumber", textBox8.Text);
                cmd4.Parameters.AddWithValue("@Address", textBox9.Text);
                cmd4.Parameters.AddWithValue("@Address2", textBox10.Text);
                cmd4.Parameters.AddWithValue("@ZipCode", textBox11.Text);
                cmd4.Parameters.AddWithValue("@Department", textBox3.Text);
                cmd4.Parameters.AddWithValue("@HealthPlan", comboBox1.Text);
                cmd4.Parameters.AddWithValue("@DentalCoverage", comboBox2.Text);
                cmd4.Parameters.AddWithValue("@VisionCoverage", comboBox3.Text);
                cmd4.ExecuteNonQuery();
            }
            con1.Close();
            MessageBox.Show("Employee Record Updated");
        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Form2 hr = new Form2();
            hr.Show();
        }
    }
    //else
    //{
    //    this.Close();
    //}
    //}
}