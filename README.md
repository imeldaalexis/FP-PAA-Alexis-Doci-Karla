# KUIS 2 PAA 

| Anggota | NRP |
| --- | -- |
| Imelda Alexis Jovita | 5025231032 |
| Jasmine Firdhousy M. | 5025231051 |
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
#### Potongan Kode Besar
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
#### Penjelasan Potongan dari Potongan Kode Besar
Penjelasan kode Player.cs akan dibuat dari potongan-potongan kode di atas
```
        public int X { get; private set; }
        public int Y { get; private set; }
        public char Symbol { get; }
```
Pada bagian ini, variabel dideklarasikan dengan konsep enkapsulasi, dimana read untuk variabel X dan Y dibuat publik, sementara writenya dibuat private. Symbol hanya diperbolehkan untuk di read saja.

```
public Player(int startX, int startY, char symbol)
        {
            X = startX;
            Y = startY;
            Symbol = symbol;
        }
```
Bagian ini merupakan konstruktor, dimana objek Player akan dibangun, pengguna harus menentukan X, Y serta Symbol untuk membuat objek player ini. 


```
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
```
Bagian ini merupakan salah satu method yang bisa digunakan oleh class yang menginherit Player. 
Parameter yang digunakan adalah jumlah stride dari player (`dx` dan `dy`) serta labirin dalam bentuk array 2d dalam wujud character `char[,] maze`.
Posisi baru akan di assign di variabel `newX` dan `newY` dengan cara menjumlahkan posisi player lama dengan stridenya.

Jika posisi terbaru tidak menyalahi aturan batas array maze, dan posisi baru yang akan ditempati oleh `NewX` dan `NewY` adalah kotak kosong atau kotak final atau tempat lawan jenis player, maka posisi akan di update dan mengembalikan true untuk di validate di Form. 

Selain itu return false

```
    public bool IsAtGoal(int goalX, int goalY)
    {
        return X == goalX && Y == goalY;
    }
```
Bagian ini merupakan salah satu method untuk mengecek posisi player saat ini dengan koordinat gol. Return hanya akan mengembalikan true jika dan hanya jika kedua koordinat (X, Y) terletak di (golX, golY)

```
     public bool IsHuntedDown(Player other)
     {
         return this.X == other.X && this.Y == other.Y;
     }
```
Bagian ini merupakan salah satu method untuk mengecek posisi player saat ini dengan posisi player yang lain. Return hanya akan mengembalikan true jika dan hanya jika kedua koordinat (X, Y) terletak di koordinat lawan (other.X, other.Y)
