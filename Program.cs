using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{
    public static int hourglassSum(List<List<int>> a)
    {
        int i, j, sumTop = 0, sumMiddle = 0, sumBottom = 0, sumTotal = 0;
        List<int> hourGlassSums = new();
        for (i = 0; i < a.Count(); i++)
        {
            if (i == 4) break;

            for (j = 0; j < a.Count(); j++)
            {
                if (j == 4) break;
                Console.WriteLine(a[i][j].ToString() + " " + a[i][j + 1].ToString() + " " + a[i][j + 2].ToString());
                Console.WriteLine("  " + a[i + 1][j + 1].ToString() + "  ");
                Console.WriteLine(a[i + 2][j].ToString() + " " + a[i + 2][j + 1].ToString() + " " + a[i + 2][j + 2].ToString());
                Console.WriteLine("------------------------");

                sumTop = a[i][j] + a[i][j + 1] + a[i][j + 2];
                sumMiddle = a[i + 1][j + 1];
                sumBottom = a[i + 2][j] + a[i + 2][j + 1] + a[i + 2][j + 2];
                sumTotal = sumTop + sumMiddle + sumBottom;
                Console.WriteLine(sumTotal);
                hourGlassSums.Add(sumTotal);
            }
        }

        return hourGlassSums.Max();
    }

    public static int Main(string[] args)
    {
        List<List<int>> arr = new List<List<int>>();

        arr = [
            [1,2,3,4,5,6],
            [7,8,9,10,11,12],
            [14,15,16,17,18,19],
            [20,21,22,23,24,25],
            [27,28,29,30,31,32],
            [33,34,35,36,37,38]
        ];

        int n = Result.hourglassSum(arr);
        Console.WriteLine(n);

        return 0;
    }

}


