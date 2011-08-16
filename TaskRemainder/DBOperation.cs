using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Collections;

namespace TaskRemainder
{
    //TODO Dodać obsługę wszystkich operacji na bazie danych
    // - insertowanie danych
    // - updejtowanie danych
    // - kasowanie danych
    public static class DBOperation
    {
        #region Variables
        static SQLiteConnection connection;
        static SQLiteCommand command;
        static SQLiteTransaction transaction;
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
        }

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
                                "[contextName] VARCHAR(255)  NOT NULL)";
                            command.ExecuteNonQuery();

                            //creating Tag table
                            command.CommandText = @"CREATE TABLE [Tag] (" +
                                "[idTag] INTEGER  NOT NULL PRIMARY KEY AUTOINCREMENT," +
                                "[tagName] VARCHAR(255)  NOT NULL)";
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
                                "[Context_idContext] INTEGER NOT NULL, " +
                                "[Tag_idTag] INTEGER NOT NULL, " +
                                "FOREIGN KEY(Folder_idFolder) REFERENCES Folder(idFolder), " +
                                "FOREIGN KEY(Context_idContext) REFERENCES Context(idContext), " +
                                "FOREIGN KEY(Tag_idTag) REFERENCES Tag(idTag))";
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

        public static DBOperation addContext(ArrayList context)
        {
            try
            {
                using (transaction = connection.BeginTransaction())
                {
                    using (command = connection.CreateCommand())
                    {
                        foreach (string item in context) // adding all new context into DB
                        {
                            command.CommandText = "insert into context(contextName) values(:name)";
                            command.Parameters.Clear();
                            command.Parameters.Add("name", System.Data.DbType.String).Value = item;
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
    }
}
