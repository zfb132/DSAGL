using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exp1app
{
    class GenericList
    {
        static void Main(string[] args)
        {
            List<Student> stuList = new List<Student>() { new Student(3016, "张超", 89),
            new Student(3053, "马飞", 80),new Student(3041, "刘羽", 96),
            new Student(3025, "赵备", 79), new Student(3039, "关云", 85)};
            stuList.Insert(2, new Student(3000, "马超", 95));
            /*
             var的使用是允许的，但不必需：当查询结果的类型可以明确表述为IEnumerable<string>
             必须使用 var：当结果是匿名类型的集合，并且该类型的名称只有编译器本身才可访问
             */
            foreach (var item in stuList)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }

    class Student
    {
        int studentID;
        string name;
        double mark;

        public Student(int id, string name, double mark)
        {
            this.studentID = id;
            this.name = name;
            this.mark = mark;
        }
        // get 关键字在属性或索引器中定义访问器方法，它将返回属性值或索引器元素
        // set 关键字在属性或索引器中定义访问器，它会向属性或索引器元素分配值
        // value 关键字用于定义由 set 访问器分配的值
        // 属性是一种成员，它提供灵活的机制来读取、写入或计算私有字段的值。 
        // 属性可用作公共数据成员，但它们实际上是称为访问器的特殊方法
        // C# 7开始使用这种定义
        // public string Name
        // {
        //     get => name;
        //     set => name = value;
        // }

        public int StudentID
        {
            get { return studentID; }
            set { studentID = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double Mark
        {
            get { return mark; }
            set { mark = value; }
        }

        public override string ToString()
        {
            return studentID.ToString() + "-" + name;
        }
    }
}
