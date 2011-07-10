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

namespace D05.ApiContactos
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void ProcurarContacto_Click(object sender, RoutedEventArgs e)
        {
            var contacts = new Contacts();
            contacts.SearchCompleted += Contacts_SearchCompleted;

            contacts.SearchAsync(nomeTextbox.Text, 
                FilterKind.DisplayName, null);
        }

        private void Contacts_SearchCompleted(object sender, ContactsSearchEventArgs e)
        {
            foreach (var c in e.Results)
            {
                MessageBox.Show(c.DisplayName);
            }
        }
    }
}