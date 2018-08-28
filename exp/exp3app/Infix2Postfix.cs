using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSAGL;

namespace exp3app
{
    class Infix2Postfix
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine(args[1]);
            string infix, postfix;
            Console.WriteLine("测试用例：");
            infix = "((1+2)*(4-3)-5+6)*8/2";
            Console.WriteLine("中序表达式: " + infix);
            postfix = ConvertExp(infix);
            Console.WriteLine("后序表达式: " + postfix);
            Console.WriteLine("表达式的值: " + CalculateExp(postfix)+"\n");

            Console.WriteLine("请输入表达式：");
            infix = Console.ReadLine();
            string matchResult = MatchingBracket(infix);
            if (matchResult.Equals("OK!"))
            {
                Console.WriteLine("中序表达式: " + infix);
                postfix = ConvertExp(infix);
                Console.WriteLine("后序表达式: " + postfix);
                Console.WriteLine("表达式的值: " + CalculateExp(postfix));
            }else
                Console.WriteLine("表达式括号不匹配："+matchResult);
        }

        /// <summary>
        /// 将输入的中序表达式转换为后序表达式
        /// <para>1.从左到右对中缀表达式进行扫描，每次处理一个字符</para>
        /// <para>2.遇到左括号，入栈；遇到数字，原样输出</para>
        /// <para>3.遇到常规运算符时：</para>
        /// <para>①栈非空 且栈顶不是左括号 且栈顶运算符的优先级不低于输入运算符优先级，</para>
        /// <para>反复将栈顶元素出栈输出</para>
        /// <para>②当不符合①时则把输入的运算符压栈</para>
        /// <para>4.若遇到右括号，则运算符出栈，直到出栈的数据元素为左括号停止</para>
        /// <para>5.当表达式的符号序列全部读入后，若栈内仍有元素，把他们依次出栈输出</para>
        /// </summary>
        public static string ConvertExp(String infixStr)
        {
            //创建长度为30的线性字符串栈 
            SequencedStack<string> ss = new SequencedStack<string>(30); 
            char ch;
            string tempStr = "";
            string postfixStr="";
            int i = 0;
            //当表达式还没有读取结束时
            while (i < infixStr.Length)
            {
                ch = infixStr[i];
                switch (ch)
                {
                    //当遇到 ＋ - 时（优先级低） 
                    case '+':       
                    case '-':
                        //栈非空且栈顶不是 ( 且栈顶运算符的优先级不低于输入的运算符的优先级时
                        //反复将栈顶元素出栈输出直到不符合上述条件
                        while (!ss.Empty && !(ss.Peek()).Equals("("))
                        {
                            tempStr = ss.Pop();
                            postfixStr += tempStr;
                        }
                        ss.Push(ch.ToString());
                        i++;
                        break;
                    //遇到 * / 时 （优先级高）
                    case '*':       
                    case '/':
                        //它的优先级比栈顶数据元素的优先级相同，所以栈顶数据元素出栈
                        //直到新栈顶数据元素的优先级比它低，然后将它入栈
                        while (!ss.Empty && ((ss.Peek()).Equals("*") ||
                         (ss.Peek()).Equals("/")))
                        {
                            tempStr = ss.Pop();
                            postfixStr += tempStr;
                        }
                        ss.Push(ch.ToString());
                        i++;
                        break;
                    case '(':
                        //遇到左括号时, 入栈（优先级最高）
                        ss.Push(ch.ToString());       
                        i++;
                        break;
                    case ')':
                        //遇到右括号时，栈顶元素出栈
                        //直到出栈的数据元素为左括号，此时才括号匹配
                        tempStr = ss.Pop();              
                        while (!ss.Empty && (tempStr == null || !tempStr.Equals("(")))
                        {
                            postfixStr += tempStr;
                            tempStr = ss.Pop();
                        }
                        i++;
                        break;
                    default:
                        //遇到数字时（根据ASCII比较大小）
                        while (ch >= '0' && ch <= '9')
                        {  
                            postfixStr += ch;
                            i++;
                            if (i < infixStr.Length)
                                ch = infixStr[i];
                            else
                                ch = '=';
                        }
                        // 添加分隔符使表达式美观
                        postfixStr += " ";
                        break;
                }
            }
            while (!ss.Empty)
            {
                tempStr = ss.Pop();
                postfixStr = postfixStr + tempStr;
            }
            return postfixStr;
        }

        /// <summary>
        /// 计算后序表达式的值（直接根据表达式从左到右进行运算即可）
        /// </summary>
        public static int CalculateExp(String postfixStr)
        {
            LinkedStack<int> ls = new LinkedStack<int>();
            char ch;
            int i = 0, x, y, z = 0;
            while (i < postfixStr.Length)
            {
                ch = postfixStr[i];
                if (ch >= '0' && ch <= '9')
                {
                    z = 0;
                    while (ch != ' ')
                    {
                        z = z * 10 + Int32.Parse(ch + "");
                        i++;
                        ch = postfixStr[i];
                    }
                    i++;
                    ls.Push(z);
                }
                else
                {
                    y = ls.Pop();
                    x = ls.Pop();
                    switch (ch)
                    {
                        case '+': z = x + y; break;
                        case '-': z = x - y; break;
                        case '*': z = x * y; break;
                        case '/': z = x / y; break;
                    }
                    ls.Push(z);
                    i++;
                }
            }
            return ls.Pop();
        }

        /// <summary>
        /// 判断表达式括号是否匹配（中序表达式）
        /// </summary>
        public static string MatchingBracket(string expstr)
        {
            SequencedStack<char> ss = new SequencedStack<char>(30);  
            char nextToken, outToken;
            int i = 0;
            bool LlrR = true;
            while (LlrR && i < expstr.Length)
            {
                nextToken = expstr[i];
                i++;
                switch (nextToken)
                {
                    //遇到 ( ,将其入栈
                    case '(':                         
                        ss.Push(nextToken);
                        break;
                    //遇到 ) ,弹出栈顶元素
                    case ')':                      
                        if (ss.Empty)
                        {
                            LlrR = false;
                        }
                        else
                        {
                            outToken = ss.Pop();
                            //遇到 ( ，但出栈的不是 ) 
                            if (!outToken.Equals('('))
                                LlrR = false;            
                        }
                        break;
                }
            }
            if (LlrR)
                return ss.Empty ? "OK!": "期望)!";
            else
                return "期望(!";
        }
    }
}


