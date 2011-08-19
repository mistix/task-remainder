using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Collections;
using System.Data;

namespace TaskRemainder
{
    //TODO Dodać obsługę wszystkich operacji na bazie danych
    // - insertowanie danych
    // - updejtowanie danych
    // - kasowanie danych

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
                            command.CommandText = @"CREATE TABLE [Context] (" +
                                "[idContext] INTEGER  NOT NULL PRIMARY KEY AUTOINCREMENT," +
                                "[contextName] VARCHAR(255)  UNIQUE NOT NULL)";
                            command.ExecuteNonQuery();

                            //creating Tag table
                            command.CommandText = @"CREATE TABLE [Tag] (" +
                                "[idTag] INTEGER  NOT NULL PRIMARY KEY AUTOINCREMENT," +
                                "[tagName] VARCHAR(255)  NOT NULL)";
                            command.ExecuteNonQuery();

                            //Creating Folders table
                            command.CommandText = @"CREATE TABLE [Folder] (" +
                                "[idFolder] INTEGER  NOT NULL PRIMARY KEY AUTOINCREMENT," +
                                "[folderName] VARCHAR(255)  UNIQUE NOT NULL," +
                                "[idSubFolder] INTEGER  NULL)";
                            command.ExecuteNonQuery();

                            //Creating Tasks table
                            command.CommandText = @"CREATE TABLE [Tasks] (" +
                                "[idTasks] INTEGER  PRIMARY KEY AUTOINCREMENT NOT NULL," +
                                "[taskDesc] NVARCHAR(500)  NOT NULL," +
                                "[taskEnd] DATE  NULL," +
                                "[taskStart] DATE  NULL," +
                                "[finished] BOOLEAN  NOT NULL)";
                            command.ExecuteNonQuery();

                            // Creating Container tabke
                            command.CommandText = @"CREATE TABLE [Container] (" +
                                "[idContainer] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, " +
                                "[Tasks_idTasks] INTEGER NULL, " +
                                "[Folder_idFolder] INTEGER NULL, " +
                                "[Tag_idTag] INTEGER NULL, " +
                                "[Context_idContext] INTEGER NULL)";
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
                transaction.Rollback(); // if error Rollback transaction
                return new DBRespons(DBStatus.InitDBError, e.Message);
            }
            transaction.Commit(); // everything is ok
            return new DBRespons(DBStatus.InitDBSuccessful);
        }
        #endregion

        #region Inserting tag, context into DB
        /// <summary>
        /// Adding context to DB
        /// </summary>
        /// <param name="context">ArrayList of context gathering from task</param>
        /// <returns>InsertError or InsertSuccessful</returns>
        public static DBRespons insertContextDB(ArrayList context)
        {
            try
            {
                OpenTransaction();
                foreach (string item in context) // adding all new context into DB
                {
                    command.CommandText = "insert into Context(contextName) values(:name)";
                    command.Parameters.Clear();
                    command.Parameters.Add("name", System.Data.DbType.String).Value = item;
                    command.ExecuteNonQuery();
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
        public static DBRespons insertTagDB(ArrayList tag)
        {
            try
            {
                OpenTransaction();
                foreach (string item in tag) // adding all new context into DB
                {
                    command.CommandText = "insert into Tag(tagName) values(:name)";
                    command.Parameters.Clear();
                    command.Parameters.Add("name", System.Data.DbType.String).Value = item;
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
                SQLiteDataReader reader = command.ExecuteReader();
                tag_list.Load(reader);
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
        /// <returns>DBRespons</returns>
        public static DBRespons insertNewTask(string taskMsg, string dateEnd, string dateStart, bool finished)
        {
            try
            {
                OpenTransaction();
                command.CommandText = "insert into Tasks(taskDesc, taskStart, taskEnd, finished) values(:taskMsg, " +
                    ":start, :end, :finished)";
                command.Parameters.Clear();
                command.Parameters.Add("taskDesc", DbType.String).Value = taskMsg;
                command.Parameters.Add("start", DbType.Date).Value = dateStart;
                command.Parameters.Add("end", DbType.Date).Value = dateEnd;
                command.Parameters.Add("finished", DbType.Boolean).Value = finished;
                command.Prepare();
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                RollbackTransaction();
                return new DBRespons(DBStatus.InsertError, e.Message);
            }
            CommitTransaction();
            return new DBRespons(DBStatus.SelectSuccessful);
        }
        #endregion
    }
}
