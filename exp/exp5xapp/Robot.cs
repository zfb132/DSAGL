using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace exp5xapp
{
    public class Robot
    {
        ///指示当前使用的搜索方式
        private static int searchType = 0;
        public static int SearchType { get => searchType; set => searchType = value; }

        /// <summary>
        /// 读取XML文件内容并返回结构化数据字符串
        /// </summary>
        public static string textByObject()
        {
            XDocument doc = new XDocument();
            //捕获异常防止程序崩溃
            try {
                //相对路径使耦合度变低
                doc =XDocument.Load("../../robots.xml", LoadOptions.PreserveWhitespace);
            }
            catch (System.IO.FileNotFoundException)
            {
                doc = XDocument.Parse("<?xml version=\"1.0\" encoding=\"utf-8\" ?> \n" +
                "<Robots> \n" +
                "  <Robot><ID>1001</ID><Name>悟空</Name><IQ>220</IQ></Robot> \n" +
                "  <Robot><ID>1002</ID><Name>八戒</Name><IQ>90</IQ></Robot> \n" +
                "  <Robot><ID>1003</ID><Name>沙僧</Name><IQ>100</IQ></Robot> \n" +
                "  <Robot><ID>1004</ID><Name>AlphaGo</Name><IQ>190</IQ></Robot> \n" +
                "  <Robot><ID>1005</ID><Name>Cortana</Name><IQ>180</IQ></Robot> \n" +
                "  <Robot><ID>1006</ID><Name>Siri</Name><IQ>185</IQ></Robot> \n" +
                "</Robots>");
            }
            var root = doc.Root;
            return root.ToString();
        }

        /// <summary>
        /// 使用LINQ从XML文件解析节点内容并返回
        /// </summary>
        public static string textByXML()
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
                "  <Robot><ID>1005</ID><Name>Cortana</Name><IQ>180</IQ></Robot> \n" +
                "  <Robot><ID>1006</ID><Name>Siri</Name><IQ>185</IQ></Robot> \n" +
                "</Robots>");
            }
            var root = doc.Root;
            //var childElements = from temp in root.Descendants("Robot") select temp;
            //StringBuilder sb = new StringBuilder();
            //foreach (var element in childElements) {
            //    sb = sb.Append("名字：");
            //    sb = sb.Append(element.Element("Name").Value);
            //    sb = sb.Append(" ID：");
            //    sb = sb.Append(element.Element("ID").Value);
            //    sb = sb.Append(" 智商：");
            //    sb = sb.Append(element.Element("IQ").Value);
            //    sb = sb.AppendLine();
            //} 
            var elements = from temp in root.Descendants("Robot")
                      select new {
                          name = temp.Element("Name").Value,
                          id = temp.Element("ID").Value,
                          iq=temp.Element("IQ").Value
                    };
            StringBuilder sb = new StringBuilder();
            foreach (var e in elements)
            {
                sb = sb.Append("名字：");
                sb = sb.Append(e.name);
                sb = sb.Append(" ID：");
                sb = sb.Append(e.id);
                sb = sb.Append(" 智商：");
                sb = sb.Append(e.iq);
                sb = sb.AppendLine();
            }
            return sb.ToString();
        }

        /// <summary>
        /// 使用LINQ从XML读取内容并转化为DataSet
        /// </summary>
        public static string textByDataSet()
        {
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            try
            {
                ds.ReadXml("../../robots.xml");
            }
            catch (Exception)
            {
                return @"文件不存在或打开异常";
            }
            //获取robots.xml中的Robot表
            var dataTable = ds.Tables["Robot"];
            //DataTable属于不可枚举类型，需要转化
            var dataRows = from t in dataTable.AsEnumerable()
                           select new {
                               name = t["Name"].ToString(),
                               id = t["ID"].ToString(),
                               iq = t["iq"].ToString()
                           };
            StringBuilder sb = new StringBuilder();
            sb = sb.Append(dataTable.Columns[1].ColumnName.ToString()+"\t\t");
            sb = sb.Append(dataTable.Columns[0].ColumnName.ToString() + "\t\t");
            sb = sb.Append(dataTable.Columns[2].ColumnName.ToString());
            sb = sb.AppendLine();
            foreach (var data in dataRows)
            {
                sb = sb.Append(data.name);
                sb = sb.Append("\t\t");
                sb = sb.Append(data.id);
                sb = sb.Append("\t\t");
                sb = sb.Append(data.iq);
                sb = sb.AppendLine();
            }
            return sb.ToString();
        }


        public static string searchwithObject(string tname)
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
            var results = from temp in root.Descendants("Robot")
                          where temp.Element("Name").Value.Equals(tname)
                          select new
                          {
                              name = temp.Element("Name"),
                              id = temp.Element("ID"),
                              iq = temp.Element("IQ")
                          };
            if (results.Count() == 0)
                return @"未查询到此人";
            StringBuilder sb = new StringBuilder();
            foreach (var e in results)
            {
                sb = sb.Append(e.name);
                sb = sb.Append(e.id);
                sb = sb.Append(e.iq);
                sb = sb.AppendLine();
            }
            return sb.ToString();
        }

        public static string searchwithXML(string tname)
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
            var results = from temp in root.Descendants("Robot")
                          where temp.Element("Name").Value.Equals(tname)
                         select new
                         {
                             name = temp.Element("Name").Value,
                             id = temp.Element("ID").Value,
                             iq = temp.Element("IQ").Value
                         };
            if (results.Count() == 0)
                return @"未查询到此人";
            StringBuilder sb = new StringBuilder();
            foreach (var e in results)
            {
                sb = sb.Append("名字：");
                sb = sb.Append(e.name);
                sb = sb.Append(" ID：");
                sb = sb.Append(e.id);
                sb = sb.Append(" 智商：");
                sb = sb.Append(e.iq);
                sb = sb.AppendLine();
            }
            return sb.ToString();
        }

        public static string searchwithDS(string tname)
        {
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            try
            {
                ds.ReadXml("../../robots.xml");
            }
            catch (Exception)
            {
                return @"文件不存在或打开异常";
            }
            //获取robots.xml中的Robot表
            var dataTable = ds.Tables["Robot"];
            //DataTable属于不可枚举类型，需要转化
            var dataRows = from t in dataTable.AsEnumerable()
                           where t["Name"].ToString().Equals(tname)
                           select new
                           {
                               name = t["Name"].ToString(),
                               id = t["ID"].ToString(),
                               iq = t["iq"].ToString()
                           };
            if (dataRows.Count() == 0)
                return @"未查询到此人";
            StringBuilder sb = new StringBuilder();
            foreach (var row in dataRows)
            {
                sb = sb.Append("名字：");
                sb = sb.Append(row.name);
                sb = sb.Append(" ID：");
                sb = sb.Append(row.id);
                sb = sb.Append(" 智商：");
                sb = sb.Append(row.iq);
                sb = sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}

//用节点创建
//XElement srcTree = new XElement("Root",
//    new XElement("Element", 1),
//    new XElement("Element", 2),
//    new XElement("Element", 3),
//    new XElement("Element", 4),
//    new XElement("Element", 5)
//);
//XElement xmlTree = new XElement("Root",
//    new XElement("Child", 1),
//    new XElement("Child", 2),
//    from el in srcTree.Elements()
//    where (int)el > 2
//    select el
//);
//Console.WriteLine(xmlTree);  

//从字符串创建XML文件
//string str =
//@"<?xml version=""1.0""?>
//<!-- comment at the root level -->
//<Root>
//    <Child>Content</Child>
//</Root>";
//XDocument doc = XDocument.Parse(str);
//Console.WriteLine(doc);

//从xml文件建立DatSet，相当于将xml建成数据库了
//ds.ReadXml("../../robots.xml");
//var m = ds.Tables;
//Console.WriteLine("数据集名为\"{0}\",包含{1}个表", ds.DataSetName, ds.Tables.Count);
//foreach (DataTable dt in ds.Tables)
//{
//    Console.WriteLine(dt.TableName);
//};
//输出
//数据集名为"Robots",包含1个表