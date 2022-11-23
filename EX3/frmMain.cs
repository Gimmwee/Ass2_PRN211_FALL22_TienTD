using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EX3
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            Text = "frmMain";
        }


        private void rdAlenticoMadrid_Click(object sender, EventArgs e)
        {
            RadioButton rd = (RadioButton)sender;
            string imgName = rd.Text.Replace(" ", "").Trim()+".png";
            image.Image = Image.FromFile("..\\..\\..\\..\\Image/"+imgName);

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show(this, "Bạn muốn đóng cửa sổ này ?", "Alert", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
        }

        private void btnLunar_Click(object sender, EventArgs e)
        {
            Lunar l = new Lunar();
            this.Hide();
            l.Show();
        }
    }
}
