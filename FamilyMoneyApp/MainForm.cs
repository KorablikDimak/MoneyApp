using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace FamilyMoneyApp
{
    public partial class MainForm : Form
    {
        private TreeNode _checkedNode;
        private DateTime _newDateTime;
        private string _spend;
        public MainForm()
        {
            InitializeComponent();
            
            LoadTree();
            
            _newDateTime = DateTime.Today;
            LoadFromFiles.LoadTable(_newDateTime, MainTable);

            ChangeDateTime.Value = _newDateTime;
            UpdateLabel();
        }

        private static string GetName()
        {
            var nameEdit = new NameEdit();
            nameEdit.ShowDialog();
            return nameEdit.Name;
        }

        private void TreeViewNodeMouseDoubleClicked(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode clickedNode = treeView1.GetNodeAt(e.Location);

            switch (clickedNode.Name)
            {
                case "ItemSpend":
                    CreateItem(Color.Red, clickedNode);
                    break;
                case "ItemProfit":
                    CreateItem(Color.Green, clickedNode);
                    break;
            }
        }

        private void CreateItem(Color color, TreeNode clickedNode)
        {
            var itemSetting = new ItemSetting(clickedNode.Text);
            itemSetting.ShowDialog();
            if (!itemSetting.EndEnter) return;
            int rowNumber = MainTable.Rows.Add();
            MainTable.Rows[rowNumber].Cells["Names"].Value = itemSetting.Name;
            MainTable.Rows[rowNumber].Cells["Prices"].Value = itemSetting.Price;
            MainTable.Rows[rowNumber].Cells["Numbers"].Value = itemSetting.Total;
            MainTable.Rows[rowNumber].Cells["Comments"].Value = itemSetting.Comment;
            MainTable.Rows[rowNumber].DefaultCellStyle.BackColor = color; 
            MainTable.CurrentCell = null;
            UpdateLabel();
        }

        private void MainFormFormClosing(object sender, FormClosingEventArgs e)
        {
            SaveTree();
            SaveTable();
        }

        private void SaveTree()
        {
            const string filename = "save//treeview.txt";
            using (Stream file = File.Open(filename, FileMode.Create))
            {
                var bf = new BinaryFormatter();
                bf.Serialize(file, treeView1.Nodes.Cast<TreeNode>().ToList());

                MyLogger.Logger.Info("save tree");
            }
        }

        private void LoadTree()
        {
            const string filename = "save//treeview.txt";

            try
            {
                using (Stream file = File.Open(filename, FileMode.Open))
                {
                    var bf = new BinaryFormatter();
                    object obj = bf.Deserialize(file);
                    TreeNode[] nodes = (obj as IEnumerable<TreeNode> ?? throw new InvalidOperationException()).ToArray();
                    
                    treeView1.Nodes.Clear();
                    treeView1.Nodes.AddRange(nodes);

                    MyLogger.Logger.Info("load tree");
                }
            }
            catch (Exception e)
            {
                MyLogger.Logger.Error(e.ToString());
            }
        }

        private void SaveTable()
        {
            string filename = "save//MainTable" + _newDateTime.Year + "_" + _newDateTime.Month + "_" + _newDateTime.Day + ".txt";
            using (var bw = new BinaryWriter(File.Open(filename, FileMode.Create)))
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

            MyLogger.Logger.Info("table saved");
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            _checkedNode = treeView1.GetNodeAt(e.Location);
            OpenSettingContextMenu();
            switch (_checkedNode.Name)
            {
                case "CategorySpend":
                    _spend = "Spend";
                    contextMenuStrip1.Items[3].Text = "Добавить статью расходов";
                    contextMenuStrip1.Show(MousePosition, ToolStripDropDownDirection.Right);
                    break;
                case "CategoryProfit":
                    _spend = "Profit";
                    contextMenuStrip1.Items[3].Text = "Добавить статью доходов";
                    contextMenuStrip1.Show(MousePosition, ToolStripDropDownDirection.Right);
                    break;
                case "ItemSpend":
                    _spend = "Spend";
                    contextMenuStrip1.Items[2].Visible = false;
                    contextMenuStrip1.Items[3].Visible = false;
                    contextMenuStrip1.Show(MousePosition, ToolStripDropDownDirection.Right);
                    break;
                case "ItemProfit":
                    _spend = "Profit";
                    contextMenuStrip1.Items[2].Visible = false;
                    contextMenuStrip1.Items[3].Visible = false;
                    contextMenuStrip1.Show(MousePosition, ToolStripDropDownDirection.Right);
                    break;
                case "spend":
                    _spend = "Spend";
                    contextMenuStrip1.Items[0].Visible = false;
                    contextMenuStrip1.Items[1].Visible = false;
                    contextMenuStrip1.Items[3].Text = "Добавить статью расходов";
                    contextMenuStrip1.Show(MousePosition, ToolStripDropDownDirection.Right);
                    break;
                case "profit":
                    _spend = "Profit";
                    contextMenuStrip1.Items[0].Visible = false;
                    contextMenuStrip1.Items[1].Visible = false;
                    contextMenuStrip1.Items[3].Text = "Добавить статью доходов";
                    contextMenuStrip1.Show(MousePosition, ToolStripDropDownDirection.Right);
                    break;
            }
        }
        
        private void OpenSettingContextMenu()
        {
            contextMenuStrip1.Items[0].Visible = true;
            contextMenuStrip1.Items[1].Visible = true;
            contextMenuStrip1.Items[2].Visible = true;
            contextMenuStrip1.Items[3].Visible = true;
        }

        private void RenameClicked(object sender, EventArgs e)
        {
            string name = GetName();
            if (name != null)
            {
                _checkedNode.Text = name;
            }
            contextMenuStrip1.Close();
        }

        private void DeleteClicked(object sender, EventArgs e)
        {
            _checkedNode.Remove();  
            contextMenuStrip1.Close();
        }
        
        private void AddCategoryClicked(object sender, EventArgs e)
        {
            string name = GetName();
            if (name == null) return;
            var itemNode = new TreeNode(name) {Name = "Category" + _spend};
            _checkedNode.Nodes.Add(itemNode);
            _checkedNode.Expand();
        }

        private void ItemClicked(object sender, EventArgs e)
        {
            string name = GetName();
            if (name == null) return;
            var itemNode = new TreeNode(name) {Name = "Item" + _spend};
            _checkedNode.Nodes.Add(itemNode); 
            _checkedNode.Expand();
        }

        private void UpdateLabel()
        {
            double totalSpend = 0;
            double totalProfit = 0;
            foreach (DataGridViewRow row in MainTable.Rows)
            {
                if (row.Cells["Sum"].Value != null && row.DefaultCellStyle.BackColor.R == 255)
                {
                    double.TryParse((row.Cells["Sum"].Value ?? "0").ToString(), out var value);
                    totalSpend += value;
                }
                
                else if (row.Cells["Sum"].Value != null && row.DefaultCellStyle.BackColor.G == 128)
                {
                    double.TryParse((row.Cells["Sum"].Value ?? "0").ToString(), out var value);
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
                double.TryParse((row.Cells["Prices"].Value ?? "0").ToString(), out var prices);
                double.TryParse((row.Cells["Numbers"].Value ?? "0").ToString(), out var numbers);
                row.Cells["Sum"].Value = prices * numbers;
            }
        }

        private void MainTableCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            UpdateValues();
            UpdateLabel();
        }

        private void MainTableUserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            UpdateLabel();   
            SaveTable();
        }

        private void CloseUpChangeDateTime(object sender, EventArgs e)
        {
            _newDateTime = ChangeDateTime.Value;
            MainTable.Rows.Clear();
            LoadFromFiles.LoadTable(_newDateTime, MainTable);
            MainTable.CurrentCell = null;
            UpdateLabel();
        }

        private void DropDownChangeDateTime(object sender, EventArgs e)
        {
            _newDateTime = ChangeDateTime.Value;
            SaveTable();
        }
        
        private void LeaveMainTable(object sender, EventArgs e)
        {
            MainTable.CurrentCell = null;
        }

        private void Label1Clicked(object sender, EventArgs e)
        {
            MainTable.CurrentCell = null;
        }

        private void LabelSumClicked(object sender, EventArgs e)
        {
            MainTable.CurrentCell = null;
        }

        private void MainFormClicked(object sender, EventArgs e)
        {
            MainTable.CurrentCell = null;
        }

        private void ShowMainForm(object sender, EventArgs e)
        {
            MainTable.CurrentCell = null;
        }

        private void LabelProfitClicked(object sender, EventArgs e)
        {
            MainTable.CurrentCell = null;
        }

        private void Label2Clicked(object sender, EventArgs e)
        {
            MainTable.CurrentCell = null;
        }

        private void StatisticClicked(object sender, EventArgs e)
        {
            SaveTable();
            var diagramForm = new DiagramForm(_newDateTime);
            diagramForm.ShowDialog();
        }

        private void Label3Clicked(object sender, EventArgs e)
        {
            MainTable.CurrentCell = null;
        }

        private void BalanceLabelClicked(object sender, EventArgs e)
        {
            MainTable.CurrentCell = null;
        }
    }
}