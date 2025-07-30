using System;
namespace MyApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[,] map = {
                                { "*", ".", ".", "." },
                                { ".", ".", ".", "*" },
                                { ".", ".", ".", "." },
                                { ".", "*", ".", "." }
            };
            int row = map.GetLength(0);
            int col = map.GetLength(1);

            string[,] mapReport = new string[row, col];
            for (int i = 0; i < 0; i++)
            {
                for (int j = 0; j < 0; j++)
                {
                    string cell = map[i, j];
                    if (cell.Equals("*"))
                    {
                        mapReport[row, col] = "*";
                    }
                    else
                    {
                        int[,] Neighbors = {
                            {row - 1, col - 1},
                            {row - 1, col},
                            {row - 1, col + 1},
                            {row, col - 1},
                            {row, col + 1},
                            {row + 1, col - 1},
                            {row + 1, col},
                            {row + 1, col + 1}
                        };
                        int count = 0;
                        int lengh = Neighbors.GetLength(0);
                        for (int k = 0; k < lengh; k++)
                        {
                            int neighborRow = Neighbors[i, 0];
                            int neighborCol = Neighbors[i, 1];
                            bool isOutOfNeighbour = j < 0 || j == col || i < 0 || i == row;
                            if (isOutOfNeighbour)
                            {
                                continue;
                            }
                            bool isMine = map[neighborRow, neighborCol].Equals("*");
                            if (isMine)
                            {
                                count++;
                            }
                        }
                        mapReport[i, j] = count.ToString();
                    }
                }
            }
            for (int i = 0; i < row; i++)
            {
                Console.WriteLine("\n");
                for (int j = 0; j < col; j++)
                {
                    String curentCellReport = mapReport[i, j];
                    Console.Write(curentCellReport + " ");
                }
                Console.ReadLine();
            }
        }
    }
}
