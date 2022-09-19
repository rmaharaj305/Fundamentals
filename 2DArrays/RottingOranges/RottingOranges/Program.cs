using System;
using System.Collections;
using System.Collections.Generic;

namespace RottingOranges
{
    class Program
    {
        #region variables
        public const int ROTTEN = 2;
        public const int FRESH = 1;
        public const int EMPTY = 0;

        public static int[][] diretions = new int[][] {
        new int[]{-1, 0}, //Up
        new int[]{0, 1}, //Right 
        new int[]{1, 0}, //Down
        new int[]{0, -1} //Left
        };
        #endregion

        #region Helper Methods
        private static void Print2DArray(int[][] grid)
        {
            for (int row = 0; row < grid.GetLength(0); row++)
            {
                for (int col = 0; col < grid[row].Length; col++)
                {
                    Console.Write(grid[row][col] + " ");
                }
                Console.Write("\n");
            }
        }
        #endregion

        public int OrangesRotting(int[][] grid)
        {
            if (grid == null) return 0;
            int freshOranges = 0;
            Queue<int[]> rottingOrangeQueue = new Queue<int[]>();
            for(int row = 0; row < grid.GetLength(0); row++)
            {
                for(int col = 0; col < grid[row].Length; col++)
                {
                    if(grid[row][col] == ROTTEN)
                    {
                        rottingOrangeQueue.Enqueue(new int[] {row, col});
                    }
                    if(grid[row][col] == FRESH)
                    {
                        freshOranges++;
                    }
                }
            }
            int currentQueueSize = rottingOrangeQueue.Count;
            int minutes = 0;
            while (rottingOrangeQueue.Count > 0)
            {
                if (currentQueueSize == 0)
                {
                    minutes++;
                    currentQueueSize = rottingOrangeQueue.Count;
                }
                var currentOrange = rottingOrangeQueue.Dequeue();
                currentQueueSize--;
                var row = currentOrange[0];
                var col = currentOrange[1];
                for (int i = 0; i < diretions.Length; i++)
                {
                    var currentDirection = diretions[i];
                    var nextRow = currentDirection[0] + row;
                    var nextCol = currentDirection[1] + col;
                    if (nextRow < 0 || nextRow >= grid.GetLength(0) || nextCol < 0 || nextCol >= grid[row].Length)
                    {
                        continue;
                    }
                    if (grid[nextRow][nextCol] == FRESH)
                    {
                        grid[nextRow][nextCol] = ROTTEN;
                        freshOranges--;
                        rottingOrangeQueue.Enqueue(new int[] { nextRow, nextCol });
                    }
                }
            }
            if (freshOranges > 0) return -1;
            if (freshOranges == 0) return minutes;
            return -1;
        }

        static void Main(string[] args)
        {
            int[][] grid = new int[][] {
            new int[] {2,1,1},
            new int[] {1,1,0},
            new int[] {1,1,0},
            new int[] {0,1,1 }
            };
            Print2DArray(grid);
        }
    }
}
