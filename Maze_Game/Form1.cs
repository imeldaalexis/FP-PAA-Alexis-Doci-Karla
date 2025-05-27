using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Maze_Game
{
    public partial class Form1 : Form
    {
        const int rows = 21;
        const int cols = 21;
        const int cellSize = 25;

        char[,] maze = new char[rows, cols];
        int goalX = cols - 2, goalY = rows - 2;

        Player player1;
        Player player2;

        Random rand = new Random();

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.Width = cols * cellSize + 20;
            this.Height = rows * cellSize + 40;
            this.KeyPreview = true;

            GenerateMaze();

            this.Paint += Form1_Paint;
            this.KeyDown += Form1_KeyDown;
        }

        void GenerateMaze()
        {
            for (int y = 0; y < rows; y++)
                for (int x = 0; x < cols; x++)
                    maze[y, x] = '#';

            DFS(1, 1);

            // Initialize players
            player1 = new Player(1, 1, 'P');
            player2 = new Player(1, cols - 2, 'Q');
            maze[player1.Y, player1.X] = player1.Symbol;
            maze[player2.Y, player2.X] = player2.Symbol;

            maze[goalY, goalX] = 'G';
        }

        void DFS(int y, int x)
        {
            maze[y, x] = ' ';
            int[] dx = { 0, 0, 2, -2 };
            int[] dy = { -2, 2, 0, 0 };
            List<int> dirs = new List<int> { 0, 1, 2, 3 };
            Shuffle(dirs);

            foreach (int dir in dirs)
            {
                int nx = x + dx[dir];
                int ny = y + dy[dir];

                if (ny > 0 && ny < rows && nx > 0 && nx < cols && maze[ny, nx] == '#')
                {
                    maze[y + dy[dir] / 2, x + dx[dir] / 2] = ' ';
                    DFS(ny, nx);
                }
            }
        }

        void Shuffle(List<int> list)
        {
            for (int i = list.Count - 1; i > 0; i--)
            {
                int j = rand.Next(i + 1);
                (list[i], list[j]) = (list[j], list[i]);
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < cols; x++)
                {
                    Rectangle rect = new Rectangle(x * cellSize, y * cellSize, cellSize, cellSize);
                    char ch = maze[y, x];
                    Brush brush = Brushes.White;

                    switch (ch)
                    {
                        case '#': brush = Brushes.Black; break;
                        case 'P': brush = Brushes.Green; break;
                        case 'Q': brush = Brushes.Blue; break;
                        case 'G': brush = Brushes.Gold; break;
                    }

                    g.FillRectangle(brush, rect);
                    g.DrawRectangle(Pens.Gray, rect);
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            bool moved = false;

            // Player 1 - Arrow keys
            if (e.KeyCode == Keys.Up) moved = player1.Move(0, -1, maze);
            else if (e.KeyCode == Keys.Down) moved = player1.Move(0, 1, maze);
            else if (e.KeyCode == Keys.Left) moved = player1.Move(-1, 0, maze);
            else if (e.KeyCode == Keys.Right) moved = player1.Move(1, 0, maze);

            // Player 2 - WASD
            else if (e.KeyCode == Keys.W) moved = player2.Move(0, -1, maze);
            else if (e.KeyCode == Keys.S) moved = player2.Move(0, 1, maze);
            else if (e.KeyCode == Keys.A) moved = player2.Move(-1, 0, maze);
            else if (e.KeyCode == Keys.D) moved = player2.Move(1, 0, maze);

            if (moved == true)
            {
                Invalidate(); // Redraw
                CheckVictory();
            }
        }

        private void CheckVictory()
        {
            if (player2.IsHuntedDown(player1))
            {
                MessageBox.Show("🎉 Player 1 Successfully Hunted Player 2!", "Victory");
                this.Close();
            }
            else if (player1.IsAtGoal(goalX, goalY))
            {
                MessageBox.Show("🎉 Player 1 reached the goal!", "Victory");
                this.Close();
            }
            else if (player2.IsAtGoal(goalX, goalY))
            {
                MessageBox.Show("🎉 Player 2 reached the goal!", "Victory");
                this.Close();
            }
        }
    }
}
