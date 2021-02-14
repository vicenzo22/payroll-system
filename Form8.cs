using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Data.OleDb;

namespace PayrollGoC
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Panel panel = new Panel();
            this.Controls.Add(panel);
            Graphics grp = panel.CreateGraphics();
            Size formSize = this.ClientSize;
            bitmap = new Bitmap(formSize.Width, formSize.Height, grp);
            grp = Graphics.FromImage(bitmap);
            Point panelLocation = PointToScreen(panel.Location);
            grp.CopyFromScreen(panelLocation.X, panelLocation.Y, 0, 0, formSize);
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();
        }
        Bitmap bitmap;
        private void CaptureScreen()
        {
            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            bitmap = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(bitmap);
            memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //sql connection
            OleDbConnection con1 = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\ieong\Source\Repos\PayrollMS1\payrollSystem.accdb");
            con1.Open();

            //1st reader
            OleDbDataReader myReader = null;
            OleDbCommand myCommand = new OleDbCommand("SELECT * FROM HRView WHERE ID =" + int.Parse(textBox1.Text), con1);
            myReader = myCommand.ExecuteReader();

            //2nd reader
            OleDbDataReader myReader2 = null;
            OleDbCommand myCommand2 = new OleDbCommand("SELECT * FROM Mastertable WHERE ID =" + int.Parse(textBox1.Text), con1);
            myReader2 = myCommand2.ExecuteReader();

            //  Chack Date
            DateTime today = DateTime.Today;
            var weekStart = today.AddDays(-(int)today.DayOfWeek);
            var weekEnd = weekStart.AddDays(7).AddSeconds(-1);
            label2.Text = DateTime.Now.ToString();
            label22.Text = weekStart.ToString();
            label67.Text = weekStart.ToString();
            label21.Text = weekEnd.ToString();
            label66.Text = weekEnd.ToString();

            //
            


            //

            while (myReader.Read() && myReader2.Read())
            {
                label1.Text = (myReader["Firstname"].ToString());
                label11.Text = (myReader["Firstname"].ToString());
                label43.Text = (myReader["Firstname"].ToString());
                label6.Text = (myReader["Lastname"].ToString());
                label10.Text = (myReader["Lastname"].ToString());
                label44.Text = (myReader["Lastname"].ToString());
                label12.Text = (myReader["Address"].ToString() + myReader["Address2"].ToString() + myReader["ZipCode"].ToString());
                label42.Text = (myReader["Address"].ToString() + myReader["Address2"].ToString() + myReader["ZipCode"].ToString());
                label19.Text = (myReader2["Weeklygrosspay"].ToString());
                label59.Text = (myReader2["Weeklygrosspay"].ToString());
                label17.Text = (myReader["Status"].ToString());
                label57.Text = (myReader["Status"].ToString());
                label52.Text = (myReader2["HourlyPay"].ToString());
                label56.Text = (myReader2["HourlyPay"].ToString());
                label51.Text = (myReader2["Overtimepay"].ToString());
                label55.Text = (myReader2["Overtimepay"].ToString());
                //label50.Text = (myReader2["Bonus"].ToString());
                //label54.Text = (myReader2["Bonus"].ToString());
                label29.Text = (myReader2["HealthCost"].ToString());
                label73.Text = (myReader2["HealthCost"].ToString());
                label37.Text = (myReader2["RetirementCost"].ToString());
                label71.Text = (myReader2["RetirementCost"].ToString());
                label40.Text = (myReader2["Netpay"].ToString());
                label69.Text = (myReader2["Netpay"].ToString());
                label18.Text = (myReader2["Netpay"].ToString());
                label58.Text = (myReader2["Netpay"].ToString());
                label20.Text = (myReader["SSN"].ToString());
                label60.Text = (myReader["SSN"].ToString());
                label3.Text = (myReader2["Netpay"].ToString());
                label32.Text = (myReader2["FedTax"].ToString());
                label76.Text = (myReader2["FedTax"].ToString());
                label31.Text = (myReader2["SSAWithholdings"].ToString());
                label75.Text = (myReader2["SSAWithholdings"].ToString());
                string state = (myReader2["State"].ToString());
                if (state == "New York")
                {
                    label30.Text = (myReader2["NYstateTax"].ToString());
                    label74.Text = (myReader2["NYstateTax"].ToString());
                }
                else if (state == "New Jersey")
                {
                    label30.Text = (myReader2["NJstateTax"].ToString());
                    label74.Text = (myReader2["NJstateTax"].ToString());
                }
                else if (state == "Connecticut")
                {
                    label30.Text = (myReader2["CTstateTax"].ToString());
                    label74.Text = (myReader2["CTstateTax"].ToString());
                }
                label49.Text = (myReader2["Weeklygrosspay"].ToString());
                label53.Text = (myReader2["Weeklygrosspay"].ToString());

            }
        }
    }
}