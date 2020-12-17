using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Windows.Forms;

namespace New_Lib
{
    internal class ShowCatalog
    {
        public static MySqlConnection conn = new MySqlConnection(LibraryForm.GetConnection());

        public static void Select(DataGridView dataGridViewCatalog, int count, string table)
        {
            conn.Open();
            MySqlDataReader reader = NewQuery.executeReader("select * from " + table, conn);
            List<string[]> data = ResponseDB.responce(reader, count);
            conn.Close();

            AddRowsToDataGridView.addRows(data, dataGridViewCatalog);
        }

        public static string ShowAuthor(DataGridView dataGridViewCatalog)
        {
            dataGridViewCatalog = DGVColumn.Clear(dataGridViewCatalog);
            dataGridViewCatalog = DGVColumn.addColumnToAuthohrs(dataGridViewCatalog);
            Select(dataGridViewCatalog, 5, "author");
            return "author";
        }

        public static string ShowPatents(DataGridView dataGridViewCatalog)
        {
            dataGridViewCatalog = DGVColumn.Clear(dataGridViewCatalog);
            dataGridViewCatalog = DGVColumn.addColumnToPatents(dataGridViewCatalog);
            Select(dataGridViewCatalog, 6, "patent");
            return "patent";
        }

        public static string ShowPubHouses(DataGridView dataGridViewCatalog)
        {
            dataGridViewCatalog = DGVColumn.Clear(dataGridViewCatalog);
            dataGridViewCatalog = DGVColumn.addColumnToPubHouses(dataGridViewCatalog);
            Select(dataGridViewCatalog, 5, "publishing_house");
            return "publishing_house";
        }

        public static string ShowArticles(DataGridView dataGridViewCatalog)
        {
            dataGridViewCatalog = DGVColumn.Clear(dataGridViewCatalog);
            dataGridViewCatalog = DGVColumn.addColumnToArticles(dataGridViewCatalog);
            Select(dataGridViewCatalog, 5, "articles");
            return "articles";
        }

        public static string ShowMembers(DataGridView dataGridViewCatalog)
        {
            dataGridViewCatalog = DGVColumn.Clear(dataGridViewCatalog);
            dataGridViewCatalog = DGVColumn.addColumnToMembers(dataGridViewCatalog);
            Select(dataGridViewCatalog, 5, "members");
            return "members";
        }

        public static string ShowGenres(DataGridView dataGridViewCatalog)
        {
            dataGridViewCatalog = DGVColumn.Clear(dataGridViewCatalog);
            dataGridViewCatalog.Columns.Add("Code_genre", "ID");
            dataGridViewCatalog.Columns[0].ReadOnly = true;
            dataGridViewCatalog.Columns.Add("Name_genre", "Genre name");
            Select(dataGridViewCatalog, 2, "genre");
            return "genre";
        }

        public static string ShowTypes(DataGridView dataGridViewCatalog)
        {
            dataGridViewCatalog = DGVColumn.Clear(dataGridViewCatalog);
            dataGridViewCatalog.Columns.Add("Code_type", "ID");
            dataGridViewCatalog.Columns[0].ReadOnly = true;
            dataGridViewCatalog.Columns.Add("Name_type", "Type name");
            Select(dataGridViewCatalog, 2, "type");
            return "type";
        }

        public static string ShowBookCatalog(DataGridView dataGridViewCatalog, string query)
        {
            dataGridViewCatalog = DGVColumn.Clear(dataGridViewCatalog);
            dataGridViewCatalog = DGVColumn.addColumnToBookCatalog(dataGridViewCatalog);

            conn.Open();
            MySqlDataReader reader = NewQuery.executeReader(query, conn);
            List<string[]> data = ResponseDB.books(reader);
            conn.Close();

            AddRowsToDataGridView.addRows(data, dataGridViewCatalog);
            return "book";
        }

        public static void ShowMyBooks(DataGridView dataGridViewMyBooks, int codeMember)
        {
            dataGridViewMyBooks = DGVColumn.Clear(dataGridViewMyBooks);
            dataGridViewMyBooks = DGVColumn.addColumnToMyBook(dataGridViewMyBooks);

            conn.Open();
            string query = "SELECT book.Code_book,Title,Name_genre,Name_type,publishing_house.Name," +
                "author.Name,author.Surname,Date_issue FROM members join on_hands on members.Code_member=on_hands.Code_member" +
                " join book on book.Code_book=on_hands.Code_book join genre on genre.Code_genre=book.Genre" +
                " join type on type.Code_type=book.type join publishing_house on book.Code_publish=publishing_house.Code_publish" +
                " join author_list on author_list.Code_book=book.Code_book join author on author_list.Code_author=author.Code_author " +
                "where on_hands.Code_member = " + codeMember + " ;";

            MySqlDataReader reader = NewQuery.executeReader(query, conn);
            List<string[]> data = ResponseDB.myBooks(reader);
            conn.Close();

            AddRowsToDataGridView.addRows(data, dataGridViewMyBooks);
        }

        public static void ShowOnHandsBooks(DataGridView dataGridViewOnHands)
        {
            dataGridViewOnHands = DGVColumn.Clear(dataGridViewOnHands);
            dataGridViewOnHands = DGVColumn.addColumnToOnHandsBook(dataGridViewOnHands);

            conn.Open();
            string query = "SELECT on_hands.Code,book.Code_book,Title,members.Name,members.Surname,members.Adress," +
                "members.Phone_number,Date_issue FROM members join on_hands on members.Code_member=on_hands.Code_member" +
                " join book on book.Code_book=on_hands.Code_book join genre on genre.Code_genre=book.Genre" +
                " join type on type.Code_type=book.type join publishing_house on book.Code_publish=publishing_house.Code_publish" +
                " join author_list on author_list.Code_book=book.Code_book join author on author_list.Code_author=author.Code_author order by on_hands.Code;";

            MySqlDataReader reader = NewQuery.executeReader(query, conn);
            List<string[]> data = ResponseDB.onHandsBooks(reader);
            conn.Close();

            AddRowsToDataGridView.addRows(data, dataGridViewOnHands);
        }
    }
}