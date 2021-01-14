using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalMenu.Models
{
    public class MenuDatabasesetting
    {
        public class MenuDatabaseSettings : IMenuDatabaseSettings
        {
            public string MenuCollectionName { get; set; }
            public string CatCollectionName { get; set; }
            public string OrderCollectionName { get; set; }
            public string ConnectionString { get; set; }
            public string DatabaseName { get; set; }
        }

        public interface IMenuDatabaseSettings
        {
            public string MenuCollectionName { get; set; }
            public string CatCollectionName { get; set; }
            public string OrderCollectionName { get; set; }
            public string ConnectionString { get; set; }
            public string DatabaseName { get; set; }
        }
    }
}
