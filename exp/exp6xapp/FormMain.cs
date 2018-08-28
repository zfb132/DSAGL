using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace exp6xapp
{
    public partial class FormMain : Form
    {
        private List<Robot> robots = new List<Robot>();
        private List<Robot> sorted = new List<Robot>();
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            XDocument doc = new XDocument();
            //捕获异常防止程序崩溃
            try
            {
                //相对路径使耦合度变低
                doc = XDocument.Load("../../robots.xml", LoadOptions.PreserveWhitespace);
            }
            catch (System.IO.FileNotFoundException)
            {
                doc = XDocument.Parse("<?xml version=\"1.0\" encoding=\"utf-8\" ?> \n" +
                "<Robots> \n" +
                "  <Robot><ID>1001</ID><Name>悟空</Name><IQ>220</IQ></Robot> \n" +
                "  <Robot><ID>1002</ID><Name>八戒</Name><IQ>90</IQ></Robot> \n" +
                "  <Robot><ID>1003</ID><Name>沙僧</Name><IQ>100</IQ></Robot> \n" +
                "  <Robot><ID>1004</ID><Name>AlphaGo</Name><IQ>190</IQ></Robot> \n" +
                "  <Robot><ID>1005</ID><Name>AlphaGo2</Name><IQ>200</IQ></Robot> \n" +
                "</Robots>");
            }
            var root = doc.Root;
            var childElements = from temp in root.Descendants("Robot") select temp;
            foreach (var element in childElements)
            {
                string name = element.Element("Name").Value;
                int id = Int32.Parse(element.Element("ID").Value);
                double iq = Double.Parse(element.Element("IQ").Value);
                robots.Add(new Robot(id, name, iq));
            }
            displayText(robots.ToArray());
            //初始化已排序列表与原列表相同
            sorted = robots;
        }

        private void displayText(Robot[] items)
        {
            string s = "ID\t\tName\t\tIQ\r\n";
            for (int i = 0; i < items.Length; i++)
            {
                s += items[i].Id + "\t\t" + items[i].Name + "\t\t" + items[i].Iq + "\r\n";
            }
            textBox1.Text = s;
        }

        private void sortByNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Robot[] temprobots = robots.ToArray();
            Array.Sort(temprobots, new RobotComparer(RobotComparer.KeyWord.NAME));
            sorted = new List<Robot>(temprobots);
            displayText(temprobots);
        }

        private void sortByNameDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Robot[] temprobots = robots.ToArray();
            Array.Sort(temprobots, new RobotComparer(RobotComparer.KeyWord.NAMEDOWN));
            sorted = new List<Robot>(temprobots);
            displayText(temprobots);
        }

        private void sortByIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Robot[] temprobots = robots.ToArray();
            Array.Sort(temprobots, new RobotComparer(RobotComparer.KeyWord.ID));
            sorted = new List<Robot>(temprobots);
            displayText(temprobots);
        }

        private void sortByIDDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Robot[] temprobots = robots.ToArray();
            Array.Sort(temprobots, new RobotComparer(RobotComparer.KeyWord.IDDOWN));
            sorted = new List<Robot>(temprobots);
            displayText(temprobots);
        }

        private void sortByIQToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Robot[] temprobots = robots.ToArray();
            Array.Sort(temprobots, new RobotComparer(RobotComparer.KeyWord.IQ));
            sorted = new List<Robot>(temprobots);
            displayText(temprobots);
        }

        private void sortByIQDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Robot[] temprobots = robots.ToArray();
            Array.Sort(temprobots, new RobotComparer(RobotComparer.KeyWord.IQDOWN));
            sorted = new List<Robot>(temprobots);
            displayText(temprobots);
        }

        private void saveResultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //防止出现命名冲突（也可以每次都把内容存在同一个文件中，只是功能不一样）
                string time = DateTime.Now.ToString("yyyyMMddHHmmss");
                string filename = "../../robots_" + time + ".xml";
                XmlTextWriter xml = new XmlTextWriter(filename, Encoding.UTF8);
                xml.Formatting = Formatting.Indented;
                xml.WriteStartDocument();
                xml.WriteStartElement("Robots");

                for (int i = 0; i < sorted.Count; i++)
                {
                    xml.WriteStartElement("Robot");
                    xml.WriteElementString("ID", sorted[i].Id + "");
                    xml.WriteElementString("Name", sorted[i].Name);
                    xml.WriteElementString("IQ", sorted[i].Iq + "");
                    xml.WriteEndElement();
                }

                xml.WriteEndElement();
                xml.WriteEndDocument();

                xml.Flush();
                xml.Close();
                MessageBox.Show("文件另存为" + filename, @"提示", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
            }
            catch(Exception ex)
            {
                MessageBox.Show(@"保存文件失败！", @"警告", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }

        }
    }
}
