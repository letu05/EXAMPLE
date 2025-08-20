﻿using System;
using System.Collections.Generic;
using System.Text;

namespace mineText
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] map = {
            {"*", ".", ".", "."},
            {".", ".", ".", "."},
            {".", "*", ".", "."},
            {".", ".", ".", "."}
        };
            int MAP_HEIGHT = map.GetLength(0);
            int MAP_WIDTH = map.GetLength(1);

            string[,] mapReport = new string[MAP_HEIGHT, MAP_WIDTH];
            for (int y = 0; y < MAP_HEIGHT; y++)
            {
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    string curentCell = map[y, x];
                    if (curentCell.Equals("*"))
                    {
                        mapReport[y, x] = "*";
                    }
                    else
                    {
                        int[,] NEIGHBOURS_ORDINATE = {
                        {y - 1, x - 1}, {y - 1, x}, {y - 1, x + 1},
                        {y, x - 1}, {y, x + 1},
                        {y + 1, x - 1}, {y + 1, x}, {y + 1, x + 1},};

                        int minesAround = 0;
                        int length = NEIGHBOURS_ORDINATE.GetLength(0);
                        for (int i = 0; i < length; i++)
                        {
                            int xNe = NEIGHBOURS_ORDINATE[i, 1];
                            int yNe = NEIGHBOURS_ORDINATE[i, 0];

                            bool isOutOfMapNeighbour = xNe < 0|| xNe == MAP_WIDTH
                                    || yNe < 0
                                    || yNe == MAP_HEIGHT;
                            if (isOutOfMapNeighbour)
                            {
                                continue;
                            }

                            bool isMineOwnerNeighbour = map[yNe, xNe].Equals("*");
                            if (isMineOwnerNeighbour)
                            {
                                minesAround++;
                            }
                        }

                        mapReport[y, x] = minesAround.ToString();
                    }
                }
            }

            for (int yOrdinate = 0; yOrdinate < MAP_HEIGHT; yOrdinate++)
            {
                Console.WriteLine("\n");
                for (int xOrdinate = 0; xOrdinate < MAP_WIDTH; xOrdinate++)
                {
                    String currentCellReport = mapReport[yOrdinate, xOrdinate];
                    Console.Write(currentCellReport);
                }
            }
            Console.ReadLine();
        }
    }
}