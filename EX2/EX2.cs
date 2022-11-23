using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex2_Assigment2_PRN211
{
    public partial class EX2 : Form
    {
        public EX2()
        {
            InitializeComponent();
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            txtSecurityCode.Text = "";
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            string txt = txtSecurityCode.Text;
            string option = "0";
            if (txt.Equals("1645") || txt.Equals("1689")) option = "1";
            else if (txt.Equals("8345")) option = "2";
            else if (txt.Equals("9998") || txt.Equals("1006")
                 || txt.Equals("1007") || txt.Equals("1008")) option = "3";
            string datetime = "";
            string log = "";
            switch (option)
            {
                case "0":
                    {
                        datetime = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
                        log = datetime + "\tRestricted Access!";
                        break;
                    }
                case "1":
                    {
                        datetime = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
                        log = datetime + "\tTechnicians";
                        break;
                    }
                case "2":
                    {
                        datetime = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
                        log = datetime + "\tCustodians";
                        break;
                    }
                case "3":
                    {
                        datetime = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
                        log = datetime + "\tScientist";
                        break;
                    }
            }
            lbxAccessLog.Items.Add(log);
           

        }


        private void btn0_Click_1(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            txtSecurityCode.Text += btn.Text;
        }
    }
}
