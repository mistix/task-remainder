﻿using System;
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
            treeView.BeginUpdate();
            treeView.Nodes.Clear();
            
            // update treeView
            createNewNode("0", treeView.Nodes);
            searchForTasks("0", treeView.Nodes);

            treeView.EndUpdate();
        }

        #region Creating new node based on parent
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        private void createNewNode(string parent, TreeNodeCollection node)
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

        #region Creating new folder, moving node up, moving node down
        /// <summary>
        /// Creating new folder, if nothing are selected create folder in main node else create folder in 
        /// selected node
        /// </summary>
        /// <param name="folderName">Folder name</param>
        /// <param name="idFolder">ID of current folder</param>
        public void createNewFolder(string folderName, string idFolder)
        {
            TreeNode sel_node = this.treeView.SelectedNode;
            if (sel_node.Parent != null)
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

        public void removeFolderTask(TreeNode node)
        {
            if (node != null)
            {
                if (node.Nodes.Count != 0)
                {
                }
            }
        }
        #endregion
    
        #region Moving nodes
        public void nodeUp(TreeNode node)
        {
            TreeNode parent = node.Parent.Parent;
            if (parent != null)
            {
                TreeNode copy = (TreeNode)node.Clone();
                parent.Nodes.Add(copy);
                treeView.SelectedNode = copy;
                node.Remove();
            }
            else if (parent == null)
            {
                TreeNode copy = (TreeNode)node.Clone();
                treeView.Nodes.Add(copy);
                treeView.SelectedNode = copy;
                node.Remove();
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

        public void nodeDown(TreeNode node)
        {
            TreeNode prev = node.PrevNode;
            if (prev != null)
            {
                TreeNode clone = (TreeNode)node.Clone();
                prev.Nodes.Add(clone);
                treeView.SelectedNode = clone;
                node.Remove();
            }
        }
        #endregion

    }
}