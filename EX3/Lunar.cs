using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EX3
{
    public partial class Lunar : Form
    {
        public Lunar()
        {
            InitializeComponent();
            Text = "Calendar -> Lunar";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Do you want exit ?", "Alert", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
        }

        private void txtDuong_MouseHover(object sender, EventArgs e)
        {
            txtDuong.BackColor = Color.Pink;
        }

        private void txtDuong_MouseLeave(object sender, EventArgs e)
        {
            txtDuong.BackColor = Color.White;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            string[] chi = new string[13];
            string[] can = new string[11];
            chi[1] = "Thân";
            chi[2] = "Dậu";
            chi[3] = "Tuất";
            chi[4] = "Hợi";
            chi[5] = "Tý";
            chi[6] = "Sửu";
            chi[7] = "Dần";
            chi[8] = "Mão";
            chi[9] = "Thìn";
            chi[10] = "Tỵ";
            chi[11] = "Ngọ";
            chi[12] = "Mùi";
            can[1] = "Canh";
            can[2] = "Tân";
            can[3] = "Nhâm";
            can[4] = "Quý";
            can[5] = "Giáp";
            can[6] = "Ất";
            can[7] = "Bính";
            can[8] = "Đinh";
            can[9] = "Mậu";
            can[10] = "Kỷ";

            Regex year = new Regex("^[0-9]+$");
            if (txtDuong.Text == "")
            {
                MessageBox.Show("Not Empty!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (year.IsMatch(txtDuong.Text) == false)
            {
                if (txtDuong.Text != "")
                {
                    MessageBox.Show("The Year is number type!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDuong.Clear();
                }

            }
            else
            {
                int v_chi, v_can;
                string v_result;
                v_chi = Convert.ToInt32(txtDuong.Text) % 12;
                v_can = Convert.ToInt32(txtDuong.Text) % 10;
                v_result = can[v_can + 1] + " " + chi[v_chi + 1];
                txtAm.Text = v_result;
                txtDuong.Focus();
            }
        }
    }
}
