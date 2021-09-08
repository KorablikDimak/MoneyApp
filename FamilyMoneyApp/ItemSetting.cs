using System;
using System.Windows.Forms;

namespace FamilyMoneyApp
{
    public partial class ItemSetting : Form
    {
        public new string Name { get; private set; }
        public int Total { get; private set; }
        public double Price { get; private set; }
        public string Comment { get; private set; }
        public bool EndEnter { get; private set; }
        public ItemSetting(string name)
        {
            InitializeComponent();
            nameTextBox.Text = name;
            EndEnter = false;
            price.Select();
        }

        private void AttemtClicked(object sender, EventArgs e)
        {
            if (!CheckEnter()) return;
            Name = nameTextBox.Text;
            Total = int.Parse(total.Text);
            Price = double.Parse(price.Text);
            Comment = comment.Text;
            EndEnter = true;
            Close();
        }

        private bool CheckEnter()
        {
            if (nameTextBox.Text != "" && total.Text != "" && price.Text != "") return true;
            MessageBox.Show("Все поля кроме 'Комменарий' должны быть заполнены", "Ошибка ввода");
            return false;
        }

        private void PriceKeyPress(object sender, KeyPressEventArgs e)
        {
            CheckChar(e, price.Text);
        }

        private void TotalKeyPress(object sender, KeyPressEventArgs e)
        {
            CheckChar(e, total.Text);
        }

        private static void CheckChar(KeyPressEventArgs e, string text)
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