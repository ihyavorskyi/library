using MySql.Data.MySqlClient;

namespace New_Lib
{
    internal class DeleteFromDataBase
    {
        public static void delete(string tableName, string deleteFrom, string uninversalCode, MySqlConnection conn)
        {
            string query = "delete from " + tableName + " where " + deleteFrom + " = '" + uninversalCode + "'";
            NewQuery.executeNonQuery(query, conn);
            conn.Close();
        }
    }
}