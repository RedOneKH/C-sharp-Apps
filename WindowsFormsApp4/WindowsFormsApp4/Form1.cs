using System;
using System.Windows.Forms;

using MySql.Data.MySqlClient;
using System.Data;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        //database conf
        private const String SERVER = "db4free.net";
        private const String DATABASE = "mabase1";
        private const String UID = "projet1";
        private const String PASSWORD = "1234567890azerty";
        private static MySqlConnection conn;

        public Form1()
        {

            InitializeDB();
            InitializeComponent();



            


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*this.Hide();
            Main ss = new Main();
            ss.Show();*/

            string user = textBox1.Text;
            string pass = textBox2.Text;

            if (IsLogin(user, pass))
            {
                MessageBox.Show("Welcome "+user+"!");
            }
            else
            {
                MessageBox.Show(" "+user+" does not exist or password is incorrect!");

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            string pass = textBox2.Text;

            if (Register(user, pass))
            {
                MessageBox.Show("User "+user+" has been created");
            }
            else
            {
                MessageBox.Show("User "+user+" has not been created");

            }
        }

        public bool Register(string user, string pass)
        {
            String query = string.Format("INSERT INTO Users(username, password) VALUES ('{0}', '{1}')", user, pass);
            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error " + ex);
                        return false;
                    }
                }
                else
                {
                    conn.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
                conn.Close();
                return false;
            }
        }

        public bool IsLogin(string user, string pass)
        {
            string query = string.Format("SELECT * FROM Users WHERE username = '{0}' AND password = '{1}'", user, pass);
            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        reader.Close();
                        conn.Close();
                        return true;
                    }
                    else
                    {
                        reader.Close();
                        conn.Close();
                        return false;
                    }
                }
                else
                {
                    conn.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
                conn.Close();
                return false;
            }
        }
        private bool OpenConnection()
        {
            try
            {
                conn.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Connection to server failed!");
                        break;
                    case 1045:
                        MessageBox.Show("Server username or password is incorrect!");
                        break;
                }
                return false;
                
            }
        }

        public static void InitializeDB()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = SERVER;
            builder.UserID = UID;
            builder.Password = PASSWORD;
            builder.Database = DATABASE;

            String connString = builder.ToString();

            builder = null;

            Console.WriteLine(connString);

            conn = new MySqlConnection(connString);

            Application.ApplicationExit += (sender, args) =>
            {
                if (conn != null)
                {
                    conn.Dispose();
                    conn = null;
                }
            };
        }


        


    }
}
