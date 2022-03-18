using MySql.Data.MySqlClient;
using nuestra_boda.Core.Properties;
using System.Data;

namespace nuestra_boda.Core.Models.BD
{
    public abstract class MySQLDBModel
    {
        public MySqlConnection conn;
        protected MySqlDataReader reader;
        protected MySqlCommand command;
        protected MySqlTransaction transaction;

        protected MySQLDBModel()
        {
            conn = new MySqlConnection(string.Format(Resources.ConnectionString, Resources.ServerIP, Resources.User, Resources.Password, Resources.Origin));
        }

        protected void CreateCommand(string query) => command = new MySqlCommand(query, conn);

        protected void CreateCommand() =>
            command = new MySqlCommand
            {
                Connection = conn,
                CommandType = CommandType.StoredProcedure
            };


    }
}
