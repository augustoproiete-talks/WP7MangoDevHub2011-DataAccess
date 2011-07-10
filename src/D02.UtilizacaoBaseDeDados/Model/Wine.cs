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
using System.Data.Linq.Mapping;
using Microsoft.Phone.Data.Linq.Mapping;

namespace D02.UtilizacaoBaseDeDados.Model
{
    [Table]
    [Index(Columns = "Name")]
    public class Wine
    {
        #region ...

        // Exemplo de criação de campo identity
        // [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT IDENTITY NOT NULL", AutoSync = AutoSync.OnInsert)]
        // public int Id { get; set; }

        #endregion

        [Column(IsPrimaryKey = true)]
        public int Id { get; set; }

        [Column]
        public string Name { get; set; }

        [Column(CanBeNull = true)]
        public string Description { get; set; }

        [Column]
        public decimal Price { get; set; }

        [Column]
        public bool IsAtHome { get; set; }

        [Column]
        public bool IsFavorite { get; set; }

        [Column]
        public string Country { get; set; }
    }
}
