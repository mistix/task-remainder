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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.dToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showTagToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showContextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.taskListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.showFinishedTasksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.todoListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showFinishedTasksToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.showTaskBoardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutBoxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.messageStrip = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.taskList = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip_taskList = new System.Windows.Forms.ToolStrip();
            this.toolSBCreateFolder = new System.Windows.Forms.ToolStripButton();
            this.toolSBRemove = new System.Windows.Forms.ToolStripButton();
            this.toolSBPrev = new System.Windows.Forms.ToolStripButton();
            this.toolSBNext = new System.Windows.Forms.ToolStripButton();
            this.toolSBUp = new System.Windows.Forms.ToolStripButton();
            this.toolSBDown = new System.Windows.Forms.ToolStripButton();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.treeView_taskList = new System.Windows.Forms.TreeView();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.labelTag = new System.Windows.Forms.Label();
            this.labelContext = new System.Windows.Forms.Label();
            this.labelDateEnd = new System.Windows.Forms.Label();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.comboBoxContext = new System.Windows.Forms.ComboBox();
            this.comboBoxTag = new System.Windows.Forms.ComboBox();
            this.labelDateStart = new System.Windows.Forms.Label();
            this.todoList = new System.Windows.Forms.TabPage();
            this.todoGridView = new System.Windows.Forms.DataGridView();
            this.idTasks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Finished = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.taskDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taskStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taskEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.taskList.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.toolStrip_taskList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.todoList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.todoGridView)).BeginInit();
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
            this.dToolStripMenuItem.Size = new System.Drawing.Size(37, 17);
            this.dToolStripMenuItem.Text = "File";
            // 
            // newTaskToolStripMenuItem
            // 
            this.newTaskToolStripMenuItem.Name = "newTaskToolStripMenuItem";
            this.newTaskToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.newTaskToolStripMenuItem.Text = "New task";
            this.newTaskToolStripMenuItem.Click += new System.EventHandler(this.newTaskToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(119, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editTaskToolStripMenuItem,
            this.deleteTaskToolStripMenuItem,
            this.showTagToolStripMenuItem,
            this.showContextToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 17);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // editTaskToolStripMenuItem
            // 
            this.editTaskToolStripMenuItem.Name = "editTaskToolStripMenuItem";
            this.editTaskToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.editTaskToolStripMenuItem.Text = "Edit task";
            // 
            // deleteTaskToolStripMenuItem
            // 
            this.deleteTaskToolStripMenuItem.Name = "deleteTaskToolStripMenuItem";
            this.deleteTaskToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.deleteTaskToolStripMenuItem.Text = "Delete task";
            // 
            // showTagToolStripMenuItem
            // 
            this.showTagToolStripMenuItem.Name = "showTagToolStripMenuItem";
            this.showTagToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.showTagToolStripMenuItem.Text = "Show tag";
            // 
            // showContextToolStripMenuItem
            // 
            this.showContextToolStripMenuItem.Name = "showContextToolStripMenuItem";
            this.showContextToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.showContextToolStripMenuItem.Text = "Show context";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.taskListToolStripMenuItem,
            this.todoListToolStripMenuItem,
            this.showTaskBoardToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 17);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // taskListToolStripMenuItem
            // 
            this.taskListToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator2,
            this.showFinishedTasksToolStripMenuItem});
            this.taskListToolStripMenuItem.Name = "taskListToolStripMenuItem";
            this.taskListToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.taskListToolStripMenuItem.Text = "Task list";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(174, 6);
            // 
            // showFinishedTasksToolStripMenuItem
            // 
            this.showFinishedTasksToolStripMenuItem.Name = "showFinishedTasksToolStripMenuItem";
            this.showFinishedTasksToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.showFinishedTasksToolStripMenuItem.Text = "Show finished tasks";
            this.showFinishedTasksToolStripMenuItem.Click += new System.EventHandler(this.showFinishedTasksToolStripMenuItem_Click);
            // 
            // todoListToolStripMenuItem
            // 
            this.todoListToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showFinishedTasksToolStripMenuItem1});
            this.todoListToolStripMenuItem.Name = "todoListToolStripMenuItem";
            this.todoListToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.todoListToolStripMenuItem.Text = "To-do list";
            // 
            // showFinishedTasksToolStripMenuItem1
            // 
            this.showFinishedTasksToolStripMenuItem1.Name = "showFinishedTasksToolStripMenuItem1";
            this.showFinishedTasksToolStripMenuItem1.Size = new System.Drawing.Size(177, 22);
            this.showFinishedTasksToolStripMenuItem1.Text = "Show finished tasks";
            // 
            // showTaskBoardToolStripMenuItem
            // 
            this.showTaskBoardToolStripMenuItem.Checked = true;
            this.showTaskBoardToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showTaskBoardToolStripMenuItem.Name = "showTaskBoardToolStripMenuItem";
            this.showTaskBoardToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.showTaskBoardToolStripMenuItem.Text = "Task board";
            this.showTaskBoardToolStripMenuItem.Click += new System.EventHandler(this.showTaskBoardToolStripMenuItem_Click);
            // 
            // aboutBoxToolStripMenuItem
            // 
            this.aboutBoxToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutApplicationToolStripMenuItem});
            this.aboutBoxToolStripMenuItem.Name = "aboutBoxToolStripMenuItem";
            this.aboutBoxToolStripMenuItem.Size = new System.Drawing.Size(52, 17);
            this.aboutBoxToolStripMenuItem.Text = "About";
            // 
            // aboutApplicationToolStripMenuItem
            // 
            this.aboutApplicationToolStripMenuItem.Name = "aboutApplicationToolStripMenuItem";
            this.aboutApplicationToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.aboutApplicationToolStripMenuItem.Text = "About application";
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
            this.messageStrip.Size = new System.Drawing.Size(35, 17);
            this.messageStrip.Text = "1/2/3";
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
            this.taskList.Controls.Add(this.tableLayoutPanel2);
            this.taskList.Location = new System.Drawing.Point(4, 22);
            this.taskList.Name = "taskList";
            this.taskList.Padding = new System.Windows.Forms.Padding(3);
            this.taskList.Size = new System.Drawing.Size(667, 354);
            this.taskList.TabIndex = 1;
            this.taskList.Text = "Task list";
            this.taskList.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.toolStrip_taskList, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.splitContainer, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(661, 348);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // toolStrip_taskList
            // 
            this.toolStrip_taskList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip_taskList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolSBCreateFolder,
            this.toolSBRemove,
            this.toolSBPrev,
            this.toolSBNext,
            this.toolSBUp,
            this.toolSBDown});
            this.toolStrip_taskList.Location = new System.Drawing.Point(0, 0);
            this.toolStrip_taskList.Name = "toolStrip_taskList";
            this.toolStrip_taskList.Size = new System.Drawing.Size(661, 24);
            this.toolStrip_taskList.TabIndex = 1;
            this.toolStrip_taskList.Text = "toolStrip1";
            // 
            // toolSBCreateFolder
            // 
            this.toolSBCreateFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolSBCreateFolder.Image = global::TaskRemainder.Properties.Resources.folder;
            this.toolSBCreateFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSBCreateFolder.Name = "toolSBCreateFolder";
            this.toolSBCreateFolder.Size = new System.Drawing.Size(23, 21);
            this.toolSBCreateFolder.Text = "Create new folder";
            this.toolSBCreateFolder.Click += new System.EventHandler(this.toolSBCreateFolder_Click);
            // 
            // toolSBRemove
            // 
            this.toolSBRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolSBRemove.Image = global::TaskRemainder.Properties.Resources.remove;
            this.toolSBRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSBRemove.Name = "toolSBRemove";
            this.toolSBRemove.Size = new System.Drawing.Size(23, 21);
            this.toolSBRemove.Text = "Remov task or folder";
            this.toolSBRemove.Click += new System.EventHandler(this.toolSBRemove_Click);
            // 
            // toolSBPrev
            // 
            this.toolSBPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolSBPrev.Image = global::TaskRemainder.Properties.Resources.previous;
            this.toolSBPrev.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSBPrev.Name = "toolSBPrev";
            this.toolSBPrev.Size = new System.Drawing.Size(23, 21);
            this.toolSBPrev.Text = "Move up";
            this.toolSBPrev.Click += new System.EventHandler(this.toolSBPrev_Click);
            // 
            // toolSBNext
            // 
            this.toolSBNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolSBNext.Image = global::TaskRemainder.Properties.Resources.next;
            this.toolSBNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSBNext.Name = "toolSBNext";
            this.toolSBNext.Size = new System.Drawing.Size(23, 21);
            this.toolSBNext.Text = "Move down to node";
            this.toolSBNext.Click += new System.EventHandler(this.toolSBNext_Click);
            // 
            // toolSBUp
            // 
            this.toolSBUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolSBUp.Image = global::TaskRemainder.Properties.Resources.up;
            this.toolSBUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSBUp.Name = "toolSBUp";
            this.toolSBUp.Size = new System.Drawing.Size(23, 21);
            this.toolSBUp.Text = "Put node on node up";
            this.toolSBUp.Click += new System.EventHandler(this.toolSBUp_Click);
            // 
            // toolSBDown
            // 
            this.toolSBDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolSBDown.Image = global::TaskRemainder.Properties.Resources.down;
            this.toolSBDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSBDown.Name = "toolSBDown";
            this.toolSBDown.Size = new System.Drawing.Size(23, 21);
            this.toolSBDown.Text = "Put node on node down";
            this.toolSBDown.Click += new System.EventHandler(this.toolSBDown_Click);
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(3, 27);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.treeView_taskList);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.tableLayoutPanel3);
            this.splitContainer.Panel2.Margin = new System.Windows.Forms.Padding(5);
            this.splitContainer.Panel2.Padding = new System.Windows.Forms.Padding(5);
            this.splitContainer.Size = new System.Drawing.Size(655, 318);
            this.splitContainer.SplitterDistance = 484;
            this.splitContainer.TabIndex = 2;
            // 
            // treeView_taskList
            // 
            this.treeView_taskList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_taskList.LabelEdit = true;
            this.treeView_taskList.Location = new System.Drawing.Point(0, 0);
            this.treeView_taskList.Name = "treeView_taskList";
            this.treeView_taskList.Size = new System.Drawing.Size(484, 318);
            this.treeView_taskList.TabIndex = 1;
            this.treeView_taskList.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeView_taskList_BeforeLabelEdit);
            this.treeView_taskList.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeView_taskList_AfterLabelEdit);
            this.treeView_taskList.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_taskList_NodeMouseClick);
            this.treeView_taskList.DoubleClick += new System.EventHandler(this.treeView_taskList_DoubleClick);
            this.treeView_taskList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.treeView_taskList_MouseMove);
            this.treeView_taskList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeView_taskList_MouseUp);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.3121F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56.6879F));
            this.tableLayoutPanel3.Controls.Add(this.labelTag, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.labelContext, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.labelDateEnd, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.dateTimePickerStart, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.dateTimePickerEnd, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.comboBoxContext, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.comboBoxTag, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.labelDateStart, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(5, 5);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 8;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(157, 308);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // labelTag
            // 
            this.labelTag.AutoSize = true;
            this.labelTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelTag.Location = new System.Drawing.Point(3, 114);
            this.labelTag.Name = "labelTag";
            this.labelTag.Size = new System.Drawing.Size(36, 16);
            this.labelTag.TabIndex = 7;
            this.labelTag.Text = "Tag";
            // 
            // labelContext
            // 
            this.labelContext.AutoSize = true;
            this.labelContext.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelContext.Location = new System.Drawing.Point(3, 76);
            this.labelContext.Name = "labelContext";
            this.labelContext.Size = new System.Drawing.Size(59, 16);
            this.labelContext.TabIndex = 6;
            this.labelContext.Text = "Context";
            // 
            // labelDateEnd
            // 
            this.labelDateEnd.AutoSize = true;
            this.labelDateEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelDateEnd.Location = new System.Drawing.Point(3, 38);
            this.labelDateEnd.Name = "labelDateEnd";
            this.labelDateEnd.Size = new System.Drawing.Size(47, 32);
            this.labelDateEnd.TabIndex = 5;
            this.labelDateEnd.Text = "Task end";
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Location = new System.Drawing.Point(70, 3);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(83, 20);
            this.dateTimePickerStart.TabIndex = 0;
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Location = new System.Drawing.Point(70, 41);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(83, 20);
            this.dateTimePickerEnd.TabIndex = 1;
            // 
            // comboBoxContext
            // 
            this.comboBoxContext.FormattingEnabled = true;
            this.comboBoxContext.Location = new System.Drawing.Point(70, 79);
            this.comboBoxContext.Name = "comboBoxContext";
            this.comboBoxContext.Size = new System.Drawing.Size(83, 21);
            this.comboBoxContext.TabIndex = 2;
            // 
            // comboBoxTag
            // 
            this.comboBoxTag.FormattingEnabled = true;
            this.comboBoxTag.Location = new System.Drawing.Point(70, 117);
            this.comboBoxTag.Name = "comboBoxTag";
            this.comboBoxTag.Size = new System.Drawing.Size(83, 21);
            this.comboBoxTag.TabIndex = 3;
            // 
            // labelDateStart
            // 
            this.labelDateStart.AutoSize = true;
            this.labelDateStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelDateStart.Location = new System.Drawing.Point(3, 0);
            this.labelDateStart.Name = "labelDateStart";
            this.labelDateStart.Size = new System.Drawing.Size(47, 32);
            this.labelDateStart.TabIndex = 4;
            this.labelDateStart.Text = "Task start";
            // 
            // todoList
            // 
            this.todoList.Controls.Add(this.todoGridView);
            this.todoList.Location = new System.Drawing.Point(4, 22);
            this.todoList.Name = "todoList";
            this.todoList.Padding = new System.Windows.Forms.Padding(3);
            this.todoList.Size = new System.Drawing.Size(667, 354);
            this.todoList.TabIndex = 2;
            this.todoList.Text = "To-do list";
            this.todoList.UseVisualStyleBackColor = true;
            // 
            // todoGridView
            // 
            this.todoGridView.AllowUserToAddRows = false;
            this.todoGridView.AllowUserToDeleteRows = false;
            this.todoGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.todoGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.todoGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.todoGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idTasks,
            this.Finished,
            this.taskDesc,
            this.taskStart,
            this.taskEnd});
            this.todoGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.todoGridView.Location = new System.Drawing.Point(3, 3);
            this.todoGridView.MultiSelect = false;
            this.todoGridView.Name = "todoGridView";
            this.todoGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.todoGridView.RowHeadersVisible = false;
            this.todoGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.todoGridView.Size = new System.Drawing.Size(661, 348);
            this.todoGridView.TabIndex = 0;
            this.todoGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.todoGridView_CellContentClick);
            // 
            // idTasks
            // 
            this.idTasks.DataPropertyName = "idTasks";
            this.idTasks.HeaderText = "idTasks";
            this.idTasks.Name = "idTasks";
            this.idTasks.Visible = false;
            // 
            // Finished
            // 
            this.Finished.DataPropertyName = "finished";
            this.Finished.FalseValue = "false";
            this.Finished.FillWeight = 50F;
            this.Finished.HeaderText = "Finished";
            this.Finished.Name = "Finished";
            this.Finished.TrueValue = "true";
            this.Finished.Width = 50;
            // 
            // taskDesc
            // 
            this.taskDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.taskDesc.DataPropertyName = "taskDesc";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.taskDesc.DefaultCellStyle = dataGridViewCellStyle2;
            this.taskDesc.HeaderText = "Task description";
            this.taskDesc.Name = "taskDesc";
            // 
            // taskStart
            // 
            this.taskStart.DataPropertyName = "taskStart";
            this.taskStart.HeaderText = "Task started";
            this.taskStart.Name = "taskStart";
            // 
            // taskEnd
            // 
            this.taskEnd.DataPropertyName = "taskEnd";
            this.taskEnd.HeaderText = "Task finish";
            this.taskEnd.Name = "taskEnd";
            this.taskEnd.ReadOnly = true;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 5000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // mainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 430);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "mainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Task remainder";
            this.Load += new System.EventHandler(this.mainWindow_Load);
            this.VisibleChanged += new System.EventHandler(this.mainWindow_VisibleChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mainWindow_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.taskList.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.toolStrip_taskList.ResumeLayout(false);
            this.toolStrip_taskList.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.todoList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.todoGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem dToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel messageStrip;
        private System.Windows.Forms.ToolStripMenuItem newTaskToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editTaskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteTaskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutBoxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showTagToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showContextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem taskListToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem showFinishedTasksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem todoListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showFinishedTasksToolStripMenuItem1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage taskList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ToolStrip toolStrip_taskList;
        private System.Windows.Forms.ToolStripButton toolSBCreateFolder;
        private System.Windows.Forms.ToolStripButton toolSBRemove;
        private System.Windows.Forms.ToolStripButton toolSBPrev;
        private System.Windows.Forms.ToolStripButton toolSBNext;
        private System.Windows.Forms.ToolStripButton toolSBUp;
        private System.Windows.Forms.ToolStripButton toolSBDown;
        private System.Windows.Forms.TabPage todoList;
        private System.Windows.Forms.DataGridView todoGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTasks;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Finished;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskEnd;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TreeView treeView_taskList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label labelTag;
        private System.Windows.Forms.Label labelContext;
        private System.Windows.Forms.Label labelDateEnd;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.ComboBox comboBoxContext;
        private System.Windows.Forms.ComboBox comboBoxTag;
        private System.Windows.Forms.Label labelDateStart;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolStripMenuItem showTaskBoardToolStripMenuItem;
    }
}

