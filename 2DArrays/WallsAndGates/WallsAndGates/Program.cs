using System;

namespace WallsAndGates
{
    class Program
    {
        public const int WALL = -1;
        public const int GATE = 0;
        public const int INF = int.MaxValue;
        public const int EMPTY = int.MaxValue;
        public static int[][] directions = new int[][]{
            new int[] {-1,0 }, //Up
            new int[] {0, 1 }, //Right
            new int[] {1, 0 }, //Down
            new int[] {0,-1 }, //Left
        };
        public static void WallsAndGates(int[][] grid)
        {
            if (grid == null) return;
            for (int row = 0; row < grid.GetLength(0); row++)
            {
                for (int col = 0; col < grid.Length; col++)
                {
                    if(grid[row][col] == GATE)
                    {
                        DFS(grid, row, col, 0);
                    }
                }
            }
        }

        private static void DFS(int[][] grid, int row, int col, int Count)
        {
           if(row < 0 || row >= grid.GetLength(0) || col < 0 || col >= grid[row].Length || Count > grid[row][col])
            {
                return;
            }
            grid[row][col] = Count;
            for (int i = 0; i < directions.Length; i++)
            {
                var currentDirection = directions[i];
                DFS(grid, row + currentDirection[0], col + currentDirection[1], Count + 1);
            }
        }

        static void Main(string[] args)
        {
            
            var grid = new int[][] { 
            new int[] {INF,  -1,    0,  INF},
            new int[] {INF,  INF,  INF,  0},
            new int[] {INF,  -1,   INF,  -1},
            new int[] {0,    -1,   INF,  INF},
            };

            WallsAndGates(grid);
            for (int row = 0; row < grid.GetLength(0); row++)
            {
                for (int col = 0; col < grid[row].Length; col++)
                {
                    Console.Write(grid[row][col] + " ");
                }
                Console.Write("\n");
            }
        }
    }
}
