using System.Windows.Forms;

/// <summary>
/// IGME-106 - Game Development and Algorithmic Problem Solving
/// Practice Exercise 3 - Windows UI (The Hard Way)
/// Class Description   : This is the driver class for Practice Exercise 3
/// Author              : Benjamin Kleynhans
/// Modified By         : Benjamin Kleynhans
/// Date                : January 25, 2018
/// Filename            : Program.cs
/// </summary>

namespace WindowsUiTheHardWay
{
    /// <summary>
    /// This class launches the MyForm class
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.Run( new MyForm() );
        }
    }
}
