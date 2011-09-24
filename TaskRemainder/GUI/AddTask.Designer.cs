namespace TaskRemainder.GUI
{
    partial class AddTask
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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxDate = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxFolder = new System.Windows.Forms.CheckBox();
            this.labelFolder = new System.Windows.Forms.Label();
            this.checkBoxEnd = new System.Windows.Forms.CheckBox();
            this.labelStart = new System.Windows.Forms.Label();
            this.labelEnd = new System.Windows.Forms.Label();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.checkBoxStartDate = new System.Windows.Forms.CheckBox();
            this.comboBoxFolder = new TaskRemainder.ComboBox_TreeView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonAddTask = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.groupBoxMessage = new System.Windows.Forms.GroupBox();
            this.messageBox = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel.SuspendLayout();
            this.groupBoxDate.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBoxMessage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.groupBoxDate, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.tableLayoutPanel2, 0, 9);
            this.tableLayoutPanel.Controls.Add(this.groupBoxMessage, 0, 3);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 10;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(420, 353);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // groupBoxDate
            // 
            this.tableLayoutPanel.SetColumnSpan(this.groupBoxDate, 2);
            this.groupBoxDate.Controls.Add(this.tableLayoutPanel1);
            this.groupBoxDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBoxDate.Location = new System.Drawing.Point(5, 5);
            this.groupBoxDate.Margin = new System.Windows.Forms.Padding(5);
            this.groupBoxDate.Name = "groupBoxDate";
            this.groupBoxDate.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel.SetRowSpan(this.groupBoxDate, 3);
            this.groupBoxDate.Size = new System.Drawing.Size(410, 95);
            this.groupBoxDate.TabIndex = 0;
            this.groupBoxDate.TabStop = false;
            this.groupBoxDate.Text = "Date";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.33788F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.66212F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tableLayoutPanel1.Controls.Add(this.checkBoxFolder, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelFolder, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxEnd, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelStart, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelEnd, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dateTimePickerStart, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.dateTimePickerEnd, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxStartDate, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxFolder, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 19);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(400, 71);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // checkBoxFolder
            // 
            this.checkBoxFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.checkBoxFolder.AutoSize = true;
            this.checkBoxFolder.Location = new System.Drawing.Point(362, 49);
            this.checkBoxFolder.Name = "checkBoxFolder";
            this.checkBoxFolder.Size = new System.Drawing.Size(15, 19);
            this.checkBoxFolder.TabIndex = 8;
            this.checkBoxFolder.UseVisualStyleBackColor = true;
            this.checkBoxFolder.CheckedChanged += new System.EventHandler(this.checkBoxFolder_CheckedChanged);
            // 
            // labelFolder
            // 
            this.labelFolder.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelFolder.AutoSize = true;
            this.labelFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelFolder.Location = new System.Drawing.Point(27, 49);
            this.labelFolder.Name = "labelFolder";
            this.labelFolder.Size = new System.Drawing.Size(66, 18);
            this.labelFolder.TabIndex = 6;
            this.labelFolder.Text = "Folder: ";
            // 
            // checkBoxEnd
            // 
            this.checkBoxEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.checkBoxEnd.AutoSize = true;
            this.checkBoxEnd.Location = new System.Drawing.Point(362, 26);
            this.checkBoxEnd.Name = "checkBoxEnd";
            this.checkBoxEnd.Size = new System.Drawing.Size(15, 17);
            this.checkBoxEnd.TabIndex = 5;
            this.checkBoxEnd.UseVisualStyleBackColor = true;
            this.checkBoxEnd.CheckedChanged += new System.EventHandler(this.checkBoxEnd_CheckedChanged);
            // 
            // labelStart
            // 
            this.labelStart.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelStart.AutoSize = true;
            this.labelStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelStart.Location = new System.Drawing.Point(4, 2);
            this.labelStart.Name = "labelStart";
            this.labelStart.Size = new System.Drawing.Size(89, 18);
            this.labelStart.TabIndex = 0;
            this.labelStart.Text = "Task start: ";
            // 
            // labelEnd
            // 
            this.labelEnd.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelEnd.AutoSize = true;
            this.labelEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelEnd.Location = new System.Drawing.Point(6, 25);
            this.labelEnd.Name = "labelEnd";
            this.labelEnd.Size = new System.Drawing.Size(87, 18);
            this.labelEnd.TabIndex = 1;
            this.labelEnd.Text = "Task end: ";
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimePickerStart.Location = new System.Drawing.Point(99, 3);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(238, 21);
            this.dateTimePickerStart.TabIndex = 2;
            this.dateTimePickerStart.Value = new System.DateTime(2011, 8, 15, 19, 16, 52, 0);
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimePickerEnd.Location = new System.Drawing.Point(99, 26);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(238, 21);
            this.dateTimePickerEnd.TabIndex = 3;
            // 
            // checkBoxStartDate
            // 
            this.checkBoxStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.checkBoxStartDate.AutoSize = true;
            this.checkBoxStartDate.Location = new System.Drawing.Point(362, 3);
            this.checkBoxStartDate.Name = "checkBoxStartDate";
            this.checkBoxStartDate.Size = new System.Drawing.Size(15, 17);
            this.checkBoxStartDate.TabIndex = 4;
            this.checkBoxStartDate.UseVisualStyleBackColor = true;
            this.checkBoxStartDate.CheckedChanged += new System.EventHandler(this.checkBoxStartDate_CheckedChanged);
            // 
            // comboBoxFolder
            // 
            this.comboBoxFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxFolder.FormattingEnabled = true;
            this.comboBoxFolder.Location = new System.Drawing.Point(99, 49);
            this.comboBoxFolder.Name = "comboBoxFolder";
            this.comboBoxFolder.Size = new System.Drawing.Size(238, 23);
            this.comboBoxFolder.TabIndex = 7;
            this.comboBoxFolder.Text = "--- Task folder ---";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel.SetColumnSpan(this.tableLayoutPanel2, 2);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.buttonAddTask, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonBack, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 318);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(414, 32);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // buttonAddTask
            // 
            this.buttonAddTask.Location = new System.Drawing.Point(106, 3);
            this.buttonAddTask.Name = "buttonAddTask";
            this.buttonAddTask.Size = new System.Drawing.Size(75, 23);
            this.buttonAddTask.TabIndex = 0;
            this.buttonAddTask.Text = "Add task";
            this.buttonAddTask.UseVisualStyleBackColor = true;
            this.buttonAddTask.Click += new System.EventHandler(this.buttonAddTask_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(209, 3);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(75, 23);
            this.buttonBack.TabIndex = 1;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // groupBoxMessage
            // 
            this.tableLayoutPanel.SetColumnSpan(this.groupBoxMessage, 2);
            this.groupBoxMessage.Controls.Add(this.messageBox);
            this.groupBoxMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBoxMessage.Location = new System.Drawing.Point(3, 108);
            this.groupBoxMessage.Name = "groupBoxMessage";
            this.tableLayoutPanel.SetRowSpan(this.groupBoxMessage, 6);
            this.groupBoxMessage.Size = new System.Drawing.Size(414, 204);
            this.groupBoxMessage.TabIndex = 2;
            this.groupBoxMessage.TabStop = false;
            this.groupBoxMessage.Text = "Message";
            // 
            // messageBox
            // 
            this.messageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.messageBox.Location = new System.Drawing.Point(3, 17);
            this.messageBox.Margin = new System.Windows.Forms.Padding(5);
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(408, 184);
            this.messageBox.TabIndex = 0;
            this.messageBox.Text = "";
            // 
            // AddTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 353);
            this.Controls.Add(this.tableLayoutPanel);
            this.MaximumSize = new System.Drawing.Size(436, 391);
            this.MinimumSize = new System.Drawing.Size(436, 391);
            this.Name = "AddTask";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add new task";
            this.Load += new System.EventHandler(this.AddTask_Load_1);
            this.tableLayoutPanel.ResumeLayout(false);
            this.groupBoxDate.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBoxMessage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.GroupBox groupBoxDate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button buttonAddTask;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.GroupBox groupBoxMessage;
        private System.Windows.Forms.RichTextBox messageBox;
        private System.Windows.Forms.Label labelStart;
        private System.Windows.Forms.Label labelEnd;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.CheckBox checkBoxStartDate;
        private System.Windows.Forms.CheckBox checkBoxEnd;
        private System.Windows.Forms.Label labelFolder;
        private ComboBox_TreeView comboBoxFolder;
        private System.Windows.Forms.CheckBox checkBoxFolder;
    }
}