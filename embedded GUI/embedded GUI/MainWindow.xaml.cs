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
                    //dataListBox.Items.Add(data.TimeStamp);
                    dataListBox.Items.Add(data.DataId);
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
            try
            {
                if (dataListBox.SelectedItem != null)
                {
                    Data data = dataRepo.GetOneById(Convert.ToInt32(dataListBox.SelectedItem));
                    MessageBox.Show(Convert.ToString(dataListBox.SelectedItem));
                    //Data data = dataRepo.GetOneByTime(Convert.ToDateTime(dataListBox.SelectedItem));
                    getData(data);
                }
            }
            catch (Exception ex)
            {
                // Show any error message.
                MessageBox.Show(ex.Message);
            }
        }

        private void getData(Data data)
        {
            try
            {
                ATxt.Text = data.A;
                BTxt.Text = data.B;
                payloadTxt.Text = data.Payload;
                timeTxt.Text = data.TimeStamp.ToString();

                //Device device = data.Device;
                Device device = deviceRepo.GetOne(data.DeviceId);
                DevIdTxt.Text = device.DeviceName;
                lastSeenTxt.Text = device.LastSeen.ToString();

                Applicatie applicatie = applicatieRepo.GetOne(device.AppId); ;
                AppIdTxt.Text = applicatie.AppName;

            }
            catch (Exception ex)
            {
                // Show any error message.
                MessageBox.Show(ex.Message);
            }
        }
    }

}
