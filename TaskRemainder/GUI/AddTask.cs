using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TaskRemainder.GUI
{
    public partial class AddTask : Form
    {
        #region Variables
        DataTable tmp_table;
        Tools tools;
        DBRespons dbrespons;

        // date
        string dateEnd;
        string dateStart;
        decimal idTask;
        decimal idTag;
        decimal idContext;
        decimal idFolder;
        #endregion

        #region Construstor
        public AddTask()
        {
            InitializeComponent();
            checkBoxStartDate.Checked = true;
            checkBoxEnd.Checked = true;
            tools = new Tools();
        }
        #endregion


        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAddTask_Click(object sender, EventArgs e)
        {
            // checking if task message isn't empty
            if (string.IsNullOrEmpty(messageBox.Text))
            {
                MessageBox.Show("Please enter message for task!", "Information", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            // checking task date for date used
            if (checkBoxEnd.Checked && checkBoxStartDate.Checked) // both checked
            {
                dateEnd = ((DateTime)dateTimePickerEnd.Value).ToShortDateString();
                dateStart = ((DateTime)dateTimePickerStart.Value).ToShortDateString();
            }
            else if (checkBoxEnd.Checked && !checkBoxStartDate.Checked) // end checked and start unchecked
            {
                dateEnd = ((DateTime)dateTimePickerEnd.Value).ToShortDateString();
                dateStart = null;
            }
            else if (!checkBoxEnd.Checked && !checkBoxStartDate.Checked) // end and start unchecked
            {
                dateEnd = null;
                dateStart = null;
            }
            
            // Processing task, searching tags and contexts
            string message = messageBox.Text;

            // searching for tag and context
            ArrayList context_list = tools.getTaskOrContextFromMessage(message, Tools.TagOrContext.Context);
            ArrayList tag_list = tools.getTaskOrContextFromMessage(message, Tools.TagOrContext.Tag);

            /* Inserting new task first */
            dbrespons = DBOperation.insertNewTask(message, dateEnd, dateStart, false, ref idTask);
            if (dbrespons.resultOperation() != DBStatus.InsertSuccessful)
            {
                MessageBox.Show("Error when inserting new task" + dbrespons.errorMessage(), "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // inserting new context into DB
            if (context_list.Count != 0)
            {
                dbrespons = DBOperation.insertContextDB(ref context_list);
                if (dbrespons.resultOperation() != DBStatus.InsertSuccessful)
                {
                    MessageBox.Show("Error when inserting new context" + dbrespons.errorMessage(), "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // inserting new tag
            if (tag_list.Count != 0)
            {
                dbrespons = DBOperation.insertTagDB(ref tag_list);
                if (dbrespons.resultOperation() != DBStatus.InsertSuccessful)
                {
                    MessageBox.Show("Error when inserting new tag" + dbrespons.errorMessage(), "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // inserting all data together
            dbrespons = DBOperation.insertContainerDB(idTask, tag_list, context_list);
            if (dbrespons.resultOperation() != DBStatus.InsertSuccessful)
            {
                MessageBox.Show("Error when inserting new task" + dbrespons.errorMessage(), "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // closing window
            this.Close();
        }

        #region CheckBoxs checked changed
        /// <summary>
        /// Enabled or disabled start date components
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxStartDate_CheckedChanged(object sender, EventArgs e)
        {
            // checking if start date is needed
            if (checkBoxStartDate.Checked)
            {
                this.dateTimePickerStart.Enabled = true;
                this.labelStart.Enabled = true;
            }
            else
            {
                this.dateTimePickerStart.Enabled = false;
                this.labelStart.Enabled = false;
            }
        }

        /// <summary>
        /// Action on clicking checkbox button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxEnd_CheckedChanged(object sender, EventArgs e)
        {
            // checking if end date is needed
            if (checkBoxEnd.Checked)
            {
                this.dateTimePickerEnd.Enabled = true;
                this.labelEnd.Enabled = true;
            }
            else
            {
                this.dateTimePickerEnd.Enabled = false;
                this.labelEnd.Enabled = false;
            }
        }
        #endregion
    }
}
