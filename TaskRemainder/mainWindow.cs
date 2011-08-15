using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace TaskRemainder
{
    public partial class mainWindow : Form
    {
        string dataBase = "task-remainder.sql";
        SQLiteConnection connection;
        SQLiteCommand command;
        SQLiteTransaction transaction;

        public mainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Working with SQL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainWindow_Load(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(dataBase) == false)
            {
                // opening database
                connection = new SQLiteConnection("Data Source=" + dataBase);
                connection.Open();

                initDataBase(); // creating database
            }
            else
            {
                connection = new SQLiteConnection("Data Source=" + dataBase);
                connection.Open();
            }
        }

        private void initDataBase()
        {
            // Opening new transaction
            try
            {
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
                    transaction.Commit(); // commiting changes
                }
            }
            catch (SQLiteException e)
            {
                transaction.Rollback();
                MessageBox.Show(e.Message, "Error during creating database", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
