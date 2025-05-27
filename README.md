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

