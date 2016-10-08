using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace PS.DataAccess
{
    class DataAccessUtils
    {

        /// <summary>
        /// Extract additional information to log more information about a sql error to help with debugging.
        /// </summary>
        /// <param name="originalException">exception thrown by the database</param>
        /// <param name="sprocCommand">sql command object that triggered the error</param>
        /// <returns>A new exception that you can throw.</returns>
        public static Exception CreateStoredProcedureException(SqlException originalException, DbCommand sprocCommand)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Error calling stored procedure: " + originalException.Message);
            sb.Append("Stored Procedure: exec " + sprocCommand.CommandText);       

            foreach(DbParameter param in sprocCommand.Parameters)
            {
                if (param.Value == DBNull.Value)
                {
                    sb.AppendFormat(" {0} = null,", param.ParameterName);
                }
                else
                {
                    switch (param.DbType)
                    {
                        case System.Data.DbType.String:
                        case System.Data.DbType.DateTimeOffset:
                        case System.Data.DbType.StringFixedLength:
                        case System.Data.DbType.Time:
                        case System.Data.DbType.DateTime:
                            sb.AppendFormat(" {0} = '{1}',", param.ParameterName, param.Value.ToString());
                            break;

                        default:
                            sb.AppendFormat(" {0} = {1},", param.ParameterName, param.Value.ToString());
                            break;
                    }
                }
            }

            Exception ex = new Exception(sb.ToString(), originalException);
            return ex;
        }
    }
}
