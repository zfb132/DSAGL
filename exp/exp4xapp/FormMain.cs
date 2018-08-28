using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace exp4xapp
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            treeView1.SelectedNode = null;
        }

        //生命周期：每当窗口第一次显示时调用
        private void FormMain_Show(object sender, EventArgs e)
        {
            treeView1.SelectedNode = null;
            treeView1.ExpandAll();
        }

        /// <summary>
        /// 显示一般的提示信息
        /// </summary>
        public static DialogResult ShowTips(string message)
        {
            return MessageBox.Show(message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        private void AboutAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new AboutBox1()).ShowDialog();
        }


        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            ShowTips(e.Node.Text);
        }
    }
}
/*
对话框不是模式就是无模式的。模式对话框，在可以继续操作应用程序的其他部分之前，必须被关闭（隐藏或卸载）。例如，如果一个对话框，在可以切换到其它窗 体或对话框之前要求先单击“确定”或“取消”，则它就是模式的。 
一、如何调用 
任何窗体（派生于基类Form的类），都可以以两种方式进行显示。 
//非模式窗体 
From qform=new Form(); 
qform.Show(); 
//模式窗体 
Form qform=new Form(); 
qform.ShowDialog(); 
一、控制权上的区别 
Form.Show创建新窗体后（非模式），立即返回，且没有在当前活动窗体和新窗体间建立任何关系，即在保持新窗口的情况下关闭（或最小化）现有 窗体或在保留现有窗体情况下关闭（或最小化）新窗口，都是可以的。 
Form.ShowDialog创建模式窗体，即只有当建立的新窗口关闭之后，原有窗体才能重新获得控制权。即如果不关闭新窗口，将无法对原活动窗 口进行任何操作。对新窗口进行的最小化、还原将会和原窗口一起进行，但是新窗口的关闭对原窗口没有影响。 
需要注意的是，不管是何种情况，只要主窗体被关闭了，或主程序结束了，那么Application.Run将会关闭所有窗体，不管它是模式还是非模 式。 
二、Owner属性带来了什么 
上面所讲的是不建立拥有关系时的窗体。当为窗体间建立了拥有关系，情况就会有所变化。 
1、首先看非模式的情况。为非模式新窗口建立拥有关系的方法是修改其Owner属性。（默认情况下，非模式窗口不存在拥有者） 
form.Owner=this; //假设当前窗口是新窗口的拥有者 
form.Show(); 
很显然，新建的非模式窗体已经被认为是原活动窗体的子窗体，原窗口的行为将会影响新窗口，所以我们姑且把它们称作父窗口和子窗口之间的关系。 
那么，改动后会有什么显著的变化呢？主要有两点： 
第一，父窗口最小化、还原或关闭，子窗口也将随之最小化、还原或关闭。（注意，在未添加拥有关系之前它们是互不相干的。）反过来，子窗口的最小化、 还原或关闭对父窗口不构成影响。 
第二、在任务栏上，只显示父窗体的图标而不显示子窗体的图标。（在父子关系诞生之前，各窗体在任务栏上有各自图标。） 
2、模式窗体的情况下。用ShowDialog方法显示新窗体时，当前窗体被认为是新窗体的逻辑拥有者。所谓逻辑拥有者，是指默认情况下，用 ShowDialog而明确指定拥有者的话，Owner值为null。但无论Owner属性设置与否，与用户的交互行为都是一样的。 
设置Owner属性的方法除了同上述Show情况下的那种之外，还有一种，即当作ShowDialog的参数传递。如： 
form.ShowDialog(this); //当前窗体为新窗体的拥有者。 
也就是说，如果你指定了第三个窗体为新模式窗口的Owner，的确，新窗口和原窗口可能断绝了关系，而是作为第三个窗口的子窗口的身份出现。但是事 实上，它们间的这种父子关系的建立并没有在行为上给我们带来跟多惊喜。比如，新窗口关闭前，父窗口还是不能获得控制权等等，一切行为都没有变。 
三、总结与说明 
1、Show方法创建的窗体在行为上具有不确定性，Owner属性对此责任重大。 
2、当前活动窗口和用ShowDialog创建的模式窗口之间有着与生俱来的关系，这一关系的承载者是可以改变的，但是这一关系的建立或解除并不能 给窗体的行为带来任何变化。 
3、一个窗体可以拥有一个可选的拥有者，同时可以成为多个窗体的拥有者。 
4、这里所指的子窗体和父窗体并不是真正意义上的，而是为了加深理解而杜撰出来的不科学的称法。应与window窗体术语中的父窗体和子窗体区分 开，不可混淆。后者存在边缘裁剪。 
*/
