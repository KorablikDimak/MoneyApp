namespace FamilyMoneyApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Траты");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Доходы");
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.MainTable = new System.Windows.Forms.DataGridView();
            this.Names = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prices = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numbers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.rename = new System.Windows.Forms.ToolStripMenuItem();
            this.delete = new System.Windows.Forms.ToolStripMenuItem();
            this.AddCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.Item = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.LabelSum = new System.Windows.Forms.Label();
            this.ChangeDateTime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.LabelProfit = new System.Windows.Forms.Label();
            this.Statistic = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.BalanceLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize) (this.MainTable)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 26);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "spend";
            treeNode1.Text = "Траты";
            treeNode2.Name = "profit";
            treeNode2.Text = "Доходы";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {treeNode1, treeNode2});
            this.treeView1.Size = new System.Drawing.Size(182, 469);
            this.treeView1.TabIndex = 0;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeViewNodeMouseDoubleClicked);
            // 
            // MainTable
            // 
            this.MainTable.AllowUserToAddRows = false;
            this.MainTable.AllowUserToResizeColumns = false;
            this.MainTable.AllowUserToResizeRows = false;
            this.MainTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.MainTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.MainTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {this.Names, this.Prices, this.Numbers, this.Sum, this.Comments});
            this.MainTable.Location = new System.Drawing.Point(209, 0);
            this.MainTable.Name = "MainTable";
            this.MainTable.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.MainTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.MainTable.Size = new System.Drawing.Size(465, 435);
            this.MainTable.TabIndex = 0;
            this.MainTable.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.MainTableCellValueChanged);
            this.MainTable.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.MainTableUserDeletedRow);
            this.MainTable.Leave += new System.EventHandler(this.LeaveMainTable);
            // 
            // Names
            // 
            this.Names.HeaderText = "Наименование";
            this.Names.Name = "Names";
            this.Names.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Names.Width = 108;
            // 
            // Prices
            // 
            this.Prices.HeaderText = "Цена";
            this.Prices.Name = "Prices";
            this.Prices.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Prices.Width = 58;
            // 
            // Numbers
            // 
            this.Numbers.HeaderText = "Количество";
            this.Numbers.Name = "Numbers";
            this.Numbers.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Numbers.Width = 91;
            // 
            // Sum
            // 
            this.Sum.HeaderText = "Итого";
            this.Sum.Name = "Sum";
            this.Sum.ReadOnly = true;
            this.Sum.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Sum.Width = 62;
            // 
            // Comments
            // 
            this.Comments.HeaderText = "Комментарий";
            this.Comments.Name = "Comments";
            this.Comments.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Comments.Width = 102;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.rename, this.delete, this.AddCategory, this.Item});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(189, 92);
            // 
            // rename
            // 
            this.rename.Name = "rename";
            this.rename.Size = new System.Drawing.Size(188, 22);
            this.rename.Text = "Переименовать";
            this.rename.Click += new System.EventHandler(this.RenameClicked);
            // 
            // delete
            // 
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(188, 22);
            this.delete.Text = "Удалить";
            this.delete.Click += new System.EventHandler(this.DeleteClicked);
            // 
            // AddCategory
            // 
            this.AddCategory.Name = "AddCategory";
            this.AddCategory.Size = new System.Drawing.Size(188, 22);
            this.AddCategory.Text = "Добавить категорию";
            this.AddCategory.Click += new System.EventHandler(this.AddCategoryClicked);
            // 
            // Item
            // 
            this.Item.Name = "Item";
            this.Item.Size = new System.Drawing.Size(188, 22);
            this.Item.Text = "Добавить статью";
            this.Item.Click += new System.EventHandler(this.ItemClicked);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(209, 438);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Итого расходов за день:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Click += new System.EventHandler(this.Label1Clicked);
            // 
            // LabelSum
            // 
            this.LabelSum.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.LabelSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.LabelSum.Location = new System.Drawing.Point(375, 438);
            this.LabelSum.Name = "LabelSum";
            this.LabelSum.Size = new System.Drawing.Size(109, 25);
            this.LabelSum.TabIndex = 2;
            this.LabelSum.Text = "0 р";
            this.LabelSum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LabelSum.Click += new System.EventHandler(this.LabelSumClicked);
            // 
            // ChangeDateTime
            // 
            this.ChangeDateTime.Location = new System.Drawing.Point(12, 0);
            this.ChangeDateTime.Name = "ChangeDateTime";
            this.ChangeDateTime.Size = new System.Drawing.Size(182, 20);
            this.ChangeDateTime.TabIndex = 6;
            this.ChangeDateTime.Value = new System.DateTime(2021, 4, 9, 0, 0, 0, 0);
            this.ChangeDateTime.CloseUp += new System.EventHandler(this.CloseUpChangeDateTime);
            this.ChangeDateTime.DropDown += new System.EventHandler(this.DropDownChangeDateTime);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(209, 471);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 24);
            this.label2.TabIndex = 7;
            this.label2.Text = "Итого доходов за день:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Click += new System.EventHandler(this.Label2Clicked);
            // 
            // LabelProfit
            // 
            this.LabelProfit.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.LabelProfit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.LabelProfit.Location = new System.Drawing.Point(375, 471);
            this.LabelProfit.Name = "LabelProfit";
            this.LabelProfit.Size = new System.Drawing.Size(109, 24);
            this.LabelProfit.TabIndex = 8;
            this.LabelProfit.Text = "0 р";
            this.LabelProfit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LabelProfit.Click += new System.EventHandler(this.LabelProfitClicked);
            // 
            // Statistic
            // 
            this.Statistic.Location = new System.Drawing.Point(490, 438);
            this.Statistic.Name = "Statistic";
            this.Statistic.Size = new System.Drawing.Size(184, 25);
            this.Statistic.TabIndex = 9;
            this.Statistic.Text = "Показать статистику";
            this.Statistic.UseVisualStyleBackColor = true;
            this.Statistic.Click += new System.EventHandler(this.StatisticClicked);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(490, 470);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 25);
            this.label3.TabIndex = 10;
            this.label3.Text = "Баланс:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Click += new System.EventHandler(this.Label3Clicked);
            // 
            // BalanceLabel
            // 
            this.BalanceLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BalanceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.BalanceLabel.Location = new System.Drawing.Point(564, 470);
            this.BalanceLabel.Name = "BalanceLabel";
            this.BalanceLabel.Size = new System.Drawing.Size(111, 25);
            this.BalanceLabel.TabIndex = 11;
            this.BalanceLabel.Text = "0 р";
            this.BalanceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BalanceLabel.Click += new System.EventHandler(this.BalanceLabelClicked);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(687, 504);
            this.Controls.Add(this.BalanceLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Statistic);
            this.Controls.Add(this.LabelProfit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ChangeDateTime);
            this.Controls.Add(this.LabelSum);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MainTable);
            this.Controls.Add(this.treeView1);
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
            this.Shown += new System.EventHandler(this.ShowMainForm);
            this.Click += new System.EventHandler(this.MainFormClicked);
            ((System.ComponentModel.ISupportInitialize) (this.MainTable)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label LabelProfit;

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.ToolStripMenuItem AddCategory;
        private System.Windows.Forms.ToolStripMenuItem Item;

        private System.Windows.Forms.DataGridViewTextBoxColumn Comments;
        private System.Windows.Forms.DataGridViewTextBoxColumn Names;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numbers;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prices;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sum;

        private System.Windows.Forms.DateTimePicker ChangeDateTime;

        private System.Windows.Forms.Label LabelSum;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.ToolStripMenuItem delete;

        private System.Windows.Forms.ToolStripMenuItem rename;

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;

        private System.Windows.Forms.DataGridView MainTable;

        private System.Windows.Forms.TreeView treeView1;

        #endregion

        private System.Windows.Forms.Button Statistic;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label BalanceLabel;
    }
}