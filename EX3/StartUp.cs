namespace EX3
{
    public partial class StartUp : Form
    {
        public StartUp()
        {
            InitializeComponent();
            Text = "Startup Form";
        }


        private void StartUp_Load(object sender, EventArgs e)
        {
            timer.Start();
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            frmMain frmMain = new frmMain();
            pgb.PerformStep();
            if(pgb.Value == pgb.Maximum)
            {
                this.Hide();
                frmMain.Show();
                timer.Stop();
            }
        }
    }
}