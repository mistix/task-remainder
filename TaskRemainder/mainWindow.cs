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
            createTreeView.updateTreeView();
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
            if ((e.ColumnIndex == 4) && (e.RowIndex != -1))
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

        /// <summary>
        /// Creating new node in main node
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolSBCreateFolder_Click(object sender, EventArgs e)
        {
            TreeNode selected_node = treeView_taskList.SelectedNode;
            string idParent = "0";
            if ((selected_node != null) && (selected_node.Parent != null))
            {
                idParent = selected_node.Tag.ToString();
            }

            dbrespons = DBOperation.createNewFolder("New folder", idParent);
            if (dbrespons.result != DBStatus.InsertSuccessful)
            {
                MessageBox.Show("Error when creating new folder!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int row = 0;
            dbrespons = DBOperation.getLastInsertedRowID(ref row);
            if (dbrespons.result != DBStatus.SelectSuccessful)
            {
                MessageBox.Show("Error when getting last row id", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            createTreeView.createNewFolder("New folder", row.ToString());
        }

        private void treeView_taskList_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {

        }

        #region Operations on nodes
        /// <summary>
        /// Moving task/folder on level up in nodes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolSBPrev_Click(object sender, EventArgs e)
        {
            TreeNode sel_node = treeView_taskList.SelectedNode;
            createTreeView.nodeUp(sel_node);
        }

        /// <summary>
        /// Moving task or folder abow next folder/task
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolSBUp_Click(object sender, EventArgs e)
        {
            TreeNode sel_node = treeView_taskList.SelectedNode;
            createTreeView.nodeMoveUp(sel_node);
        }

        /// <summary>
        /// Moving on level down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolSBNext_Click(object sender, EventArgs e)
        {
            TreeNode sel_node = treeView_taskList.SelectedNode;
            createTreeView.nodeDown(sel_node);
        }

        /// <summary>
        /// Moving task or folder under task/folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolSBDown_Click(object sender, EventArgs e)
        {
            TreeNode sel_node = treeView_taskList.SelectedNode;
            createTreeView.nodeMoveDown(sel_node);
        }
        #endregion

        /// <summary>
        /// Removing task or folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolSBRemove_Click(object sender, EventArgs e)
        {
            TreeNode selected = treeView_taskList.SelectedNode;
            if (selected != null)
            {
                if (selected.Name.ToString().Equals("F"))
                {
                    createTreeView.removeFolderTask(selected); // removing selected folder
                }
                else if (selected.Name.ToString().Equals("T"))
                {
                    createTreeView.removeTask(selected); // removing selected task
                }
                // updating data after delete
                createTreeView.updateTreeView();
                updateTaskList();
            }
        }

        private void treeView_taskList_AfterSelect(object sender, TreeViewEventArgs e)
        {
        }

        /// <summary>
        /// Updating Folder name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView_taskList_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Node.Name.ToString().Equals("F"))
            {
                string idFolder = e.Node.Tag.ToString();
                string folderName = e.Label;
                if (e.Label == null) return; // return if nothing was been changed

                dbrespons = DBOperation.updateFolderName(idFolder, folderName);
                if (dbrespons.result != DBStatus.UpdateSuccessful)
                {
                    MessageBox.Show("Error when changing folder name", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
            }
        }

        #region Edit tree node label
        private void treeView_taskList_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Node != null)
            {
                if (e.Node.Name.ToString().Equals("F"))
                {
                    e.CancelEdit = false;
                }
                else
                {
                    e.CancelEdit = true;
                }
            }

        }

        /// <summary>
        /// Turn on edit mode after double click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView_taskList_DoubleClick(object sender, EventArgs e)
        {
            TreeNode node = treeView_taskList.SelectedNode;
            if (node != null)
            {
                treeView_taskList.LabelEdit = true;
                if (!node.IsEditing)
                {
                    node.BeginEdit();
                }
            }
        }
        #endregion

        /// <summary>
        /// Describe when user want see finished tasks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showFinishedTasksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (showFinishedTasksToolStripMenuItem.Checked)
            {
                showFinishedTasksToolStripMenuItem.Checked = false;
            }
            else
            {
                showFinishedTasksToolStripMenuItem.Checked = true;
            }
        }

    }
}
