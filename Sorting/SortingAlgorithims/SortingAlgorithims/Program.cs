using System;

namespace SortingAlgorithims
{
    class Program
    {
        public static int[] BubbleSort(int[] heights)
        {
            for(int i=0; i<heights.Length-1; i++)
            {
                for(int j = 0; j < heights.Length-1; j++)
                {
                    if(heights[j] > heights[j+1])
                    {
                        var temp = heights[j];
                        heights[j] = heights[j + 1];
                        heights[j + 1] = temp;
                    }
                }
            }
            return heights;
        }

        static void Main(string[] args)
        {
            int[] numbers = { 99, 44, 6, 2, 1, 5, 63, 87, 283, 4, 0 };
            int[] floydsTest = { 1, 3, 4, 2, 2 };
            //var sortedNumbers = BubbleSort(numbers);
            Console.WriteLine(String.Join(" ", BubbleSort(numbers)));

        }
    }
}
