using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
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
using System.Windows.Threading;
using embedded_GUI.Models;
using embedded_GUI.Repos;
using MySql.Data.MySqlClient;

namespace embedded_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private static TTNdbContext context = new TTNdbContext();
        private static IApplicatieRepo applicatieRepo = new ApplicatieRepo(context);
        private static IDeviceRepo deviceRepo = new DeviceRepo(context);
        private static IDataRepo dataRepo = new DataRepo(context);

        private static Applicatie applicatie;
        private static Device device;
        private static Data newData;

        DispatcherTimer timer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            FillListBox();
            timer.Tick += new EventHandler(dispatcherTimer_Tick);
            timer.Interval = new TimeSpan(0, 1, 0);
            timer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            FillListBox();
        }

        private void FillListBox()
        {
            try
            {
                dataListBox.Items.Clear();
                IList<Data> datas = dataRepo.GetAll();
                foreach (Data data in datas)
                {
                    dataListBox.Items.Add(data.TimeStamp);
                }

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
                        DevIdTxt.Text = reader.GetString(2);
                        topicTxt.Text = reader.GetString(3);
                        timeTxt.Text = reader.GetString(1);
                        payloadTxt.Text = reader.GetString(4);
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
    }

}
