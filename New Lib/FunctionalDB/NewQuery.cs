using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace New_Lib
{
    public class NewQuery
    {
        public static void executeNonQuery(string query, MySqlConnection conn)
        {
            try
            {
                MySqlCommand command = new MySqlCommand(query, conn);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("Eror! " + e.Message, "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public static MySqlDataReader executeReader(string query, MySqlConnection conn)
        {
            MySqlCommand command = new MySqlCommand(query, conn);
            MySqlDataReader reader = command.ExecuteReader();
            return reader;
        }
    }
}