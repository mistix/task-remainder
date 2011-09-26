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
        DataGridViewCellStyle strikedOut;
        DataGridViewCellStyle regular;
        ContextMenu cont_menu;
        MenuItem showInformation;
        TreeNode oldSelNode;
        int oldNodeIndex = -1;
        int currentNodeIndex;
        TreeNode oldNode = null;
        GUI.taskBoard taskBoard = new GUI.taskBoard();
        #endregion

        public mainWindow()
        {
            InitializeComponent();
            createTreeView = new CreateTreeView(ref treeView_taskList);

            // style for strikeout cell
            strikedOut = new DataGridViewCellStyle(taskDesc.DefaultCellStyle);
            strikedOut.Font = new Font(strikedOut.Font, FontStyle.Strikeout);

            // style for regular cell
            regular = new DataGridViewCellStyle(taskDesc.DefaultCellStyle);
            regular.Font = new Font(regular.Font, FontStyle.Regular);
            cont_menu = new ContextMenu();
        }

        /// <summary>
        /// Working with SQL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainWindow_Load(object sender, EventArgs e)
        {
            // on start hide panel2
            splitContainer.Panel2Collapsed = true;
            splitContainer.BorderStyle = BorderStyle.FixedSingle;

            // menu for treeView
            showInformation = new MenuItem();
            showInformation.Text = "Show task information";
            showInformation.Click += new EventHandler(showInformation_Click);
            cont_menu.MenuItems.Add(showInformation);

            // Initialization DB 
            dbrespons = DBOperation.initDateBase();
            if (dbrespons.resultOperation() != DBStatus.InitDBSuccessful)
            {
                MessageBox.Show("Error durning initialization DB" + dbrespons.errorMessage(), "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //seting up position of task board
            int x = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            int y = 10;
            x -= (10 + taskBoard.Width);

            taskBoard.StartPosition = FormStartPosition.Manual;
            taskBoard.Location = new Point(x, y);
            taskBoard.Visible = true;

            // creating new tree folder list
            updateTaskList();
            createTreeView.initTreeView();
            updateTaskBoard();
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
            updateTaskBoard();
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

            // FIXME dosn't work don't know why
            // task finished
            foreach (DataGridViewRow row in todoGridView.Rows)
            {
                if ((bool)row.Cells["finished"].Value)
                {
                    DataGridViewCell cell = row.Cells["taskDesc"];
                    cell.Style = strikedOut;
                }
            }
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

                // checked if is checked
                if (!finish)
                {
                    cell.Style = strikedOut;
                    todoGridView["finished", i].Value = "True";

                    // saving data to DB
                    dbrespons = DBOperation.taskFinished(todoGridView["idTasks", i].Value.ToString(), true);
                    if (dbrespons.result != DBStatus.UpdateSuccessful)
                    {
                        MessageBox.Show("Error durning update task status", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                if(finish)
                {
                    cell.Style = regular;
                    todoGridView["finished", i].Value = "False";

                    // saving data to DB
                    dbrespons = DBOperation.taskFinished(todoGridView["idTasks", i].Value.ToString(), true);
                    if (dbrespons.result != DBStatus.UpdateSuccessful)
                    {
                        MessageBox.Show("Error durning update task status", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
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

        #region Updating labels on task and folder
        /// <summary>
        /// Updating Folder name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView_taskList_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            // updating folder name
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

            // updating task message
            if (e.Node.Name.ToString().Equals("T"))
            {
                string idTask = e.Node.Tag.ToString();
                if (e.Label == null) return; // preventing ESC when editing node
                string taskDesc = e.Label.ToString();
                dbrespons = DBOperation.updateTaskDescriptionDB(idTask, taskDesc);
                if (dbrespons.result != DBStatus.UpdateSuccessful)
                {
                    MessageBox.Show("Error durning updating task desc", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                updateTaskList();
                updateTaskBoard();
            }
        }
        #endregion

        #region Edit tree node label
        private void treeView_taskList_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Node != null)
            {
                /*if (e.Node.Name.ToString().Equals("F"))
                {
                    e.CancelEdit = false;
                }
                else
                {
                    e.CancelEdit = true;
                } */
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

        private void mainWindow_VisibleChanged(object sender, EventArgs e)
        {
            updateTaskList();
        }


        /// <summary>
        /// Tool tip for tasks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView_taskList_MouseMove(object sender, MouseEventArgs e)
        {
            TreeNode node = treeView_taskList.GetNodeAt(treeView_taskList.PointToClient(Cursor.Position));
            if (node != null)
            {
                currentNodeIndex = node.Index;
                if ((node.Name != "F") && (currentNodeIndex != oldNodeIndex))
                {
                }
            }
        }

        /// <summary>
        /// Inserting new task
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            #region Insert new task
            if ((e.KeyCode == Keys.Insert) && (tabControl1.SelectedIndex == 0))
            {
                // creating new task
                decimal idTask = 0;
                string idFolder = "0"; // idFolder 0 means root node
                dbrespons = DBOperation.insertNewTask("New task", null, null, false, ref idTask);
                if (dbrespons.result != DBStatus.InsertSuccessful)
                {
                    MessageBox.Show("Error durning inserting new task", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // new task into edit mode
                TreeNode newNode = new TreeNode();
                newNode.Name = "T";
                newNode.Tag = idTask.ToString();
                newNode.Text = "New task";
                newNode.ImageIndex = 1;
                newNode.SelectedImageIndex = 1;

                // if node is selected insert new task into folder
                TreeNode selNode = treeView_taskList.SelectedNode;
                if ((selNode != null) && (selNode.Name.Equals("F")))
                {
                    idFolder = selNode.Tag.ToString();
                    selNode.Nodes.Add(newNode);
                }
                else if ((selNode != null) && (selNode.Name.Equals("T")) && (selNode.Parent != null))
                {
                    idFolder = selNode.Parent.Tag.ToString();
                    selNode.Parent.Nodes.Add(newNode);
                }
                else
                {
                    treeView_taskList.Nodes.Add(newNode);
                }

                // inserting task into container
                dbrespons = DBOperation.insertContainerDB(idTask, null, null, idFolder);
                if (dbrespons.result != DBStatus.InsertSuccessful)
                {
                    MessageBox.Show("Error durning inserting new task", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // new node is in edit mode
                treeView_taskList.BeginUpdate();
                // selected node
                treeView_taskList.SelectedNode = newNode;
                treeView_taskList.LabelEdit = true;
                newNode.BeginEdit();
                treeView_taskList.EndUpdate();
            }
            #endregion
        }

        private void treeView_taskList_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point p = new Point(e.X, e.Y);
                TreeNode node = treeView_taskList.GetNodeAt(p);
                if (node != null)
                {
                    oldSelNode = treeView_taskList.SelectedNode;
                    treeView_taskList.SelectedNode = node;
                    cont_menu.Show(treeView_taskList, p);
                    treeView_taskList.SelectedNode = oldSelNode;
                    oldSelNode = null;
                }
            }
        }

        private void showInformation_Click(object sender, EventArgs e)
        {
            if (splitContainer.Panel2Collapsed)
            {
                splitContainer.Panel2Collapsed = false;
                showInformation.Text = "Hide task information";

                TreeNode node = treeView_taskList.SelectedNode;
                if(node.Name != "F")
                {
                    string idTask = node.Tag.ToString();
                    DataTable data = new DataTable(); // contains task information

                    dbrespons = DBOperation.getTaskDate(idTask, ref data);
                    if (dbrespons.result != DBStatus.SelectSuccessful)
                    {
                        MessageBox.Show("Unable read task informaion", "Information",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // setingup date
                    if (!string.IsNullOrEmpty(data.Rows[0][0].ToString()))
                    {
                        dateTimePickerEnd.Enabled = true;
                        DateTime end = new DateTime();
                        end = DateTime.ParseExact(data.Rows[0][0].ToString(), "yyyy-MM-dd HH:mm:ss", null);
                        dateTimePickerEnd.Value = end;
                    }
                    else
                    {
                        dateTimePickerEnd.Enabled = false;
                    }

                    // start date
                    if (!string.IsNullOrEmpty(data.Rows[0][1].ToString()))
                    {
                        dateTimePickerStart.Enabled = true;
                        DateTime start = new DateTime();
                        start = DateTime.ParseExact(data.Rows[0][1].ToString(), "yyyy-MM-dd HH:mm:ss", null);
                        dateTimePickerEnd.Value = start;
                    }
                    else
                    {
                        dateTimePickerStart.Enabled = false;
                    }
                }
            }
            else
            {
                showInformation.Text = "Show task information";
                splitContainer.Panel2Collapsed = true;
            }
        }

        // checking up if node is changed
        private void treeView_taskList_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (oldNode == null)
            {
                oldNode = treeView_taskList.SelectedNode;
            }

            // update informations about task
            if (oldNode != treeView_taskList.SelectedNode)
            {
                if (splitContainer.Panel2Collapsed == false) // when panel is visible
                {
                    TreeNode node = e.Node; 
                    if (node.Name != "F")
                    {
                        string idTask = node.Tag.ToString();
                        DataTable data = new DataTable(); // contains task information

                        dbrespons = DBOperation.getTaskDate(idTask, ref data);
                        if (dbrespons.result != DBStatus.SelectSuccessful)
                        {
                            MessageBox.Show("Unable read task informaion", "Information",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // setingup date
                        if (!string.IsNullOrEmpty(data.Rows[1][0].ToString()))
                        {
                            dateTimePickerEnd.Enabled = true;
                            DateTime end = new DateTime();
                            end = DateTime.ParseExact(data.Rows[1][0].ToString(), "yyyy-MM-dd HH:mm:ss", null);
                            dateTimePickerEnd.Value = end;
                        }
                        else
                        {
                            dateTimePickerEnd.Enabled = false;
                        }

                        // start date
                        if (!string.IsNullOrEmpty(data.Rows[1][1].ToString()))
                        {
                            dateTimePickerStart.Enabled = true;
                            DateTime start = new DateTime();
                            start = DateTime.ParseExact(data.Rows[1][1].ToString(), "yyyy-MM-dd HH:mm:ss", null);
                            dateTimePickerEnd.Value = start;
                        }
                        else
                        {
                            dateTimePickerStart.Enabled = false;
                        }
                    }
                }
            }
        }

        #region Timer action
        // checking every 5 min if any task is going to end or start
        private void timer_Tick(object sender, EventArgs e)
        {
            updateTaskBoard();
        }

        /// <summary>
        /// Updating task board
        /// </summary>
        private void updateTaskBoard()
        {
            DataTable tasks = (DataTable)todoGridView.DataSource;
            DataRow[] rows = tasks.Select("","taskEnd ASC"); // order by taskEnd DESC
            taskBoard.clearBoard(); // clear board

            foreach (DataRow row in rows) // adding new tasks to board
            {
                taskBoard.addTask(row[1].ToString(), row[2].ToString());
            }
        }
        #endregion

        // seting up visibility of task board
        private void showTaskBoardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (showTaskBoardToolStripMenuItem.Checked)
            {
                showTaskBoardToolStripMenuItem.Checked = false;
                taskBoard.Visible = false;
            }
            else
            {
                showTaskBoardToolStripMenuItem.Checked = true;
                taskBoard.Visible = true;
            }
        }
    }
}
