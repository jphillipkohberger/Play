using System;


class Result
{
    public static int hourglassSum(List<List<int>> a)
    {
        int i, j, sumTop = 0, sumMiddle = 0, sumBottom = 0, sumTotal = 0;
        List<int> hourGlassSums = new();
        for (i = 0; i < a.Count(); i++)
        {
            // 4 is max number of rows
            if (i == 4) break;
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

    public static int Main(string[] args)
    {
        // new 2 dimensional array
        List<List<int>> arr = new List<List<int>>();

        // input
        arr = [
            [1,2,3,4,5,6],
            [7,8,9,10,11,12],
            [14,15,16,17,18,19],
            [20,21,22,23,24,25],
            [27,28,29,30,31,32],
            [33,34,35,36,37,38]
        ];

        // calc
        int n = Result.hourglassSum(arr);

        //print
        Console.WriteLine("Maximum of Hour Glass Sums " + n);

        return 0;
    }

}


