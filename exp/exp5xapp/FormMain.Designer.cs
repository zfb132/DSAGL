namespace exp5xapp
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
            this.linq2ObjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linq2XMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linq2DataSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.button_search = new System.Windows.Forms.Button();
            this.textBox_display = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_tip = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.linq2ObjectToolStripMenuItem,
            this.linq2XMLToolStripMenuItem,
            this.linq2DataSetToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(466, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // linq2ObjectToolStripMenuItem
            // 
            this.linq2ObjectToolStripMenuItem.Name = "linq2ObjectToolStripMenuItem";
            this.linq2ObjectToolStripMenuItem.Size = new System.Drawing.Size(89, 21);
            this.linq2ObjectToolStripMenuItem.Text = "Linq2Object";
            this.linq2ObjectToolStripMenuItem.ToolTipText = "Search By Linq2Object";
            this.linq2ObjectToolStripMenuItem.Click += new System.EventHandler(this.linq2ObjectToolStripMenuItem_Click);
            // 
            // linq2XMLToolStripMenuItem
            // 
            this.linq2XMLToolStripMenuItem.Name = "linq2XMLToolStripMenuItem";
            this.linq2XMLToolStripMenuItem.Size = new System.Drawing.Size(77, 21);
            this.linq2XMLToolStripMenuItem.Text = "Linq2XML";
            this.linq2XMLToolStripMenuItem.ToolTipText = "Search By Linq2XML";
            this.linq2XMLToolStripMenuItem.Click += new System.EventHandler(this.linq2XMLToolStripMenuItem_Click);
            // 
            // linq2DataSetToolStripMenuItem
            // 
            this.linq2DataSetToolStripMenuItem.Name = "linq2DataSetToolStripMenuItem";
            this.linq2DataSetToolStripMenuItem.Size = new System.Drawing.Size(96, 21);
            this.linq2DataSetToolStripMenuItem.Text = "Linq2DataSet";
            this.linq2DataSetToolStripMenuItem.ToolTipText = "Search By Linq2DataSet";
            this.linq2DataSetToolStripMenuItem.Click += new System.EventHandler(this.linq2DataSetToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "请输入机器人名字：";
            // 
            // textBox_name
            // 
            this.textBox_name.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_name.Location = new System.Drawing.Point(152, 36);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(150, 23);
            this.textBox_name.TabIndex = 2;
            // 
            // button_search
            // 
            this.button_search.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_search.Location = new System.Drawing.Point(339, 36);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(75, 23);
            this.button_search.TabIndex = 3;
            this.button_search.Text = "搜索";
            this.button_search.UseVisualStyleBackColor = true;
            this.button_search.Click += new System.EventHandler(this.button_search_Click);
            // 
            // textBox_display
            // 
            this.textBox_display.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_display.Location = new System.Drawing.Point(15, 75);
            this.textBox_display.Multiline = true;
            this.textBox_display.Name = "textBox_display";
            this.textBox_display.ReadOnly = true;
            this.textBox_display.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_display.Size = new System.Drawing.Size(444, 204);
            this.textBox_display.TabIndex = 4;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_tip});
            this.statusStrip1.Location = new System.Drawing.Point(0, 287);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(466, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel_tip
            // 
            this.toolStripStatusLabel_tip.Name = "toolStripStatusLabel_tip";
            this.toolStripStatusLabel_tip.Size = new System.Drawing.Size(131, 17);
            this.toolStripStatusLabel_tip.Text = "toolStripStatusLabel1";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 309);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.textBox_display);
            this.Controls.Add(this.button_search);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search By LINQ";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem linq2ObjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem linq2XMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem linq2DataSetToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Button button_search;
        private System.Windows.Forms.TextBox textBox_display;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_tip;
    }
}

