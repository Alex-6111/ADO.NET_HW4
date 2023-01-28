using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ADO.NET_HW4
{

    class DatabaseAccess
    {
        private SqlConnection connection;

        public DatabaseAccess(string connectionString)
        {
            connection = new SqlConnection(connectionString);
        }

        public void OpenConnection()
        {
            connection.Open();
        }

        public void CloseConnection()
        {
            connection.Close();
        }

        public void InsertData(string tableName, string values)
        {
            string query = "INSERT INTO " + tableName + " VALUES (" + values + ")";
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
        }

        public void UpdateData(string tableName, string set, string where)
        {
            string query = "UPDATE " + tableName + " SET " + set + " WHERE " + where;
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
        }

        public void DeleteData(string tableName, string where)
        {
            string query = "DELETE FROM " + tableName + " WHERE " + where;
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
        }

        public SqlDataReader SelectData(string tableName, string columns, string where)
        {
            string query = "SELECT " + columns + " FROM " + tableName;
            if (!string.IsNullOrEmpty(where))
            {
                query += " WHERE " + where;
            }
            SqlCommand command = new SqlCommand(query, connection);
            return command.ExecuteReader();
        }
    }
}
