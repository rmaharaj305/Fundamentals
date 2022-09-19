using System;
using System.Collections;
using System.Collections.Generic;

namespace NumberOfIslands
{
    public class Program
    {

        public static int NumIslands(char[][] grid)
        {
            if (grid == null) return 0;
            int islandCount = 0;
            for(int row = 0; row < grid.GetLength(0);row++)
            {
                for(int col =0; col < grid[row].Length; col++)
                {
                    if (grid[row][col] == '1')
                    {
                        islandCount++;
                        grid[row][col] = '0';
                        Queue<int[]> bfsQueue = new Queue<int[]>();
                        bfsQueue.Enqueue(new int[] { row, col });
                        while (bfsQueue.Count > 0)
                        {
                            var currentPosition = bfsQueue.Dequeue();
                            var currentRow = currentPosition[0];
                            var currentCol = currentPosition[1];
                            for (int i = 0; i < directions.Length; i++)
                            {
                                var currentDirection = directions[i];
                                var nextRow = currentRow + currentDirection[0];
                                var nextColumn = currentCol + currentDirection[1];
                                if (nextRow < 0 || nextRow >= grid.GetLength(0) || nextColumn < 0 || nextColumn >= grid[row].Length)
                                {
                                    continue;
                                }

                                if (grid[nextRow][nextColumn] == '1')
                                {
                                    bfsQueue.Enqueue(new int[] { nextRow, nextColumn });
                                    grid[nextRow][nextColumn] = '0';
                                }
                            }
                        }
                    }
                }
            }
            return islandCount;
        }

        public static int NumberIslandsDFS(char[][] grid)
        {
            if (grid == null) return 0;
            int islandCount = 0;
            for(int row =0; row < grid.GetLength(0); row++)
            {
                for(int col = 0; col < grid[row].Length; col++)
                {
                    if(grid[row][col] == '1')
                    {
                        islandCount++;
                        DFS(grid, row, col);
                    }
                }
            }
            return islandCount;
        }

        private static void DFS(char[][] grid, int currentRow, int currentCol)
        {
            if(currentRow < 0 || currentRow >= grid.GetLength(0) || currentCol < 0 || currentCol >= grid[currentRow].Length)
            {
                return;
            }
            if (grid[currentRow][currentCol] == '1')
            {
                grid[currentRow][currentCol] = '0';
                for(int i =0; i < directions.Length; i++)
                {
                    var currentDirection = directions[i];
                    int nextRow = currentDirection[0];
                    var nextCol = currentDirection[1];
                    DFS(grid, currentRow + nextRow, currentCol + nextCol);
                }
            }
        }

        public static int[][] directions = new int[][] {
            new int [] {-1, 0}, // Up
            new int [] {0, 1}, // right
            new int [] {1, 0}, // Down
            new int [] {0, -1} // left
        };
        static void Main(string[] args)
        {
            //Multidimensional Array 
            char[,] grid2 ={{'1','1','1','0','0'},
                            {'1','1','1','0','1'},
                            {'0','1','0','0','1'},
                            {'0','0','0','1','1'}
                            };

            //Initalize jagged array (array of arrays)
            char[][] map = new char[][]
            {
                new char[] {'1','1','1','0','0'},
                new char[] {'1','1','1','0','1'},
                new char[] {'0','1','0','0','1'},
                new char[] {'0','0','0','1','1'},
            };

            //Console.WriteLine(grid2.GetLength(0)); (for row length) :4
            //Console.WriteLine(grid2[1].Length); (for col length) :5
            //for (int row = 0; row < map.GetLength(0); row++)
            //{
            //    for (int col = 0; col < map[row].Length; col++)
            //    {
            //        Console.Write(map[row][col] + " ");
            //    }
            //    Console.WriteLine();
            //}

            //Console.WriteLine(NumIslands(map));
            Console.WriteLine(NumberIslandsDFS(map));
        }
    }
}
