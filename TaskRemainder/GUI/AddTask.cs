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
        CDBOperation.DBOperation resultDB;
        #endregion

        #region Construstor
        public AddTask()
        {
            InitializeComponent();
            checkBoxStartDate.Checked = true;
            checkBoxEnd.Checked = true;
        }
        #endregion

        /// <summary>
        /// Types of search variable
        /// </summary>
        public enum TagOrContext
        {
            Tag,
            Context
        }

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
                DateTime startDate = dateTimePickerStart.Value;
                DateTime endDate = dateTimePickerEnd.Value;
                string message = messageBox.Text;

                // searching for tag and context
                ArrayList context_list = getTaskOrContextFromMessage(message, TagOrContext.Context);
                ArrayList tag_list = getTaskOrContextFromMessage(message, TagOrContext.Tag);

                // checking result operation of DB
                resultDB = CDBOperation.insertContextDB(context_list);
                if (resultDB != CDBOperation.DBOperation.InsertSuccessful)
                {
                    MessageBox.Show("Error when inserting new context", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // insrting new tag
                resultDB = CDBOperation.insertTagDB(tag_list);
                if (resultDB != CDBOperation.DBOperation.InsertSuccessful)
                {
                    MessageBox.Show("Error when inserting new tag", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
            else if (checkBoxEnd.Checked && !checkBoxStartDate.Checked) // end checked and start unchecked
            {
                //TODO dodać obsługę daty tylko końcowej
            }
            else if (!checkBoxEnd.Checked && !checkBoxStartDate.Checked) // end and start unchecked
            {
                //TODO przypadek, gdy żadna data nie jest aktywna (taski w przyszłości)
            }

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

        #region Searching for context and tag in string
        /// <summary>
        /// Searching and returning arraylist of context or tags
        /// </summary>
        /// <param name="message">Task message</param>
        /// <param name="type">What we should search Tag or Context</param>
        /// <returns>array of context from task message</returns>
        private ArrayList getTaskOrContextFromMessage(string message, TagOrContext type)
        {
            // checking of tag or context
            string tag;
            switch (type)
            {
                case TagOrContext.Context:
                    tag = "@";
                    break;
                case TagOrContext.Tag:
                    tag = ":";
                    break;
                default:
                    tag = "";
                    break;
            }

            ArrayList list = new ArrayList();
            string[] split = message.Split(new char[] {' '});
            
            //Searching for tag or context
            foreach (string item in split)
            {
                if (item.Contains(tag))
                {
                    string tmp = item.Substring(1);
                    if(!item.Contains(tmp)) // don't contain that item
                        list.Add(tmp);
                }
            }

            return list;
        }
        #endregion
    }
}
