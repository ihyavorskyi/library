using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace New_Lib
{
    public class AddToDataBase
    {
        public static MySqlConnection conn = new MySqlConnection(LibraryForm.GetConnection());

        public static string add(int idAdd, DataGridView dataGridViewCatalog, string tableName, string Query)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure?", "INFO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                conn.Open();
                switch (idAdd)
                {
                    case 1:
                        postAdd(dataGridViewCatalog, "genre");
                        tableName = ShowCatalog.ShowGenres(dataGridViewCatalog);
                        break;

                    case 2:
                        postAdd(dataGridViewCatalog, "type");
                        tableName = ShowCatalog.ShowTypes(dataGridViewCatalog);
                        break;

                    case 3:
                        postAdd(dataGridViewCatalog, "author");
                        tableName = ShowCatalog.ShowAuthor(dataGridViewCatalog);
                        break;

                    case 4:
                        postAdd(dataGridViewCatalog, "publishing_house");
                        tableName = ShowCatalog.ShowPubHouses(dataGridViewCatalog);
                        break;

                    case 5:
                        bookAdd(dataGridViewCatalog);
                        tableName = ShowCatalog.ShowBookCatalog(dataGridViewCatalog, Query + "order by book.Code_book");
                        break;

                    case 6:
                        postAdd(dataGridViewCatalog, "patent");
                        tableName = ShowCatalog.ShowPatents(dataGridViewCatalog);
                        break;

                    case 7:
                        postAdd(dataGridViewCatalog, "articles");
                        tableName = ShowCatalog.ShowArticles(dataGridViewCatalog);
                        break;
                }
                MessageBox.Show("Added successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return tableName;
        }

        private static void postAdd(DataGridView dataGridView, string tableName)
        {
            for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
            {
                string query = "insert into " + tableName + " values (null,'";
                for (int j = 1; j < dataGridView.Rows[i].Cells.Count; j++)
                {
                    query += dataGridView.Rows[i].Cells[j].Value.ToString();
                    if (j != dataGridView.Rows[i].Cells.Count - 1)
                    {
                        query += "','";
                    }
                }
                query += "');";
                NewQuery.executeNonQuery(query, conn);
            }
            conn.Close();
        }

        private static void bookAdd(DataGridView dataGridView)
        {
            for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
            {
                string code_book = "";
                string title = dataGridView.Rows[i].Cells[1].Value.ToString();
                string author = dataGridView.Rows[i].Cells[2].Value.ToString();
                string pages = dataGridView.Rows[i].Cells[3].Value.ToString();
                string year = dataGridView.Rows[i].Cells[4].Value.ToString();
                string genre = dataGridView.Rows[i].Cells[5].Value.ToString();
                string type = dataGridView.Rows[i].Cells[6].Value.ToString();
                string pubHouse = dataGridView.Rows[i].Cells[7].Value.ToString();
                string count = dataGridView.Rows[i].Cells[8].Value.ToString();

                string query = "insert into book values (null,'" + title + "','" + pages + "','" + year + "','" + pubHouse + "','" + genre + "','" + type + "','" + count + "');";
                NewQuery.executeNonQuery(query, conn);

                query = "select max(Code_book) from book";
                MySqlCommand command = new MySqlCommand(query, conn);
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    code_book = reader[0].ToString();
                }
                reader.Close();

                query = "insert into author_list values (null,'" + author + "','" + code_book + "');";
                NewQuery.executeNonQuery(query, conn);
            }
            conn.Close();
        }
    }
}