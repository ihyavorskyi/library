using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace New_Lib
{
    internal class DeleteFromDataBase
    {
        public static string delete(string uninversalCode, MySqlConnection conn, string tableName, DataGridView dataGridViewCatalog, string Query)
        {
            if (uninversalCode != "0")
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure?", "INFO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    conn.Open();
                    switch (tableName)
                    {
                        case "book":
                            delete(tableName, "code_book", uninversalCode, conn);
                            tableName = ShowCatalog.showBookCatalog(conn, dataGridViewCatalog, Query + "order by book.Code_book");
                            break;

                        case "author":
                            delete(tableName, "code_author", uninversalCode, conn);
                            tableName = ShowCatalog.showAuthor(conn, dataGridViewCatalog);
                            break;

                        case "genre":
                            delete(tableName, "code_genre", uninversalCode, conn);
                            tableName = ShowCatalog.showGenres(conn, dataGridViewCatalog);
                            break;

                        case "type":
                            delete(tableName, "code_type", uninversalCode, conn);
                            tableName = ShowCatalog.showTypes(conn, dataGridViewCatalog);
                            break;

                        case "publishing_house":
                            delete(tableName, "Code_publish", uninversalCode, conn);
                            tableName = ShowCatalog.showPubHouses(conn, dataGridViewCatalog);
                            break;
                    }
                    conn.Close();
                    MessageBox.Show("Deleted successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            return tableName;
        }

        private static void delete(string tableName, string deleteFrom, string uninversalCode, MySqlConnection conn)
        {
            string query = "delete from " + tableName + " where " + deleteFrom + " = '" + uninversalCode + "'";
            NewQuery.executeNonQuery(query, conn);
            conn.Close();
        }
    }
}