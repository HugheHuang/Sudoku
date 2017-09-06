using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace homework02
{
    public class Util
    {
        private static StreamWriter SW ;
        public static int Count { get; private set; }
        
          
        
        public static int ReadArgs(string[] args)
        {
            int arg = -1;


            try
            {
                if (args[0] == "-c")
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

        public static void Show(ref int[,] array)
        {
            if (SW == null) {
                SW = new StreamWriter(new FileStream("sudoku.txt",FileMode.Create,FileAccess.Write));
            }
            Count++;
            if (Count != 1) { SW.WriteLine(); }
            for (int i = 1; i < 10; i++)
            {
                for (int j = 1; j < 10; j++)
                {
                    if (j == 1) SW.Write(array[i, j]);
                    else SW.Write(" " + array[i, j]);
                }
                SW.WriteLine();
            }
            

        }
        public static void CloseStreamWriter() {
            if (SW != null) SW.Close();
        }
    }
}
