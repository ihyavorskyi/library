using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace New_Lib
{
    public partial class LibraryForm : Form
    {
        private string role { get; set; }

        private string Query = "SELECT book.Code_book,Title,author.Name,author.Surname,Pages," +
                "Year_publish,Name_genre,Name_type,publishing_house.Name,Count_in_library FROM book  join " +
                "genre on genre.Code_genre=book.Genre join type on type.Code_type=book.type " +
                "join publishing_house on book.Code_publish=publishing_house.Code_publish join " +
                "author_list on author_list.Code_book=book.Code_book join author on " +
                "author_list.Code_author=author.Code_author ";

        private int codeMember { get; set; }
        private string uninversalCode { get; set; }
        private string codeOnHands { get; set; }
        private string title { get; set; }
        private int idAdd { get; set; }
        private string tableName { get; set; }

        private string[] dataForUpdate = new string[10];

        public LibraryForm(string role, int id)
        {
            InitializeComponent();
            this.role = role;
            codeMember = id;
            uninversalCode = "0";
            codeOnHands = "0";
            idAdd = 0;
            tableName = "";
            isAdmin();
            tableName = ShowCatalog.ShowBookCatalog(dataGridViewCatalog, Query + "order by book.Code_book");
            ShowCatalog.ShowMyBooks(dataGridViewMyBooks, codeMember);
            ShowCatalog.ShowOnHandsBooks(dataGridViewOnHands);
        }

        public static string GetConnection()
        {
            return "Server = 127.0.0.1; Database = library; port = 3306; User = root; password = Pro100 Igor";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SingInForm form = new SingInForm();
            form.Show();
            Close();
        }

        private void booksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isAdd(false);
            isDeleteUpdate();
            isTake(1);
            tableName = ShowCatalog.ShowBookCatalog(dataGridViewCatalog, Query + "order by book.Code_book");
            isUser();
        }

        private void authorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isCheck();
            tableName = ShowCatalog.ShowAuthor(dataGridViewCatalog);
            isUser();
        }

        private void publishingHousesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isCheck();
            tableName = ShowCatalog.ShowPubHouses(dataGridViewCatalog);
            isUser();
        }

        private void membersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isCheck();
            tableName = ShowCatalog.ShowMembers(dataGridViewCatalog);
        }

        private void genresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isCheck();
            tableName = ShowCatalog.ShowGenres(dataGridViewCatalog);
        }

        private void typesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isCheck();
            tableName = ShowCatalog.ShowTypes(dataGridViewCatalog);
        }

        private void dataGridViewCatalog_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int selRowNum = dataGridViewCatalog.SelectedCells[0].RowIndex;
            uninversalCode = dataGridViewCatalog.Rows[selRowNum].Cells[0].Value.ToString();
            title = dataGridViewCatalog.Rows[selRowNum].Cells[1].Value.ToString();
            textBoxSelectedID.Text = "ID: " + uninversalCode;

            dataForUpdate[0] = uninversalCode;
            dataForUpdate[1] = title;
            if (tableName == "author" || tableName == "publishing_house" || tableName == "book")
            {
                for (int i = 2; i <= 4; i++)
                {
                    dataForUpdate[i] = dataGridViewCatalog.Rows[selRowNum].Cells[i].Value.ToString();
                }
                if (tableName == "book")
                {
                    for (int i = 5; i <= 8; i++)
                    {
                        dataForUpdate[i] = dataGridViewCatalog.Rows[selRowNum].Cells[i].Value.ToString();
                    }
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

        private void isAdd(bool isAdmin)
        {
            if (isAdmin)
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
                tableName = ShowCatalog.ShowBookCatalog(dataGridViewCatalog, query);
            }
        }

        private void buttonTakeIt_Click(object sender, EventArgs e)
        {
            DataGridView[] dataGridViews = new DataGridView[] { dataGridViewCatalog, dataGridViewMyBooks, dataGridViewOnHands };
            TakeBook.takeIt(uninversalCode, codeMember, title, Query, dataGridViews);
        }

        private void buttonReturned_Click(object sender, EventArgs e)
        {
            DataGridView[] dataGridViews = new DataGridView[] { dataGridViewCatalog, dataGridViewMyBooks, dataGridViewOnHands };
            ReturnBook.returned(codeOnHands, uninversalCode, title, Query, dataGridViews, codeMember);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DeleteFromDataBase.delete(uninversalCode, tableName, dataGridViewCatalog, Query);
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            UpdateDataBase.update(uninversalCode, tableName, dataForUpdate, dataGridViewCatalog, Query);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddToDataBase.add(idAdd, dataGridViewCatalog, tableName, Query);
        }
    }
}