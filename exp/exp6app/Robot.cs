using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exp6app
{
    public class Robot : IComparable
    {
        private int id;
        private string name;
        private double iq;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public double Iq { get => iq; set => iq = value; }

        /// <summary>
        /// robot类的构造函数
        /// </summary>
        public Robot(int robotID, string robotName, double robotIQ)
        {
            Id = robotID;
            Name = robotName;
            Iq = robotIQ;
        }

        public int CompareTo(object obj)
        {
            if (obj is Robot)
            {
                Robot robot = (Robot)obj;
                return this.Id.CompareTo(robot.Id);
            }
            throw new ArgumentException(String.Format("object is not a Robot"));
        }
    }
    public class RobotComparer : IComparer
    {
        public enum KeyWord { ID, IDDOWN, NAME, NAMEDOWN, IQ, IQDOWN };
        private KeyWord key;
        public KeyWord Key { get => key; set => key = value; }
        /// <summary>
        /// RobotComparer类的比较关键字构造方法
        /// </summary>
        public RobotComparer(KeyWord k)
        {
            Key = k;
        }
        int IComparer.Compare(object x, object y)
        {
            if (x is Robot && y is Robot)
            {
                Robot ra = (Robot)x;
                Robot rb = (Robot)y;
                switch (Key)
                {
                    case KeyWord.ID: return ra.Id.CompareTo(rb.Id);
                    case KeyWord.IDDOWN: return rb.Id.CompareTo(ra.Id);
                    case KeyWord.NAME: return ra.Name.CompareTo(rb.Name);
                    case KeyWord.NAMEDOWN: return rb.Name.CompareTo(ra.Name);
                    case KeyWord.IQ: return ra.Iq.CompareTo(rb.Iq);
                    case KeyWord.IQDOWN: return rb.Iq.CompareTo(ra.Iq);
                    default: return ra.Id.CompareTo(rb.Id);
                }
            }
            throw new ArgumentException(String.Format("object is not a Robot"));
        }
    }
}
