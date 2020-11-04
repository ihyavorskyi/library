using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace New_Lib
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            labelName.Text = "Name : ";
            labelPhone.Text = "Phone number : ";
            labelSurname.Text = "Surname : ";
            labelPassword.Text = "Password : ";
            labelAdress.Text = "Adress : ";
            buttonRegisterNew.Text = "Register now";
            buttonSignIn.Text = "Sign in";
        }

        private string GetConnection()
        {
            return "Server = 127.0.0.1; Database = library; port = 3306; User = root; password = Pro100 Igor";
        }

        private void buttonRegisterNew_Click(object sender, EventArgs e)
        {
            if (textBoxPhone.Text == "" || textBoxAdress.Text == "" || textBoxPassword.Text == "" || textName.Text == "" || textBoxSurname.Text == "")
            {
                MessageBox.Show("Incorrect data entered", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                checkAccount(textName.Text, textBoxSurname.Text, textBoxAdress.Text, textBoxPhone.Text, textBoxPassword.Text);
            }
        }

        private void checkAccount(string name, string surname, string adress, string phoneNum, string password)
        {
            string connString = GetConnection();

            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();

            string query = "insert into members values(null,'" + name + "','" + surname + "','" + adress + "','" + password + "','" + phoneNum + "','User')";

            NewQuery.executeNonQuery(query, conn);

            conn.Close();
            MessageBox.Show("New account registration successful, sign in now", "SUCCESSFUL", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            openSignInForm();
            conn.Close();
        }

        private void buttonSignIn_Click(object sender, EventArgs e)
        {
            openSignInForm();
        }

        private void openSignInForm()
        {
            Form1 form1 = new Form1();
            form1.Show();
            Close();
        }
    }
}