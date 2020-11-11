using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace New_Lib
{
    internal class ReturnBook
    {
        public static MySqlConnection conn = new MySqlConnection(LibraryForm.GetConnection());

        public static void returned(string codeOnHands, string uninversalCode, string title, string Query, DataGridView[] dataGridViews, int codeMember)
        {
            if (codeOnHands != "0")
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure?", "INFO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    conn.Open();

                    string query = "DELETE FROM `library`.`on_hands` WHERE(`Code` = '" + codeOnHands + "');";
                    NewQuery.executeNonQuery(query, conn);

                    query = "update book set count_in_library = count_in_library+1 where Code_book = " + uninversalCode;
                    NewQuery.executeNonQuery(query, conn);

                    MessageBox.Show("Book '" + title + "' has been returned", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                    ShowCatalog.ShowBookCatalog(dataGridViews[0], Query + "order by book.Code_book");
                    ShowCatalog.ShowMyBooks(dataGridViews[1], codeMember);
                    ShowCatalog.ShowOnHandsBooks(dataGridViews[2]);
                }
            }
        }
    }
}