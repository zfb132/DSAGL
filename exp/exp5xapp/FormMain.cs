using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace exp5xapp
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //textBox_display.Text = Robot.textByObject();
            toolStripStatusLabel_tip.Text = @"未选择搜索方式";
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            if(textBox_name.Text.Length == 0)
            {
                MessageBox.Show(@"请输入姓名", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }
            if(Robot.SearchType==0)
            {
                MessageBox.Show(@"请点击菜单栏选择搜索方式", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }
            switch (Robot.SearchType)
            {
                case 1: textBox_display.Text = Robot.searchwithObject(textBox_name.Text); break;
                case 2: textBox_display.Text = Robot.searchwithXML(textBox_name.Text);break;
                case 3: textBox_display.Text = Robot.searchwithDS(textBox_name.Text); break;
                default:
                    break;
            }
            
        }

        private void linq2ObjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Robot.SearchType = 1;
            textBox_display.Text = Robot.textByObject();
            toolStripStatusLabel_tip.Text = @"Search by linq2Object";
        }

        private void linq2XMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Robot.SearchType = 2;
            textBox_display.Text = Robot.textByXML();
            toolStripStatusLabel_tip.Text = @"Search by linq2XML";
        }

        private void linq2DataSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Robot.SearchType = 3;
            textBox_display.Text = Robot.textByDataSet();
            toolStripStatusLabel_tip.Text = @"Search by linq2DataSet";
        }
    }
}
