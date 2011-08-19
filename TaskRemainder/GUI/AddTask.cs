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
            // checking if any task message is writen
            if (string.IsNullOrEmpty(messageBox.Text))
            {
                MessageBox.Show("Pleas enter any task message!", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            // checking if task message isn't empty
            if (string.IsNullOrEmpty(messageBox.Text))
            {
                MessageBox.Show("Please enter message for task!", "Information", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            // checking task date both date are used
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
