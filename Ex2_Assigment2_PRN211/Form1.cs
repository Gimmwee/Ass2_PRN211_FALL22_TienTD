namespace Ex2_Assigment2_PRN211
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Text = "Dental Payment Form";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show(this, "Do you want to exit?", "Alert", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Environment.Exit(0);

            }

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtTotal.Enabled = false;
            txtTotal.Text = "";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void GetPay()
        {
            if (txtName.Text.Trim().Equals(""))
            {
                MessageBox.Show("Enter Name!");
            }
            else
            {
                double total = 0;
                if (chkClean.Checked) total += 100000;
                if (chkWhitening.Checked) total += 1200000;
                if (chkXRay.Checked) total += 200000;
                double totalFilling = (double)(numFilling.Value * 80000);
                total += totalFilling;
                txtTotal.Text = total.ToString();
            }
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            GetPay();
        }
    }
}