using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;


namespace WebApp.Core
{
    public static class DB
    {
        private static SqlConnection GetSqlConection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["StudentsData"].ConnectionString;
            var sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            return sqlConnection;
            
        }
        public static DataTable GetDataFromDB(string sql, List<SqlParameter> sqlPar = null)
        {
            var sqlConnection = GetSqlConection();
            var getData = new SqlCommand(sql, sqlConnection);            
            if (sqlPar != null)
            {
                foreach (var par in sqlPar)
                {
                    getData.Parameters.Add(par);
                }
            }
            var results = getData.ExecuteReader();
            DataTable dataTableRes = new DataTable();
            dataTableRes.Load(results);
            sqlConnection.Close();
            return dataTableRes;
        }

        public static int ExecScalar(string sql, List<SqlParameter> sqlPar = null) 
        {
            var sqlConnection = GetSqlConection();
            var getData = new SqlCommand(sql, sqlConnection);
            if (sqlPar != null)
            {
                foreach (var par in sqlPar)
                {
                    getData.Parameters.Add(par);
                }
            }
            var results = Convert.ToInt32(getData.ExecuteScalar());
            sqlConnection.Close();
            return results;
        }
    }
}