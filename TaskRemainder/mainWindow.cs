using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace TaskRemainder
{
    //TODO stworzenie metody do:
    // - tworzenia drzewa z zadań wg daty zakończenia
    // - listy todo
    public partial class mainWindow : Form
    {
        public mainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Working with SQL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainWindow_Load(object sender, EventArgs e)
        {
        }

        private void initDataBase()
        {
            // Initialization DB 
            // creating tables
            CDBOperation.initDateBase();
        }

        /// <summary>
        /// Closing whole application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Open add task dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI.AddTask addtask = new GUI.AddTask();
            addtask.ShowDialog(this);
            addtask.Dispose();
        }

    }
}
