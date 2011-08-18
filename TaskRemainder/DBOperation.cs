﻿using System;
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

    public static class CDBOperation
    {
        #region Variables
        static SQLiteConnection connection = null;
        static SQLiteCommand command = null;
        static SQLiteTransaction transaction = null;
        static string dataBase = "task-remainder.sql";
        #endregion

        /// <summary>
        /// Describe operation on DB
        /// </summary>
        public enum DBOperation
        {
            InsertSuccessful,
            UpdateSuccessful,
            SelectSuccessful,
            InitDBSuccessful,
            InsertError,
            UpdateError,
            SelectError,
            InitDBError
        };

        #region Open and close transaction
        private static void OpenTransaction()
        {
            if (connection == null)
            {
                connection = new SQLiteConnection("Data Source=" + dataBase);
                connection.Open();
            }

            if (transaction == null)
            {
                transaction = connection.BeginTransaction();
                command = connection.CreateCommand();
            }
        }

        private static void CloseTransaction()
        {
            if (transaction != null)
            {
                transaction.Rollback();
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
        public static DBOperation initDateBase()
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
                                "[contextName] VARCHAR(255)  UNIQUE NOT NULL, " +
                                "[Task_idTask] INTEGER NOT NULL, " +
                                "FOREIGN KEY(Task_idTask) REFERENCES Task(idTask))";
                            command.ExecuteNonQuery();

                            //creating Tag table
                            command.CommandText = @"CREATE TABLE [Tag] (" +
                                "[idTag] INTEGER  NOT NULL PRIMARY KEY AUTOINCREMENT," +
                                "[tagName] VARCHAR(255)  NOT NULL, " +
                                "[Task_idTask] INTEGER NOT NULL,  " +
                                "FOREIGN KEY(Task_idTask) REFERENCES Task(idTask))";
                            command.ExecuteNonQuery();

                            //Creating Folders table
                            command.CommandText = @"CREATE TABLE [Folder] (" +
                                "[idFolder] INTEGER  NOT NULL PRIMARY KEY AUTOINCREMENT," +
                                "[folderName] VARCHAR(255)  NULL," +
                                "[Folder_idFolder] INTEGER  UNIQUE NOT NULL)";
                            command.ExecuteNonQuery();

                            //Creating Tasks table
                            command.CommandText = @"CREATE TABLE [Tasks] (" +
                                "[idTasks] INTEGER  PRIMARY KEY AUTOINCREMENT NOT NULL," +
                                "[taskDesc] NVARCHAR(500)  NOT NULL," +
                                "[taskEnd] DATE  NULL," +
                                "[taskStart] DATE  NULL," +
                                "[finished] BOOLEAN  NOT NULL, " +
                                "[Folder_idFolder] INTEGER NOT NULL, " +
                                "FOREIGN KEY(Folder_idFolder) REFERENCES Folder(idFolder))";
                            command.ExecuteNonQuery();
                        }
                    }
                }
                else
                {
                    connection = new SQLiteConnection("Data Source=" + dataBase);
                    connection.Open();
                }
            }
            catch (Exception)
            {
                transaction.Rollback(); // if error Rollback transaction
                return DBOperation.InitDBError;
            }
            transaction.Commit(); // everything is ok

            return DBOperation.InitDBSuccessful;
        }
        #endregion

        #region Insertin tag, context into DB
        /// <summary>
        /// Adding context to DB
        /// </summary>
        /// <param name="context">ArrayList of context gathering from task</param>
        /// <returns>InsertError or InsertSuccessful</returns>
        public static DBOperation insertContextDB(ArrayList context)
        {
            try
            {
                using (transaction = connection.BeginTransaction())
                {
                    using (command = connection.CreateCommand())
                    {
                        foreach (string item in context) // adding all new context into DB
                        {
                            command.CommandText = "insert into Context(contextName) values(:name)";
                            command.Parameters.Clear();
                            command.Parameters.Add("name", System.Data.DbType.String).Value = item;

                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception)
            {
                transaction.Rollback();
                return DBOperation.InsertError;
            }

            transaction.Commit();

            return DBOperation.InsertSuccessful;
        }

        /// <summary>
        /// Insert Tag to the Tag table 
        /// </summary>
        /// <param name="tag">ArryList of tags who will be inserted into DB</param>
        /// <returns>InsertError or InsertSuccessful</returns>
        public static DBOperation insertTagDB(ArrayList tag)
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
            catch (Exception)
            {
                transaction.Rollback();
                return DBOperation.InsertError;
            }

            transaction.Commit();
            CloseTransaction();

            return DBOperation.InsertSuccessful;
        }
        #endregion

        #region Returning tables of Tag and Context
        /// <summary>
        /// Getting arraylist of tag in DB
        /// </summary>
        /// <param name="tag_list"></param>
        /// <returns></returns>
        public static DBOperation getTagTable(ref DataTable tag_list)
        {
            try
            {
                tag_list = new DataTable();
                OpenTransaction();
                command.CommandText = "select * from Tag";
                SQLiteDataReader reader = command.ExecuteReader();
                tag_list.Load(reader);
                CloseTransaction();
            }
            catch (Exception e)
            {
                CloseTransaction();
                return DBOperation.SelectError;
            }
            return DBOperation.SelectSuccessful;
        }
        #endregion


    }
}
