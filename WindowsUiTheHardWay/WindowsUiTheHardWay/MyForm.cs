using System;

using System.Windows.Forms;
using System.Drawing;

/// <summary>
/// IGME-106 - Game Development and Algorithmic Problem Solving
/// Practice Exercise 3 - Windows UI (The Hard Way)
/// Class Description   : This class creates and populates the Windows UI
///                         form for Practice Exercise 3
/// Author              : Benjamin Kleynhans
/// Modified By         : Benjamin Kleynhans
/// Date                : January 25, 2018
/// Filename            : MyForm.cs
/// </summary>

namespace WindowsUiTheHardWay
{
    /// <summary>
    /// This class creates a form containing a number of buttons.  You specify the
    ///     number of buttons you require per row and column.  If no row or column
    ///     numbers are specified, a default grid of 10 x 10 buttons is created.
    /// </summary>
    class MyForm : Form
    {
        // Width and Height of buttons in pixels
        const int ButtonWidth = 50;
        const int ButtonHeight = 50;

        // Default number of buttons to create if ButtonsPerRow and ButtonsPerColumn
        // are set to 0;
        const int DefaultNumberOfButtons = 10;

        // Set these values to define the number of buttons to create per row and column.  Set
        // a value to 0 to default it to 10
        const int ButtonsPerRow = 0;
        const int ButtonsPerColumn = 0;

        public MyForm()
        {
            this.Size = new Size(1500, 800);                        // Size of the form that will house the buttons
            this.Text = "My custom title bar message";
            this.StartPosition = FormStartPosition.CenterScreen;    // Set the form to be drawn centered on the screen
            
            int startX = 0;                                         // Coordinates for first button in the form
            int startY = 0;

            int buttonCounter = 0;
            
            for (int i = 0; i < BtnsPerColumn(); i++)
            {
                for (int j = 0; j < BtnsPerRow(); j++)
                {
                    Button btn = new Button();
                    btn.Name = "Button_" + (buttonCounter + 1);     // Attach names to buttons
                    btn.Size = new Size(50, 50);
                    btn.BackColor = Color.LightGray;

                    btn.MouseEnter += ChangeButton;                 // Attach Mouse Enter event
                    btn.MouseLeave += ChangeButton;                 // Attach Mouse Exit event
                    btn.Location = new Point(startX, startY);       // Set button location 

                    this.Controls.Add(btn);                         // Add button to form
                    buttonCounter++;

                    startX += (ButtonWidth + 1);                    // Adjust button X position
                }

                startX = 0;
                startY += (ButtonHeight + 1);                       // Adjust button Y position
            }
        }

        /// <summary>
        /// This method changes the characteristics of the button whenever a MouseEnter or MouseLeave
        ///     event is triggered.
        /// </summary>
        /// <param name="sender">Determine what the source of the event is</param>
        /// <param name="e">Determine any arguments that may be passed as part of the event</param>
        private void ChangeButton(object sender, EventArgs e)
        {            
            if (sender is Button)
            {
                Button btn = (Button)sender;

                if (btn.BackColor == Color.LightGray)
                {
                    btn.BackColor = Color.Red;
                    btn.Text = btn.Name.Substring(                      // Extract the number of the button
                        (btn.Name.IndexOf("_") + 1),                        // from its name and set as label
                        (btn.Name.Length - (btn.Name.IndexOf("_") + 1))
                    );
                }                    
                else if (btn.BackColor == Color.Red)
                {
                    btn.BackColor = Color.LightGray;
                    btn.Text = "";                                      // Remove label from button
                }
            }
        }

        /// <summary>
        /// Determine whether a number of rows is specified and returns this number
        ///     or default number if nothing is specified
        /// </summary>
        /// <returns>Number of buttons that should be created per row</returns>
        private int BtnsPerRow()
        {
            int returnValue = 0;

            if (ButtonsPerRow == 0)
                returnValue = DefaultNumberOfButtons;
            else
                returnValue = ButtonsPerRow;

            return returnValue;
        }

        /// <summary>
        /// Determine whether a number of columns is specified and returns this number
        ///     or default number if nothing is specified
        /// </summary>
        /// <returns>Number of buttons that should be created per column</returns>
        private int BtnsPerColumn()
        {
            int returnValue = 0;

            if (ButtonsPerColumn == 0)
                returnValue = DefaultNumberOfButtons;
            else
                returnValue = ButtonsPerColumn;

            return returnValue;
        }
    }
}
