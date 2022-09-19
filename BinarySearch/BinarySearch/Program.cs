using System;

namespace BinarySearch
{
    class Program
    {
        public static int BinarySearch(int[] numbers, int target)
        {
            int min = 0;
            int max = numbers.Length - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (target == numbers[mid])
                {
                    return mid;
                }
                else if (target < numbers[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return -1;
        }
        static void Main(string[] args)
        {
            int[] numbers = { 6, 7, 8, 9, 10,11};
            int target = 1;
            Console.WriteLine(String.Join(" ",BinarySearch(numbers,target)));
        }
    }
}
