namespace ManagementLibraryProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
        int startpoin = 0;
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            startpoin += 1;
            MyProcess.Value = startpoin;
            if (MyProcess.Value == 100)
            {
                MyProcess.Value = 0;
                timer1.Stop();
                LoginForm log = new LoginForm();
                log.Show();
                this.Hide();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}