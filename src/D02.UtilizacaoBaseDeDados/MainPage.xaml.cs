using System;
using System.Collections.Generic;
using System.Data.Linq;
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

namespace D02.UtilizacaoBaseDeDados
{
    using Model;

    public partial class MainPage : PhoneApplicationPage
    {
        private WineDataContext dbContext;
        
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            dbContext = new WineDataContext(App.WineDbConnectionString);
        }

        #region Consultar Registos

        private void ConsultarRegistos_Click(object sender, RoutedEventArgs e)
        {
            var query = from w in dbContext.Wines
                        where w.Country == "Portugal"
                        orderby w.Price descending
                        select w;

            var portugueseWines = query.ToList();

            if (portugueseWines.Count == 0)
            {
                MessageBox.Show("Não encontrei vinhos na BD!");
                return;
            }

            foreach (var w in portugueseWines)
            {
                MessageBox.Show(String.Format(
                    "{0} ({1:C2}) @Portugal", w.Name, w.Price));
            }
        }

        #endregion

        #region Inserir Registos

        private void InserirRegistos_Click(object sender, RoutedEventArgs e)
        {
            var wine1 = new Wine()
                {
                    Id = 1,
                    Name = "Gazela Vinho Verde 2000",
                    Price = 7.99M,
                    IsAtHome = false,
                    IsFavorite = false,
                    Country = "Portugal",
                };

            var wine2 = new Wine()
                {
                    Id = 2,
                    Name = "Montecillo Blanco 1998",
                    Price = 10.99M,
                    IsAtHome = true,
                    IsFavorite = false,
                    Country = "Spain",
                };

            var wine3 = new Wine()
            {
                Id = 3,
                Name = "Quinta do Noval Ruby Port",
                Price = 8.99M,
                IsAtHome = true,
                IsFavorite = true,
                Country = "Portugal",
            };


            dbContext.Wines.InsertOnSubmit(wine1);
            dbContext.Wines.InsertOnSubmit(wine2);
            dbContext.Wines.InsertOnSubmit(wine3);

            dbContext.SubmitChanges();

            MessageBox.Show("Registos inseridos!");
        }

        #endregion

        #region Actualizar Registo

        private void ActualizarRegistos_Click(object sender, RoutedEventArgs e)
        {
            var wine = (from w in dbContext.Wines
                        where w.Id == 1
                        select w).FirstOrDefault();

            if (wine == null)
            {
                MessageBox.Show("Ops... Vinho não encontrado!");
                return;
            }

            wine.Price = 15.98M;

            dbContext.SubmitChanges();
            
            MessageBox.Show("Registo actualizado!");
        }

        #endregion

        #region Apagar Registos

        private void ApagarRegistos_Click(object sender, RoutedEventArgs e)
        {
            var winesToDelete = from w in dbContext.Wines
                                where w.Price > 10.0M
                                select w;

            dbContext.Wines.DeleteAllOnSubmit(winesToDelete);

            dbContext.SubmitChanges();

            MessageBox.Show("Registos apagados!");
        }

        #endregion

        #region Consultar Registos c/ Query Compilada

        Func<WineDataContext, IQueryable<Wine>> winesAtHomeQuery;

        private void ConsultarRegistosQueryCompilada_Click(object sender, RoutedEventArgs e)
        {
            if (winesAtHomeQuery == null)
            {
                winesAtHomeQuery = CompiledQuery.Compile((WineDataContext dc) =>
                    (
                        from Wine w in dc.Wines
                        where w.IsAtHome == true
                        select w
                    ));
            }

            var winesAtHome = winesAtHomeQuery(dbContext)
                .ToList();

            if (winesAtHome.Count == 0)
            {
                MessageBox.Show("Não encontrei vinhos na BD!");
                return;
            }

            foreach (var w in winesAtHome)
            {
                MessageBox.Show(String.Format("{0} ({1}) @Home", 
                    w.Name, w.Country));
            }
        }

        #endregion
    }
}