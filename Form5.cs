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
    public partial class Form5 : Form
    {

        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            //to get the emplid from login form:
            label31.Text = Form1.SetValueForText1;
            this.TopMost = true;


            //database connection
            OleDbConnection con1 = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\ieong\Source\Repos\PayrollMS1\payrollSystem.accdb");
            con1.Open();

            //retrieve info from databse based on empl id
            OleDbDataReader myReader = null;
            OleDbCommand myCommand = new OleDbCommand("select * from HRView where ID =" + label31.Text, con1);

            myReader = myCommand.ExecuteReader();

            //read data from database into gui form 4:
            while (myReader.Read())
            {

                label1.Text = (myReader["Firstname"].ToString());
                label2.Text = (myReader["Lastname"].ToString());
                label4.Text = (myReader["Gender"].ToString());
                label15.Text = (myReader["Department"].ToString());
                label16.Text = (myReader["Position"].ToString());
                //label20.Text = (myReader["IncomeType"].ToString());
                //label21.Text = (myReader["GrossIncome"].ToString());
                label24.Text = (myReader["HealthPlan"].ToString());
                label33.Text = (myReader["Status"].ToString());

            }
            
            OleDbCommand myCommand1 = new OleDbCommand("select * from Mastertable where ID =" + label31.Text, con1);

            myReader = myCommand1.ExecuteReader();

            //read data from database into gui form 5:
            while (myReader.Read())
            {

                label20.Text = (myReader["Paytime"].ToString());
                label21.Text = (myReader["Weeklygrosspay"].ToString());
                label25.Text = (myReader["DentalCoverage"].ToString());
                label26.Text = (myReader["VisionCoverage"].ToString());
                label3.Text = (myReader["DateofBirth"].ToString());
                label10.Text = (Convert.ToDouble(label21.Text) - ( Benefits.soc_sec_adm(Convert.ToDouble(label21.Text)) + Benefits.medicare(Convert.ToDouble(label21.Text)) + Benefits.healthCoverage(Convert.ToDouble(label21.Text), label24.Text) + Benefits.dentalCoverage(Convert.ToDouble(label21.Text), label25.Text) + Benefits.visionCoverage(Convert.ToDouble(label21.Text), label26.Text) + Benefits.retirement(Convert.ToDouble(label21.Text)))).ToString();
                label27.Text = ((FedTax.FedRate(Convert.ToDouble(label21.Text)).ToString()));
                label35.Text = (myReader["State"].ToString());
                label22.Text = (myReader["HourlyPay"].ToString());
                label39.Text = (Benefits.soc_sec_adm(Convert.ToDouble(label21.Text)).ToString());
                label42.Text = (Benefits.healthCoverage(Convert.ToDouble(label21.Text), label24.Text).ToString());
                label41.Text = (Benefits.dentalCoverage(Convert.ToDouble(label21.Text), label25.Text).ToString());
                label37.Text = (Benefits.visionCoverage(Convert.ToDouble(label21.Text), label26.Text).ToString());
                label45.Text = (Benefits.retirement(Convert.ToDouble(label21.Text)).ToString());

                if (label35.Text == "New York")
                {
                    label28.Text = ((NYstateTax.PayRateNY(Convert.ToDouble(label21.Text)).ToString()));
                    OleDbCommand addCommand5 = new OleDbCommand("UPDATE Mastertable SET [NYstateTax] = @NYstateTax where ID = " + int.Parse(label31.Text), con1);
                    addCommand5.Parameters.AddWithValue("@NYstateTax", label28.Text);
                    addCommand5.ExecuteNonQuery();
                }
                else if (label35.Text == "New Jersey")
                {   
                    label28.Text = ((NJstateTax.PayRateNJ(Convert.ToDouble(label21.Text)).ToString()));
                    OleDbCommand addCommand6 = new OleDbCommand("UPDATE Mastertable SET [NJstateTax] = @NJstateTax where ID = " + int.Parse(label31.Text), con1);
                    addCommand6.Parameters.AddWithValue("@NJstateTax", label28.Text);
                    addCommand6.ExecuteNonQuery();
                }
                else if (label35.Text == "Connecticut")
                {
                    label28.Text = ((CTstateTax.PayRateCT(Convert.ToDouble(label21.Text)).ToString()));
                    OleDbCommand addCommand7 = new OleDbCommand("UPDATE Mastertable SET [CTstateTax] = @CTstateTax where ID = " + int.Parse(label31.Text), con1);
                    addCommand7.Parameters.AddWithValue("@CTstateTax", label28.Text);
                    addCommand7.ExecuteNonQuery();
                }

            }

            OleDbCommand addCommand8 = new OleDbCommand("UPDATE Mastertable SET [Netpay] = @Netpay , [FedTax] = @FedTax, [SSAWithholdings] = @SSAWithholdings, [HealthCost]=@HealthCost, [DentalCost] = @Dentalcost, [Visioncost] = @Visioncost, [RetirementCost] = @RetirementCost where ID = " + int.Parse(label31.Text), con1);
            addCommand8.Parameters.AddWithValue("@Netpay", label10.Text);
            addCommand8.Parameters.AddWithValue("@FedTax", label27.Text);
            addCommand8.Parameters.AddWithValue("@SSAWithholdings", label39.Text);
            addCommand8.Parameters.AddWithValue("@HealthCost", label42.Text);
            addCommand8.Parameters.AddWithValue("@Dentalcost", label41.Text);
            addCommand8.Parameters.AddWithValue("@Visioncost", label37.Text);
            addCommand8.Parameters.AddWithValue("@RetirementCost", label45.Text);
            addCommand8.ExecuteNonQuery();
        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (label15.Text == "Hr" || label15.Text == "HR" || label15.Text == "hr" || label15.Text == "Human Resource" || label15.Text == "human resource" || label15.Text == "Human resource")
            {
                this.Close();
                Form2 hrview = new Form2();
                hrview.Show();
            }
            else {
                this.Close();
                Form6 myview = new Form6();
                myview.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Form6 coworker = new Form6();
            coworker.Show();
        }
    }
}
