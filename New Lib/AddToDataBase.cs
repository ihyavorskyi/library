using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace New_Lib
{
    public class AddToDataBase
    {
        public static void genreAdd(DataGridView dataGridView, MySqlConnection conn)
        {
            for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
            {
                string query = "insert into genre values (null,'" + dataGridView.Rows[i].Cells[1].Value.ToString() + "');";
                NewQuery.executeNonQuery(query, conn);
            }
            conn.Close();
        }

        public static void typeAdd(DataGridView dataGridView, MySqlConnection conn)
        {
            for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
            {
                string query = "insert into type values (null,'" + dataGridView.Rows[i].Cells[1].Value.ToString() + "');";
                NewQuery.executeNonQuery(query, conn);
            }
            conn.Close();
        }

        public static void authorAdd(DataGridView dataGridView, MySqlConnection conn)
        {
            for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
            {
                string name = dataGridView.Rows[i].Cells[1].Value.ToString();
                string surname = dataGridView.Rows[i].Cells[2].Value.ToString();
                string birthday = dataGridView.Rows[i].Cells[3].Value.ToString();
                string homeland = dataGridView.Rows[i].Cells[4].Value.ToString();
                string query = "insert into author values (null,'" + name + "','" + surname + "','" + birthday + "','" + homeland + "');";
                NewQuery.executeNonQuery(query, conn);
            }
            conn.Close();
        }

        public static void pubHouseAdd(DataGridView dataGridView, MySqlConnection conn)
        {
            for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
            {
                string name = dataGridView.Rows[i].Cells[1].Value.ToString();
                string adress = dataGridView.Rows[i].Cells[2].Value.ToString();
                string city = dataGridView.Rows[i].Cells[3].Value.ToString();
                string mail = dataGridView.Rows[i].Cells[4].Value.ToString();
                string query = "insert into publishing_house values (null,'" + name + "','" + adress + "','" + city + "','" + mail + "');";
                NewQuery.executeNonQuery(query, conn);
            }
            conn.Close();
        }

        public static void bookAdd(DataGridView dataGridView, MySqlConnection conn)
        {
            for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
            {
                string code_book = "";
                string title = dataGridView.Rows[i].Cells[1].Value.ToString();
                string author = dataGridView.Rows[i].Cells[2].Value.ToString();
                string pages = dataGridView.Rows[i].Cells[3].Value.ToString();
                string year = dataGridView.Rows[i].Cells[4].Value.ToString();
                string genre = dataGridView.Rows[i].Cells[5].Value.ToString();
                string type = dataGridView.Rows[i].Cells[6].Value.ToString();
                string pubHouse = dataGridView.Rows[i].Cells[7].Value.ToString();
                string count = dataGridView.Rows[i].Cells[8].Value.ToString();

                string query = "insert into book values (null,'" + title + "','" + pages + "','" + year + "','" + pubHouse + "','" + genre + "','" + type + "','" + count + "');";
                NewQuery.executeNonQuery(query, conn);

                query = "select max(Code_book) from book";
                MySqlCommand command = new MySqlCommand(query, conn);
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    code_book = reader[0].ToString();
                }
                reader.Close();

                query = "insert into author_list values (null,'" + author + "','" + code_book + "');";
                NewQuery.executeNonQuery(query, conn);
            }
            conn.Close();
        }
    }
}