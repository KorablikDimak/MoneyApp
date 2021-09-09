using System;
using System.Windows.Forms;

namespace MoneyManager
{
    public partial class NameEdit : Form
    {
        public new string Name { get; private set; }
        public NameEdit()
        {
            InitializeComponent();
            textBox1.Text = "";
            textBox1.Select();
        }

        private void ButtonClicked(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Поле ввода не может быть пустым", "Введите название");
            }
            else
            {
                Name = textBox1.Text;
                Close();
            }
        }
    }
}