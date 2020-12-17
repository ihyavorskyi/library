using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;

namespace New_Lib
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
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

        private void checkAccount(string name, string surname, string adress, string password, string phoneNum)
        {
            string connString = GetConnection();

            byte[] tmpHash;

            byte[] tmpSource = ASCIIEncoding.ASCII.GetBytes(password);
            tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);

            password = ByteArrayToString(tmpHash);

            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();

            string query = "insert into members values(null,'" + name + "','" + surname + "','" + adress + "','" + phoneNum + "','" + password  + "','User')";

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
            SingInForm form = new SingInForm();
            form.Show();
            Close();
        }

        private static string ByteArrayToString(byte[] arrInput)
        {
            int i;
            StringBuilder sOutput = new StringBuilder(arrInput.Length);
            for (i = 0; i < arrInput.Length - 1; i++)
            {
                sOutput.Append(arrInput[i].ToString("X2"));
            }
            return sOutput.ToString();
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {
        }
    }
}