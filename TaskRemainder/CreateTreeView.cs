using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Drawing;

namespace TaskRemainder
{
    public class CreateTreeView
    {
        #region Variables
        TreeView treeView;
        DBRespons dbrespons;
        DataTable folder;
        #endregion

        #region Constructor
        public CreateTreeView(ref TreeView treeView)
        {
            this.treeView = treeView;
            ImageList imageList = new ImageList();
            imageList.Images.Add(global::TaskRemainder.Properties.Resources.folder);
            imageList.Images.Add(global::TaskRemainder.Properties.Resources.task);
            treeView.ImageList = imageList;
        }
        #endregion

        #region Initialization treeView and update treeView
        /// <summary>
        /// Method for initialization folders tree
        /// </summary>
        public void initTreeView()
        {
            // making node
            // find all parent nodes idSubFolder = null
            createNewNode("0", treeView.Nodes);
            searchForTasks("0", treeView.Nodes);
        }

        /// <summary>
        /// Updating treeView
        /// </summary>
        public void updateTreeView()
        {
            // FIXME in feauture make state collaps or extend tree view constant
            treeView.BeginUpdate();
            treeView.Nodes.Clear();
            
            // update treeView
            createNewNode("0", treeView.Nodes);
            searchForTasks("0", treeView.Nodes);

            treeView.EndUpdate();
        }
        #endregion

        #region Creating new node based on parent
        /// <summary>
        /// Searching for folders and tasks
        /// </summary>
        /// <param name="parent"></param>
        public void createNewNode(string parent, TreeNodeCollection node)
        {
            dbrespons = DBOperation.getFolderByParent(parent, ref folder);
            if (dbrespons.result != DBStatus.SelectSuccessful)
            {
                MessageBox.Show("Error durning creating folders structure", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (DataRow item in folder.Rows)
            {
                TreeNode newNode = new TreeNode();
                newNode.ImageIndex = 0; // image
                newNode.SelectedImageIndex = 0;
                newNode.Tag = item["idFolder"].ToString();
                newNode.Name = "F";
                newNode.Text = item["folderName"].ToString();
                node.Add(newNode); // adding new node
                createNewNode(item["idFolder"].ToString(), newNode.Nodes);
                searchForTasks(item["idFolder"].ToString(), newNode.Nodes);
            }

        }

        /// <summary>
        /// Making structure of directories
        /// </summary>
        /// <param name="parent">ID parent</param>
        /// <param name="node">node</param>
        public void createFolderTree(string parent, TreeNodeCollection node)
        {
            dbrespons = DBOperation.getFolderByParent(parent, ref folder);
            if (dbrespons.result != DBStatus.SelectSuccessful)
            {
                MessageBox.Show("Error durning creating folders structure", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (DataRow item in folder.Rows)
            {
                TreeNode newNode = new TreeNode();
                newNode.ImageIndex = 0; // image
                newNode.SelectedImageIndex = 0;
                newNode.Tag = item["idFolder"].ToString();
                newNode.Name = "F";
                newNode.Text = item["folderName"].ToString();
                node.Add(newNode); // adding new node
                createNewNode(item["idFolder"].ToString(), newNode.Nodes);
            }
        }
        #endregion

        #region Populate tasks for parent
        private void searchForTasks(string idFolder, TreeNodeCollection node)
        {
            DataTable task = new DataTable();
            dbrespons = DBOperation.getTasksFromFolder(idFolder, ref task);
            if (dbrespons.result != DBStatus.SelectSuccessful)
            {
                MessageBox.Show("Error durning creating folders structure", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (DataRow item in task.Rows)
            {
                TreeNode nnode = new TreeNode();
                nnode.Name = "T";
                nnode.ImageIndex = 1;
                nnode.SelectedImageIndex = 1;
                nnode.Tag = item["idTasks"].ToString();
                nnode.Text = item["taskDesc"].ToString();
                node.Add(nnode);
            }
        }
        #endregion

        #region Creating new folder
        /// <summary>
        /// Creating new folder, if nothing are selected create folder in main node else create folder in 
        /// selected node
        /// </summary>
        /// <param name="folderName">Folder name</param>
        /// <param name="idFolder">ID of current folder</param>
        public void createNewFolder(string folderName, string idFolder)
        {
            TreeNode sel_node = this.treeView.SelectedNode;
            if ((sel_node != null) && (sel_node.Parent != null))
            {
                sel_node = sel_node.Parent;
                TreeNode nnode = new TreeNode();
                nnode.Name = "F";
                nnode.Tag = idFolder;
                nnode.Text = folderName;
                sel_node.Nodes.Add(nnode);
            }
            else
            {
                TreeNode nnode = new TreeNode();
                nnode.Name = "F";
                nnode.Tag = idFolder;
                nnode.Text = folderName;
                treeView.Nodes.Add(nnode);
            }
        }
        #endregion

        #region Removing folder and all it contains
        /// <summary>
        /// Removing folder from treeView
        /// </summary>
        /// <param name="node">Node that contains folder</param>
        public void removeFolderTask(TreeNode node)
        {
            if (node != null)
            {
                if (node.Nodes.Count != 0)
                {
                    DialogResult result = MessageBox.Show("Removing folder will remove whole contins of folder", "Question",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        removeFolderTaskNode(node);
                    }
                }
                else if (node.Nodes.Count == 0)
                {
                    dbrespons = DBOperation.removingFolder(node.Tag.ToString());
                    if (dbrespons.result != DBStatus.DeleteSuccessful)
                    {
                        MessageBox.Show("Problem removing folder!", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Removing folders contains task or other folders
        /// </summary>
        /// <param name="node">Node to remove</param>
        private void removeFolderTaskNode(TreeNode node)
        {
            if (node == null) return; // finish

            // removing node
            if (node.Nodes.Count == 0)
            {
                dbrespons = DBOperation.removingFolder(node.Tag.ToString());
                if (dbrespons.result != DBStatus.DeleteSuccessful)
                {
                    MessageBox.Show("Problem removing folder!", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                return; // finish
            }

            // removing node nodes
            foreach (TreeNode item in node.Nodes)
            {
                // folder can have subfolders
                if (item.Name.ToString().Equals("F"))
                {
                    if (node.Nodes.Count != 0) // removing deeper levels
                        removeFolderTaskNode(node.Nodes[0]);

                    dbrespons = DBOperation.removingFolder(node.Tag.ToString());
                    if (dbrespons.result != DBStatus.DeleteSuccessful)
                    {
                        MessageBox.Show("Problem removing folder!", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                }
                // tasks can't have subtasks
                else if (item.Name.ToString().Equals("T"))
                {
                    removeTask(node);
                }
            }
        }
        #endregion
    
        #region Moving nodes
        /// <summary>
        /// Moving node or folder one position up
        /// </summary>
        /// <param name="node">Node to move</param>
        public void nodeUp(TreeNode node)
        {
            TreeNode parent = null;
            if ((node != null) && (node.Parent != null) && (node.Parent.Parent != null))
            {
                parent = node.Parent.Parent;
            }

            // Folder1 
            //      |---> Folder2
            //      |---> Folder3
            // ------ after operation --------------
            // Folder3
            // Folder1
            //      |---> Folder2
            if (parent != null) // folder on level up
            {
                TreeNode copy = (TreeNode)node.Clone();
                parent.Nodes.Add(copy);
                treeView.SelectedNode = copy;
                node.Remove();

                // information about parent
                string idParent = parent.Tag.ToString(); // parent id
                string idFolder = copy.Tag.ToString(); // idFolder or idTask

                if (node.Name.Equals("F")) // operation on folders
                {
                    dbrespons = DBOperation.updateFolderPosition(idParent, copy.Text, idFolder);
                    if (dbrespons.result != DBStatus.UpdateSuccessful)
                    {
                        MessageBox.Show("Error durning updating folder position!", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else if (node.Name.Equals("T"))
                {
                    dbrespons = DBOperation.updateTaskPosition(idFolder, idParent);
                    if(dbrespons.result != DBStatus.UpdateSuccessful)
                    {
                        MessageBox.Show("Error durning updating task position!", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            else if (parent == null) // folder is in root node
            {
                TreeNode copy = (TreeNode)node.Clone();
                treeView.Nodes.Add(copy);
                treeView.SelectedNode = copy;
                node.Remove();

                // information about parent
                string idParent = "0";
                string idFolder = copy.Tag.ToString();

                if (copy.Name.Equals("F")) // moving folder
                {
                    dbrespons = DBOperation.updateFolderPosition(idParent, copy.Text, idFolder);
                    if (dbrespons.result != DBStatus.UpdateSuccessful)
                    {
                        MessageBox.Show("Error durning updating folder position!", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                if (copy.Name.Equals("T")) // moving task
                {
                    dbrespons = DBOperation.updateTaskPosition(idFolder, idParent);
                    if(dbrespons.result != DBStatus.UpdateSuccessful)
                    {
                        MessageBox.Show("Error durning updating task position!", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Moving node up
        /// </summary>
        /// <param name="node"></param>
        public void nodeMoveUp(TreeNode node)
        {
            moveNode(node, -1);
        }

        /// <summary>
        /// Moving node by adding or substraction number
        /// </summary>
        /// <param name="node"></param>
        /// <param name="count"></param>
        private void moveNode(TreeNode node, int count)
        {
            if (node.Parent != null)
            {
                int index = node.Index + count;
                TreeNode clone = (TreeNode)node.Clone();
                node.Parent.Nodes.Insert(index, clone);
                treeView.SelectedNode = clone;
                node.Remove();
            }
            else
            {
                TreeNode clone = (TreeNode)node.Clone();
                int index = node.Index + count;
                treeView.Nodes.Insert(index , clone);
                treeView.SelectedNode = clone;
                node.Remove();
            }
        }

        /// <summary>
        /// Moving node down
        /// </summary>
        /// <param name="node"></param>
        public void nodeMoveDown(TreeNode node)
        {
            moveNode(node, 2);
        }

        // Moving node up and down throught treeView structure
        // Folder1
        //     |--> Task1
        //     |--> Task2
        // after making node down
        // Folder1
        //     |--> Task1
        // Task2
        public void nodeDown(TreeNode node)
        {
            TreeNode prev = node.PrevNode;
            if ((prev != null) && (node.Name.Equals("F"))) // folder
            {
                TreeNode clone = (TreeNode)node.Clone();
                prev.Nodes.Add(clone);
                treeView.SelectedNode = clone;
                node.Remove();

                // information about parent
                string idParent = clone.Parent.Tag.ToString();
                string idFolder = clone.Tag.ToString();

                dbrespons = DBOperation.updateFolderPosition(idParent, clone.Text, idFolder);
                if (dbrespons.result != DBStatus.UpdateSuccessful)
                {
                    MessageBox.Show("Error durning updating folder position!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if ((prev != null) && (node.Name.Equals("T"))) // operations for task
            {
                TreeNode clone = (TreeNode)node.Clone();
                prev.Nodes.Add(clone);
                treeView.SelectedNode = clone;
                node.Remove();

                // information about parent
                string idParent = clone.Parent.Tag.ToString();
                string idFolder = clone.Tag.ToString();

                // saving data into DB
                dbrespons = DBOperation.updateTaskPosition(idFolder, idParent);
                if(dbrespons.result != DBStatus.UpdateSuccessful)
                {
                    MessageBox.Show("Error durning updating task position!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
        #endregion

        #region Remove task
        /// <summary>
        /// Removing task based on node
        /// </summary>
        /// <param name="node"></param>
        public void removeTask(TreeNode node)
        {
            string idTask = node.Tag.ToString();
            dbrespons = DBOperation.removingTask(idTask);
            if (dbrespons.result != DBStatus.DeleteSuccessful)
            {
                MessageBox.Show("Error: deleteing task!", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
        }
        #endregion
    }
}