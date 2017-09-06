using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace homework02
{
    /**
     * v1.0 工具类，实现IO操作
     * v1.1 提高代码复用
     */
    public class Util
    {
        private static StreamWriter SW;
        public static int Count { get; private set; }
        private static String Filename;
        /*
         * v1.0 返回打印次数
         * v1.1 将参数判断的格式提取出来
         */
        public static int ReadArgs(string[] args,string format)
        {
            int arg = -1;

            try
            {
                if (args[0] == format)
                {
                    arg = int.Parse(args[1]);
                    return arg;
                }
                else
                {
                    DoWhile(ref arg);
                }
            }
            catch (Exception)
            {
                DoWhile(ref arg);
            }
            return arg;

        }
        /**
         * 该函数是对输入参数错误的处理：
         * 不断循环，直至加入正确的参数。
         */
        private static int DoWhile(ref int arg)
        {
            while (true)
            {
                arg = -1;
                Console.WriteLine("参数错误!");
                Console.WriteLine("格式:");
                Console.WriteLine("-c 整数");
                int a1 = Console.Read();
                int a2 = Console.Read();
                string s = Console.ReadLine();
                if (a1 == '-' && a2 == 'c')
                {
                    try
                    {
                        arg = int.Parse(s);
                        return arg;
                    }
                    catch (Exception)
                    {
                        arg = -1;
                    }

                }
                if (arg > 0)
                {
                    return arg;
                }

            }
        }
        /**
         * 该函数实现数组输出到文件工作
         */
        public static void Show(ref int[,] array,string filename)
        {
            if (SW == null)
            {
                //v1.1,将输出文件的文件名改为参数传递
                Filename = filename;
                SW = new StreamWriter(new FileStream(Filename, FileMode.Create, FileAccess.Write));
                
            }
            else if (!Filename.Equals(filename))
            {
                //V1.1,新增的分支。Show函数在调用过程中可能会改变文件输出路径
                //虽然在本题中不可能
                CloseStreamWriter();
                Filename = filename;
                SW = new StreamWriter(new FileStream(Filename, FileMode.Create, FileAccess.Write));
            }
            Count++;
            //v1.1,将i和j的上限改为数组长度，而不是固定的数值10
  
            int i_max = array.GetLength(0);
            int j_max = array.GetLength(1);
            for (int i = 1; i < i_max; i++)
            {
                for (int j = 1; j < j_max; j++)
                {
                    if (j == 1) SW.Write(array[i, j]);
                    else SW.Write(" " + array[i, j]);
                }
                SW.WriteLine();
            }
            SW.WriteLine();

        }
        /**
         * 关闭文件流
         */
        public static void CloseStreamWriter()
        {
            if (SW != null) SW.Close();
        }
    }
}
