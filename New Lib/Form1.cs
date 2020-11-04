using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace New_Lib
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            labelSingIn.Text = "Sign in account";
            labelPhone.Text = "Phone number: ";
            labelPassword.Text = "Password: ";
            buttonSignIn.Text = "Sign In";
            buttonRegister.Text = "Register now";
        }
        private string GetConnection()
        {
            return "Server = 127.0.0.1; Database = library; port = 3306; User = root; password = Pro100 Igor";
        }

        private void buttonSignIn_Click(object sender, EventArgs e)
        {
            if (textBoxPhone.Text == "" || textBoxPass.Text == "")
            {
                MessageBox.Show("Incorrect data entered or the account does not exist", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                checkAccount(textBoxPhone.Text, textBoxPass.Text);
            }
        }

        private void checkAccount(string phoneNum, string password)
        {
            string connString = GetConnection();

            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();

            string query = "select * from members where Phone_number = '" +
                phoneNum + "' and Password = '" + password + "'";

            MySqlCommand command = new MySqlCommand(query, conn);
            MySqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                Form2 form2 = new Form2(reader[6].ToString(),(int)reader[0]);
                form2.Text = "Library. " + reader[1].ToString() + " " + reader[2].ToString() + ". Role : " + reader[6].ToString();
                form2.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Incorrect data entered or the account does not exist", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            reader.Close();
            conn.Close();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            Hide();
        }
    }
}