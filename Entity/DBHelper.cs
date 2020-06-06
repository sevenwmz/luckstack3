using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Data.SqlClient;

namespace Entity
{
    public class DBHelper
    {
        /// <summary>
        /// Database connection string
        /// </summary>
        private const string _connectionToDatabase = "Data Source=-20191126PKLSWP;Initial Catalog=17bang;Integrated Security=True";

        /// <summary>
        /// For out connection
        /// </summary>
        public DbConnection Connection
        {
            get => new SqlConnection(_connectionToDatabase);
        }


        /// <summary>
        /// Excute ADO.NET sql command
        /// </summary>
        /// <param name="cmdText">Need Sql command string</param>
        /// <param name="parametersName">Need sql parameters</param>
        public void ExcuteNonQuery(string cmdText, params SqlParameter[] parametersName)
        {
            DbConnection connection = Connection;
            new DBHelper().ExcuteNonQuery(cmdText,connection,parametersName);
        }
        /// <summary>
        /// Excute ADO.NET sql command
        /// </summary>
        /// <param name="cmdText">Need Sql command string</param>
        /// <param name="connection">Need DbConnection connection</param>
        /// <param name="parameterName">Need sql parameters</param>
        public void ExcuteNonQuery(string cmdText, DbConnection connection, params SqlParameter[] parameterName)
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            using (DbCommand cmd = new SqlCommand(cmdText, (SqlConnection)connection))
            {
                cmd.Parameters.AddRange(parameterName);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Return Insert Id
        /// </summary>
        /// <param name="cmdText">Sql CmdText</param>
        /// <param name="parametersName">SqlParameters</param>
        /// <returns></returns>
        public int Insert(string cmdText, params SqlParameter[] parametersName)
        {
            return new DBHelper().Insert(Connection,cmdText,parametersName);
        }

        /// <summary>
        /// Excute ADO.NET sql command And return Insert Id
        /// </summary>
        /// <param name="cmdText">Need Sql command string</param>
        /// <param name="connection">Need DbConnection connection</param>
        /// <param name="parameterName">Need sql parameters</param>
        public int Insert(DbConnection connection, string cmdText, params SqlParameter[] parameterName)
        {
            cmdText = cmdText + " Set @NewId = @@Identity ";
            DbCommand cmd = new SqlCommand(cmdText, (SqlConnection)connection);
            SqlParameter pId = new SqlParameter("@NewId", System.Data.SqlDbType.Int)
            {
                Direction = System.Data.ParameterDirection.Output
            };
            cmd.Parameters.Add(pId);
            cmd.Parameters.AddRange(parameterName);
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            cmd.ExecuteNonQuery();

            return Convert.ToInt32(pId.Value);
        }

        /// <summary>
        /// Retrun string scalar
        /// </summary>
        /// <param name="cmdText">Need Sql command string</param>
        /// <param name="parameterName">Need sql parameter</param>
        /// <returns></returns>
        public string ExcuteScalar(string cmdText, SqlParameter parameterName)
        {
            DbConnection connection = Connection;
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

            try
            {
                DbCommand cmd = new SqlCommand(cmdText, (SqlConnection)connection);
                cmd.Parameters.Add(parameterName);
                object reader = cmd.ExecuteScalar();
                if (reader == DBNull.Value)
                {
                    return null;
                }//else nothing.
                if (string.IsNullOrEmpty(reader.ToString()))
                {
                    return null;
                }//else nothing.
                return reader.ToString();

            }
            finally
            {
                connection.Close();
            }
        }
        /// <summary>
        /// Retrun string scalar
        /// </summary>
        /// <param name="cmdText">Need Sql command string</param>
        /// <param name="parameterName">Need sql parameter</param>
        /// <param name="connection">Need DbConnection connection</param>
        /// <returns></returns>
        public string ExcuteScalar(string cmdText, SqlParameter parameterName, DbConnection connection)
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

            DbCommand cmd = new SqlCommand(cmdText, (SqlConnection)connection);
            cmd.Parameters.Add(parameterName);
            object reader = cmd.ExecuteScalar();

            if (reader == DBNull.Value)
            {
                return null;
            }//else nothing.
            if (string.IsNullOrEmpty(reader.ToString()))
            {
                return null;
            }//else nothing.
            return reader.ToString();
        }

        /// <summary>
        /// Return one of DbDataReader result
        /// </summary>
        /// <param name="cmdText">Need Sql command string</param>
        /// <param name="connection">Need DbConnection connection</param>
        /// <returns></returns>
        public DbDataReader ExcuteReader(string cmdText, DbConnection connection)
        {
            DbCommand cmd = new SqlCommand(cmdText, (SqlConnection)connection);
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            DbDataReader reader = cmd.ExecuteReader();
            return reader;
        }

        public DbDataReader ExcuteReader(string cmdText, DbConnection connection, params SqlParameter[] parameterName)
        {
            DbCommand cmd = new SqlCommand(cmdText, (SqlConnection)connection);
            cmd.Parameters.AddRange(parameterName);
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            DbDataReader reader = cmd.ExecuteReader();
            return reader;
        }
    }
}
