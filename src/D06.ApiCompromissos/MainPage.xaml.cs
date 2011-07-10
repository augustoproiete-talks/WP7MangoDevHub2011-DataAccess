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
using Microsoft.Phone.UserData;

namespace D06.ApiCompromissos
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void ProcurarProximoCompromisso_Click(object sender, RoutedEventArgs e)
        {
            var appointments = new Appointments();
            appointments.SearchCompleted += Appointments_SearchCompleted;

            appointments.SearchAsync(DateTime.Now,
                DateTime.Now + TimeSpan.FromDays(7), 1, null);
        }

        private void Appointments_SearchCompleted(object sender, AppointmentsSearchEventArgs e)
        {
            var proximoCompromisso = e.Results.FirstOrDefault();

            if (proximoCompromisso == null)
            {
                MessageBox.Show("Não há compromissos");
                return;
            }

            MessageBox.Show(proximoCompromisso.Subject);
        }
    }
}