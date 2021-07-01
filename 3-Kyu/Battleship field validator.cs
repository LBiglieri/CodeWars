//Write a method that takes a field for well-known board game "Battleship" as an argument and returns true if it has a valid disposition of ships, false otherwise. Argument is guaranteed to be 10*10 two-dimension array. Elements in the array are numbers, 0 if the cell is free and 1 if occupied by ship.

//Battleship (also Battleships or Sea Battle) is a guessing game for two players. Each player has a 10x10 grid containing several "ships" and objective is to destroy enemy's forces by targetting individual cells on his field. The ship occupies one or more cells in the grid. Size and number of ships may differ from version to version. In this kata we will use Soviet/Russian version of the game.


//Before the game begins, players set up the board and place the ships accordingly to the following rules:
//There must be single battleship(size of 4 cells), 2 cruisers(size 3), 3 destroyers(size 2) and 4 submarines(size 1).Any additional ships are not allowed, as well as missing ships.
//Each ship must be a straight line, except for submarines, which are just single cell.

//The ship cannot overlap or be in contact with any other ship, neither by edge nor by corner.

//This is all you need to solve this kata.If you're interested in more information about the game, visit  https://en.wikipedia.org/wiki/Battleship_(game)

namespace Solution
{
    using System;
    using System.Collections.Generic;
    public class BattleshipField
    {
        public static bool ValidateBattlefield(int[,] field)
        {
            var result = true;
            var battleships = 0;
            var cruisers = 0;
            var destroyers = 0;
            var submarines = 0;
            var maxX = field.GetLength(1);
            var maxY = field.GetLength(0);

            for (var y = 0; y < maxY; y++)
            {
                for (var x = 0; x < maxX; x++)
                {
                    var sizeUnknownShip = 0;

                    if (x + 1 < maxX && y + 1 < maxY)
                    {
                        if (field[y, x] != 0 && field[y + 1, x + 1] != 0) result = false;
                    }

                    if (x - 1 >= 0 && y - 1 >= 0)
                    {
                        if (field[y, x] != 0 && field[y + 1, x - 1] != 0) result = false;
                    }

                    if (field[y, x] == 1)
                    {
                        if (x + 1 < maxX && field[y, x + 1] == 1)
                        {
                            for (var xp = 0; xp < maxX - x; xp++)
                            {
                                if (x + xp < maxX && field[y, x + xp] == 1)
                                {
                                    field[y, x + xp] = 2;
                                    sizeUnknownShip++;
                                }
                                else
                                    break;
                            }
                        }

                        if (y + 1 < maxY && field[y + 1, x] == 1)
                        {
                            for (var yp = 0; yp < maxY - y; yp++)
                            {
                                if (y + yp < maxY && field[y + yp, x] == 1)
                                {
                                    field[y + yp, x] = 2;
                                    sizeUnknownShip++;
                                }
                                else
                                    break;
                            }
                        }

                        if (field[y, x] == 1)
                        {
                            field[y, x] = 2;
                            sizeUnknownShip++;
                        }
                    }

                    switch (sizeUnknownShip)
                    {
                        case 0: break;
                        case 1: submarines++; break;
                        case 2: destroyers++; break;
                        case 3: cruisers++; break;
                        case 4: battleships++; break;
                        default: result = false; break;
                    }
                }
            }

            if (submarines != 4) result = false;
            if (destroyers != 3) result = false;
            if (cruisers != 2) result = false;
            if (battleships != 1) result = false;

            return result;
        }
    }
}