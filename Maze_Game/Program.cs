using Microsoft.SqlServer.Server;
using System;
using System.Windows.Forms;

namespace Maze_Game
{
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
}
