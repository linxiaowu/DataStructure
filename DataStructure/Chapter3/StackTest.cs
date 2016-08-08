using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Chapter3
{
    /// <summary>
    /// 测试顺序栈
    /// </summary>
    static class StackTest
    {
        /// <summary>
        /// 测试顺序栈
        /// </summary>
        public static void TestSeqStack()
        {
            IStack<int> stack = new SeqStack<int>(20);
            Test(stack);
            Console.WriteLine(EvaluateExpression());
        }

        /// <summary>
        /// 测试链栈
        /// </summary>
        public static void TestLinkStack()
        {
            IStack<int> stack = new LinkStack<int>();
            Test(stack);

            Console.WriteLine("\n\r括号匹配：");
            char[] arr = { '{', '[', '(', ')', ']', '(', ')', '}' };
            char[] arr2 = { '{', '(', '[', ')', ']', '(', ')', '}' };
            Console.Write(arr);
            Console.Write(":" + MatchBracket(arr));
            Console.WriteLine();

            Console.Write(arr2);
            Console.Write(":" + MatchBracket(arr2));
            Console.WriteLine();
        }

        /// <summary>
        /// 测试栈
        /// </summary>
        /// <param name="stack"></param>
        static void Test(IStack<int> stack)
        {
            Console.WriteLine("len：" + stack.GetLength());
            Console.WriteLine("\r\n测试Push方法");
            TestPush(stack);
            Console.WriteLine("期望长度6，len：" + stack.GetLength());

            Console.WriteLine("\n\r测试GetPop方法");
            TestGetPop(stack);
            Console.WriteLine("期望长度6，len：" + stack.GetLength());


            Console.WriteLine("\n\r测试Pop方法");
            TestPop(stack);
            Console.WriteLine("期望长度0，len：" + stack.GetLength());

            Console.WriteLine("\n\r进制转换，12：");
            Conversion(12, 8);
            Conversion(12, 2);
        }

        /// <summary>
        /// 测试Push方法
        /// </summary>
        /// <param name="stack"></param>
        static void TestPush(IStack<int> stack)
        {
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);
            stack.Push(6);
        }

        /// <summary>
        /// 测试GetPop方法
        /// </summary>
        /// <param name="stack"></param>
        static void TestGetPop(IStack<int> stack)
        {
            Console.WriteLine("期望6：" + stack.GetTop());
        }

        /// <summary>
        /// 测试TestPop方法
        /// </summary>
        /// <param name="stack"></param>
        static void TestPop(IStack<int> stack)
        {
            while (!stack.IsEmpty())
            {
                Console.Write(stack.Pop() + " ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// 进制转换
        /// </summary>
        /// <param name="n">十进制数据</param>
        /// <param name="m">待转换进制</param>
        static void Conversion(int n, int m)
        {
            LinkStack<int> s = new LinkStack<int>();
            while (n > 0)
            {
                s.Push(n % m);
                n /= m;
            }

            while (!s.IsEmpty())
            {
                Console.Write(s.Pop() + " ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// 括号匹配
        /// </summary>
        /// <param name="charlist"></param>
        /// <returns></returns>
        static bool MatchBracket(char[] charlist)
        {
            LinkStack<char> stack = new LinkStack<char>();
            foreach (char c in charlist)
            {
                if (stack.IsEmpty())
                {
                    stack.Push(c);
                    continue;
                }

                if (stack.GetTop().Equals('(') && c.Equals(')'))
                {
                    stack.Pop();
                    continue;
                }

                if (stack.GetTop().Equals('[') && c.Equals(']'))
                {
                    stack.Pop();
                    continue;
                }

                if (stack.GetTop().Equals('{') && c.Equals('}'))
                {
                    stack.Pop();
                    continue;
                }

                stack.Push(c);
            }
            return stack.IsEmpty();
        }

        /// <summary>
        /// 计算表达式
        /// </summary>
        /// <returns></returns>
        static int EvaluateExpression()
        {
            SeqStack<char> optr = new SeqStack<char>(20);
            SeqStack<int> opnd = new SeqStack<int>(20);
            optr.Push('#');

            int num1 = 0;   //操作数1
            int num2 = 0;   //操作数2
            char c = (char)Console.Read();

            while (true)
            {
                if (!Operator.IsOperator(c))
                {
                    opnd.Push(c - 48);
                    c = (char)Console.Read();
                }
                else
                {
                    switch (Operator.Precede(optr.GetTop(), c))
                    {
                        case OperatorResultTypes.Less:
                            optr.Push(c);
                            c = (char)Console.Read();
                            break;
                        case OperatorResultTypes.Equal:
                            optr.Pop();
                            c = (char)Console.Read();
                            break;
                        case OperatorResultTypes.Greater:
                            if (Operator.IsCalcOperator(optr.GetTop()))
                            {
                                num2 = opnd.Pop();
                                num1 = opnd.Pop();
                                opnd.Push(Operator.Calc(num1, num2, optr.Pop()));
                            }
                            else
                            {
                                optr.Push(c);
                                c = (char)Console.Read();
                            }
                            break;

                    }
                }

                if (optr.IsEmpty())
                {
                    break;
                }
            }

            return opnd.GetTop();
        }
    }


    /// <summary>
    /// 操作符
    /// </summary>
    class Operator
    {
        /*
         * 操作符字典<操作符,优先级权重>
         * 操作符优先级比较：
         *  1、若优先级相等，则左边优先级高
         *  2、若优先级不相等但和为0则表示优先级相同
         */
        static Dictionary<char, int> operators;


        //异常组合，该组合出现表示算术异常
        static string[] err;

        static Operator()
        {
            operators = new Dictionary<char, int>()
            {
                {'+',1},
                {'-',1},
                {'*',2},
                {'/',2},
                {'(',3},
                {')',-3},
                {'#',-4}
            };

            err = new string[] { ")(", "#)", "(#" };
        }

        /// <summary>
        /// 是否为运算符
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsOperator(char c)
        {
            //char[] arr = { '+', '-', '*', '/', '(', ')' };
            return operators.Keys.Contains(c);
        }

        /// <summary>
        /// 是否为计算运算符
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsCalcOperator(char c)
        {
            return operators[c] == 1 || operators[c] == 2;
        }

        /// <summary>
        /// 比较操作符优先级
        /// </summary>
        /// <param name="op1"></param>
        /// <param name="opo2"></param>
        /// <returns></returns>
        public static OperatorResultTypes Precede(char op1, char op2)
        {
            if (IsError(op1, op2))
            {
                return OperatorResultTypes.Error;
            }

            if (operators[op1] + operators[op2] == 0 || (op1 == op2 && op1 == '#'))
            {
                return OperatorResultTypes.Equal;
            }

            if (operators[op1] >= operators[op2])
            {
                return OperatorResultTypes.Greater;
            }

            return OperatorResultTypes.Less;
        }

        /// <summary>
        /// 计算
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="op"></param>
        /// <returns></returns>
        public static int Calc(int num1, int num2, char op)
        {
            switch (op)
            {
                case '+': return num1 + num2;
                case '-': return num1 - num2;
                case '*': return num1 * num2;
                case '/': return num1 / num2;
            }
            return 0;
        }

        /// <summary>
        /// 是否异常组合
        /// </summary>
        /// <param name="op1"></param>
        /// <param name="op2"></param>
        /// <returns></returns>
        static bool IsError(char op1, char op2)
        {
            return err.Contains(op1.ToString() + op2);
        }


    }

    /// <summary>
    /// 操作符比较结果
    /// </summary>
    enum OperatorResultTypes
    {
        Error,
        Greater,
        Equal,
        Less
    }
}
