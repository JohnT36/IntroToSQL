using System;
using System.Collections.Generic;
using System.Text;

namespace IntroToSQL
{
    public class Product
    {

        public int ProductID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int CategoryType { get; set; }
        public int OnSale { get; set; }
        public string StockLevel { get; set; }

    }
}
