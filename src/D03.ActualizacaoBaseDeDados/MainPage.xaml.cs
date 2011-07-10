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
using Microsoft.Phone.Data.Linq;

namespace D03.ActualizacaoBaseDeDados
{
    using Model;

    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        #region Adicionar Campo Na Tabela

        private void AdicionarCampoNaTabela_Click(object sender, RoutedEventArgs e)
        {
            using (var dbContext = new WineDataContextV2(App.WineDbConnectionString))
            {
                var dbUpdate = dbContext.CreateDatabaseSchemaUpdater();

                int dbVersion = dbUpdate.DatabaseSchemaVersion;
                if (dbVersion == 0)
                {
                    dbUpdate.AddColumn<WineV2>("BottleType");
                    dbUpdate.DatabaseSchemaVersion = 1;
                    dbUpdate.Execute();

                    MessageBox.Show("Novo campo adicionado!");
                    return;
                }

                MessageBox.Show("Base de dados já está actualizada!");
            }
        }

        #endregion
    }
}