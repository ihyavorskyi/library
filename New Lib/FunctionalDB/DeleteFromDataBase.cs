using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace New_Lib
{
    internal class DeleteFromDataBase
    {
        public static MySqlConnection conn = new MySqlConnection(LibraryForm.GetConnection());

        public static void delete(string code, string tableName, DataGridView dataGridViewCatalog, string Query)
        {
            if (code != "0")
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure?", "INFO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    conn.Open();
                    switch (tableName)
                    {
                        case "book":
                            delete(tableName, "code_book", code);
                            ShowCatalog.ShowBookCatalog(dataGridViewCatalog, Query + "order by book.Code_book");
                            break;

                        case "author":
                            delete(tableName, "code_author", code);
                            ShowCatalog.ShowAuthor(dataGridViewCatalog);
                            break;

                        case "genre":
                            delete(tableName, "code_genre", code);
                            ShowCatalog.ShowGenres(dataGridViewCatalog);
                            break;

                        case "type":
                            delete(tableName, "code_type", code);
                            ShowCatalog.ShowTypes(dataGridViewCatalog);
                            break;

                        case "publishing_house":
                            delete(tableName, "Code_publish", code);
                            ShowCatalog.ShowPubHouses(dataGridViewCatalog);
                            break;
                    }
                    conn.Close();
                    MessageBox.Show("Deleted successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private static void delete(string tableName, string deleteFrom, string code)
        {
            string query = "delete from " + tableName + " where " + deleteFrom + " = '" + code + "'";
            NewQuery.executeNonQuery(query, conn);
            conn.Close();
        }
    }
}