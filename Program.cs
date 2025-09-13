using System;
using static System.Runtime.InteropServices.JavaScript.JSType;


class Result
{
    /**
     * returns the Maximum Hour Glass Sum
     */
    public static int maximumHourglassSum(List<List<int>> a)
    {
        // declare variables
        int i, j;

        // create new list
        List<int> hourGlassSums = new();

        // iterate throw rows
        for (i = 0; i < a.Count(); i++)
        {
            // 4 is max number of rows
            if (i == 4) break;

            // iterate through columns
            for (j = 0; j < a.Count(); j++)
            {
                // 4 is max number of columns
                if (j == 4) break;

                // calculation of sum added to list
                hourGlassSums.Add(

                       // in Hour Glass format
                       a[i][j]   +   a[i][j + 1]    +  a[i][j + 2]

                                + a[i + 1][j + 1]

                    + a[i + 2][j] + a[i + 2][j + 1] + a[i + 2][j + 2]

                );
            }
        }

        return hourGlassSums.Max();
    }

    public static List<int> DynamicArray(int n, List<List<int>> queries)
    {
        int i, j, lastAnswer, idx;

        lastAnswer = 0;

        // create a 2 dimensional array 
        // with n empty arrays
        // all zero-indexed
        List<List<int>> arr = [];
        for(i = 0; i < n; i++)
        {
            arr.Add(new List<int>());
        }

        // Declare a 2 - dimensional array, arr , with n empty arrays, all zero-indexed.
        // Declare an integer, lastAnswer , and initialize it to 0.

        //1. Query 1 x y
        //    Compute idx = x ^ lastAnswer
        //    Append the integer y to arr[idx]

        //2. Query 2 x y
        //    Compute idx = x ^ lastAnswer
        //    Set lastAnswer = arr[idx][y % size(arr[idx])]
        //    Store the new value of lastAnswer in an answers array

        //Here’s the key point:
        //The first number in each query(1 or 2) tells you what kind of operation to do.
        //The second number(x) is only used to calculate the index into arr.
        //Only the third number(y) in a Type 1 query is actually appended.


        List<int> answers = new();
        for (i = 0; i < queries.Count(); i++)
        {
            idx = (queries[i][1] ^ lastAnswer) % n;

            if(queries[i][0] == 1) arr[idx].Add(queries[i][2]);

            if (queries[i][0] == 2)
            {
                lastAnswer = arr[idx][queries[i][2] % arr[idx].Count()];
                answers.Add(lastAnswer);
            }
            
            Console.WriteLine("\n");
        }

        return answers;
    }

    public static long ArrayManipulation(int n, List<List<int>> queries)
    {
        // return max long
        long max = 0;

        // initialized 0 indexed array
        long [] a = new long [n];

        // for loop control variables
        int i = 0, j = 0, start = 0, end = 0;

        // iterate through all queries
        for (i = 0; i < queries.Count(); i++)
        {
            // set dynamic start and end for inner loop
            start = queries[i][0] - 1;
            end = queries[i][1] - 1;

            // add queries[i][2] to a[i]
            for (j = start; j <= end; j++) a[j] += queries[i][2];

            // write result
            Console.WriteLine(string.Join(", ",a));
        }

        //set max var and return
        max = a.Max();
        return max;
    }

    public static int Main(string[] args)
    {
        /**
         * 
         * 
         * HOUR GLASS SUM
         * 
         * 
         */



        // new 2 dimensional array
        List<List<int>> a = new List<List<int>>();

        // input
        a = [
            [1,2,3,4,5,6],
            [7,8,9,10,11,12],
            [14,15,16,17,18,19],
            [20,21,22,23,24,25],
            [27,28,29,30,31,32],
            [33,34,35,36,37,38]
        ];

        //print
        Console.WriteLine("Maximum of Hour Glass Sums " + Result.maximumHourglassSum(a) + "\n");



        /**
         * 
         * 
         * HOUR GLASS SUM
         * 
         * 
         */

        // XOR with 2 inputs
        //int a = 5;  // Binary: 0101
        //int b = 3;  // Binary: 0011
        //int result = a ^ b; // Binary: 0110 (decimal 6)  

        // chain XOR with ultiple inputs
        //int a = 5;  // Binary: 0101
        //int b = 3;  // Binary: 0011
        //int c = 6;  // Binary: 0110

        // Chaining bitwise XOR operations
        // int result = a ^ b ^ c;
        // (0101 ^ 0011) = 0110 (6)
        // (0110 ^ 0110) = 0000 (0)
        //int result = 0000 = 0

        int n = 3;
        List<List<int>> queries = [[1, 0, 5], [1, 1, 7], [1, 0, 3], [2, 1, 0], [2, 1, 1]];

        List<int> answers = Result.DynamicArray(n, queries);

        for (int x = 0; x < answers.Count(); x++) Console.WriteLine(answers[x]);

        n = 10;
        queries = [[1, 5, 3], [4, 8, 7], [6, 9, 1]];
        long max = Result.ArrayManipulation(n, queries);

        return 0;
    }

}


