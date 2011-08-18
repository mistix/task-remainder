using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;

namespace TaskRemainder
{
    public class Tools
    {
        /// <summary>
        /// Types of search variable
        /// </summary>
        public enum TagOrContext
        {
            Tag,
            Context
        }

        #region Removing repeated elements from DB
        /// <summary>
        /// Removing duplicated elements from list
        /// </summary>
        /// <param name="tag_list"></param>
        /// <param name="table"></param>
        public void removeRepeatedElement(ref ArrayList tag_list, DataTable table)
        {
            // removing all unnesesary duplicates
            tag_list = removeDuplicates(tag_list);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                for (int j = 0; j<tag_list.Count; j++)
                {
                    if (table.Rows[i][1].ToString().Equals(tag_list[j].ToString()))
                        tag_list.RemoveAt(j); j--;
                }
            }
        }
        #endregion

        #region Removing duplicates from ArrayList
        /// <summary>
        /// Returning ArrayList who contin no duplicates
        /// </summary>
        /// <param name="list">ArrayList</param>
        /// <returns></returns>
        public ArrayList removeDuplicates(ArrayList list)
        {
            ArrayList noDup = new ArrayList();

            foreach (string item in list)
            {
                if(!noDup.Contains(item.Trim()))
                    noDup.Add(item);
            }
            noDup.Sort();
            return noDup;
        }
        #endregion

        #region Searching for context and tag in string
        /// <summary>
        /// Searching and returning arraylist of context or tags
        /// </summary>
        /// <param name="message">Task message</param>
        /// <param name="type">What we should search Tag or Context</param>
        /// <returns>array of context from task message</returns>
        public ArrayList getTaskOrContextFromMessage(string message, TagOrContext type)
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
                    list.Add(tmp);
                }
            }

            return list;
        }
        #endregion
    }
}
