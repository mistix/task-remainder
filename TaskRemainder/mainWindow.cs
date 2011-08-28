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
    public partial class mainWindow : Form
    {
        #region Variables
        DBRespons dbrespons;
        DataTable task;
        CreateTreeView createTreeView;
        #endregion
        public mainWindow()
        {
            InitializeComponent();
            createTreeView = new CreateTreeView(ref treeView_taskList);
        }

        /// <summary>
        /// Working with SQL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainWindow_Load(object sender, EventArgs e)
        {
            // Initialization DB 
            dbrespons = DBOperation.initDateBase();
            if (dbrespons.resultOperation() != DBStatus.InitDBSuccessful)
            {
                MessageBox.Show("Error durning initialization DB" + dbrespons.errorMessage(), "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            // creating new tree folder list
            updateTaskList();
            createTreeView.initTreeView();
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
            updateTaskList(); 
        }

        /// <summary>
        /// Method for update task list raised when added,deleted or modify task
        /// </summary>
        private void updateTaskList()
        {
            // Searching of tasks
            dbrespons = DBOperation.getTaskList(ref task);
            if (dbrespons.resultOperation() != DBStatus.SelectSuccessful)
            {
                MessageBox.Show("Error durning searching for tasks " + dbrespons.errorMessage(), "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            todoGridView.DataSource = task;
        }

        /// <summary>
        /// Checking if cell is clicked and strikeout finished task
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void todoGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // if user click on first column 
            if (e.ColumnIndex == 4)
            {
                int i = e.RowIndex;
                DataGridViewCell cell = todoGridView["taskDesc", i];
                bool finish = (bool)todoGridView["finished", i].Value;

                // new style for taskDesc strikeout when finish is selected
                DataGridViewCellStyle strikedOut = new DataGridViewCellStyle(taskDesc.DefaultCellStyle);

                //FIXME repair strikeout task description fast clicking == crash
                if (!finish)
                {
                    // creating new style for cell
                    strikedOut.Font = new Font(strikedOut.Font, FontStyle.Strikeout);
                    cell.Style = strikedOut;
                    todoGridView["finished", i].Value = "True";
                }

                if(finish)
                {
                    strikedOut.Font = new Font(strikedOut.Font, FontStyle.Regular);
                    cell.Style = strikedOut;
                    todoGridView["finished", i].Value = "False";
                }
            }
        }
    }
}
