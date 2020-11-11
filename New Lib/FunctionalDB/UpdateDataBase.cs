using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace New_Lib
{
    public class UpdateDataBase
    {
        public static MySqlConnection conn = new MySqlConnection(LibraryForm.GetConnection());

        public static void update(string uninversalCode, string tableName, string[] dataForUpdate, DataGridView dataGridViewCatalog, string Query)
        {
            if (uninversalCode != "0")
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure?", "INFO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    conn.Open();
                    switch (tableName)
                    {
                        case "author":
                            updateAuthor(dataForUpdate);
                            ShowCatalog.ShowAuthor(dataGridViewCatalog);
                            break;

                        case "book":
                            updateBook(dataForUpdate);
                            ShowCatalog.ShowBookCatalog(dataGridViewCatalog, Query + "order by book.Code_book");
                            break;

                        case "genre":
                            updateGenre(dataForUpdate);
                            ShowCatalog.ShowGenres(dataGridViewCatalog);
                            break;

                        case "type":
                            updateType(dataForUpdate);
                            ShowCatalog.ShowTypes(dataGridViewCatalog);
                            break;

                        case "publishing_house":
                            updatePubHouse(dataForUpdate);
                            ShowCatalog.ShowPubHouses(dataGridViewCatalog);
                            break;
                    }
                    conn.Close();
                    MessageBox.Show("Updated successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private static void updateBook(string[] data)
        {
            string query = "update book set Title ='" + data[1] + "',pages=" + int.Parse(data[3]) + ",Year_publish="
                + int.Parse(data[4]) + ",Count_in_library=" + int.Parse(data[8]) + " where code_book = " + data[0];
            NewQuery.executeNonQuery(query, conn);

            updateBookPost(data, 2, 15);
            updateBookPost(data, 5, 7);
            updateBookPost(data, 6, 8);
            updateBookPost(data, 7, 10);

            conn.Close();
        }

        private static void updateBookPost(string[] data, int number, int countInDB)
        {
            if (Char.IsDigit(data[number][0]) && int.Parse(data[number]) <= countInDB)
            {
                string query = "update author_list set Code_author =" + int.Parse(data[number]) + " where code_book = " + data[0];
                NewQuery.executeNonQuery(query, conn);
            }
        }

        private static void updateGenre(string[] data)
        {
            string query = "update genre set Name_genre = '" + data[1] + "' where Code_genre = " + data[0];
            NewQuery.executeNonQuery(query, conn);
            conn.Close();
        }

        private static void updateType(string[] data)
        {
            string query = "update type set Name_type = '" + data[1] + "' where Code_type = " + data[0];
            NewQuery.executeNonQuery(query, conn);
            conn.Close();
        }

        private static void updateAuthor(string[] data)
        {
            string query = "update author set name ='" + data[1] + "',surname ='" + data[2] + "',Birthday ='"
                + data[3] + "',homeland ='" + data[4] + "' where code_author = " + data[0];
            NewQuery.executeNonQuery(query, conn);
            conn.Close();
        }

        private static void updatePubHouse(string[] data)
        {
            string query = "update publishing_house set name ='" + data[1] + "',Adress ='" + data[2] + "',City ='"
                + data[3] + "',Mail ='" + data[4] + "' where Code_publish = " + data[0];
            NewQuery.executeNonQuery(query, conn);
            conn.Close();
        }
    }
}