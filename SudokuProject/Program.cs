using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework02
{
    class Program
    {



        static void Main(string[] args)
        {

            Sudoku sudoku = new Sudoku();
            sudoku.display(new string[]{ "-c", "10000" });

        }
    }
}
