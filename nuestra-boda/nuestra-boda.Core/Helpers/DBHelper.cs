using MySql.Data.MySqlClient;
using nuestra_boda.Core.Models.BD;
using System;
using System.Collections.Generic;
using System.Data;

namespace nuestra_boda.Core.Helpers
{
    public class DBHelper : MySQLDBModel
    {
        public DBHelper() : base() { }

        public DataTable Reader(string query, Dictionary<string, object> sqlParameters)
        {
            try
            {
                conn.Open();
                CreateCommand(query);
                foreach (KeyValuePair<string, object> sqlParameter in sqlParameters)
                    command.Parameters.AddWithValue(sqlParameter.Key, sqlParameter.Value ?? DBNull.Value);
                DataTable dt = new();
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    adapter.Fill(dt);
                //MySqlDataReader reader = command.ExecuteReader();

                command.Dispose();
                

                return dt;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        public int NonQuery(string query, Dictionary<string, object> sqlParameters)
        {
            int ret;

            try
            {
                conn.Open();
                CreateCommand(query);
                foreach (KeyValuePair<string, object> sqlParameter in sqlParameters)
                    command.Parameters.AddWithValue(sqlParameter.Key, sqlParameter.Value ?? (object)DBNull.Value);

                ret = command.ExecuteNonQuery();

                //conn.Close();
                command.Dispose();

                return ret;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return -1;
            }
            finally
            {
                conn.Close();
            }
        }

        public long InsertQuery(string query, Dictionary<string, object> sqlParameters)
        {
            long ret;

            try
            {
                conn.Open();
                CreateCommand(query);
                foreach (KeyValuePair<string, object> sqlParameter in sqlParameters)
                    command.Parameters.AddWithValue(sqlParameter.Key, sqlParameter.Value ?? (object)DBNull.Value);

                _ = command.ExecuteNonQuery();
                ret = command.LastInsertedId;
                //conn.Close();
                command.Dispose();

                return ret;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return -1;
            }
            finally
            {
                conn.Close();
            }

        }
    }
}
