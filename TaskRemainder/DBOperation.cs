using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Collections;
using System.Data;

namespace TaskRemainder
{
    //TODO make update operation for finish tasks

    public class DBOperation
    {
        #region Variables
        static SQLiteConnection connection = null;
        static SQLiteCommand command = null;
        static SQLiteTransaction transaction = null;
        static string dataBase = "task-remainder.sql";
        #endregion


        #region All methods connected with transaction 
        private static void OpenTransaction()
        {
            if (connection == null)
            {
                try
                {
                    connection = new SQLiteConnection("Data Source=" + dataBase);
                    connection.Open();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            if (transaction == null)
            {
                transaction = connection.BeginTransaction();
                command = connection.CreateCommand();
            }
        }

        private static void RollbackTransaction()
        {
            if (transaction != null)
            {
                transaction.Rollback();
                transaction.Dispose();
                transaction = null;
            }
        }

        private static void CommitTransaction()
        {
            if (transaction != null)
            {
                transaction.Commit();
                transaction.Dispose();
                transaction = null;
            }
        }
        #endregion

        #region Initialization DB
        /// <summary>
        /// Initialization DB, creating tables
        /// </summary>
        /// <returns></returns>
        public static DBRespons initDateBase()
        {
            try
            {
                if (System.IO.File.Exists(dataBase) == false)
                {
                    // opening database
                    connection = new SQLiteConnection("Data Source=" + dataBase);
                    connection.Open();

                    using (transaction = connection.BeginTransaction())
                    {
                        using (command = connection.CreateCommand())
                        {
                            // Creating Context table
                            command.CommandText = "CREATE TABLE IF NOT EXISTS [Context] (" +
                                "[idContext] INTEGER  NOT NULL PRIMARY KEY AUTOINCREMENT, " +
                                "[contextName] VARCHAR(255)  UNIQUE NOT NULL)";
                            command.ExecuteNonQuery();

                            //creating Tag table
                            command.CommandText = "CREATE TABLE [Tag] (" +
                                "[idTag] INTEGER  NOT NULL PRIMARY KEY AUTOINCREMENT, " +
                                "[tagName] VARCHAR(255)  NOT NULL)";
                            command.ExecuteNonQuery();

                            //Creating Folders table
                            command.CommandText = "CREATE TABLE [Folder] (" +
                                "[idFolder] INTEGER  NOT NULL PRIMARY KEY AUTOINCREMENT, " +
                                "[folderName] VARCHAR(255) UNIQUE NOT NULL, " +
                                "[idParentFolder] INTEGER  NULL)";
                            command.ExecuteNonQuery();

                            //Creating Tasks table
                            command.CommandText = "CREATE TABLE [Tasks] (" +
                                "[idTasks] INTEGER  PRIMARY KEY AUTOINCREMENT NOT NULL, " +
                                "[taskDesc] NVARCHAR(500)  NOT NULL, " +
                                "[taskEnd] DATE  NULL, " +
                                "[taskStart] DATE  NULL, " +
                                "[finished] BOOLEAN  NOT NULL)";
                            command.ExecuteNonQuery();

                            // Creating Container tabke
                            command.CommandText = "CREATE TABLE [Container] (" +
                                "[idContainer] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, " +
                                "[Tasks_idTasks] INTEGER NULL, " +
                                "[Folder_idFolder] INTEGER NULL, " +
                                "[Tag_idTag] INTEGER NULL, " +
                                "[Context_idContext] INTEGER NULL)";
                            command.ExecuteNonQuery();
                            transaction.Commit();
                        }
                    }
                }
                else
                {
                    connection = new SQLiteConnection("Data Source=" + dataBase);
                    connection.Open();
                }
            }
            catch (Exception e)
            {
                RollbackTransaction();
                return new DBRespons(DBStatus.InitDBError, e.Message);
            }
            //CommitTransaction();
            return new DBRespons(DBStatus.InitDBSuccessful);
        }
        #endregion

        #region Inserting tag, context into DB
        /// <summary>
        /// Adding context to DB
        /// </summary>
        /// <param name="context">ArrayList of context gathering from task</param>
        /// <returns>InsertError or InsertSuccessful</returns>
        public static DBRespons insertContextDB(ref ArrayList context)
        {
            try
            {
                bool makeQuery;
                DataTable tmp_table = new DataTable();

                OpenTransaction();
                command.CommandText = "select * from Context";
                command.Prepare();

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    tmp_table.Load(reader);
                }

                for (int i = 0; i < context.Count; i++) 
                {
                    makeQuery = true;
                    // checking if context dosn't exist in DB
                    for (int j = 0; j < tmp_table.Rows.Count; j++)
                    {
                        if (context[i].ToString().Equals(tmp_table.Rows[j]["contextName"].ToString()))
                        {
                            makeQuery = false;
                            break;
                        }
                    }

                    if (makeQuery) // inserting new context to DB if data is unique
                    {
                        command.CommandText = "insert into Context(contextName) values(:name)";
                        command.Parameters.Clear();
                        command.Parameters.Add("name", System.Data.DbType.String).Value = context[i].ToString();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                RollbackTransaction();
                return new DBRespons(DBStatus.InsertError, e.Message);
            }
            CommitTransaction();
            return new DBRespons(DBStatus.InsertSuccessful);
        }

        /// <summary>
        /// Insert Tag to the Tag table 
        /// </summary>
        /// <param name="tag">ArryList of tags who will be inserted into DB</param>
        /// <returns>InsertError or InsertSuccessful</returns>
        public static DBRespons insertTagDB(ref ArrayList tag)
        {
            try
            {
                bool makeQuery;
                DataTable tmp_table = new DataTable();

                OpenTransaction();
                command.CommandText = "select * from Tag";
                command.Prepare();
                SQLiteDataReader reader = command.ExecuteReader();
                tmp_table.Load(reader);

                for(int i=0; i<tag.Count; i++)
                {
                    makeQuery = true;
                    // checking if context dosn't exist in DB
                    for (int j = 0; j < tmp_table.Rows.Count; j++)
                    {
                        if (tag[i].ToString().Equals(tmp_table.Rows[j]["tagName"].ToString()))
                        {
                            makeQuery = false;
                            break;
                        }
                    }

                    if (makeQuery) // inserting new context to DB if data is unique
                    {
                        command.CommandText = "insert into Tag(tagName) values(:name)";
                        command.Parameters.Clear();
                        command.Parameters.Add("name", System.Data.DbType.String).Value = tag[i].ToString();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                RollbackTransaction();
                return new DBRespons(DBStatus.InsertError, e.Message);
            }
            CommitTransaction();
            return new DBRespons(DBStatus.InsertSuccessful);
        }
        #endregion

        #region Returning tables of Tag and Context
        /// <summary>
        /// Getting tag list from DB
        /// </summary>
        /// <param name="tag_list">reference DataTable contined tag list</param>
        /// <returns>SelectSuccessful or SelectError</returns>
        public static DBRespons getTagTable(ref DataTable tag_list)
        {
            try
            {
                tag_list = new DataTable();
                OpenTransaction();
                command.CommandText = "select * from Tag";

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    tag_list.Load(reader);
                }
            }
            catch (Exception e)
            {
                return new DBRespons(DBStatus.SelectError, e.Message);
            }
            return new DBRespons(DBStatus.SelectSuccessful);
        }

        /// <summary>
        /// Getting containt of Context table
        /// </summary>
        /// <param name="context_list">contains Context table</param>
        /// <returns>SelectSuccessful</returns>
        public static DBRespons getContextTable(ref DataTable context_list)
        {
            try
            {
                context_list = new DataTable();
                OpenTransaction();
                command.CommandText = "select * from Context";
                SQLiteDataReader reader = command.ExecuteReader();
                context_list.Load(reader);
            }
            catch (Exception e)
            {
                return new DBRespons(DBStatus.SelectError, e.Message);
            }
            return new DBRespons(DBStatus.SelectSuccessful);
        }
        #endregion

        #region Inserting new task to DB


        /// <summary>
        /// Inserting new task
        /// </summary>
        /// <param name="taskMsg">task message</param>
        /// <param name="dateEnd">task end date</param>
        /// <param name="dataStart">task start date</param>
        /// <param name="finished">if task is finished</param>
        /// <param name="idTask">returning ID of new task</param>
        /// <returns>DBRespons</returns>
        public static DBRespons insertNewTask(string taskMsg, string dateEnd, string dateStart, bool finished, ref decimal idTask)
        {
            try
            {
                // initialization reference
                idTask = 0;

                OpenTransaction();
                command.CommandText = "insert into Tasks(taskDesc, taskStart, taskEnd, finished) values(:taskMsg, " +
                    ":start, :end, :finished)";
                command.Parameters.Clear();
                command.Parameters.Add("taskMsg", DbType.String).Value = taskMsg;
                command.Parameters.Add("start", DbType.Date).Value = dateStart;
                command.Parameters.Add("end", DbType.Date).Value = dateEnd;
                command.Parameters.Add("finished", DbType.Boolean).Value = finished;
                command.Prepare();
                command.ExecuteNonQuery();

                command.CommandText = "select max(idTasks) from Tasks";
                command.Parameters.Clear();
                command.Prepare();
                idTask = decimal.Parse(command.ExecuteScalar().ToString());
            }
            catch (Exception e)
            {
                RollbackTransaction();
                return new DBRespons(DBStatus.InsertError, e.Message);
            }
            CommitTransaction();
            return new DBRespons(DBStatus.InsertSuccessful);
        }
        #endregion

        #region Update Container set folder
        public static DBRespons updateContainerDB(decimal idTask, decimal idFolder)
        {
            try
            {
                OpenTransaction();
                command.CommandText = "update Container set Folder_idFolder = :idFolder where Tasks_idTasks = :idTask";
                command.Parameters.Clear();
                command.Parameters.Add("idFolder", DbType.VarNumeric).Value = idFolder;
                command.Parameters.Add("idTask", DbType.VarNumeric).Value = idTask;
                command.Prepare();
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                RollbackTransaction();
                return new DBRespons(DBStatus.UpdateError, e.Message);
            }
            CommitTransaction();
            return new DBRespons(DBStatus.UpdateSuccessful);
        }
        #endregion

        #region Connecting all data together in Container
        /// <summary>
        /// Inserting data to Container table
        /// </summary>
        /// <param name="idTask">Task ID</param>
        /// <param name="tag">Array contains tags found in task message</param>
        /// <param name="context">Array of context found in task message</param>
        /// <returns>InsertError or InsertSuccessful</returns>
        public static DBRespons insertContainerDB(decimal idTask, ArrayList tag, ArrayList context)
        {
            try
            {
                int tagCounter = tag.Count;
                int contextCounter = context.Count;
                string idTag;
                string idContext;

                // preparing new DT for contain all data
                DataTable data = new DataTable();
                data.Columns.Add("idTask", typeof(string));
                data.Columns.Add("idTag", typeof(string));
                data.Columns.Add("idContext", typeof(string));
                data.Columns.Add("idFolder", typeof(string));

                OpenTransaction();
                if (tagCounter > contextCounter)
                {
                    for (int i = 0; i < tagCounter; i++)
                    {
                        DataRow row = data.NewRow();
                        row[0] = idTask;
                        row[3] = null;

                        command.CommandText = "select idTag from Tag where tagName= :name";
                        command.Parameters.Clear();
                        command.Parameters.Add("name", DbType.String).Value = tag[i];
                        command.Prepare();
                        idTag = Convert.ToString(command.ExecuteScalar());

                        if (i >= contextCounter)
                        {
                            idContext = null;
                        }
                        else
                        {
                            command.CommandText = "select idContext from Context where contextName= :name";
                            command.Parameters.Clear();
                            command.Parameters.Add("name", DbType.String).Value = context[i];
                            command.Prepare();
                            idContext = Convert.ToString(command.ExecuteScalar());
                        }

                        // preparing data
                        row[1] = idTag;
                        row[2] = idContext;
                        data.Rows.InsertAt(row, 0);
                    }
                }

                if (tagCounter < contextCounter)
                {
                    for (int i = 0; i < contextCounter; i++)
                    {
                        DataRow row = data.NewRow();
                        row[0] = idTask;
                        row[3] = null;

                        command.CommandText = "select idContext from Context where contextName= :name";
                        command.Parameters.Add("name", DbType.String).Value = context[i];
                        command.Prepare();
                        idContext = Convert.ToString(command.ExecuteScalar());

                        if (i >= tagCounter)
                        {
                            idTag = null;
                        }
                        else
                        {
                            command.CommandText = "select idTag from Tag where tagName= :name";
                            command.Parameters.Clear();
                            command.Parameters.Add("name", DbType.String).Value = tag[i];
                            command.Prepare();
                            idTag = Convert.ToString(command.ExecuteScalar());
                        }

                        // preparing data
                        row[1] = idTag;
                        row[2] = idContext;
                    }
                }

                if (tagCounter == contextCounter)
                {
                    for (int i = 0; i < tagCounter; i++)
                    {
                        DataRow row = data.NewRow();
                        row[0] = idTask;
                        row[3] = null;

                        command.CommandText = "select idTag from Tag where tagName= :name";
                        command.Parameters.Add("name", DbType.String).Value = tag[i];
                        command.Prepare();
                        idTag = Convert.ToString(command.ExecuteScalar());

                        command.CommandText = "select idContext from Context where contextName= :name";
                        command.Parameters.Add("name", DbType.String).Value = context[i];
                        command.Prepare();
                        idContext = Convert.ToString(command.ExecuteScalar());

                        // preparing data
                        row[1] = idTag;
                        row[2] = idContext;
                    }
                }

                // inserting whole date
                foreach (DataRow row in data.Rows)
                {
                    command.CommandText = "insert into Container(Tasks_idTasks, Context_idContext, Tag_idTag) " +
                        " values(:idTask, :idContext, :idTag)";
                    command.Parameters.Clear();
                    command.Parameters.Add("idTask", DbType.VarNumeric).Value = row[0];
                    command.Parameters.Add("idContext", DbType.VarNumeric).Value = row[2];
                    command.Parameters.Add("idTag", DbType.VarNumeric).Value = row[1];
                    command.Prepare();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                RollbackTransaction();
                return new DBRespons(DBStatus.InsertError, e.Message);
            }
            return new DBRespons(DBStatus.InsertSuccessful);
        }
        #endregion

        #region Getting task list
        /// <summary>
        /// Getting table contains all tasks
        /// </summary>
        /// <param name="task">DataTable for holding data</param>
        /// <returns></returns>
        public static DBRespons getTaskList(ref DataTable task)
        {
            try
            {
                task = new DataTable();

                OpenTransaction();
                command.CommandText = "select * from Tasks order by taskEnd";
                command.Prepare();

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    task.Load(reader);
                }
            }
            catch (Exception e)
            {
                RollbackTransaction();
                return new DBRespons(DBStatus.SelectError, e.Message);
            }

            return new DBRespons(DBStatus.SelectSuccessful);
        }
        #endregion

        #region Getting folders
        public static DBRespons getFolders(SQLiteCommand command, ref DataTable folders)
        {
            try
            {
                folders = new DataTable();

                OpenTransaction();
                command.CommandText = "select * from Folders";
                command.Prepare();

                // release as fast as posible
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    folders.Load(reader);
                }
            }
            catch (Exception e)
            {
                RollbackTransaction();
                return new DBRespons(DBStatus.SelectError, e.Message);
            }
            return new DBRespons(DBStatus.SelectSuccessful);
        }
        #endregion

        #region Searching folder parent
        public static DBRespons getFolderByParent(string parent, ref DataTable folder)
        {
            try
            {
                folder = new DataTable();

                OpenTransaction();
                command.CommandText = "select folderName, idFolder, idParentFolder as idP from Folder where idParentFolder = :idSub";
                command.Parameters.Add("idSub", DbType.String).Value = parent;
                command.Prepare();

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    folder.Load(reader);
                }
            }
            catch (Exception e)
            {
                RollbackTransaction();
                return new DBRespons(DBStatus.SelectError, e.Message);
            }
            return new DBRespons(DBStatus.SelectSuccessful);
        }
        #endregion

        #region Searching tasks in parent folder
        /// <summary>
        /// Method for searching all tasks constrain with folder/node
        /// </summary>
        /// <param name="idFolder">ID folder</param>
        /// <param name="tasks">Table contains result of searching</param>
        /// <returns>SelectError or SelectSuccessful</returns>
        public static DBRespons getTasksFromFolder(string idFolder, ref DataTable tasks)
        {
            try
            {
                tasks = new DataTable();
                command.CommandText = "select t.idTasks, t.taskDesc from Tasks t, Container c where " +
                    "t.idTasks = c.Tasks_idTasks and c.Folder_idFolder = :Folder";
                command.Parameters.Clear();
                command.Parameters.Add("Folder", DbType.VarNumeric).Value = idFolder;
                command.Prepare();

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    tasks.Load(reader);
                }
            }
            catch (Exception e)
            {
                RollbackTransaction();
                return new DBRespons(DBStatus.SelectError, e.Message);
            }
            CommitTransaction();
            return new DBRespons(DBStatus.SelectSuccessful);
        }
        #endregion

        #region Creating new folder
        /// <summary>
        /// Creating new folder
        /// </summary>
        /// <param name="folderName">Folder name</param>
        /// <param name="idParentFolder">ID of parent folder if parent is a root then 0</param>
        /// <returns>InsertError or InsertSuccessful</returns>
        public static DBRespons createNewFolder(string folderName, string idParentFolder)
        {
            try
            {
                OpenTransaction();
                command.CommandText = "insert into Tasks values(:folder, :parent)";
                command.Parameters.Add("folder", DbType.String).Value = folderName;
                command.Parameters.Add("parent", DbType.VarNumeric).Value = idParentFolder;
                command.Prepare();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                RollbackTransaction();
                return new DBRespons(DBStatus.InsertError, ex.Message);
            }
            CommitTransaction();
            return new DBRespons(DBStatus.InsertSuccessful);
        }
        #endregion

        #region Getting last updated row
        /// <summary>
        /// Getting last inserted row id
        /// </summary>
        /// <param name="idRow">Returning id of last inserted row</param>
        /// <returns>SelectSuccessful or SelectError</returns>
        public static DBRespons getLastInsertedRowID(ref int idRow)
        {
            try
            {
                OpenTransaction();
                command.CommandText = "select last_insert_rowid()";
                command.Prepare();

                idRow = int.Parse(command.ExecuteScalar().ToString());
            }
            catch (Exception e)
            {
                RollbackTransaction();
                return new DBRespons(DBStatus.SelectError, e.Message);
            }
            CommitTransaction();
            return new DBRespons(DBStatus.SelectSuccessful);
        }
        #endregion
    }
}
