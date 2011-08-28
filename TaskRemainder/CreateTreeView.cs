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
        DataTable dbtree;
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

        /// <summary>
        /// Method for initialization folders tree
        /// </summary>
        public void initTreeView()
        {
            // find all parent nodes idSubFolder = null
            dbrespons = DBOperation.getFolderByParent("0", ref folder);
            if (dbrespons.result != DBStatus.SelectSuccessful)
            {
                MessageBox.Show("Error durning creating folders structure", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (DataRow item in folder.Rows)
            {
                // adding new folder
                this.treeView.Nodes.Add(item["folderName"].ToString());
                createNewNode(item["idFolder"].ToString(), treeView.Nodes[0]);
                searchForTasks(item["idFolder"].ToString(), treeView.Nodes[0]);
            }
        }

        #region Creating new node based on parent
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        private void createNewNode(string parent, TreeNode node)
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
                TreeNode newNode = new TreeNode(item["folderName"].ToString(),0,0);
                newNode.ImageIndex = 0; // image
                node.Nodes.Add(newNode); // adding new node
                createNewNode(item["idFolder"].ToString(), newNode);
                searchForTasks(item["idFolder"].ToString(), newNode);
            }
        }
        #endregion

        #region Populate tasks for parent
        private void searchForTasks(string idFolder, TreeNode node)
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
                node.Nodes.Add(item["idTasks"].ToString(), item["taskDesc"].ToString(),1, 1);
            }
        }
        #endregion

    }
}