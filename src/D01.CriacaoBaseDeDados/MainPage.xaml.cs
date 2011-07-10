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

namespace D01.CriacaoBaseDeDados
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void CriarBaseDeDados_Click(object sender, RoutedEventArgs e)
        {
            #region ...
            
            // using (var dbContext = new WineDataContext(
            //     "Data Source=appdata:/WineDB.sdf;mode='read only';"))

            #endregion

            using (var dbContext = new WineDataContext(
                "Data Source=isostore:/WineDB.sdf;"))
            {
                if (!dbContext.DatabaseExists())
                {
                    dbContext.CreateDatabase();
                    MessageBox.Show("Base de dados foi criada!");

                    return;
                }

                MessageBox.Show("Base de dados já existe...");
            }
        }
    }
}