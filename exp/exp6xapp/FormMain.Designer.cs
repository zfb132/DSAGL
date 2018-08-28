namespace exp6xapp
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sortByToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortByNameDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortByIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortByIDDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortByIQToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortByIQDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveResultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sortByToolStripMenuItem,
            this.sortByNameDownToolStripMenuItem,
            this.sortByIDToolStripMenuItem,
            this.sortByIDDownToolStripMenuItem,
            this.sortByIQToolStripMenuItem,
            this.sortByIQDownToolStripMenuItem,
            this.saveResultToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(668, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sortByToolStripMenuItem
            // 
            this.sortByToolStripMenuItem.Name = "sortByToolStripMenuItem";
            this.sortByToolStripMenuItem.Size = new System.Drawing.Size(93, 21);
            this.sortByToolStripMenuItem.Text = "SortByName";
            this.sortByToolStripMenuItem.Click += new System.EventHandler(this.sortByNameToolStripMenuItem_Click);
            // 
            // sortByNameDownToolStripMenuItem
            // 
            this.sortByNameDownToolStripMenuItem.Name = "sortByNameDownToolStripMenuItem";
            this.sortByNameDownToolStripMenuItem.Size = new System.Drawing.Size(126, 21);
            this.sortByNameDownToolStripMenuItem.Text = "SortByNameDown";
            this.sortByNameDownToolStripMenuItem.Click += new System.EventHandler(this.sortByNameDownToolStripMenuItem_Click);
            // 
            // sortByIDToolStripMenuItem
            // 
            this.sortByIDToolStripMenuItem.Name = "sortByIDToolStripMenuItem";
            this.sortByIDToolStripMenuItem.Size = new System.Drawing.Size(71, 21);
            this.sortByIDToolStripMenuItem.Text = "SortByID";
            this.sortByIDToolStripMenuItem.Click += new System.EventHandler(this.sortByIDToolStripMenuItem_Click);
            // 
            // sortByIDDownToolStripMenuItem
            // 
            this.sortByIDDownToolStripMenuItem.Name = "sortByIDDownToolStripMenuItem";
            this.sortByIDDownToolStripMenuItem.Size = new System.Drawing.Size(104, 21);
            this.sortByIDDownToolStripMenuItem.Text = "SortByIDDown";
            this.sortByIDDownToolStripMenuItem.Click += new System.EventHandler(this.sortByIDDownToolStripMenuItem_Click);
            // 
            // sortByIQToolStripMenuItem
            // 
            this.sortByIQToolStripMenuItem.Name = "sortByIQToolStripMenuItem";
            this.sortByIQToolStripMenuItem.Size = new System.Drawing.Size(72, 21);
            this.sortByIQToolStripMenuItem.Text = "SortByIQ";
            this.sortByIQToolStripMenuItem.Click += new System.EventHandler(this.sortByIQToolStripMenuItem_Click);
            // 
            // sortByIQDownToolStripMenuItem
            // 
            this.sortByIQDownToolStripMenuItem.Name = "sortByIQDownToolStripMenuItem";
            this.sortByIQDownToolStripMenuItem.Size = new System.Drawing.Size(105, 21);
            this.sortByIQDownToolStripMenuItem.Text = "SortByIQDown";
            this.sortByIQDownToolStripMenuItem.Click += new System.EventHandler(this.sortByIQDownToolStripMenuItem_Click);
            // 
            // saveResultToolStripMenuItem
            // 
            this.saveResultToolStripMenuItem.Name = "saveResultToolStripMenuItem";
            this.saveResultToolStripMenuItem.Size = new System.Drawing.Size(82, 21);
            this.saveResultToolStripMenuItem.Text = "SaveResult";
            this.saveResultToolStripMenuItem.Click += new System.EventHandler(this.saveResultToolStripMenuItem_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(13, 38);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(643, 311);
            this.textBox1.TabIndex = 1;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 374);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sort by various keys";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sortByToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sortByNameDownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sortByIDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sortByIDDownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sortByIQToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sortByIQDownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveResultToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
    }
}

