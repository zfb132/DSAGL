using DSAGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exp2app
{
    class GenericList
    {
        class Student
        {
            private int id;
            private string name;
            private int old;

            public Student(int id, string name, int old)
            {
                this.id = id;
                this.name = name;
                this.old = old;
            }

            public int ID
            {
                get
                {
                    return id;
                }
                set
                {
                    id = value;
                }
            }
            public string NAME
            {
                get
                {
                    return name;
                }
                set
                {
                    name = value;
                }
            }
            public int OLD
            {
                get
                {
                    return old;
                }
                set
                {
                    old = value;
                }
            }
        }
        static void Main(string[] args)
        {
            // 声明并构造整型数的列表 
            List<int> a = new List<int>();
            a.Add(86); a.Insert(0, 100);

            // 声明构造学生类列表
            Student m1 = new Student(1, "aa", 18);
            Student m2 = new Student(5, "ee", 22);
            List<Student> list1 = new List<Student>() { new Student(2, "bb", 19) };
            List<Student> list2 = new List<Student>() { new Student(3, "cc", 20), new Student(4, "dd", 21) };
            list1.Add(m1);
            list2.Insert(1, m2);
            Console.WriteLine(list1[1].NAME);
            Console.WriteLine(list2[1].NAME);

            //--------SingleLinkedList---------//
            // 声明并构造整型数的列表 
            SingleLinkedList<int> sa = new SingleLinkedList<int>();
            sa.Add(86);
            sa.Insert(0, 100);

            // 声明构造学生类列表
            Student sm1 = new Student(1, "aa", 18);
            Student sm2 = new Student(2, "bb", 19);
            Student[] sm = new Student[2]{ new Student(3, "cc", 20), new Student(4, "dd", 21) };
            SingleLinkedList<Student> slist1 = new SingleLinkedList<Student>(sm);
            SingleLinkedList<Student> slist2 = new SingleLinkedList<Student>(new Student(5, "ee", 22));
            slist1.Add(sm1);
            slist2.Insert(1, sm2);
            Console.WriteLine(slist1[2].NAME);
            Console.WriteLine(slist2[1].NAME);
        }
    }

    
}
