using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exp6app
{
    class SortArrayByTest
    {
        static void Main(string[] args)
        {
            Robot[] robots = new Robot[5];
            Robot[] robots_backup = new Robot[5];
            initData(robots);
            Console.WriteLine("原序列：");
            Show(robots);

            Console.WriteLine("按ID排序（从低到高）");
            Array.Copy(robots, robots_backup, 5);
            Array.Sort(robots_backup, new RobotComparer(RobotComparer.KeyWord.ID));
            Show(robots_backup);

            Console.WriteLine("按ID排序（从高到低）");
            Array.Copy(robots, robots_backup, 5);
            Array.Sort(robots_backup, new RobotComparer(RobotComparer.KeyWord.IDDOWN));
            Show(robots_backup);

            Console.WriteLine("按Name排序（从低到高）");
            Array.Copy(robots, robots_backup, 5);
            Array.Sort(robots_backup, new RobotComparer(RobotComparer.KeyWord.NAME));
            Show(robots_backup);

            Console.WriteLine("按Name排序（从高到低）");
            Array.Copy(robots, robots_backup, 5);
            Array.Sort(robots_backup, new RobotComparer(RobotComparer.KeyWord.NAMEDOWN));
            Show(robots_backup);

            Console.WriteLine("按IQ排序（从低到高）");
            Array.Copy(robots, robots_backup, 5);
            Array.Sort(robots_backup, new RobotComparer(RobotComparer.KeyWord.IQ));
            Show(robots_backup);

            Console.WriteLine("按IQ排序（从高到低）");
            Array.Copy(robots, robots_backup, 5);
            Array.Sort(robots_backup, new RobotComparer(RobotComparer.KeyWord.IQDOWN));
            Show(robots_backup);
        }
        public static void initData(Robot[] temp)
        {
            temp[0] = new Robot(1, "Shannon", 145.1);
            temp[1] = new Robot(2, "Fourier", 159.3);
            temp[2] = new Robot(3, "Laplace", 150.5);
            temp[3] = new Robot(4, "Maxwell", 186.7);
            temp[4] = new Robot(5, "AlphaGo", 238.9);
        }
        static void Show(Robot[] items)
        {
            Console.WriteLine("ID\tName\tIQ");
            for (int j = 0; j < items.Length; j++)
            {
                Console.WriteLine(items[j].Id + "\t" + items[j].Name + "\t" + items[j].Iq);
            }
        }
    }
}
