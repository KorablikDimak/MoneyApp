using System;
using System.Windows.Forms;
using NLog;

namespace NewFamilyMoney
{
    public partial class NameEdit : Form
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public string name { get; private set; }
        public NameEdit()
        {
            InitializeComponent();
            textBox1.Text = "";
            textBox1.Select();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Поле ввода не может быть пустым", "Введите название");
            }
            else
            {
                name = textBox1.Text;
                Close();
            }
        }
    }
}