namespace GUI_Sum
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var num1 = decimal.Parse(textBoxNumber1.Text);
            var num2 = decimal.Parse(textBoxNumber2.Text);
            var result = num1 + num2;
            textBoxSum.Text = result.ToString();
        }
    }
}