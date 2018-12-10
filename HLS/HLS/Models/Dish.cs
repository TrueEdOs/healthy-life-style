using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace HLS.Models
{
    public class Dish
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Description { get; set; } = "";
        public string Name { get; set; } = "";
        public string Properties { get; set; } = "";
        public double CalloriesSpend { get; set; }
        public double ProteinsSpend { get; set; }
        public double CarbohydratesSpend { get; set; }
        public double FatsSpend { get; set; }
    }
}
