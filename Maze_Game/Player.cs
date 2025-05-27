using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Game
{
    public class Player
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public char Symbol { get; }

        public Player(int startX, int startY, char symbol)
        {
            X = startX;
            Y = startY;
            Symbol = symbol;
        }

        public bool Move(int dx, int dy, char[,] maze)
        {
            int newX = X + dx;
            int newY = Y + dy;

            if (newY >= 0 && newY < maze.GetLength(0) &&
                newX >= 0 && newX < maze.GetLength(1) &&
                (maze[newY, newX] == ' ' || maze[newY, newX] == 'G' || maze[newY, newX] == 'P' || maze[newY, newX] == 'Q'))
            {
                maze[Y, X] = ' ';
                X = newX;
                Y = newY;
                maze[Y, X] = Symbol;
                return true;
            }

            return false;
        }

        public bool IsAtGoal(int goalX, int goalY)
        {
            return X == goalX && Y == goalY;
        }

        public bool IsHuntedDown(Player other)
        {
            return this.X == other.X && this.Y == other.Y;
        }
    }
}
