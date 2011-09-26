using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TaskRemainder.GUI
{
    public partial class taskBoard : Form
    {
        #region Variables
        bool mouseEnter = false;
        #endregion

        public taskBoard()
        {
            InitializeComponent();
        }

        // mouse enter visible part of window
        private void taskBoard_MouseEnter(object sender, EventArgs e)
        {
            if ((splitContainer.Panel2Collapsed) && (mouseEnter == false))
            {
                mouseEnter = true;
                splitContainer.Panel2Collapsed = false;
                splitContainer.Refresh();
            }
        }

        // mouse leave visible part of window
        private void taskBoard_MouseLeave(object sender, EventArgs e)
        {
            if ((!splitContainer.Panel2Collapsed) && mouseEnter)
            {
                mouseEnter = false;
                splitContainer.Panel2Collapsed = true;
                splitContainer.Refresh();
            }
        }

        private void richTextBox_MouseEnter(object sender, EventArgs e)
        {
            int x = MousePosition.X;
            int y = MousePosition.Y;
            int wX = this.Location.X;
            int wY = this.Location.Y;
            int boundX = this.Bounds.Width;
            int boundY = this.Height;

            if (!(((x >= wX) && (x <= wX + boundX)) && ((y <= wY) && (y >= wY + boundY))))
            {
                taskBoard_MouseEnter(sender, e);
            }
        }

        private void richTextBox_MouseLeave(object sender, EventArgs e)
        {
            int x = Cursor.Position.X;
            int y = Cursor.Position.Y;
            int wX = this.DesktopLocation.X;
            int wY = this.DesktopLocation.Y;
            int boundX = this.Bounds.Width;
            int boundY = this.Height;

            if (!(((x >= wX) && (x <= wX + boundX)) && ((y >= wY) && (y <= (wY + boundY)))))
            {
                taskBoard_MouseLeave(sender, e);
            }
        }

        // resize window
        private void statusStrip1_Resize(object sender, EventArgs e)
        {
        }

        private void statusStrip1_MouseEnter(object sender, EventArgs e)
        {
            int x = MousePosition.X;
            int y = MousePosition.Y;
            int wX = this.Location.X;
            int wY = this.Location.Y;
            int boundX = this.Bounds.Width;
            int boundY = this.Height;

            if (!(((x >= wX) && (x <= wX + boundX)) && ((y >= wY) && (y <= (wY + boundY)))))
            {
                taskBoard_MouseEnter(sender, e);
            }
        }

        // FIXME when mouse fast leave area event don't catch that mouse leave window
        private void statusStrip1_MouseLeave(object sender, EventArgs e)
        {
            int x = MousePosition.X;
            int y = MousePosition.Y;
            int wX = this.Location.X;
            int wY = this.Location.Y;
            int boundX = this.Bounds.Width;
            int boundY = this.Height;

            if (!(((x >= wX) && (x <= wX + boundX)) && ((y >= wY) && ( y > (wY + boundY)))))
            {
                taskBoard_MouseLeave(sender, e);
            }
        }

        #region Operations on text
        public void addTask(string task, string date)
        {
            if (string.IsNullOrEmpty(date)) return;

            DateTime currentDate = System.DateTime.Now;
            DateTime taskDate = new DateTime();
            taskDate = DateTime.ParseExact(date, "yyyy-MM-dd HH:mm:ss", null);
            int day = taskDate.DayOfYear - currentDate.DayOfYear;
            string sRTF;

            // FIXME colortable is added to many times, colors are bad displayed
            if ((day >= 0) && (day < 2)) // 0 days and 1 day left red
            {
                richTextBox.AppendText(taskDate.ToShortDateString() + ": " + task + "\n");
                sRTF = richTextBox.Rtf;

                int iColorTable = sRTF.IndexOf("\\colortbl");
                if (iColorTable == -1)
                {
                    // creating RTF colortable
                    int loc = sRTF.IndexOf("\\rtf1");
                    int locBrack = sRTF.IndexOf("}}", loc);
        
                    // inserting table befor the end bracket of the header
                    if (locBrack == -1) locBrack = sRTF.IndexOf('}', loc) - 1;
                    // inserting color table
                    sRTF = sRTF.Insert(locBrack+2, "{\\colortbl;\\red255\\green255\\yellow10;\\red0\\green128\\blue0;}"); 
                    richTextBox.Rtf = sRTF;
                }

                sRTF = sRTF.Replace(taskDate.ToShortDateString(), "\\cf1\\b " + (taskDate.DayOfWeek).ToString() + "\\cf0\\b0");
                richTextBox.Rtf = sRTF;
                return;
            }

            if ((day >= 2) && (day <= 5)) // 2-5 days left yellow
            {
                richTextBox.AppendText(taskDate.ToShortDateString() + ": " + task + "\n");
                sRTF = richTextBox.Rtf;

                int iColorTable = sRTF.IndexOf("\\colortbl");
                if (iColorTable == -1)
                {
                    // creating RTF colortable
                    sRTF = richTextBox.Rtf;
                    int loc = sRTF.IndexOf("\\rtf1");
                    int locBrack = sRTF.IndexOf('{', loc);
        
                    // inserting table befor the end bracket of the header
                    if (locBrack == -1) locBrack = sRTF.IndexOf('}', loc) - 1;
                    // inserting color table
                    sRTF = sRTF.Insert(locBrack, "{\\colortbl ;\\red255\\green255\\yellow10;\\red0\\green128\\blue0;red0\\green0\\blue255;} \\margl720\\margr720\\margt720\\margb720");
                    richTextBox.Rtf = sRTF;
                }

                sRTF = richTextBox.Rtf;
                sRTF = sRTF.Replace(taskDate.ToShortDateString(), "\\cf3\\b " + (taskDate.DayOfWeek).ToString() + "\\cf0\\b0");
                richTextBox.Rtf = sRTF;
                return;
            }

            if ((day > 5) && (day < 10)) // green 
            {
                richTextBox.AppendText(taskDate.ToShortDateString() + ": " + task + "\n");
                sRTF = richTextBox.Rtf;

                int iColorTable = sRTF.IndexOf("\\colortbl");
                if (iColorTable == -1)
                {
                    // creating RTF colortable
                    sRTF = richTextBox.Rtf;
                    int loc = sRTF.IndexOf("\\rtf1");
                    int locBrack = sRTF.IndexOf('{', loc);
        
                    // inserting table befor the end bracket of the header
                    if (locBrack == -1) locBrack = sRTF.IndexOf('}', loc) - 1;
                    // inserting color table
                    sRTF = sRTF.Insert(locBrack, "{\\colortbl ;\\red255\\green255\\yellow10;\\red0\\green128\\blue0;red0\\green0\\blue255;} \\margl720\\margr720\\margt720\\margb720");
                    richTextBox.Rtf = sRTF;
                }

                sRTF = richTextBox.Rtf;
                sRTF = sRTF.Replace(taskDate.ToShortDateString(), "\\cf2\\b " + (taskDate.DayOfWeek).ToString() + "\\cf0\\b0");
                richTextBox.Rtf = sRTF;
            }

        }

        /// <summary>
        /// Removing all text from board
        /// </summary>
        public void clearBoard()
        {
            richTextBox.Clear();
        }
        #endregion
    }
}
