using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace New_Lib
{
    public class ResponseDB
    {
        public static List<string[]> onHandsBooks(MySqlDataReader reader)
        {
            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {
                data.Add(new string[7]);
                for (int i = 0; i < data[data.Count - 1].Length; i++)
                {
                    if (i < 3)
                    {
                        data[data.Count - 1][i] = reader[i].ToString();
                    }
                    if (i == 3)
                    {
                        data[data.Count - 1][i] = reader[i].ToString() + " " + reader[i + 1].ToString();
                    }
                    if (i > 3)
                    {
                        data[data.Count - 1][i] = reader[i + 1].ToString();
                    }
                }
            }
            reader.Close();
            return data;
        }

        public static List<string[]> myBooks(MySqlDataReader reader)
        {
            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {
                data.Add(new string[7]);
                for (int i = 0; i < data[data.Count - 1].Length; i++)
                {
                    if (i < 5)
                    {
                        data[data.Count - 1][i] = reader[i].ToString();
                    }
                    if (i == 5)
                    {
                        data[data.Count - 1][i] = reader[i].ToString() + " " + reader[i + 1].ToString();
                    }
                    if (i > 5)
                    {
                        data[data.Count - 1][i] = reader[i + 1].ToString();
                    }
                }
            }
            reader.Close();
            return data;
        }

        public static List<string[]> books(MySqlDataReader reader)
        {
            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {
                data.Add(new string[9]);
                for (int i = 0; i < data[data.Count - 1].Length; i++)
                {
                    if (i < 2)
                    {
                        data[data.Count - 1][i] = reader[i].ToString();
                    }
                    if (i == 2)
                    {
                        data[data.Count - 1][i] = reader[i].ToString() + " " + reader[i + 1].ToString();
                    }
                    if (i > 2)
                    {
                        data[data.Count - 1][i] = reader[i + 1].ToString();
                    }
                }
            }
            reader.Close();
            return data;
        }

        public static List<string[]> responce(MySqlDataReader reader, int count)
        {
            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {
                data.Add(new string[count]);
                for (int i = 0; i < data[data.Count - 1].Length; i++)
                {
                    data[data.Count - 1][i] = reader[i].ToString();
                }
            }
            reader.Close();
            return data;
        }
    }
}