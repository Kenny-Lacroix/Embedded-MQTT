using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace embedded_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FillListBox();
        }

        private void FillListBox()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=lora;";
            string query = "SELECT * FROM data";

            // Prepare the connection
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                // Open the database
                databaseConnection.Open();

                // Execute the query
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        dataListBox.Items.Add(reader.GetString(1));
                    }
                }
                else
                {
                    MessageBox.Show("No rows found.");
                }
                // Finally close the connection
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                // Show any error message.
                MessageBox.Show(ex.Message);
            }
        }

        private void dataListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataListBox.SelectedItem!=null)
            {
                string selectedItem = dataListBox.Items[dataListBox.SelectedIndex].ToString();
                getData(selectedItem);
            }
        }

        private void getData(string timestamp)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=lora;";
            string query = "SELECT * FROM data WHERE timestamp LIKE '"+timestamp+"'";

            // Prepare the connection
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                // Open the database
                databaseConnection.Open();

                // Execute the query
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        idTxt.Text = reader.GetString(2);
                        topicTxt.Text = reader.GetString(3);
                        timeTxt.Text = reader.GetString(1);
                        payloadTxt.Text = HexToString(reader.GetString(4));
                    }
                }
                else
                {
                    MessageBox.Show("No rows found.");
                }
                // Finally close the connection
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                // Show any error message.
                MessageBox.Show(ex.Message);
            }
        }

        private string HexToString(string hex)
        {
            hex = hex.Replace("-", "");
            byte[] raw = new byte[hex.Length / 2];
            string payload="";
            for (int i = 0; i < raw.Length; i++)
            {
                raw[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
                payload += Convert.ToChar(raw[i]).ToString();
            }

            return payload;
        }
    }

}
