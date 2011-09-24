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

            // creating RTF colortable
            string rtf = richTextBox.Rtf;
        }

        // mouse enter visible part of window
        private void taskBoard_MouseEnter(object sender, EventArgs e)
        {
            richTextBox_MouseEnter(sender, e);
        }

        // mouse leave visible part of window
        private void taskBoard_MouseLeave(object sender, EventArgs e)
        {
            richTextBox_MouseLeave(sender, e);
        }

        private void richTextBox_MouseEnter(object sender, EventArgs e)
        {
            if (splitContainer.Panel2Collapsed)
            {
                splitContainer.Panel2Collapsed = false;
                splitContainer.Refresh();
            }
        }

        private void richTextBox_MouseLeave(object sender, EventArgs e)
        {
            if (!splitContainer.Panel2Collapsed)
            {
                splitContainer.Panel2Collapsed = true;
                splitContainer.Refresh();
            }
        }

        // resize window
        private void statusStrip1_Resize(object sender, EventArgs e)
        {
        }

        private void statusStrip1_MouseEnter(object sender, EventArgs e)
        {
            //richTextBox_MouseEnter(sender, e);
        }

        private void statusStrip1_MouseLeave(object sender, EventArgs e)
        {
           // richTextBox_MouseLeave(sender, e);
        }

        #region Operations on text
        public void addTask(string task, string date)
        {
            if (string.IsNullOrEmpty(date)) return;

            DateTime currentDate = System.DateTime.Now;
            DateTime taskDate = new DateTime();
            taskDate = DateTime.ParseExact(date, "yyyy-MM-dd HH:mm:ss", null);

            //TODO add switch for today, tomorow, 3 days left and 7 days left
            // colors for today is red, tomorrow to 3 days yellow, 7 days green

            // append text
            richTextBox.AppendText(taskDate.ToShortDateString() + ": " + task + "\n");
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
