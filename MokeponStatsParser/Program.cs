﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MokeponStatsParser
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new Parser();
            var res = parser.Run();
            if (!res)
                Console.WriteLine("Something went booboo :(");
        }
    }
}
