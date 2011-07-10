using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;

namespace D04.AddressChooserTaskEx
{
    public partial class MainPage : PhoneApplicationPage
    {
        private AddressChooserTask addressChooserTask;

        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void EscolherEndereco_Click(object sender, RoutedEventArgs e)
        {
            addressChooserTask = new AddressChooserTask();
            addressChooserTask.Completed += AddressChooserTask_Completed;
            addressChooserTask.Show();
        }

        private void AddressChooserTask_Completed(object sender, AddressResult e)
        {
            if (null == e.Error && TaskResult.OK == e.TaskResult)
            {
                MessageBox.Show(String.Format("Endereço do(a) {0}: {1}", 
                    e.DisplayName, e.Address));
            }
        }
    }
}