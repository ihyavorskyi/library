using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace New_Lib
{
    public partial class Form2 : Form
    {
        private string role { get; set; }
        private string Query { get; set; }
        private int codeMember { get; set; }
        private string uninversalCode { get; set; }
        private string codeOnHands { get; set; }
        private string title { get; set; }
        private MySqlConnection conn { get; set; }
        private int idAdd { get; set; }
        private string tableName { get; set; }

        private string[] dataForUpdate = new string[10];

        public Form2(string role, int id)
        {
            InitializeComponent();
            this.role = role;
            codeMember = id;
            conn = new MySqlConnection(GetConnection());
            uninversalCode = "0";
            codeOnHands = "0";
            idAdd = 0;
            tableName = "";

            Query = "SELECT book.Code_book,Title,author.Name,author.Surname,Pages," +
                "Year_publish,Name_genre,Name_type,publishing_house.Name,Count_in_library FROM book  join " +
                "genre on genre.Code_genre=book.Genre join type on type.Code_type=book.type " +
                "join publishing_house on book.Code_publish=publishing_house.Code_publish join " +
                "author_list on author_list.Code_book=book.Code_book join author on " +
                "author_list.Code_author=author.Code_author ";

            isAdmin();
            showBookCatalog(Query + " order by book.Code_book;");
            showMyBooks();
            showOnHandsBooks();
        }

        private string GetConnection()
        {
            return "Server = 127.0.0.1; Database = library; port = 3306; User = root; password = Pro100 Igor";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            Close();
        }

        private void booksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showBookCatalog(Query + "order by book.Code_book");
        }

        private void authorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showAuthor();
        }

        private void publishingHousesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPubHouses();
        }

        private void membersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showMembers();
        }

        private void genresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showGenres();
        }

        private void typesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showTypes();
        }

        private void showBookCatalog(string query)
        {
            isAdd(false);
            isDeleteUpdate();
            isTake(1);
            tableName = "book";
            dataGridViewCatalog = AddColumnToDataGridView.ClearDataGridView(dataGridViewCatalog);
            dataGridViewCatalog = AddColumnToDataGridView.addColumnToBookCatalog(dataGridViewCatalog);

            conn.Open();
            MySqlDataReader reader = NewQuery.executeReader(query, conn);
            List<string[]> data = NewStringList.books(reader);
            conn.Close();

            AddRowsToDataGridView.addRows(data, dataGridViewCatalog);
            isUser();
        }

        private void showAuthor()
        {
            isCheck();
            tableName = "author";
            dataGridViewCatalog = AddColumnToDataGridView.ClearDataGridView(dataGridViewCatalog);
            dataGridViewCatalog = AddColumnToDataGridView.addColumnToAuthohrs(dataGridViewCatalog);

            conn.Open();
            MySqlDataReader reader = NewQuery.executeReader("select * from author", conn);
            List<string[]> data = NewStringList.authors(reader);
            conn.Close();

            AddRowsToDataGridView.addRows(data, dataGridViewCatalog);
            isUser();
        }

        private void showPubHouses()
        {
            isCheck();
            tableName = "publishing_house";
            dataGridViewCatalog = AddColumnToDataGridView.ClearDataGridView(dataGridViewCatalog);
            dataGridViewCatalog = AddColumnToDataGridView.addColumnToPubHouses(dataGridViewCatalog);

            conn.Open();
            MySqlDataReader reader = NewQuery.executeReader("select * from `publishing_house`", conn);
            List<string[]> data = NewStringList.pubHouse(reader);
            conn.Close();

            AddRowsToDataGridView.addRows(data, dataGridViewCatalog);
            isUser();
        }

        private void showMembers()
        {
            isCheck();
            tableName = "members";
            dataGridViewCatalog = AddColumnToDataGridView.ClearDataGridView(dataGridViewCatalog);
            dataGridViewCatalog = AddColumnToDataGridView.addColumnToMembers(dataGridViewCatalog);

            conn.Open();
            MySqlDataReader reader = NewQuery.executeReader("select * from members", conn);
            List<string[]> data = NewStringList.members(reader);
            conn.Close();

            AddRowsToDataGridView.addRows(data, dataGridViewCatalog);
        }

        private void showGenres()
        {
            tableName = "genre";
            dataGridViewCatalog = AddColumnToDataGridView.ClearDataGridView(dataGridViewCatalog);

            dataGridViewCatalog.Columns.Add("Code_genre", "ID");
            dataGridViewCatalog.Columns[0].ReadOnly = true;
            dataGridViewCatalog.Columns.Add("Name_genre", "Genre name");

            conn.Open();
            MySqlDataReader reader = NewQuery.executeReader("select * from genre", conn);
            List<string[]> data = NewStringList.genres(reader);
            conn.Close();

            AddRowsToDataGridView.addRows(data, dataGridViewCatalog);
        }

        private void showTypes()
        {
            isCheck();
            tableName = "type";
            dataGridViewCatalog = AddColumnToDataGridView.ClearDataGridView(dataGridViewCatalog);
            dataGridViewCatalog.Columns.Add("Code_type", "ID");
            dataGridViewCatalog.Columns[0].ReadOnly = true;
            dataGridViewCatalog.Columns.Add("Name_type", "Type name");

            conn.Open();
            MySqlDataReader reader = NewQuery.executeReader("select * from type", conn);
            List<string[]> data = NewStringList.types(reader);
            conn.Close();

            AddRowsToDataGridView.addRows(data, dataGridViewCatalog);
        }

        private void showMyBooks()
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

        private void showOnHandsBooks()
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

        private void dataGridViewCatalog_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int selRowNum = dataGridViewCatalog.SelectedCells[0].RowIndex;
            uninversalCode = dataGridViewCatalog.Rows[selRowNum].Cells[0].Value.ToString();
            title = dataGridViewCatalog.Rows[selRowNum].Cells[1].Value.ToString();
            textBoxSelectedID.Text = "ID: " + uninversalCode;

            dataForUpdate[0] = dataGridViewCatalog.Rows[selRowNum].Cells[0].Value.ToString();
            dataForUpdate[1] = dataGridViewCatalog.Rows[selRowNum].Cells[1].Value.ToString();
            if (tableName == "author" || tableName == "publishing_house" || tableName == "book")
            {
                dataForUpdate[2] = dataGridViewCatalog.Rows[selRowNum].Cells[2].Value.ToString();
                dataForUpdate[3] = dataGridViewCatalog.Rows[selRowNum].Cells[3].Value.ToString();
                dataForUpdate[4] = dataGridViewCatalog.Rows[selRowNum].Cells[4].Value.ToString();
                if (tableName == "book")
                {
                    dataForUpdate[5] = dataGridViewCatalog.Rows[selRowNum].Cells[5].Value.ToString();
                    dataForUpdate[6] = dataGridViewCatalog.Rows[selRowNum].Cells[6].Value.ToString();
                    dataForUpdate[7] = dataGridViewCatalog.Rows[selRowNum].Cells[7].Value.ToString();
                    dataForUpdate[8] = dataGridViewCatalog.Rows[selRowNum].Cells[8].Value.ToString();
                }
            }
        }

        private void dataGridViewOnHands_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int selRowNum = dataGridViewOnHands.SelectedCells[0].RowIndex;
            codeOnHands = dataGridViewOnHands.Rows[selRowNum].Cells[0].Value.ToString();
            uninversalCode = dataGridViewOnHands.Rows[selRowNum].Cells[1].Value.ToString();
            title = dataGridViewOnHands.Rows[selRowNum].Cells[2].Value.ToString();
            textBoxOnHands.Text = "ID: " + codeOnHands;
        }

        private void isTake(int isTakeIt)
        {
            if (isTakeIt == 1)
            {
                buttonTakeIt.Visible = true;
            }
            else
            {
                buttonTakeIt.Visible = false;
            }
        }

        private void isAdmin()
        {
            if (role == "Admin")
            {
                addToolStripMenuItem.Visible = true;
                membersToolStripMenuItem.Visible = true;
                genresToolStripMenuItem.Visible = true;
                typesToolStripMenuItem.Visible = true;
                dataGridViewCatalog.ReadOnly = false;
                textBoxOnHands.Visible = true;
                buttonReturned.Visible = true;
                buttonUpdate.Visible = true;
                buttonDelete.Visible = true;
            }
            else
            {
                addToolStripMenuItem.Visible = false;
                membersToolStripMenuItem.Visible = false;
                genresToolStripMenuItem.Visible = false;
                typesToolStripMenuItem.Visible = false;
                dataGridViewCatalog.ReadOnly = true;
                textBoxOnHands.Visible = false;
                buttonReturned.Visible = false;
                buttonUpdate.Visible = false;
                buttonDelete.Visible = false;
                tabControl1.TabPages[2].Parent = null;
            }
        }

        private void isAdd(bool check)
        {
            if (check)
            {
                buttonUpdateOrAdd.Visible = true;
                buttonUpdate.Visible = false;
                buttonDelete.Visible = false;
            }
            else
            {
                buttonUpdateOrAdd.Visible = false;
                buttonUpdate.Visible = true;
                buttonDelete.Visible = true;
            }
        }

        private void isDeleteUpdate()
        {
            if (tableName == "members")
            {
                buttonDelete.Visible = false;
                buttonUpdate.Visible = false;
            }
            else
            {
                buttonDelete.Visible = true;
                buttonUpdate.Visible = true;
            }
        }

        private void isUser()
        {
            if (role == "User")
            {
                buttonDelete.Visible = false;
                buttonUpdate.Visible = false;
            }
        }

        private void isCheck()
        {
            isAdd(false);
            isTake(0);
            isDeleteUpdate();
        }

        private void genreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isAdd(true);
            isTake(0);
            dataGridViewCatalog = AddColumnToDataGridView.ClearDataGridView(dataGridViewCatalog);
            dataGridViewCatalog.Columns.Add("Code_genre", "ID");
            dataGridViewCatalog.Columns[0].ReadOnly = true;
            dataGridViewCatalog.Columns.Add("Name_genre", "Genre name");
            idAdd = 1;
        }

        private void typeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isAdd(true);
            isTake(0);
            dataGridViewCatalog = AddColumnToDataGridView.ClearDataGridView(dataGridViewCatalog);
            dataGridViewCatalog.Columns.Add("Code_type", "ID");
            dataGridViewCatalog.Columns[0].ReadOnly = true;
            dataGridViewCatalog.Columns.Add("Name_type", "Type name");
            idAdd = 2;
        }

        private void authorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isAdd(true);
            isTake(0);
            dataGridViewCatalog = AddColumnToDataGridView.ClearDataGridView(dataGridViewCatalog);
            dataGridViewCatalog = AddColumnToDataGridView.addColumnToAuthohrs(dataGridViewCatalog);
            idAdd = 3;
        }

        private void publishingHouseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isAdd(true);
            isTake(0);
            dataGridViewCatalog = AddColumnToDataGridView.ClearDataGridView(dataGridViewCatalog);
            dataGridViewCatalog = AddColumnToDataGridView.addColumnToPubHouses(dataGridViewCatalog);
            idAdd = 4;
        }

        private void bookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isAdd(true);
            isTake(0);
            dataGridViewCatalog = AddColumnToDataGridView.ClearDataGridView(dataGridViewCatalog);
            dataGridViewCatalog = AddColumnToDataGridView.addColumnToBookCatalog(dataGridViewCatalog);
            idAdd = 5;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (textBoxSearch.Text != "")
            {
                string query = Query + " where Title like '%" + textBoxSearch.Text + "%' order by book.Code_book";
                showBookCatalog(query);
            }
        }

        private void buttonTakeIt_Click(object sender, EventArgs e)
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
                            showBookCatalog(Query + " order by book.Code_book");
                            showMyBooks();
                            showOnHandsBooks();
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

        private void buttonReturned_Click(object sender, EventArgs e)
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
                    showBookCatalog(Query + " order by book.Code_book");
                    showMyBooks();
                    showOnHandsBooks();
                }
            }
        }

        private void buttonUpdateOrAdd_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure?", "INFO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                conn.Open();
                switch (idAdd)
                {
                    case 1:
                        AddToDataBase.genreAdd(dataGridViewCatalog, conn);
                        showGenres();
                        break;

                    case 2:
                        AddToDataBase.typeAdd(dataGridViewCatalog, conn);
                        showTypes();
                        break;

                    case 3:
                        AddToDataBase.authorAdd(dataGridViewCatalog, conn);
                        showAuthor();
                        break;

                    case 4:
                        AddToDataBase.pubHouseAdd(dataGridViewCatalog, conn);
                        showPubHouses();
                        break;

                    case 5:
                        AddToDataBase.bookAdd(dataGridViewCatalog, conn);
                        showBookCatalog(Query + " order by book.Code_book;");
                        break;
                }
                MessageBox.Show("Added successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (uninversalCode != "0")
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure?", "INFO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    conn.Open();
                    switch (tableName)
                    {
                        case "book":
                            DeleteFromDataBase.delete(tableName, "code_book", uninversalCode, conn);
                            showBookCatalog(Query + " order by book.Code_book");
                            break;

                        case "author":
                            DeleteFromDataBase.delete(tableName, "code_author", uninversalCode, conn);
                            showAuthor();
                            break;

                        case "genre":
                            DeleteFromDataBase.delete(tableName, "code_genre", uninversalCode, conn);
                            showGenres();
                            break;

                        case "type":
                            DeleteFromDataBase.delete(tableName, "code_type", uninversalCode, conn);
                            showTypes();
                            break;

                        case "publishing_house":
                            DeleteFromDataBase.delete(tableName, "Code_publish", uninversalCode, conn);
                            showPubHouses();
                            break;
                    }
                    conn.Close();
                    MessageBox.Show("Deleted successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
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
                            UpdateDataBase.updateAuthor(dataForUpdate, conn);
                            showAuthor();
                            break;

                        case "book":
                            UpdateDataBase.updateBook(dataForUpdate, conn);
                            showBookCatalog(Query + " order by book.Code_book");
                            break;

                        case "genre":
                            UpdateDataBase.updateGenre(dataForUpdate, conn);
                            showGenres();
                            break;

                        case "type":
                            UpdateDataBase.updateType(dataForUpdate, conn);
                            showTypes();
                            break;

                        case "publishing_house":
                            UpdateDataBase.updatePubHouse(dataForUpdate, conn);
                            showPubHouses();
                            break;
                    }
                    conn.Close();
                    MessageBox.Show("Updated successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}