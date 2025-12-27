using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
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

    public static long ArrayManipulationParallel(int n, List<List<int>> queries)
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

        public void PrintLinkedList()
        {
            var current = this.head;
            while (current != null)
            {
                Console.WriteLine("Built In Print: " + current.data);
                current = current.next;
            }
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

    static void PrintLinkedListReverse(SinglyLinkedListNode head)
    {
        var current = head;
        List<int> tempContainerLinkedList = new List<int>();
        while (current != null)
        {
            tempContainerLinkedList.Add(current.data);
            current = current.next;
        }

        int originalCount = tempContainerLinkedList.Count() - 1;

        while (tempContainerLinkedList.Count() > 0)
        {
            int lastItem = tempContainerLinkedList.Last();
            tempContainerLinkedList.RemoveAt(originalCount--);
            Console.WriteLine(lastItem.ToString());
        }
    }

    static void LinkedListReverse(SinglyLinkedListNode head)
    {
        var current = head;
        List<int> tempContainerLinkedList = new List<int>();
        while (current != null)
        {
            tempContainerLinkedList.Add(current.data);
            current = current.next;
        }

        int originalCount = tempContainerLinkedList.Count() - 1;

        while (tempContainerLinkedList.Count() > 0)
        {
            int lastItem = tempContainerLinkedList.Last();
            tempContainerLinkedList.RemoveAt(originalCount--);
            Console.WriteLine(lastItem.ToString());
        }
    }

    public static void PlusMinus(List<int> arr)
    {
        int count = arr.Count(), next = 0, counter = 0, i = 0, current = 0;
        List<KeyValuePair<string,double>> ratios = new();
        double ratio;
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
                    ratio = (double)((double)counter / (double)count);
                    ratios.Add(new KeyValuePair<string,double>("Negative", ratio));
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
                    ratio = (double)((double)counter / (double)count);
                    ratios.Add(new KeyValuePair<string, double>("Negative", ratio));
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
                    ratio = (double)((double)counter / (double)count);
                    ratios.Add(new KeyValuePair<string, double>("Zero", ratio));
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
                    ratio = (double)((double)counter / (double)count);
                    ratios.Add(new KeyValuePair<string, double>("Zero", ratio));
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
                    ratio = (double)((double)counter / (double)count);
                    ratios.Add(new KeyValuePair<string, double>("Positive", ratio));
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

        //ratios.Sort();
        //ratios.Reverse(); 

        if(ratios.Count() == 1)
        {
            if (ratios[0].Key == "Negative")
            {
                ratios.Add(new KeyValuePair<string, double>("Zero", 0));
                ratios.Add(new KeyValuePair<string, double>("Positive", 0));
            }
            if (ratios[0].Key == "Zero")
            {
                ratios.Add(new KeyValuePair<string, double>("Negative", 0));
                ratios.Add(new KeyValuePair<string, double>("Positive", 0));
            }
            if (ratios[0].Key == "Positive")
            {
                ratios.Add(new KeyValuePair<string, double>("Zero", 0));
                ratios.Add(new KeyValuePair<string, double>("Negative", 0));
            }
        }

    List<KeyValuePair<string, double>> ratiosForPrint = new List<KeyValuePair<string, double>>();


        bool found = false;
        List<string> labels = ["Positive", "Negative", "Zero"];
        for (int j = 0; j < labels.Count(); j++)
        {
            found = false;
            for (i = 0; i < ratios.Count(); i++)
            {
                if (labels[j] == ratios[i].Key)
                {
                    ratiosForPrint.Add(new KeyValuePair<string, double>(labels[j], ratios[i].Value));
                    found = true; break;
                }
            }
            if (found == false)
            {
                ratiosForPrint.Add(new KeyValuePair<string,double>(labels[j], 0));
            }

        }

        for (i = 0; i < ratiosForPrint.Count(); i++)
        {
            Console.WriteLine(string.Format(ratiosForPrint[i].Value.ToString("0.000000"), "F6"));
        }
    }

    public static long AVeryBigSum(List<long> ar)
    {
        return (long)ar.Sum();
    }

    /**
     * List<List<int>> arr = [
            [11, 2, 7,  4],
            [4,  5, 5,  6],
            [10, 8, 11,-12],
            [18, 5, 14,-28]
        ];
    */

    public static int DiagonalDifferenceCheck(List<List<int>> arr)
    {
        if (arr.Count() < 1 ) { return 0; }
        if (arr.Count() != arr[0].Count()) { return 0; }

        int absSumLeftToRight = 0, absSumRightToLeft = 0, rightToLeft = arr.Count() - 1,
            thisRow = 0, thisColumn = 0, nextColumn = 0, nextRow = 0;

        int i = 0;

        while (thisRow < arr.Count())
        {       
            thisColumn = 0;
            while (thisColumn < arr[thisRow].Count()) 
            {
                if(thisRow == thisColumn)
                {
                    absSumLeftToRight += arr[thisRow][thisColumn];
                }
                thisColumn++;
            }
            thisRow++;
        }

        thisRow = arr.Count() - 1;
        while (thisRow >= 0)
        {
            thisColumn = 0;
            while (thisColumn < arr[thisRow].Count())
            {
                if(thisRow ==  arr[thisRow].Count() - 1 && thisColumn == 0)
                {
                    absSumRightToLeft += arr[thisRow][thisColumn];
                    nextRow = thisRow - 1;
                    nextColumn = thisColumn + 1;
                    break;
                }
                if(thisRow == nextRow && thisColumn == nextColumn)
                {
                    absSumRightToLeft += arr[thisRow][thisColumn];
                    nextRow = thisRow - 1;
                    nextColumn = thisColumn + 1;
                    break;
                }
                thisColumn++;
            }
            thisRow--;
        }

        return Math.Abs(absSumLeftToRight - absSumRightToLeft);
    }

    public static int DiagonalDifference(List<List<int>> arr)
    {
        int absSumLeftToRight = 0, absSumRightToLeft = 0, leftToRight = 0, rightToLeft = arr.Count() - 1, 
            thisRow = 0, lastRow = 0, thisColumn = 0, lastColumn = 0, i = 0, j = 0;

        for(i = 0; i < arr.Count(); i++)
        {
            thisRow = i;
            for (j = 0; j < arr[i].Count(); j++)
            {
                thisColumn = j;
                if(thisColumn == 0 && thisRow == 0)
                {
                    absSumLeftToRight += (arr[i][j]);
                    lastColumn = j;
                    break;
                }

                if (thisColumn == arr[i].Count() - 1 && i == arr.Count() - 1)
                {
                    absSumLeftToRight += (arr[i][j]);
                    lastColumn = j;
                    break;
                }

                if (thisColumn == lastColumn + 1)
                {
                    absSumLeftToRight += (arr[i][j]);
                    lastColumn = j;
                    break;
                }
            }
            
        }

        for (i = 0; i < arr.Count(); i++)
        {
            thisRow = i;
            for (j = arr[i].Count() - 1; j >= 0; --j)
            {
                thisColumn = j;
                if (thisColumn == arr[i].Count() - 1 && thisRow == 0)
                {
                    absSumRightToLeft += (arr[i][j]);
                    lastColumn = j;
                    break;
                }

                if (thisColumn == 0 && thisRow == arr.Count() - 1)
                {
                    absSumRightToLeft += (arr[i][j]);
                    lastColumn = j;
                    break;
                }

                if (thisColumn == lastColumn - 1)
                {
                    absSumRightToLeft += (arr[i][j]);
                    lastColumn = j;
                    break;
                }
            }
        }

        return Math.Abs(absSumLeftToRight - absSumRightToLeft);
    }

    public static long ArrayManipulation(int n, List<List<int>> queries)
    {
        // return max long
        long max = 0;
        long[] a;

        // initialized 0 indexed array
        a = new long[n];

        // for loop control variables
        int i = 0, j = 0, start = 0, end = 0;

        var quizzyMax = queries.AsParallel().Select((List<int> query, int i) =>
        {
            start = queries[i][0] - 1;
            end = queries[i][1] - 1;

            // add queries[i][2] to a[i]
            for (j = (queries[i][0] - 1); j <= (queries[i][1] - 1); j++) a[j] += queries[i][2];

            return query;
        }).ToList();

        return a.Max();
    }

    public static void StaircaseCheck(int n)
    {
        int i = 0, j = 0, k = 0, l = 0, tracker = 0;

        string buffer = "";

        tracker = n;
        List<List<string>> arr = new();
        while (i < n) 
        {
            List<string> strList = Enumerable.Repeat("#", tracker).ToList();
            int difference = n - strList.Count();
            k = 0;
            for (k = 0; k < difference; k++)
            {
                strList.Insert(0, " "); 
            }
            arr.Add(strList);
            i++;
            tracker--;
        }

        i = n - 1;
        j = 0;
        while (i >= 0) {
            buffer = "";
            j = 0;
            while (j < arr[i].Count()) 
            {
                buffer += arr[i][j];
                j++;
            }
            Console.WriteLine(buffer);
            i--;
        }
    }
        
    public static void Staircase(int n)
    {
        int absSumLeftToRight = 0, absSumRightToLeft = 0, leftToRight = 0, rightToLeft = n - 1,
            thisRow = 0, lastRow = 0, thisColumn = 0, lastColumn = 0, i = 0, j = 0;

        string writer = "";

        bool written = false;

        List<List<string>> arr = new();

        for(i = 0; i < n; i++)
        {
            arr.Add(new List<string>());
            for(j = 0; j < n; j++)
            {
                arr[i].Add("#");
            }
        }

        for (i = 0; i < n; i++)
        {
            for (j = 0; j < n; j++)
            {
                writer += arr[i][j] + " ";
            }
            Console.WriteLine(writer);
            writer = "";
        }

        Console.WriteLine("");

        Console.WriteLine("");

        for (i = 0; i < arr.Count(); i++)
        {
            thisRow = i;
            for (j = 0; j < arr[i].Count(); j++)
            {
                thisColumn = j;
                // first row, first column
                if (thisColumn == 0 && thisRow == 0)
                {
                    writer += "#";
                    lastColumn = j;
                    lastRow = i;
                    written = true;
                }

                // last row, last column
                if (thisColumn == arr[i].Count() - 1 && thisRow == arr.Count() - 1)
                {
                    writer += "#";
                    lastColumn = j;
                    lastRow = i;
                    written = true;
                }

                //  one column to the right from last position, one row to the bottom from the last position
                if (written == false && thisColumn == lastColumn + 1 && thisRow == lastRow + 1)
                {
                    writer += "#";
                    lastRow = i;
                    lastColumn = j;
                    written = true;
                }

                // thisColumn is greater than the diagonal cutoff
                if (written == false && thisColumn <= lastColumn + 1 && thisRow == lastRow + 1)
                {
                    writer = "#" + writer;
                    written = true;
                }

                // if nothing has been written and the current iteration is less than current row column count
                if (written == false && j < arr[i].Count())
                {
                    writer += " ";
                    written = true;
                }

                written = false;

            }
            Console.WriteLine(writer);
            writer = "";

        }


        for (i = 0; i < arr.Count(); i++)
        {
            thisRow = i;
            for (j = arr[i].Count() - 1; j >= 0; --j)
            {
                thisColumn = j;
                // last column, first row
                if (thisColumn == arr[i].Count() - 1 && thisRow == 0)
                {
                    writer = "#";
                    lastColumn = j;
                    lastRow = i;
                    written = true;
                }

                // last row, first column
                if (thisRow == arr.Count() - 1 && thisColumn == 0)
                {
                    writer = "#" + writer;
                    lastColumn = j;
                    lastRow = i;
                    written = true;
                    writer = writer.Trim();
                }

                //  one column to the left from last position, one row to the bottom from the last position
                if (written == false && thisColumn == lastColumn - 1 && thisRow == lastRow + 1)
                {
                    writer = "#" + writer;
                    lastRow = i;
                    lastColumn = j;
                    written = true;
                }

                // thisColumn is less than the diagonal cutoff
                if (written == false && thisColumn >= lastColumn - 1 && thisRow == lastRow + 1)
                {
                    writer = "#" + writer;
                    written = true;
                }

                // if nothing has been written and the current iteration is greater than current row column count
                if (written == false && j >= 0)
                {
                    writer = " " + writer;
                    written = true;
                }

                written = false;

            }
            Console.WriteLine(writer);
            writer = "";

        }
    }

    public static void MiniMaxSum(List<int> arr)
    {
        int i = 0, j = 0;
        long sum = 0, min = 0, max = 0;

        List<long> sums = new();

        for (i = 0; i < arr.Count(); i++)
        {
            sum = 0;
            for (j = 0; j < arr.Count(); j++)
            {
                if(arr[i] == arr[j] && i == j)
                {
                    continue;
                }
                sum += arr[j];
            }
            sums.Add(sum);
        }

        min = (long)sums.Min();
        max = (long)sums.Max();

        Console.WriteLine(min.ToString() + " " + max.ToString());

        string writer = "";
    }

    public static int BirthdayCakeCandles(List<int> candles)
    {
        int i = 0, count = 0, last = 0;

        candles = candles.OrderByDescending(n => n).ToList();

        for (i = 0; i < candles.Count(); i++)
        {
            if(i != 0 && last != candles[i])
            {
                break;
            }

            count++;

            last = candles[i];
        }

        return count;
    }

    public static string TimeConversion(string s)
    {
        return DateTime.ParseExact(s, "hh:mm:sstt", System.Globalization.CultureInfo.InvariantCulture).ToString("HH:mm:ss");
    }

    public static List<int> GradingStudents(List<int> grades)
    {
        int i = 0;

        for(i = 0; i < grades.Count; i++)
        {
            if(grades[i] < 38)
            {
                continue;
            }

            if (((grades[i] + 2) % 5 == 0))
            {
                grades[i] += 2;
            }

            if (((grades[i] + 1) % 5 == 0))
            {
                grades[i] += 1;
            }
        }

        return grades;
    }

    public static string GliderExam(int N, int M, int X)
    {
        // GOLD = 1, SILVER = 0
        // X is position of GOLD in keys list
        // M is number of tries for GOLD
        // N is number of keys

        // if position of GOLD is greater than size of keys return
        if (X > N - 1) return "";

        // initialize all elements to silver in keys list
        List<int> keys = new List<int>(new int[N]);
        // set position of gold in keys list
        keys[X] = 1;

        List<string> players = new List<string>(["HARRY", "STEVE"]);

        int i = 0, j = 0, k =0, start = 0, end = 0;

        bool found = false, playerTurnEvenOdd = true;

        string playersTurn = "HARRY";

        // continue loop perpetually until one player wins
        while(found == false)
        {
            // alternate turns between STEVE and HARRY
            if(k % 2 == 0 || k == 0)
            {
                playersTurn = players[0];
            }
            else
            {
                playersTurn = players[1];
            }

            start = i;
            end = start + M;

            // each turn consists of M consecutive tries
            for (j = start; j <= end; j++)
            {
                if (j == X)
                {
                    return playersTurn;
                }

                if (j == M)
                {
                    break;
                }
            }

            // odd increement that both had chance once
            if(k % 2 != 0)
            {
                i++;
            }
            k++;
        }

        return "";
    }

    /*
     * Write a function that takes an integer as input, and returns the 
     * number of bits that are equal to one in the binary representation 
     * of that number. You can guarantee that input is non-negative.
     * Example: The binary representation of 1234 is 10011010010, 
     * so the function should return 5 in this case
    **/

    public static int BitsEqualToOne(int number)
    {
        if (number <= 0) return 0;

        int returnNumber = 0;
        string numberBinaryAsString = Convert.ToString(number, 2);
        char localNumberBinaryAsChar;
        string localNumberBinaryAsString = "";
        for (int i = 0; i < numberBinaryAsString.Length; i++)
        {
            localNumberBinaryAsChar = numberBinaryAsString[i];
            localNumberBinaryAsString = localNumberBinaryAsChar.ToString();
            if (localNumberBinaryAsString.Equals("1"))
            {
                returnNumber++;
            }
        }

        Console.WriteLine("Number: " + number.ToString() + " Converted: " + numberBinaryAsString + " Number of Bits equal to 1: " + returnNumber.ToString());
        return 0;
    }

    static int SolveMeFirst(int a, int b)
    {
        if (a >= 1 && b >= 1 && a <= 1000 && b <= 1000)
        {
            return a + b;
        }
        return 0;   
    }

    public static List<int> CompareTriplets(List<int> a, List<int> b)
    {
        int alice = 0, bob = 0;

        for (int i = 0; i < a.Count(); i++)
        {
            if (a[i] > b[i])
            {
                alice++;
            }

            if (a[i] < b[i])
            {
                bob++;
            }

            // moot point
            if (a[i] == b[i])
            {
                continue;
            }
        }
        Console.WriteLine("Alice: " + alice + " Bob: " + bob);
        return [alice, bob];
    }

    /**
     *
     * The function accepts following parameters:
     *  1. INTEGER s
     *  2. INTEGER t
     *  3. INTEGER a
     *  4. INTEGER b
     *  5. INTEGER_ARRAY apples
     *  6. INTEGER_ARRAY oranges
     **/

    public static void CountApplesAndOranges(int s, int t, int a, int b, List<int> apples, List<int> oranges)
    {
        int i;

        i = 0;
        List<int> applesSum = new List<int>();
        while (i < apples.Count())
        {
            if ((a + apples[i]) >= s && (a + apples[i]) <= t) applesSum.Add(a + apples[i]);
            i++;
        }

        i = 0;
        List<int> orangesSum = new List<int>();
        while (i < oranges.Count())
        {
            if ((b + oranges[i]) >= s && (b + oranges[i]) <= t) orangesSum.Add(b + oranges[i]);
            i++;
        }
        Console.WriteLine(applesSum.Count());
        Console.WriteLine(orangesSum.Count());
    }

    /*
     * Complete the 'kangaroo' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts following parameters:
     *  1. INTEGER x1
     *  2. INTEGER v1
     *  3. INTEGER x2
     *  4. INTEGER v2
     */

    public static string Kangaroo(int x1, int v1, int x2, int v2)
    {
        return "YES";
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
        Console.WriteLine("Maximum of Hour Glass Sums: " + Result.maximumHourglassSum(a) + "\n");



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
        llist.InsertNode(101);
        llist.InsertNode(302);
        llist.InsertNode(164);
        llist.InsertNode(530);
        llist.InsertNode(474);

        llist.PrintLinkedList();

        Result.PrintLinkedList(llist.head);
        Result.PrintLinkedListReverse(llist.head);
        Result.LinkedListReverse(llist.head);


        //string spacedNumbers = "55 48 48 45 91 97 45 1 39 54 36 6 19 35 66 36 72 93 38 21 65 70 36 63 39 76 82 26 67 29 24 82 62 53 1 50 47 65 67 19 66 90 77";

        string spacedNumbers = "0 100 35 0 94 40 42 87 59 0";

        List<int> numberList = spacedNumbers.Split(' ') // Split by space
            .Select(s => int.Parse(s)) // Parse each substring to an int
            .ToList();

        numberList = [-4, 3, -9, 0, 4, 1];
        Result.PlusMinus(numberList);

        List<List<int>> arr = [
            [11, 2, 7,  4],
            [4,  5, 5,  6],
            [10, 8, 11,-12],
            [18, 5, 14,-28]
        ];

        int diagonalDifferenceAbsoluteSum = Result.DiagonalDifference(arr);

        Console.WriteLine("Diagonal Difference Absolute Sum: " + diagonalDifferenceAbsoluteSum);

        int diagonalDifferenceAbsoluteSumCheck = Result.DiagonalDifferenceCheck(arr);

        Console.WriteLine("Diagonal Difference Absolute Sum Check: " + diagonalDifferenceAbsoluteSumCheck);

        Result.Staircase(6);
        Result.StaircaseCheck(6);

        Result.MiniMaxSum([1, 2, 3, 4, 5]);

        Result.BirthdayCakeCandles([3, 2, 1, 4 ,3, 5 , 5 , 5]);

        Result.GradingStudents([73, 67, 38, 33]);

        // Result.GliderExam(20,5,15);

        int number = 7819;

        Result.BitsEqualToOne(number);

        Result.Kangaroo(0,3,4,2);

        Console.WriteLine("Solve Me First called last: " + Result.SolveMeFirst(1, 3));

        Console.WriteLine("Comparing Triplets: " + CompareTriplets([17, 28, 30], [99, 16, 8]));

        /**
         * 
         * Variables for CountApplesAndOranges function
         * 
         **/

        int s = 7, t = 10, aa = 4, b = 12;
        List<int> apples = new List<int> { 2, 3, -4 };
        List<int> oranges = new List<int> { 3, -2, -4 };

        Result.CountApplesAndOranges(s,t, aa, b, apples, oranges);

        return 0;
    }

}


