using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using NLog;

namespace NewFamilyMoney
{
    public partial class Form1 : Form
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public TreeNode CheckedNode { get; private set; }
        public DateTime newDateTime { get; private set; }
        public string spend { get; private set; }
        public Form1()
        {
            InitializeComponent();
            
            LoadTree();
            
            newDateTime = DateTime.Today;
            Program.LoadTable(newDateTime, MainTable);

            ChangeDateTime.Value = newDateTime;
            UpdateLabel();
        }

        private string getName()
        {
            logger.Info("вызов getName");

            var NameEdit = new NameEdit();
            NameEdit.ShowDialog();
            return NameEdit.name;
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode ClickedNode = treeView1.GetNodeAt(e.Location);

            if (ClickedNode.Name == "ItemSpend")
            {
                CreateItem(Color.Red, ClickedNode);
            } 
            
            else if (ClickedNode.Name == "ItemProfit")
            {
                CreateItem(Color.Green, ClickedNode);
            }
        }

        private void CreateItem(Color color, TreeNode ClickedNode)
        {
            var ItemSetting = new ItemSetting(ClickedNode.Text);
            ItemSetting.ShowDialog();
            if (ItemSetting.endEnter)
            {
                int rowNumber = MainTable.Rows.Add();
                MainTable.Rows[rowNumber].Cells["Names"].Value = ItemSetting.name;
                MainTable.Rows[rowNumber].Cells["Prices"].Value = ItemSetting.price;
                MainTable.Rows[rowNumber].Cells["Numbers"].Value = ItemSetting.total;
                MainTable.Rows[rowNumber].Cells["Comments"].Value = ItemSetting.comment;
                MainTable.Rows[rowNumber].DefaultCellStyle.BackColor = color; 
                MainTable.CurrentCell = null;
                UpdateLabel();
            } 
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveTree();
            SaveTable();

            logger.Info("закрытие Form1");
        }

        private void SaveTree()
        {
            string filename = "save//treeview.txt";
            using (Stream file = File.Open(filename, FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(file, treeView1.Nodes.Cast<TreeNode>().ToList());

                logger.Info("сохранение древа");
            }
        }

        private void LoadTree()
        {
            string filename = "save//treeview.txt";
            
            try
            {
                using (Stream file = File.Open(filename, FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    object obj = bf.Deserialize(file);
                    TreeNode[] nodes = (obj as IEnumerable<TreeNode>).ToArray();
                    
                    treeView1.Nodes.Clear();
                    treeView1.Nodes.AddRange(nodes);

                    logger.Info("загрузка древа");
                }
            }
            catch (Exception e)
            {
                logger.Error(e.ToString());
            }
        }

        private void SaveTable()
        {
            string filename = "save//MainTable" + newDateTime.Year + "_" + newDateTime.Month + "_" + newDateTime.Day + ".txt";
            using (BinaryWriter bw = new BinaryWriter(File.Open(filename, FileMode.Create)))
            {
                bw.Write(MainTable.Columns.Count);  
                bw.Write(MainTable.Rows.Count);
                foreach (DataGridViewRow row in MainTable.Rows)
                {
                    for (int i = 0; i < MainTable.Columns.Count; i++)
                    {
                        object value = row.Cells[i].Value;
                        bw.Write(value.ToString());
                    } 
                    bw.Write(row.DefaultCellStyle.BackColor.R);
                    bw.Write(row.DefaultCellStyle.BackColor.G);
                    bw.Write(row.DefaultCellStyle.BackColor.B);
                    bw.Write(row.DefaultCellStyle.BackColor.A);
                }
            }

            logger.Info("таблица сохранена");
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                CheckedNode = treeView1.GetNodeAt(e.Location);
                settingContextMenu();
                switch (CheckedNode.Name)
                {
                    case "CategorySpend":
                        spend = "Spend";
                        contextMenuStrip1.Items[3].Text = "Добавить статью расходов";
                        contextMenuStrip1.Show(MousePosition, ToolStripDropDownDirection.Right);
                        break;
                    case "CategoryProfit":
                        spend = "Profit";
                        contextMenuStrip1.Items[3].Text = "Добавить статью доходов";
                        contextMenuStrip1.Show(MousePosition, ToolStripDropDownDirection.Right);
                        break;
                    case "ItemSpend":
                        spend = "Spend";
                        contextMenuStrip1.Items[2].Visible = false;
                        contextMenuStrip1.Items[3].Visible = false;
                        contextMenuStrip1.Show(MousePosition, ToolStripDropDownDirection.Right);
                        break;
                    case "ItemProfit":
                        spend = "Profit";
                        contextMenuStrip1.Items[2].Visible = false;
                        contextMenuStrip1.Items[3].Visible = false;
                        contextMenuStrip1.Show(MousePosition, ToolStripDropDownDirection.Right);
                        break;
                    case "spend":
                        spend = "Spend";
                        contextMenuStrip1.Items[0].Visible = false;
                        contextMenuStrip1.Items[1].Visible = false;
                        contextMenuStrip1.Items[3].Text = "Добавить статью расходов";
                        contextMenuStrip1.Show(MousePosition, ToolStripDropDownDirection.Right);
                        break;
                    case "profit":
                        spend = "Profit";
                        contextMenuStrip1.Items[0].Visible = false;
                        contextMenuStrip1.Items[1].Visible = false;
                        contextMenuStrip1.Items[3].Text = "Добавить статью доходов";
                        contextMenuStrip1.Show(MousePosition, ToolStripDropDownDirection.Right);
                        break;
                }
            }
        }
        
        private void settingContextMenu()
        {
            contextMenuStrip1.Items[0].Visible = true;
            contextMenuStrip1.Items[1].Visible = true;
            contextMenuStrip1.Items[2].Visible = true;
            contextMenuStrip1.Items[3].Visible = true;
        }

        private void rename_Click(object sender, EventArgs e)
        {
            string name = getName();
            if (name != null)
            {
                CheckedNode.Text = name;
            }
            contextMenuStrip1.Close();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            CheckedNode.Remove();  
            contextMenuStrip1.Close();
        }
        
        private void AddCategory_Click(object sender, EventArgs e)
        {
            string name = getName();
            if (name != null)
            {
                TreeNode ItemNode = new TreeNode(name);
                ItemNode.Name = "Category" + spend;
                CheckedNode.Nodes.Add(ItemNode);
                CheckedNode.Expand();
            }
        }

        private void Item_Click(object sender, EventArgs e)
        {
            string name = getName();
            if (name != null)
            {
                TreeNode ItemNode = new TreeNode(name);
                ItemNode.Name = "Item" + spend;
                CheckedNode.Nodes.Add(ItemNode); 
                CheckedNode.Expand();
            }
        }

        private void UpdateLabel()
        {
            double totalSpend = 0;
            double totalProfit = 0;
            foreach (DataGridViewRow row in MainTable.Rows)
            {
                if (row.Cells["Sum"].Value != null && row.DefaultCellStyle.BackColor.R == 255)
                {
                    double value;
                    double.TryParse((row.Cells["Sum"].Value ?? "0").ToString(), out value);
                    totalSpend += value;
                }
                
                else if (row.Cells["Sum"].Value != null && row.DefaultCellStyle.BackColor.G == 128)
                {
                    double value;
                    double.TryParse((row.Cells["Sum"].Value ?? "0").ToString(), out value);
                    totalProfit += value;
                }
            }

            LabelSum.Text = totalSpend + " р";
            LabelProfit.Text = totalProfit + " р";
            BalanceLabel.Text = (totalProfit - totalSpend) + " р";
        }

        private void UpdateValues()
        {
            foreach (DataGridViewRow row in MainTable.Rows)
            {
                double prices;
                double numbers;
                double.TryParse((row.Cells["Prices"].Value ?? "0").ToString(), out prices);
                double.TryParse((row.Cells["Numbers"].Value ?? "0").ToString(), out numbers);
                row.Cells["Sum"].Value = prices * numbers;
            }
        }

        private void MainTable_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            UpdateValues();
            UpdateLabel();
        }

        private void MainTable_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            UpdateLabel();   
            SaveTable();

            logger.Info("удаление строки пользователем");
        }

        private void ChangeDateTime_CloseUp(object sender, EventArgs e)
        {
            newDateTime = ChangeDateTime.Value;
            MainTable.Rows.Clear();
            Program.LoadTable(newDateTime, MainTable);
            MainTable.CurrentCell = null;
            UpdateLabel();

            logger.Info("смена даты в Form1");
        }

        private void ChangeDateTime_DropDown(object sender, EventArgs e)
        {
            newDateTime = ChangeDateTime.Value;
            SaveTable();
        }
        
        private void MainTable_Leave(object sender, EventArgs e)
        {
            MainTable.CurrentCell = null;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MainTable.CurrentCell = null;
        }

        private void LabelSum_Click(object sender, EventArgs e)
        {
            MainTable.CurrentCell = null;
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            MainTable.CurrentCell = null;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            MainTable.CurrentCell = null;
        }

        private void LabelProfit_Click(object sender, EventArgs e)
        {
            MainTable.CurrentCell = null;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            MainTable.CurrentCell = null;
        }

        private void Statistic_Click(object sender, EventArgs e)
        {
            logger.Info("открытие формы диаграмм");

            SaveTable();
            var Form2 = new Form2(newDateTime);
            Form2.ShowDialog();

            logger.Info("закрытие формы диаграмм");
        }
    }
}