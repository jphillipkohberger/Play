using System;


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
        // create a 2 dimensional array 
        // with n empty arrays
        // all zero-indexed
        return null;
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
        Console.WriteLine("Maximum of Hour Glass Sums " + Result.maximumHourglassSum(a));



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
        List<List<int>> queries = [[1,2,3]];

        Result.DynamicArray(n, queries);

        return 0;
    }

}


