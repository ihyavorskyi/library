using System.Windows.Forms;

namespace New_Lib
{
    public class AddColumnToDataGridView
    {
        public static DataGridView ClearDataGridView(DataGridView dataGridView)
        {
            dataGridView.Columns.Clear();
            dataGridView.Rows.Clear();
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            return dataGridView;
        }

        public static DataGridView addColumnToMyBook(DataGridView dataGridView)
        {
            dataGridView.Columns.Add("Code_book", "ID");
            dataGridView.Columns.Add("Title", "Title of book");
            dataGridView.Columns.Add("Name_genre", "Genre");
            dataGridView.Columns.Add("Name_type", "Type");
            dataGridView.Columns.Add("Publishing_house", "Publishing house");
            dataGridView.Columns.Add("Author", "Author");
            dataGridView.Columns.Add("Date_issue", "Date_issue");
            return dataGridView;
        }

        public static DataGridView addColumnToOnHandsBook(DataGridView dataGridView)
        {
            dataGridView.Columns.Add("Code", "ID");
            dataGridView.Columns.Add("book_id", "Book_ID");
            dataGridView.Columns.Add("Title", "Title of book");
            dataGridView.Columns.Add("Member", "Member");
            dataGridView.Columns.Add("Adress", "Adress");
            dataGridView.Columns.Add("Phone_number", "Phone_number");
            dataGridView.Columns.Add("Date_issue", "Date_issue");
            return dataGridView;
        }

        public static DataGridView addColumnToBookCatalog(DataGridView dataGridView)
        {
            dataGridView.Columns.Add("Code_book", "ID");
            dataGridView.Columns[0].ReadOnly = true;
            dataGridView.Columns.Add("Title", "Title of book");
            dataGridView.Columns.Add("Author", "Author");
            dataGridView.Columns.Add("Pages", "Pages");
            dataGridView.Columns.Add("Year_publish", "Year publish");
            dataGridView.Columns.Add("Name_genre", "Genre");
            dataGridView.Columns.Add("Name_type", "Type");
            dataGridView.Columns.Add("Publishing_house", "Publishing house");
            dataGridView.Columns.Add("Count", "Count");
            return dataGridView;
        }

        public static DataGridView addColumnToAuthohrs(DataGridView dataGridView)
        {
            dataGridView.Columns.Add("Code_author", "ID");
            dataGridView.Columns[0].ReadOnly = true;
            dataGridView.Columns.Add("Name_author", "Name");
            dataGridView.Columns.Add("Surname_author", "Surname");
            dataGridView.Columns.Add("Birthday_author", "Birthday");
            dataGridView.Columns.Add("Homeland_author", "Homeland");
            return dataGridView;
        }

        public static DataGridView addColumnToPubHouses(DataGridView dataGridView)
        {
            dataGridView.Columns.Add("Code_member", "ID");
            dataGridView.Columns[0].ReadOnly = true;
            dataGridView.Columns.Add("Name_member", "Name");
            dataGridView.Columns.Add("Adress_publishing_house", "Adress");
            dataGridView.Columns.Add("City_publishing_house", "City");
            dataGridView.Columns.Add("Mail_publishing_house", "Mail");
            return dataGridView;
        }

        public static DataGridView addColumnToMembers(DataGridView dataGridView)
        {
            dataGridView.Columns.Add("Code_member", "ID");
            dataGridView.Columns[0].ReadOnly = true;
            dataGridView.Columns.Add("Name_member", "Name");
            dataGridView.Columns.Add("Surname_member", "Surname");
            dataGridView.Columns.Add("Adress_member", "Adress");
            dataGridView.Columns.Add("Phone_number_member", "Phone number");
            return dataGridView;
        }
    }
}