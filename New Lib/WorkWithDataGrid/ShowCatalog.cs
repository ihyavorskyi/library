using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Windows.Forms;

namespace New_Lib
{
    internal class ShowCatalog
    {
        public static string showAuthor(MySqlConnection conn, DataGridView dataGridViewCatalog)
        {
            dataGridViewCatalog = AddColumnToDataGridView.ClearDataGridView(dataGridViewCatalog);
            dataGridViewCatalog = AddColumnToDataGridView.addColumnToAuthohrs(dataGridViewCatalog);

            conn.Open();
            MySqlDataReader reader = NewQuery.executeReader("select * from author", conn);
            List<string[]> data = NewStringList.authors(reader);
            conn.Close();

            AddRowsToDataGridView.addRows(data, dataGridViewCatalog);
            return "author";
        }

        public static string showPubHouses(MySqlConnection conn, DataGridView dataGridViewCatalog)
        {
            dataGridViewCatalog = AddColumnToDataGridView.ClearDataGridView(dataGridViewCatalog);
            dataGridViewCatalog = AddColumnToDataGridView.addColumnToPubHouses(dataGridViewCatalog);

            conn.Open();
            MySqlDataReader reader = NewQuery.executeReader("select * from `publishing_house`", conn);
            List<string[]> data = NewStringList.pubHouse(reader);
            conn.Close();

            AddRowsToDataGridView.addRows(data, dataGridViewCatalog);
            return "publishing_house";
        }

        public static string showMembers(MySqlConnection conn, DataGridView dataGridViewCatalog)
        {
            dataGridViewCatalog = AddColumnToDataGridView.ClearDataGridView(dataGridViewCatalog);
            dataGridViewCatalog = AddColumnToDataGridView.addColumnToMembers(dataGridViewCatalog);

            conn.Open();
            MySqlDataReader reader = NewQuery.executeReader("select * from members", conn);
            List<string[]> data = NewStringList.members(reader);
            conn.Close();

            AddRowsToDataGridView.addRows(data, dataGridViewCatalog);
            return "members";
        }

        public static string showGenres(MySqlConnection conn, DataGridView dataGridViewCatalog)
        {
            dataGridViewCatalog = AddColumnToDataGridView.ClearDataGridView(dataGridViewCatalog);

            dataGridViewCatalog.Columns.Add("Code_genre", "ID");
            dataGridViewCatalog.Columns[0].ReadOnly = true;
            dataGridViewCatalog.Columns.Add("Name_genre", "Genre name");

            conn.Open();
            MySqlDataReader reader = NewQuery.executeReader("select * from genre", conn);
            List<string[]> data = NewStringList.genres(reader);
            conn.Close();

            AddRowsToDataGridView.addRows(data, dataGridViewCatalog);
            return "genre";
        }

        public static string showTypes(MySqlConnection conn, DataGridView dataGridViewCatalog)
        {
            dataGridViewCatalog = AddColumnToDataGridView.ClearDataGridView(dataGridViewCatalog);
            dataGridViewCatalog.Columns.Add("Code_type", "ID");
            dataGridViewCatalog.Columns[0].ReadOnly = true;
            dataGridViewCatalog.Columns.Add("Name_type", "Type name");

            conn.Open();
            MySqlDataReader reader = NewQuery.executeReader("select * from type", conn);
            List<string[]> data = NewStringList.types(reader);
            conn.Close();

            AddRowsToDataGridView.addRows(data, dataGridViewCatalog);
            return "type";
        }

        public static string showBookCatalog(MySqlConnection conn, DataGridView dataGridViewCatalog, string query)
        {
            dataGridViewCatalog = AddColumnToDataGridView.ClearDataGridView(dataGridViewCatalog);
            dataGridViewCatalog = AddColumnToDataGridView.addColumnToBookCatalog(dataGridViewCatalog);

            conn.Open();
            MySqlDataReader reader = NewQuery.executeReader(query, conn);
            List<string[]> data = NewStringList.books(reader);
            conn.Close();

            AddRowsToDataGridView.addRows(data, dataGridViewCatalog);
            return "book";
        }

        public static void showMyBooks(MySqlConnection conn, DataGridView dataGridViewMyBooks, int codeMember)
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
            List<string[]> data = NewStringList.myBooks(reader);
            conn.Close();

            AddRowsToDataGridView.addRows(data, dataGridViewMyBooks);
        }

        public static void showOnHandsBooks(MySqlConnection conn, DataGridView dataGridViewOnHands)
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
            List<string[]> data = NewStringList.onHandsBooks(reader);
            conn.Close();

            AddRowsToDataGridView.addRows(data, dataGridViewOnHands);
        }
    }
}