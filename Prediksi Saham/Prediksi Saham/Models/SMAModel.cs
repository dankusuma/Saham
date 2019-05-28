using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prediksi_Saham.Models
{

    public class SMAModel
    {
        public List<SMAModelDetail> BCA { get; set; }
        public List<SMAModelDetail> Mandiri { get; set; }
        public List<SMAModelDetail> Danamon { get; set; }
        public List<SMAModelDetail> CIMB { get; set; }
        public List<SMAModelDetail> MAYA { get; set; }
    }

    public class SMAModelDetail
    {
        public double average { get; set; }
        public string month { get; set; }
        public string year { get; set; }
    }
}