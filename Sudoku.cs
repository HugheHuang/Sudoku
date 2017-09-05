﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace homework02
{
    public class Sudoku
    {
        int[,] sudoku;
        int max;

        public void display(string[] args)
        {
            init(args);
            dfs(1, 2);



        }

        private void init(string[] args)
        {

            sudoku = new int[10, 10];
            sudoku[1, 1] = (1 + 0) % 9 + 1;
            max = Util.ReadArgs(args);
        }


        private void dfs(int x, int y)
        {
            if (x == 10)
            {
                Util.Show(ref sudoku);
                return;
            }
            for (int i = 1; i < 10; i++)
            {
                if (Util.Count == max)
                {
                    Util.CloseStreamWriter();
                    return;
                }
                if (check(i, x, y))
                {
                    sudoku[x, y] = i;
                    if (y == 9) dfs(x + 1, 1);
                    else dfs(x, y + 1);
                }
            }
            return;
        }

        private Boolean check(int i, int x, int y)
        {
            //行检查
            for (int k = 1; k < y; k++) { if (sudoku[x, k] == i) return false; }
            //列检查
            for (int k = 1; k < x; k++) { if (sudoku[k, y] == i) return false; }
            //九宫格检查
            //找到每个块的起始点
            int a = (x - 1) / 3 * 3 + 1;
            int b = (y - 1) / 3 * 3 + 1;
            for (int j = a; j < a + 3; j++)
            {
                for (int k = b; k < b + 3; k++)
                {
                    if (j != x && k != y && sudoku[j, k] == i) return false;
                }
            }

            return true;
        }
    }
}