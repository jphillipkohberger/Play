using System;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.InteropServices;



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

        // for loop control variables
        int i = 0, j = 0;

        unsafe
        {
            fixed (byte* managedMemory = new byte[(n - 1) * sizeof(long)]) 
            {
                // iterate through all queries
                for (i = 0; i < queries.Count(); i++)
                {
                    for (j = ((queries[i][0] - 1) * sizeof(long)); j <= ((queries[i][1] - 1) * sizeof(long)); j += sizeof(long))
                    {
                        *(long*)(managedMemory + j) += (long)queries[i][2];

                        if (*(long*)(managedMemory + j) > max) 
                        {
                            max = *(long*)(managedMemory + j);
                        }
                    }
                }
            }
        }
        return max;
    }

    class SinglyLinkedListNode
    {
        public int data;
        public SinglyLinkedListNode next;

        public SinglyLinkedListNode(int nodeData)
        {
            this.data = nodeData;
            this.next = null;
        }
    }

    class SinglyLinkedList
    {
        public SinglyLinkedListNode head;
        public SinglyLinkedListNode tail;

        public SinglyLinkedList()
        {
            this.head = null;
            this.tail = null;
        }

        public void InsertNode(int nodeData)
        {
            SinglyLinkedListNode node = new SinglyLinkedListNode(nodeData);

            if (this.head == null)
            {
                this.head = node;
            }
            else
            {
                this.tail.next = node;
            }

            this.tail = node;
        }
    }

    static void PrintLinkedList(SinglyLinkedListNode head)
    {
        var current = head;
        while (current != null)
        {
            Console.WriteLine(current.data);
            current = current.next;
        }
    }

    public static void PlusMinus(List<int> arr)
    {
        int count = arr.Count(), next = 0, counter = 0, i = 0, current = 0;
        List<double> ratios = new();
        arr.Sort();

        for (i = 0; i < count; i++)
        {
            current = arr[i];
            // if its not the last item we want to know 
            // what the next item in the sorted list is
            if (i != (count - 1))
            {
                next = arr[i + 1];
            }

            if (current < 0)
            {
                // if it is the last item increment counter - if its a new number
                // the ratio will be 1/count - if its a continuation of a number
                // increment counter to reflect the last instance becausse we will 
                // break after this if statement
                // IF ITS NEGATIVE AND LAST ITERATION COUNT ONCE MORE ADD RATIO TO PRINT STRUCT
                if (i == (count - 1))
                {
                    counter++;
                    ratios.Add(((double)counter / (double)count));
                    counter = 0;
                    break;
                }

                // if the current item is not equal to the next item in a sorted array
                // this indicates a change in value increment counter to reflect last
                // instance of a set of same values
                // IF ITS NEGATIVE AND NEXT ITERATION ZERO COUNT ONCE MORE ADD RATIO TO PRINT STRUCT
                if (next == 0 || next > 0)
                {
                    counter++;
                    ratios.Add(((double)counter / (double)count));
                    counter = 0;
                    continue;
                }

                // we have identified the two instances are not in a continuation
                // of the same value - 1 is the last element we wont reach this
                // far in that case, we increment one last time, calculate and leave the loop - 
                // 2 is an identification that the next element in the sorted
                // array is different than the current, we increment, calculate and move on
                // skipping this incrementation
                // IF ITS NEGATIVE, NOT LAST ITERATION, NEXT NOT ZERO AND NOT POSITIVE, COUNT ONCE MORE
                counter++;
            }

            if (current == 0)
            {
                // if it is the last item increment counter - if its a new number
                // the ratio will be 1/count - if its a continuation of a number
                // increment counter to reflect the last instance becausse we will 
                // break after this if statement
                // IF ITS 0 AND LAST ITERATION COUNT ONCE MORE ADD RATIO TO PRINT STRUCT
                if (i == (count - 1))
                {
                    counter++;
                    ratios.Add(((double)counter / (double)count));
                    counter = 0;
                    break;
                }

                // if the current item is not equal to the next item in a sorted array
                // this indicates a change in value increment counter to reflect last
                // instance of a set of same values
                // IF ITS 0 AND NEXT ITERATION POSITIVE COUNT ONCE MORE ADD RATIO TO PRINT STRUCT
                if (next > 0)
                {
                    counter++;
                    ratios.Add(((double)counter / (double)count));
                    counter = 0;
                    continue;
                }

                // we have identified the two instances are not in a continuation
                // of the same value - 1 is the last element we wont reach this
                // far in that case, we increment one last time, calculate and leave the loop - 
                // 2 is an identification that the next element in the sorted
                // array is different than the current, we increment, calculate and move on
                // skipping this incrementation
                // IF ITS ZERO AND NOT LAST ITERATION AND NEXT NOT POSITIVE COUNT ONCE MORE
                counter++;
            }

            if (current > 0)
            {
                // if it is the last item increment counter - if its a new number
                // the ratio will be 1/count - if its a continuation of a number
                // increment counter to reflect the last instance becausse we will 
                // break after this if statement
                if (i == (count - 1))
                {
                    counter++;
                    ratios.Add(((double)counter / (double)count));
                    counter = 0;
                    break;
                }

                // we have identified the two instances are not in a continuation
                // of the same value - 1 is the last element we wont reach this
                // far in that case, we increment one last time, calculate and leave the loop - 
                // 2 is an identification that the next element in the sorted
                // array is different than the current, we increment, calculate and move on
                // skipping this incrementation
                counter++;
            }

            
        }

        ratios.Sort();
        ratios.Reverse();

        for (i = 0; i < ratios.Count(); i++)
        {
            Console.WriteLine(ratios[i]);
        }
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

        Console.WriteLine("Max Bottom: " + max);

        SinglyLinkedList llist = new SinglyLinkedList();
        llist.InsertNode(1);
        llist.InsertNode(2);
        llist.InsertNode(3);
        llist.InsertNode(4);
        llist.InsertNode(5);

        //Result.PrintLinkedList(llist.head);


        string spacedNumbers = "55 48 48 45 91 97 45 1 39 54 36 6 19 35 66 36 72 93 38 21 65 70 36 63 39 76 82 26 67 29 24 82 62 53 1 50 47 65 67 19 66 90 77";

        List<int> numberList = spacedNumbers.Split(' ') // Split by space
                                           .Select(s => int.Parse(s)) // Parse each substring to an int
                                           .ToList();
        //[-4, 3, -9, 0, 4, 1] 
        Result.PlusMinus(numberList);

        return 0;
    }

}


