using MySql.Data.MySqlClient;
using System;

namespace New_Lib
{
    public class UpdateDataBase
    {
        public static void updateBook(string[] data, MySqlConnection conn)
        {
            string query = "update book set Title ='" + data[1] + "',pages=" + int.Parse(data[3]) + ",Year_publish="
                + int.Parse(data[4]) + ",Count_in_library=" + int.Parse(data[8]) + " where code_book = " + data[0];
            NewQuery.executeNonQuery(query, conn);

            if (Char.IsDigit(data[2][0]) && int.Parse(data[2]) <= 15)
            {
                query = "update author_list set Code_author =" + int.Parse(data[2]) + " where code_book = " + data[0];
                NewQuery.executeNonQuery(query, conn);
            }

            if (Char.IsDigit(data[5][0]) && int.Parse(data[5]) <= 7)
            {
                query = "update book set Genre =" + int.Parse(data[5]) + " where code_book = " + data[0];
                NewQuery.executeNonQuery(query, conn);
            }

            if (Char.IsDigit(data[6][0]) && int.Parse(data[6]) <= 8)
            {
                query = "update book set type =" + int.Parse(data[6]) + " where code_book = " + data[0];
                NewQuery.executeNonQuery(query, conn);
            }

            if (Char.IsDigit(data[7][0]) && int.Parse(data[7]) <= 10)
            {
                query = "update book set Code_publish =" + int.Parse(data[7]) + " where code_book = " + data[0];
                NewQuery.executeNonQuery(query, conn);
            }
            conn.Close();
        }

        public static void updateGenre(string[] data, MySqlConnection conn)
        {
            string query = "update genre set Name_genre = '" + data[1] + "' where Code_genre = " + data[0];
            NewQuery.executeNonQuery(query, conn);
            conn.Close();
        }

        public static void updateType(string[] data, MySqlConnection conn)
        {
            string query = "update type set Name_type = '" + data[1] + "' where Code_type = " + data[0];
            NewQuery.executeNonQuery(query, conn);
            conn.Close();
        }

        public static void updateAuthor(string[] data, MySqlConnection conn)
        {
            string query = "update author set name ='" + data[1] + "',surname ='" + data[2] + "',Birthday ='"
                + data[3] + "',homeland ='" + data[4] + "' where code_author = " + data[0];
            NewQuery.executeNonQuery(query, conn);
            conn.Close();
        }

        public static void updatePubHouse(string[] data, MySqlConnection conn)
        {
            string query = "update publishing_house set name ='" + data[1] + "',Adress ='" + data[2] + "',City ='"
                + data[3] + "',Mail ='" + data[4] + "' where Code_publish = " + data[0];
            NewQuery.executeNonQuery(query, conn);
            conn.Close();
        }
    }
}