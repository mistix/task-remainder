using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskRemainder
{
    /// <summary>
    /// Describe operation on DB
    /// </summary>
    public enum DBStatus
    {
        InsertSuccessful,
        UpdateSuccessful,
        SelectSuccessful,
        InitDBSuccessful,
        OpenSuccessful,
        InsertError,
        UpdateError,
        SelectError,
        InitDBError,
        OpenError,
        DeleteSuccessful,
        DeleteError
    };


    #region DBRespons
    public class DBRespons
    {
        #region Variables
        string msg;
        DBStatus status;
        #endregion

        #region Construstor with one parameter
        /// <summary>
        /// Class used for easier describe error or success
        /// </summary>
        /// <param name="status">Operation status fail or success</param>
        public DBRespons(DBStatus status)
        {
            this.status = status;
            switch (status)
            {
                case DBStatus.InsertSuccessful:
                    msg = "Insert successful";
                    break;
                case DBStatus.UpdateSuccessful:
                    msg = "Update successful";
                    break;
                case DBStatus.SelectSuccessful:
                    msg = "select successful";
                    break;
                case DBStatus.InitDBSuccessful:
                    msg = "Init DB successful";
                    break;
                case DBStatus.OpenSuccessful:
                    msg = "Open DB successful";
                    break;
                case DBStatus.InsertError:
                    msg = "Insert error";
                    break;
                case DBStatus.UpdateError:
                    msg = "Update error";
                    break;
                case DBStatus.SelectError:
                    msg = "Select error";
                    break;
                case DBStatus.InitDBError:
                    msg = "Init DB error";
                    break;
                case DBStatus.OpenError:
                    msg = "Open DB error";
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region Constructor with two parameters
        /// <summary>
        /// Constructor used to report error operation in DB
        /// it containt exception message for easier debugin
        /// </summary>
        /// <param name="status">Operation status</param>
        /// <param name="message">Exception message</param>
        public DBRespons(DBStatus status, string message)
        {
            this.status = status;
            this.msg = message;
        }
        #endregion

        #region Information methods
        public DBStatus resultOperation()
        {
            return status;
        }

        public DBStatus result
        {
            get { return status; }
        }

        public string error
        {
            get { return msg; }
        }

        public string errorMessage()
        {
            return msg;
        }
        #endregion
    }
    #endregion
}
