using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace TaskRemainder
{
    public class ComboBox_TreeView : ComboBox
    {
        ToolStripControlHost treeViewHost;
        TreeView treeView;
        ToolStripDropDown dropDown;

        public ComboBox_TreeView()
        {
            // new empty tree view
            treeView = new TreeView();
            treeView.BorderStyle = BorderStyle.None;
            treeViewHost = new ToolStripControlHost(treeView);

            // create drop down and add it
            dropDown = new ToolStripDropDown();
            dropDown.Items.Add(treeViewHost);

            // adding signal for action after selection
            treeView.AfterSelect += new TreeViewEventHandler(treeView_AfterSelect);
        }

        public TreeView TreeView
        {
            get { return treeViewHost.Control as TreeView; }
        }

        private void ShowDropDown()
        {
            if (dropDown != null)
            {
                treeView.BeginUpdate();
                treeView.Width = DropDownWidth;
                treeView.EndUpdate();
                treeViewHost.Width = DropDownWidth; 
                treeViewHost.Height = DropDownHeight;

                // seting up new size
                dropDown.Show(this, 0, this.Height);
                dropDown.DropShadowEnabled = true;
            }
        }

        private const int WM_USER = 0x0400,
                          WM_REFLECT = WM_USER + 0x1C00,
                          WM_COMMAND = 0x0111,
                          CBN_DROPDOWN = 7;

        public static int HIWORD(int n)
        {
            return (n >> 16) & 0xffff;
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == (WM_REFLECT + WM_COMMAND))
            {
                if (HIWORD((int)m.WParam) == CBN_DROPDOWN)
                {
                    ShowDropDown();
                    return;

                }
            }
            base.WndProc(ref m);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (dropDown != null)
                {
                    dropDown.Dispose();
                    dropDown = null;
                }
            }
            base.Dispose(disposing);
        }

        // return folder ID
        public string FolderID
        {
            get
            {
                return treeView.SelectedNode.Tag.ToString();
            }
        }
        

        #region Signals for treeView inside combobox
        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.Text = treeView.SelectedNode.Text.ToString();
            dropDown.Close();
        }
        #endregion
    }
}
