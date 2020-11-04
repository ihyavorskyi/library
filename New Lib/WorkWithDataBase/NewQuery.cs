using MySql.Data.MySqlClient;

namespace New_Lib
{
    public class NewQuery
    {
        public static void executeNonQuery(string query, MySqlConnection conn)
        {
            MySqlCommand command = new MySqlCommand(query, conn);
            command.ExecuteNonQuery();
        }

        public static MySqlDataReader executeReader(string query, MySqlConnection conn)
        {
            MySqlCommand command = new MySqlCommand(query, conn);
            MySqlDataReader reader = command.ExecuteReader();
            return reader;
        }
    }
}