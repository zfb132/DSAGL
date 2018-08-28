using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAGL
{
    /**
     * 操作复数的类Complex

     * @author wwwang
     * @version 1.0
     */
    public class Complex : IComparable
    {
        private double rp = 0.0;			// 复数的实部
        private double ip = 0.0;		    // 复数的虚部
        private static double eps = 0.0;           // 缺省精度

        /**
         * 属性: 实部
         */
        public double RealPart
        {
            get
            {
                return rp;
            }
            set
            {
                rp = value;
            }
        }

        /**
         * 属性: 虚部
         */
        public double ImaginaryPart
        {
            get
            {
                return ip;
            }
            set
            {
                ip = value;
            }
        }

        /**
         * 属性: Eps
         */
        public static double Eps
        {
            get
            {
                return eps;
            }
            set
            {
                eps = value;
            }
        }

        /**
         * 基本构造函数
         */
        public Complex()
        {
        }

        /**
         * 指定值构造函数
         * 
         * @param r - 指定的实部
         * @param i - 指定的虚部
         */
        public Complex(double r, double i)
        {
            rp = r;
            ip = i;
        }

        /**
         * 拷贝构造函数
         * 
         * @param sc - 源复数
         */
        public Complex(Complex sc)
        {
            rp = sc.rp;
            ip = sc.ip;
        }

        /**
         * 根据"a,b"形式的字符串来构造复数，以a为复数的实部，b为复数的虚部
         * 
         * @param s - "a,b"形式的字符串，a为复数的实部，b为复数的虚部
         * @param sDelim - a, b之间的分隔符
         */
        public Complex(string s, string sDelim)
        {
            SetValue(s, sDelim);
        }


        /**
         * 将"a,b"形式的字符串转化为复数，以a为复数的实部，b为复数的虚部
         * 
         * @param s - "a,b"形式的字符串，a为复数的实部，b为复数的虚部
         * @param sDelim - a, b之间的分隔符
         */
        public void SetValue(string s, string sDelim)
        {
            int nPos = s.IndexOf(sDelim);
            if (nPos == -1)
            {
                s = s.Trim();
                rp = Double.Parse(s);
                ip = 0;
            }
            else
            {
                int nLen = s.Length;
                string sLeft = s.Substring(0, nPos);
                string sRight = s.Substring(nPos + 1, nLen - nPos - 1);
                sLeft = sLeft.Trim();
                sRight = sRight.Trim();
                rp = Double.Parse(sLeft);
                ip = Double.Parse(sRight);
            }
        }

        /**
         * 重载 + 运算符
         * 
         * @return Complex对象
         */
        public static Complex operator +(Complex c1, Complex c2)
        {
            Complex rs = new Complex(c1);
            rs.rp += c2.rp;
            rs.ip += c2.ip;
            return rs;
        }

        /**
         * 重载 - 运算符
         * 
         * @return Complex对象
         */
        public static Complex operator -(Complex c1, Complex c2)
        {
            Complex rs = new Complex(c1);
            rs.rp -= c2.rp;
            rs.ip -= c2.ip;
            return rs;
        }

        /**
         * 重载 * 运算符
         * 
         * @return Complex对象
         */
        public static Complex operator *(Complex c1, Complex c2)
        {
            Complex rs = new Complex(c1);
            rs.rp = rs.rp * c2.rp - rs.ip * c2.ip;
            rs.ip = rs.rp * c2.ip + rs.ip * c2.rp;
            return rs;
        }

        /**
         * 重载 / 运算符
         * 
         * @return Complex对象
         */
        public static Complex operator /(Complex c1, Complex c2)
        {
            Complex rs = new Complex(c1);
            rs.Divide(c2);
            return rs;
        }

        /**
         * 重载 double 运算符
         * 
         * @return double值
         */
        public static implicit operator double(Complex c)
        {
            return c.Abs();
        }

        /**
         * 将复数转化为"a+bj"形式的字符串
         * 
         * @return string 型，"a+bj"形式的字符串
         */
        public override string ToString()
        {
            string s;
            if (rp != 0.0)
            {
                if (ip > 0)
                    s = rp.ToString("F") + "+" + ip.ToString("F") + "j";
                else if (ip < 0)
                {
                    double absImag = -1 * ip;
                    s = rp.ToString("F") + "-" + absImag.ToString("F") + "j";
                }
                else
                    s = rp.ToString("F");
            }
            else
            {
                if (ip > 0)
                    s = ip.ToString("F") + "j";
                else if (ip < 0)
                {
                    double absImag = -1 * ip;
                    s = absImag.ToString("F") + "j";
                }
                else
                    s = rp.ToString("F");
            }

            return s;
        }

        /**
         * 比较两个复数是否相等
         * 
         * @param other - 用于比较的复数
         * @return bool型，相等则为true，否则为false
         */
        public override bool Equals(object other)
        {
            Complex c = other as Complex;
            if (c == null)
                return false;
            return Math.Abs(rp - c.rp) <= eps &&
                Math.Abs(ip - c.ip) <= eps;
        }

        /**
         * 因为重写了Equals，因此必须重写GetHashCode
         * 
         * @return int型，返回复数对象散列码
         */
        public override int GetHashCode()
        {
            return (int)this.Abs();
        }

        /**
         * 给复数赋值
         * 
         * @param x - 用于给复数赋值的源复数
         * @return Complex型，与x相等的复数
         */
        public Complex SetValue(Complex x)
        {
            rp = x.rp;
            ip = x.ip;
            return this;
        }

        /**
         * 实现复数的加法
         * 
         * @param c - 与指定复数相加的复数
         * @return Complex型，指定复数与c相加之和
         */
        public Complex Add(Complex c)
        {
            this.rp += c.rp;
            this.ip += c.ip;
            return this;
        }

        /**
         * 实现复数的减法
         * 
         * @param c - 与指定复数相减的复数
         * @return Complex型，指定复数减去c之差
         */
        public Complex Subtract(Complex c)
        {
            this.rp -= c.rp;
            this.ip -= c.ip;
            return this;
        }

        /**
         * 实现复数的乘法
         * 
         * @param c - 与指定复数相乘的复数
         * @return Complex型，指定复数与c相乘之积
         */
        public Complex Multiply(Complex c)
        {
            this.rp = this.rp * c.rp - this.ip * c.ip;
            this.ip = this.rp * c.ip + this.ip * c.rp;
            return this;
        }

        /**
         * 实现复数的除法
         * 
         * @param c - 与指定复数相除的复数
         * @return Complex型，指定复数除与c之商
         */
        public Complex Divide(Complex c)
        {
            double e, f, x, y;

            if (Math.Abs(c.rp) >= Math.Abs(c.ip))
            {
                e = c.ip / c.rp;
                f = c.rp + e * c.ip;

                x = (rp + ip * e) / f;
                y = (ip - rp * e) / f;
            }
            else
            {
                e = c.rp / c.ip;
                f = c.ip + e * c.rp;

                rp = (rp * e + ip) / f;
                ip = (ip * e - rp) / f;
            }

            return this;
        }

        /**
         * 计算复数的模
         * 
         * @return double型，指定复数的模
         */
        public double Abs()
        {
            return (Math.Sqrt(rp * rp + ip * ip));
        }


        /**
         * 计算复数的实幂指数
         * 
         * @param x - 待求实幂指数的幂次
         * @return Complex型，复数的实幂指数值
         */
        public Complex Pow(double x)
        {
            // 常量
            const double PI = 3.14159265358979;

            // 局部变量
            double r, t;

            // 特殊值处理
            if ((rp == 0) && (ip == 0))
                return this;

            // 幂运算公式中的三角函数运算
            if (rp == 0)
            {
                if (ip > 0)
                    t = 1.5707963268;
                else
                    t = -1.5707963268;
            }
            else
            {
                if (rp > 0)
                    t = Math.Atan2(ip, rp);
                else
                {
                    if (ip >= 0)
                        t = Math.Atan2(ip, rp) + PI;
                    else
                        t = Math.Atan2(ip, rp) - PI;
                }
            }

            // 模的幂
            r = Math.Exp(x * Math.Log(Math.Sqrt(rp * rp + ip * ip)));

            // 复数的实幂指数
            rp = r * Math.Cos(x * t);
            ip = r * Math.Sin(x * t);
            return this;
        }


        /**
         * 计算复数的自然对数
         * 
         * @return Complex型，复数的自然对数值
         */
        public Complex Log()
        {
            double p = Math.Log(Math.Sqrt(rp * rp + ip * ip));
            rp = p; ip = Math.Atan2(ip, rp);
            return this;
        }

        /**
         * 计算复数的正弦
         * 
         * @return Complex型，复数的正弦值
         */
        public Complex Sin()
        {
            int i;
            double x, y, y1, br, b1, b2;
            double[] c = new double[6];

            // 切比雪夫公式的常数系数
            c[0] = 1.13031820798497;
            c[1] = 0.04433684984866;
            c[2] = 0.00054292631191;
            c[3] = 0.00000319843646;
            c[4] = 0.00000001103607;
            c[5] = 0.00000000002498;

            y1 = Math.Exp(ip);
            x = 0.5 * (y1 + 1 / y1);
            br = 0;
            if (Math.Abs(ip) >= 1)
                y = 0.5 * (y1 - 1 / y1);
            else
            {
                b1 = 0;
                b2 = 0;
                y1 = 2 * (2 * ip * ip - 1);
                for (i = 5; i >= 0; --i)
                {
                    br = y1 * b1 - b2 - c[i];
                    if (i != 0)
                    {
                        b2 = b1;
                        b1 = br;
                    }
                }

                y = ip * (br - b1);
            }

            // 组合计算结果
            rp = x * Math.Sin(rp);
            ip = y * Math.Cos(rp);

            return this;
        }

        /**
         * 计算复数的余弦
         * 
         * @return Complex型，复数的余弦值
         */
        public Complex Cos()
        {
            int i;
            double x, y, y1, br, b1, b2;
            double[] c = new double[6];

            // 切比雪夫公式的常数系数
            c[0] = 1.13031820798497;
            c[1] = 0.04433684984866;
            c[2] = 0.00054292631191;
            c[3] = 0.00000319843646;
            c[4] = 0.00000001103607;
            c[5] = 0.00000000002498;

            y1 = Math.Exp(ip);
            x = 0.5 * (y1 + 1 / y1);
            br = 0;
            if (Math.Abs(ip) >= 1)
                y = 0.5 * (y1 - 1 / y1);
            else
            {
                b1 = 0;
                b2 = 0;
                y1 = 2 * (2 * ip * ip - 1);
                for (i = 5; i >= 0; --i)
                {
                    br = y1 * b1 - b2 - c[i];
                    if (i != 0)
                    {
                        b2 = b1;
                        b1 = br;
                    }
                }

                y = ip * (br - b1);
            }

            // 组合计算结果
            rp = x * Math.Cos(rp);
            ip = -y * Math.Sin(rp);

            return this;
        }

        public int CompareTo(object obj)
        {
            Complex c = obj as Complex;
            if (c == null)
                throw new ArgumentException("CompareTo（Complex）");
            if (this.Equals(c))
                return 0;
            double d1, d2;
            d1 = this.Abs();
            d2 = c.Abs();
            if (d1 < d2)
                return -1;
            else
                return 1;
        }
    }
}
