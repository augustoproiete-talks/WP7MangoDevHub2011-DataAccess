using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Data.Linq;

namespace D03.ActualizacaoBaseDeDados
{
    using Model;

    public class WineDataContext : DataContext
    {
        public WineDataContext(string connectionString)
            : base(connectionString)
        {
        }

        public Table<Wine> Wines;
    }
}
