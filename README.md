# KUIS 2 PAA 

| Anggota | NRP |
| --- | -- |
| Imelda Alexis Jovita | 5025231032 |
| Jeri Firdaus bin Dodot | 5025231051 |
| Karla Pentol Widjanarko | 5025231123 |

## Penjelasan Kode 
### Part 1: Program.cs
```
static class Program
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread] // Required for Windows Forms
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new Form1()); // Start Form1
    }
}
```
Pada kelas Program.cs, terdapat main Program Runner untuk menjalankan Main Form.
Pada kode diatas, 
`Application.EnableVisualStyles();` digunakan untuk membuat Form terlihat modern.
`Application.SetCompatibleTextRenderingDefault(false);` supaya menggunakan new text rendering system. 
`Application.Run(new Form1());` supaya aplikasi menjalankan main form.

### Part 2: Player.Cs
```
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
```

Pada kelas Player.Cs
