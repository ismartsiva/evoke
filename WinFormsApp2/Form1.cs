namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            this.Click += Form1_Click;
        }



        private void Form1_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}