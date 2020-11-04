using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace New_Lib
{
    public class UpdateDataBase
    {
        public static string update(MySqlConnection conn, string uninversalCode, string tableName, string[] dataForUpdate, DataGridView dataGridViewCatalog, string Query)
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
                            updateAuthor(dataForUpdate, conn);
                            tableName = ShowCatalog.showAuthor(conn, dataGridViewCatalog);
                            break;

                        case "book":
                            updateBook(dataForUpdate, conn);
                            tableName = ShowCatalog.showBookCatalog(conn, dataGridViewCatalog, Query + "order by book.Code_book");
                            break;

                        case "genre":
                            updateGenre(dataForUpdate, conn);
                            tableName = ShowCatalog.showGenres(conn, dataGridViewCatalog);
                            break;

                        case "type":
                            updateType(dataForUpdate, conn);
                            tableName = ShowCatalog.showTypes(conn, dataGridViewCatalog);
                            break;

                        case "publishing_house":
                            updatePubHouse(dataForUpdate, conn);
                            tableName = ShowCatalog.showPubHouses(conn, dataGridViewCatalog);
                            break;
                    }
                    conn.Close();
                    MessageBox.Show("Updated successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            return tableName;
        }

        private static void updateBook(string[] data, MySqlConnection conn)
        {
            string query = "update book set Title ='" + data[1] + "',pages=" + int.Parse(data[3]) + ",Year_publish="
                + int.Parse(data[4]) + ",Count_in_library=" + int.Parse(data[8]) + " where code_book = " + data[0];
            NewQuery.executeNonQuery(query, conn);

            if (Char.IsDigit(data[2][0]) && int.Parse(data[2]) <= 15)
            {
                query = "update author_list set Code_author =" + int.Parse(data[2]) + " where code_book = " + data[0];
                NewQuery.executeNonQuery(query, conn);
            }

            if (Char.IsDigit(data[5][0]) && int.Parse(data[5]) <= 7)
            {
                query = "update book set Genre =" + int.Parse(data[5]) + " where code_book = " + data[0];
                NewQuery.executeNonQuery(query, conn);
            }

            if (Char.IsDigit(data[6][0]) && int.Parse(data[6]) <= 8)
            {
                query = "update book set type =" + int.Parse(data[6]) + " where code_book = " + data[0];
                NewQuery.executeNonQuery(query, conn);
            }

            if (Char.IsDigit(data[7][0]) && int.Parse(data[7]) <= 10)
            {
                query = "update book set Code_publish =" + int.Parse(data[7]) + " where code_book = " + data[0];
                NewQuery.executeNonQuery(query, conn);
            }
            conn.Close();
        }

        private static void updateGenre(string[] data, MySqlConnection conn)
        {
            string query = "update genre set Name_genre = '" + data[1] + "' where Code_genre = " + data[0];
            NewQuery.executeNonQuery(query, conn);
            conn.Close();
        }

        private static void updateType(string[] data, MySqlConnection conn)
        {
            string query = "update type set Name_type = '" + data[1] + "' where Code_type = " + data[0];
            NewQuery.executeNonQuery(query, conn);
            conn.Close();
        }

        private static void updateAuthor(string[] data, MySqlConnection conn)
        {
            string query = "update author set name ='" + data[1] + "',surname ='" + data[2] + "',Birthday ='"
                + data[3] + "',homeland ='" + data[4] + "' where code_author = " + data[0];
            NewQuery.executeNonQuery(query, conn);
            conn.Close();
        }

        private static void updatePubHouse(string[] data, MySqlConnection conn)
        {
            string query = "update publishing_house set name ='" + data[1] + "',Adress ='" + data[2] + "',City ='"
                + data[3] + "',Mail ='" + data[4] + "' where Code_publish = " + data[0];
            NewQuery.executeNonQuery(query, conn);
            conn.Close();
        }
    }
}