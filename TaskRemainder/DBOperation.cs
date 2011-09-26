using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Collections;
using System.Data;

namespace TaskRemainder
{
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

                    // opening new transaction and connection
                    OpenTransaction();

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
                        "[folderName] VARCHAR(255) NOT NULL, " +
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
            CommitTransaction();
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
        /// <param name="idFolder">ID of folder who contains current task</param>
        /// <returns>InsertError or InsertSuccessful</returns>
        public static DBRespons insertContainerDB(decimal idTask, ArrayList tag, ArrayList context, string idFolder)
        {
            try
            {
                int tagCounter;
                int contextCounter;

                if (tag == null)
                    tagCounter = 0;
                else
                    tagCounter = tag.Count;

                if (context == null)
                    contextCounter = 0;
                else
                    contextCounter = context.Count;

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
                        row[3] = idFolder;

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
                        row[3] = idFolder;

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
                        data.Rows.InsertAt(row, 0);
                    }
                }

                if (tagCounter == contextCounter)
                {
                    for (int i = 0; i < tagCounter; i++)
                    {
                        DataRow row = data.NewRow();
                        row[0] = idTask;
                        row[3] = idFolder;

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
                        data.Rows.InsertAt(row, 0);
                    }
                }

                // no tags and context in message
                if ((tagCounter == 0) && (contextCounter == 0))
                {
                    DataRow row = data.NewRow();
                    row[0] = idTask;
                    row[3] = idFolder;
                    row[1] = null;
                    row[2] = null;
                    data.Rows.InsertAt(row, 0);
                }

                // inserting whole date
                foreach (DataRow row in data.Rows)
                {
                    command.CommandText = "insert into Container(Tasks_idTasks, Context_idContext, Tag_idTag, Folder_idFolder) " +
                        " values(:idTask, :idContext, :idTag, :idFolder)";
                    command.Parameters.Clear();
                    command.Parameters.Add("idTask", DbType.VarNumeric).Value = row[0];
                    command.Parameters.Add("idContext", DbType.VarNumeric).Value = row[2];
                    command.Parameters.Add("idTag", DbType.VarNumeric).Value = row[1];
                    command.Parameters.Add("idFolder", DbType.VarNumeric).Value = row[3];
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

        #region Updating task status
        /// <summary>
        /// Updating data describing if task is finished or not
        /// </summary>
        /// <param name="idTask">ID task</param>
        /// <param name="finished">true or false</param>
        /// <returns>UpdateError, UpdateSuccessful</returns>
        public static DBRespons taskFinished(string idTask, bool finished)
        {
            try
            {
                command.CommandText = "update Tasks set finished = :finished where idTasks = :idTask";
                command.Parameters.Add("finished", DbType.Boolean).Value = finished;
                command.Parameters.Add("idTask", DbType.VarNumeric).Value = idTask;
                command.Prepare();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                RollbackTransaction();
                return new DBRespons(DBStatus.UpdateError, ex.Message);
            }
            CommitTransaction();
            return new DBRespons(DBStatus.UpdateSuccessful);
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
                command.CommandText = "insert into Folder values((select max(idFolder)+1 from Folder),:folder, :parent)";
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

        #region Updating folder and task position
        /// <summary>
        /// Updating position of folder
        /// </summary>
        /// <param name="idParent">ID parent folder if 0 it is root</param>
        /// <param name="folderName">Name of folder</param>
        /// <param name="idFolder">ID folder</param>
        /// <returns>UpdateSuccessful or UpdateError</returns>
        public static DBRespons updateFolderPosition(string idParent, string folderName, string idFolder)
        {
            try
            {
                OpenTransaction();
                command.CommandText = "update Folder set folderName = :name, idParentFolder = :parent where idFolder = :idF";
                command.Parameters.Add("parent", DbType.VarNumeric).Value = idParent;
                command.Parameters.Add("idF", DbType.VarNumeric).Value = idFolder;
                command.Parameters.Add("name", DbType.String).Value = folderName;
                command.Prepare();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                RollbackTransaction();
                return new DBRespons(DBStatus.UpdateError, ex.Message);
            }
            CommitTransaction();
            return new DBRespons(DBStatus.UpdateSuccessful);
        }

        /// <summary>
        /// Updating task position
        /// </summary>
        /// <param name="idTasks">ID task</param>
        /// <param name="idFolder">ID folder</param>
        /// <returns>UpdateSuccessful or UpdateError</returns>
        public static DBRespons updateTaskPosition(string idTasks, string idFolder)
        {
            try
            {
                OpenTransaction();
                command.CommandText = "update Container set Folder_idFolder = :idFolder where Tasks_idTasks = :idTask";
                command.Parameters.Add("idFolder", DbType.VarNumeric).Value = idFolder;
                command.Parameters.Add("idTask", DbType.VarNumeric).Value = idTasks;
                command.Prepare();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                RollbackTransaction();
                return new DBRespons(DBStatus.UpdateError, ex.Message);
            }
            CommitTransaction();
            return new DBRespons(DBStatus.UpdateSuccessful);
        }
        #endregion

        #region Updating task information
        /// <summary>
        /// Updating informations about task
        /// </summary>
        /// <param name="idTasks">ID task</param>
        /// <param name="taskDesc">task information</param>
        /// <param name="taskEnd">task date end</param>
        /// <param name="taskBegin">task date start</param>
        /// <param name="finished">is task finished</param>
        /// <returns>UpdateSuccessful or UpdateError</returns>
        public static DBRespons updateTasksDB(string idTasks, string taskDesc, string taskEnd, string taskBegin, bool finished)
        {
            try
            {
                OpenTransaction();
                command.CommandText = "update Tasks set taskDesc=:taskDesc, taskEnd=:taskEnd, taskStart=:taskBegin, " +
                    " finished=:finished where idTasks=:idTasks";
                command.Parameters.Clear();
                command.Parameters.Add("taskDesc", DbType.String).Value = taskDesc;
                command.Parameters.Add("taskEnd", DbType.Date).Value = taskEnd;
                command.Parameters.Add("taskBegin", DbType.Date).Value = taskBegin;
                command.Parameters.Add("finished", DbType.Boolean).Value = finished;
                command.Parameters.Add("idTasks", DbType.VarNumeric).Value = idTasks;
                command.Prepare();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                RollbackTransaction();
                return new DBRespons(DBStatus.UpdateError, ex.Message);
            }
            CommitTransaction();
            return new DBRespons(DBStatus.UpdateSuccessful);
        }

        /// <summary>
        /// Updating tasks description (used in edit task treeView)
        /// </summary>
        /// <param name="idTasks">ID tasks</param>
        /// <param name="taskDesc">task description</param>
        /// <returns>UpdateSuccessful or UpdateError</returns>
        public static DBRespons updateTaskDescriptionDB(string idTasks, string taskDesc)
        {
            try
            {
                OpenTransaction();
                command.CommandText = "update Tasks set taskDesc = :taskDesc where idTasks = :idTasks";
                command.Parameters.Add("taskDesc", DbType.String).Value = taskDesc;
                command.Parameters.Add("idTasks", DbType.VarNumeric).Value = idTasks;
                command.Prepare();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                RollbackTransaction();
                return new DBRespons(DBStatus.UpdateError, ex.Message);
            }
            CommitTransaction();
            return new DBRespons(DBStatus.UpdateSuccessful);
        }
        #endregion

        #region Update folder name
        /// <summary>
        /// Updating folder name after user changed it
        /// </summary>
        /// <param name="idFolder">ID folder</param>
        /// <param name="folderName">New folder name</param>
        /// <returns>UpdateError or UpdateSuccessful</returns>
        public static DBRespons updateFolderName(string idFolder, string folderName)
        {
            try
            {
                command.CommandText = "update Folder set folderName = :folder where idFolder = :idF";
                command.Parameters.Add("folder", DbType.String).Value = folderName;
                command.Parameters.Add("idF", DbType.VarNumeric).Value = idFolder;
                command.Prepare();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                RollbackTransaction();
                return new DBRespons(DBStatus.UpdateError, ex.Message);
            }
            CommitTransaction();
            return new DBRespons(DBStatus.UpdateSuccessful);
        }
        #endregion

        #region Removing folder
        /// <summary>
        /// Removing folder from DB
        /// </summary>
        /// <param name="idFolder">ID folder to remove</param>
        /// <returns>DeleteError or DeleteSuccessful</returns>
        public static DBRespons removingFolder(string idFolder)
        {
            try
            {
                command.CommandText = "delete from Folder where idFolder = :idFolder";
                command.Parameters.Add("idFolder", DbType.VarNumeric).Value = idFolder;
                command.Prepare();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                RollbackTransaction();
                return new DBRespons(DBStatus.DeleteError, ex.Message);
            }
            CommitTransaction();
            return new DBRespons(DBStatus.DeleteSuccessful);
        }
        #endregion

        #region Removnig Container
        /// <summary>
        /// Removing folder from Container
        /// </summary>
        /// <param name="idTasks">ID of task to remove</param>
        /// <returns>DeleteError or DeleteSuccessful</returns>
        public static DBRespons removingTask(string idTasks)
        {
            try
            {
                // removing from Container
                command.CommandText = "delete from Container where Tasks_idTasks = :idFolder";
                command.Parameters.Add("idFolder", DbType.VarNumeric).Value = idTasks;
                command.Prepare();
                command.ExecuteNonQuery();
                
                // removing from Tasks
                command.Parameters.Clear();
                command.CommandText = "delete from Tasks where idTasks = :idFolder";
                command.Parameters.Add("idFolder", DbType.VarNumeric).Value = idTasks;
                command.Prepare();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                RollbackTransaction();
                return new DBRespons(DBStatus.DeleteError, ex.Message);
            }
            CommitTransaction();
            return new DBRespons(DBStatus.DeleteSuccessful);
        }
        #endregion

        #region Task date (start task and end task)
        /// <summary>
        /// Getting start and end task date
        /// </summary>
        /// <param name="idTasks">ID task</param>
        /// <param name="date">Table contains date end and start</param>
        /// <returns>SelectSuccessfull and SelectError</returns>
        static public DBRespons getTaskDate(string idTasks, ref DataTable date)
        {
            try
            {
                date = new DataTable();

                OpenTransaction();
                command.CommandText = "select taskEnd, taskStart FROM Tasks";
                command.Prepare();

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    date.Load(reader);
                }
            }
            catch (Exception ex)
            {
                return new DBRespons(DBStatus.SelectError, ex.Message);
            }
            return new DBRespons(DBStatus.SelectSuccessful);
        }
        #endregion

        #region Information about task
        /// <summary>
        /// Getting all nessesary information about tas
        /// </summary>
        /// <param name="idTasks">ID task</param>
        /// <param name="date">Table contains informations about task</param>
        /// <returns>SelectSuccessful or SelectError</returns>
        static public DBRespons getTaskInformation(string idTasks, ref DataTable date)
        {
            try
            {
                date = new DataTable();

                OpenTransaction();
                // date information
                command.CommandText = "select t.taskStart, t.taskEnd, tg.tagName, ct.contextName FROM Container c " +
                    "LEFT OUTER JOIN Tag tg ON c.Tag_idTag=tg.idTag " +
                    "LEFT OUTER JOIN Context ct ON ct.idContext=c.Context_idContext " +
                    "LEFT OUTER JOIN Tasks t ON t.idTasks=c.Tasks_idTasks " +
                    "WHERE c.Tasks_idTasks=:idTask";
                command.Parameters.Add("idTask", DbType.VarNumeric).Value = idTasks;
                command.Prepare();

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    date.Load(reader);
                }
            }
            catch (Exception ex)
            {
                return new DBRespons(DBStatus.SelectError, ex.Message);
            }
            return new DBRespons(DBStatus.SelectSuccessful);
        }
        #endregion
    }
}
