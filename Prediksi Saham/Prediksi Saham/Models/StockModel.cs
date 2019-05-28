using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prediksi_Saham.Models
{
    public class StockModel
    {
        public DateTime Date { get; set; }
        public string Open { get; set; }
        public string High { get; set; }
        public string Low { get; set; }
        public string Close { get; set; }
        public string AdjClose { get; set; }
        public string Volume { get; set; }
    }
}