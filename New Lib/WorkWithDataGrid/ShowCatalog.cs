using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace New_Lib
{
    internal class ShowCatalog
    {
        public static MySqlConnection conn = new MySqlConnection(LibraryForm.GetConnection());

        public static string ShowAuthor(DataGridView dataGridViewCatalog)
        {
            dataGridViewCatalog = AddColumnToDataGridView.ClearDataGridView(dataGridViewCatalog);
            dataGridViewCatalog = AddColumnToDataGridView.addColumnToAuthohrs(dataGridViewCatalog);

            conn.Open();
            MySqlDataReader reader = NewQuery.executeReader("select * from author", conn);
            List<string[]> data = ResponseDB.authors(reader);
            conn.Close();

            AddRowsToDataGridView.addRows(data, dataGridViewCatalog);
            return "author";
        }

        public static string ShowPubHouses(DataGridView dataGridViewCatalog)
        {
            dataGridViewCatalog = AddColumnToDataGridView.ClearDataGridView(dataGridViewCatalog);
            dataGridViewCatalog = AddColumnToDataGridView.addColumnToPubHouses(dataGridViewCatalog);

            conn.Open();
            MySqlDataReader reader = NewQuery.executeReader("select * from `publishing_house`", conn);
            List<string[]> data = ResponseDB.pubHouse(reader);
            conn.Close();

            AddRowsToDataGridView.addRows(data, dataGridViewCatalog);
            return "publishing_house";
        }

        public static string ShowMembers(DataGridView dataGridViewCatalog)
        {
            dataGridViewCatalog = AddColumnToDataGridView.ClearDataGridView(dataGridViewCatalog);
            dataGridViewCatalog = AddColumnToDataGridView.addColumnToMembers(dataGridViewCatalog);

            conn.Open();
            MySqlDataReader reader = NewQuery.executeReader("select * from members", conn);
            List<string[]> data = ResponseDB.members(reader);
            conn.Close();

            AddRowsToDataGridView.addRows(data, dataGridViewCatalog);
            return "members";
        }

        public static string ShowGenres(DataGridView dataGridViewCatalog)
        {
            dataGridViewCatalog = AddColumnToDataGridView.ClearDataGridView(dataGridViewCatalog);

            dataGridViewCatalog.Columns.Add("Code_genre", "ID");
            dataGridViewCatalog.Columns[0].ReadOnly = true;
            dataGridViewCatalog.Columns.Add("Name_genre", "Genre name");

            conn.Open();
            MySqlDataReader reader = NewQuery.executeReader("select * from genre", conn);
            List<string[]> data = ResponseDB.genres(reader);
            conn.Close();

            AddRowsToDataGridView.addRows(data, dataGridViewCatalog);
            return "genre";
        }

        public static string ShowTypes(DataGridView dataGridViewCatalog)
        {
            dataGridViewCatalog = AddColumnToDataGridView.ClearDataGridView(dataGridViewCatalog);
            dataGridViewCatalog.Columns.Add("Code_type", "ID");
            dataGridViewCatalog.Columns[0].ReadOnly = true;
            dataGridViewCatalog.Columns.Add("Name_type", "Type name");

            conn.Open();
            MySqlDataReader reader = NewQuery.executeReader("select * from type", conn);
            List<string[]> data = ResponseDB.types(reader);
            conn.Close();

            AddRowsToDataGridView.addRows(data, dataGridViewCatalog);
            return "type";
        }

        public static string ShowBookCatalog(DataGridView dataGridViewCatalog, string query)
        {
            dataGridViewCatalog = AddColumnToDataGridView.ClearDataGridView(dataGridViewCatalog);
            dataGridViewCatalog = AddColumnToDataGridView.addColumnToBookCatalog(dataGridViewCatalog);

            conn.Open();
            MySqlDataReader reader = NewQuery.executeReader(query, conn);
            List<string[]> data = ResponseDB.books(reader);
            conn.Close();

            AddRowsToDataGridView.addRows(data, dataGridViewCatalog);
            return "book";
        }

        public static void ShowMyBooks(DataGridView dataGridViewMyBooks, int codeMember)
        {
            dataGridViewMyBooks = AddColumnToDataGridView.ClearDataGridView(dataGridViewMyBooks);
            dataGridViewMyBooks = AddColumnToDataGridView.addColumnToMyBook(dataGridViewMyBooks);

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
            dataGridViewOnHands = AddColumnToDataGridView.ClearDataGridView(dataGridViewOnHands);
            dataGridViewOnHands = AddColumnToDataGridView.addColumnToOnHandsBook(dataGridViewOnHands);

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