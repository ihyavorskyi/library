using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace New_Lib
{
    internal class TakeBook
    {
        public static MySqlConnection conn = new MySqlConnection(LibraryForm.GetConnection());

        public static void takeIt(string uninversalCode, int codeMember, string title, string Query, DataGridView[] dataGridViews)
        {
            if (uninversalCode != "0")
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure?", "INFO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    conn.Open();

                    string query = "select Count_in_library from book where Code_book = " + uninversalCode;
                    MySqlDataReader reader = NewQuery.executeReader(query, conn);
                    if (reader.Read())
                    {
                        if ((int)reader[0] != 0)
                        {
                            int book_count = (int)reader[0];
                            reader.Close();

                            query = "insert into on_hands values (null," + uninversalCode + "," + codeMember + ",'" + DateTime.Today + "')";
                            NewQuery.executeNonQuery(query, conn);

                            query = "update book set Count_in_library = " + (book_count - 1) + " where Code_book = " + uninversalCode;
                            NewQuery.executeNonQuery(query, conn);

                            conn.Close();
                            MessageBox.Show("You took '" + title + "'. Thank you for choosing us", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ShowCatalog.ShowBookCatalog(dataGridViews[0], Query + "order by book.Code_book");
                            ShowCatalog.ShowMyBooks(dataGridViews[1], codeMember);
                            ShowCatalog.ShowOnHandsBooks(dataGridViews[2]);
                        }
                        else
                        {
                            MessageBox.Show("This book is not available. Please accept our apologies.", "SORRY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    conn.Close();
                }
            }
        }
    }
}