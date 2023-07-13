
namespace WinFormsApp1

{

    public partial class Form1 : Form

    {

        public Form1()

        {

            InitializeComponent();

        }

        private int CountChar()

        {

            int count = 0;

            using (StreamReader reader = new StreamReader(@"C:\Users\spothala\Documents\pracfiles\a.txt"))

            {

                count = reader.ReadToEnd().Length;

                Thread.Sleep(5000);

            }

            return count;

        }



        private void Form1_Load(object sender, EventArgs e)

        {



        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Task<int> task = new Task<int>(CountChar);
            task.Start();
            label1.Text = "Started counting please wait.....";
            int c = await task;
            label1.Text = "Count " + c.ToString();
        }

        //private void button1_Click(object sender, EventArgs e)

        //{

        //    label1.Text = "Started counting character please wait.....";

        //    int c = CountChar();

        //    label1.Text = "Count" + c.ToString();

        //}



        private void label1_Click(object sender, EventArgs e)

        {


        }

    }

}