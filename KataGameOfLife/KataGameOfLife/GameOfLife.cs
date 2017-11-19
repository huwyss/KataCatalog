using System;
using KataGameOfLife;

namespace KataGameOfLife
{
    // Requirements:
    // http://codingdojo.org/cgi-bin/index.pl?action=browse&diff=1&id=KataGameOfLife
    // 1. Any live cell with fewer than two live neighbours dies, as if caused by underpopulation.
    // 2. Any live cell with more than three live neighbours dies, as if by overcrowding.
    // 3. Any live cell with two or three live neighbours lives on to the next generation.
    // 4. Any dead cell with exactly three live neighbours becomes a live cell.

    // live cells:
    //  0, 1, 4, 5, ...    --> dead
    //  2, 3               --> lives  
    //
    // dead cells:
    //  0, 1, 2, 4, 5, ... --> dead
    //  3                  --> lives  

    public class GameOfLife
    {
        public Board GetNextGen(Board startBoard)
        {
            Board nextBoard = new Board(startBoard.GetBoardDimX(), startBoard.GetBoardDimY());

            for (int x = 0; x < startBoard.GetBoardDimX(); x++)
            {
                for (int y = 0; y < startBoard.GetBoardDimY(); y++)
                {
                    if ((!startBoard.GetAlive(x, y) && startBoard.GetAliveNeighbors(x, y) == 3) ||
                        (startBoard.GetAlive(x, y) && 
                        (startBoard.GetAliveNeighbors(x, y) == 2 || startBoard.GetAliveNeighbors(x, y) == 3)))
                    {
                        nextBoard.SetAlive(x, y);
                    }
                }
            }

            return nextBoard;
        }

        
    }
}