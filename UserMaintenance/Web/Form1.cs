﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;
using Web.Entities;
using Web.MnbServiceReference;

namespace Web
{
    public partial class Form1 : Form
    {
        BindingList<RateData> Rates = new BindingList<RateData>();
        
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = Rates;
            string eredmeny =  SzolgaltatasHivas();
            XML(eredmeny);
            Megjelenites();
        }
        public string SzolgaltatasHivas() 
        {
            MNBArfolyamServiceSoapClient mnbService = new MNBArfolyamServiceSoapClient();
            GetExchangeRatesRequestBody request = new GetExchangeRatesRequestBody()
            {
                currencyNames = "EUR",
                startDate = "2020-01-01",
                endDate = "2020-06-30"
            };
            var response = mnbService.GetExchangeRates(request);
            var result = response.GetExchangeRatesResult;
            return result;

        }
        void XML(string result) 
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(result);
            foreach (XmlElement element in xml.DocumentElement)
            {
                RateData rate = new RateData();
                Rates.Add(rate);
                rate.Date = DateTime.Parse(element.GetAttribute("date"));
                var childelement = (XmlElement)element.ChildNodes[0];
                rate.Currency = childelement.GetAttribute("curr");

                var unit =  decimal.Parse(childelement.GetAttribute("unit"));
                var value = decimal.Parse(childelement.InnerText);
                if (unit != 0)
                {
                    rate.Value = value / unit;
                }


            }
        }
        void Megjelenites() 
        {
            chartRateData.DataSource = Rates;
            var series = chartRateData.Series[0];
            series.ChartType = SeriesChartType.Line;
            series.XValueMember = "Date";
            series.YValueMembers = "Value";
            series.BorderWidth = 2;
            var legend = chartRateData.Legends[0];
            legend.Enabled = false;
            var chartArea = chartRateData.ChartAreas[0];
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.Enabled = false;
            chartArea.AxisY.IsStartedFromZero = false;


        }


    }
}
