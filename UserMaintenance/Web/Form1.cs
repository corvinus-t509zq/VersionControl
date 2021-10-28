using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        }


    }
}
