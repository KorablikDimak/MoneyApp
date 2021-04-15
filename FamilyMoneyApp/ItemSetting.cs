using System;
using System.Windows.Forms;

namespace NewFamilyMoney
{
    public partial class ItemSetting : Form
    {
        public string name { get; private set; }
        public int total { get; private set; }
        public double price { get; private set; }
        public string comment { get; private set; }
        public bool endEnter { get; private set; }
        public ItemSetting(string name)
        {
            InitializeComponent();
            Name_e.Text = name;
            endEnter = false;
            price_e.Select();
        }

        private void Attemt_Click(object sender, EventArgs e)
        {
            if (CheckEnter())
            {
                name = Name_e.Text;
                total = int.Parse(total_e.Text);
                price = double.Parse(price_e.Text);
                comment = Comment_e.Text;
                endEnter = true;
                Close();
            }
        }

        private bool CheckEnter()
        {
            if (Name_e.Text == "" || total_e.Text == "" || price_e.Text == "")
            {
                MessageBox.Show("Все поля кроме 'Комменарий' должны быть заполнены", "Ошибка ввода");
                return false;
            }

            return true;
        }

        private void price_e_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            CheckChar(e, price_e.Text);
        }

        private void total_e_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckChar(e, total_e.Text);
        }

        private void CheckChar(KeyPressEventArgs e, string text)
        {
            char key = e.KeyChar;
            if (key >= 47 && key <= 58 || key == ',' && !text.Contains(",") || key == 8) {}
            else
            {
                e.Handled = true;
            }
        }
    }
}