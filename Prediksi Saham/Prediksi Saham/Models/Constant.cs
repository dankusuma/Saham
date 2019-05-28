using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Prediksi_Saham.Models
{
    public class Constant
    {
        public string BBCA_JK_CSV { get; set; }
        public string BMRI_JK_CSV { get; set; }
        public string BDMN_JK_CSV { get; set; }
        public string BNGA_JK_CSV { get; set; }
        public string MAYA_JK_CSV { get; set; }

        public Constant()
        {
            BBCA_JK_CSV  = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"/CSV/stockfile/BBCA.JK.csv");
            BMRI_JK_CSV = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"/CSV/stockfile/BMRI.JK.csv");
            BDMN_JK_CSV = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"/CSV/stockfile/BDMN.JK.csv");
            BNGA_JK_CSV = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"/CSV/stockfile/BNGA.JK.csv");
            MAYA_JK_CSV = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"/CSV/stockfile/MAYA.JK.csv");

        }

    }
}