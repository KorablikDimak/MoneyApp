using System.ComponentModel;

namespace NewFamilyMoney
{
    partial class ItemSetting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
            this.label1 = new System.Windows.Forms.Label();
            this.Name_e = new System.Windows.Forms.TextBox();
            this.Attemt = new System.Windows.Forms.Button();
            this.price_e = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.total_e = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Comment_e = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // Name_e
            // 
            this.Name_e.Location = new System.Drawing.Point(12, 37);
            this.Name_e.Name = "Name_e";
            this.Name_e.Size = new System.Drawing.Size(100, 20);
            this.Name_e.TabIndex = 1;
            // 
            // Attemt
            // 
            this.Attemt.Location = new System.Drawing.Point(70, 139);
            this.Attemt.Name = "Attemt";
            this.Attemt.Size = new System.Drawing.Size(99, 22);
            this.Attemt.TabIndex = 2;
            this.Attemt.Text = "Принять";
            this.Attemt.UseVisualStyleBackColor = true;
            this.Attemt.Click += new System.EventHandler(this.Attemt_Click);
            // 
            // price_e
            // 
            this.price_e.Location = new System.Drawing.Point(124, 37);
            this.price_e.Name = "price_e";
            this.price_e.Size = new System.Drawing.Size(105, 20);
            this.price_e.TabIndex = 3;
            this.price_e.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.price_e_KeyPress_1);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(125, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 22);
            this.label2.TabIndex = 4;
            this.label2.Text = "Цена";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(14, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Количество";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // total_e
            // 
            this.total_e.Location = new System.Drawing.Point(12, 98);
            this.total_e.Name = "total_e";
            this.total_e.Size = new System.Drawing.Size(99, 20);
            this.total_e.TabIndex = 6;
            this.total_e.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.total_e_KeyPress);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(125, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 30);
            this.label4.TabIndex = 7;
            this.label4.Text = "Комментарий";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // Comment_e
            // 
            this.Comment_e.Location = new System.Drawing.Point(124, 98);
            this.Comment_e.Name = "Comment_e";
            this.Comment_e.Size = new System.Drawing.Size(105, 20);
            this.Comment_e.TabIndex = 8;
            // 
            // ItemSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 173);
            this.Controls.Add(this.Comment_e);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.total_e);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.price_e);
            this.Controls.Add(this.Attemt);
            this.Controls.Add(this.Name_e);
            this.Controls.Add(this.label1);
            this.Name = "ItemSetting";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox Comment_e;

        private System.Windows.Forms.Label label4;

        private System.Windows.Forms.TextBox total_e;

        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.Button Attemt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox price_e;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Name_e;

        #endregion
    }
}