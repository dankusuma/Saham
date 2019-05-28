using Prediksi_Saham.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Prediksi_Saham.Controllers
{
    public class DataStockController : ApiController
    {

        [HttpGet]
        public  List<StockModel> RefreshModel(string fileurl)
        {
            List<StockModel> stockmodels = new List<StockModel>();
            var reader = new StreamReader(fileurl);
            string csvDataLine = ""; int CurrentLine = 0;
            string[] StockData = null;
                #region while loop
                        // Looping to read the File stream and Add Data to the database line by line
            while ((csvDataLine = reader.ReadLine()) != null)
            {
                // Ignore First Line of the file where columns names
                if (CurrentLine != 0)
                {
                    csvDataLine = csvDataLine.Trim();
                    if (!csvDataLine.Contains(",,,,,,"))
                    {
                        StockData = csvDataLine.Split(',');
                        if (!string.IsNullOrEmpty(StockData[0]))
                        {
                            StockModel stockmodel = new StockModel();
                            stockmodel.Date = DateTime.Parse(StockData[0]);
                            stockmodel.Open = StockData[1];
                            stockmodel.High = StockData[2];
                            stockmodel.Low = StockData[3];
                            stockmodel.Close = StockData[4];
                            stockmodel.AdjClose = StockData[5];
                            stockmodel.Volume = StockData[6];

                            stockmodels.Add(stockmodel);

                        }
                        else
                        {

                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    CurrentLine += 1;
                }
            }
                        #endregion
            return stockmodels;
        }

        [HttpGet]
        public SMAModel SMAALLBANK(string yearstart, string yearend)
        {
            SMAModel smas = new SMAModel();
            Constant C = new Constant();
            smas.BCA = SMA(yearstart, yearend, C.BBCA_JK_CSV);
            smas.Mandiri = SMA(yearstart, yearend, C.BMRI_JK_CSV);
            smas.Danamon = SMA(yearstart, yearend, C.BDMN_JK_CSV);
            smas.CIMB = SMA(yearstart, yearend, C.BNGA_JK_CSV);
            smas.MAYA = SMA(yearstart, yearend, C.MAYA_JK_CSV);
            return smas;
        }

        [HttpGet]
        public List<SMAModelDetail> SMA(string yearstart,string yearend,string fileurl)
        {
            
           List<SMAModelDetail> smas = new List<SMAModelDetail>();
           List<StockModel> stockmodels = RefreshModel(fileurl).Where(x => int.Parse(x.Date.Year.ToString())>=int.Parse(yearstart) && int.Parse(x.Date.Year.ToString())<=int.Parse(yearend)).ToList();
           for (int i = 1;i<=stockmodels.Count();i++)
           {
               int index = i - 1;
               if (i % 3 == 0)
               {
                   SMAModelDetail sma = new SMAModelDetail();
                   double sum = double.Parse(stockmodels[index].Close) + double.Parse(stockmodels[index - 1].Close) + double.Parse(stockmodels[index - 2].Close);
                   double avg = sum / 3;
                   sma.average = avg;
                   sma.month = stockmodels[i - 1].Date.Month.ToString();
                   sma.year = stockmodels[i - 1].Date.Year.ToString();
                   smas.Add(sma);
               }
           }
           return smas;
        }



        // GET api/datastock/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/datastock
        public void Post([FromBody]string value)
        {
        }

        // PUT api/datastock/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/datastock/5
        public void Delete(int id)
        {
        }
    }
}
