namespace TaskRemainder
{
    partial class mainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainWindow));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.messageStrip = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.dToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.taskList = new System.Windows.Forms.TabPage();
            this.todoList = new System.Windows.Forms.TabPage();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutBoxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "Task remainder";
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Task remainder";
            this.notifyIcon.Visible = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.menuStrip, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.statusBar, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(681, 430);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // statusBar
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.statusBar, 2);
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.messageStrip});
            this.statusBar.Location = new System.Drawing.Point(0, 408);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(681, 22);
            this.statusBar.TabIndex = 0;
            this.statusBar.Text = "statusStrip1";
            // 
            // messageStrip
            // 
            this.messageStrip.Name = "messageStrip";
            this.messageStrip.Size = new System.Drawing.Size(35, 16);
            this.messageStrip.Text = "1/2/3";
            // 
            // menuStrip
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.menuStrip, 2);
            this.menuStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dToolStripMenuItem,
            this.editToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.aboutBoxToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(681, 21);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // dToolStripMenuItem
            // 
            this.dToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newTaskToolStripMenuItem,
            this.toolStripSeparator1,
            this.quitToolStripMenuItem});
            this.dToolStripMenuItem.Name = "dToolStripMenuItem";
            this.dToolStripMenuItem.Size = new System.Drawing.Size(37, 18);
            this.dToolStripMenuItem.Text = "File";
            // 
            // tabControl1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.tabControl1, 2);
            this.tabControl1.Controls.Add(this.taskList);
            this.tabControl1.Controls.Add(this.todoList);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 24);
            this.tabControl1.Name = "tabControl1";
            this.tableLayoutPanel1.SetRowSpan(this.tabControl1, 2);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(675, 380);
            this.tabControl1.TabIndex = 2;
            // 
            // taskList
            // 
            this.taskList.Location = new System.Drawing.Point(4, 22);
            this.taskList.Name = "taskList";
            this.taskList.Padding = new System.Windows.Forms.Padding(3);
            this.taskList.Size = new System.Drawing.Size(667, 354);
            this.taskList.TabIndex = 1;
            this.taskList.Text = "Task list";
            this.taskList.UseVisualStyleBackColor = true;
            // 
            // todoList
            // 
            this.todoList.Location = new System.Drawing.Point(4, 22);
            this.todoList.Name = "todoList";
            this.todoList.Padding = new System.Windows.Forms.Padding(3);
            this.todoList.Size = new System.Drawing.Size(667, 355);
            this.todoList.TabIndex = 2;
            this.todoList.Text = "To-do list";
            this.todoList.UseVisualStyleBackColor = true;
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editTaskToolStripMenuItem,
            this.deleteTaskToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 18);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // newTaskToolStripMenuItem
            // 
            this.newTaskToolStripMenuItem.Name = "newTaskToolStripMenuItem";
            this.newTaskToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newTaskToolStripMenuItem.Text = "New task";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // editTaskToolStripMenuItem
            // 
            this.editTaskToolStripMenuItem.Name = "editTaskToolStripMenuItem";
            this.editTaskToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.editTaskToolStripMenuItem.Text = "Edit task";
            // 
            // deleteTaskToolStripMenuItem
            // 
            this.deleteTaskToolStripMenuItem.Name = "deleteTaskToolStripMenuItem";
            this.deleteTaskToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteTaskToolStripMenuItem.Text = "Delete task";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 18);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // aboutBoxToolStripMenuItem
            // 
            this.aboutBoxToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutApplicationToolStripMenuItem});
            this.aboutBoxToolStripMenuItem.Name = "aboutBoxToolStripMenuItem";
            this.aboutBoxToolStripMenuItem.Size = new System.Drawing.Size(52, 18);
            this.aboutBoxToolStripMenuItem.Text = "About";
            // 
            // aboutApplicationToolStripMenuItem
            // 
            this.aboutApplicationToolStripMenuItem.Name = "aboutApplicationToolStripMenuItem";
            this.aboutApplicationToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.aboutApplicationToolStripMenuItem.Text = "About application";
            // 
            // mainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 430);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "mainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Task remainder";
            this.Load += new System.EventHandler(this.mainWindow_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem dToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel messageStrip;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage taskList;
        private System.Windows.Forms.TabPage todoList;
        private System.Windows.Forms.ToolStripMenuItem newTaskToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editTaskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteTaskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutBoxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutApplicationToolStripMenuItem;
    }
}

