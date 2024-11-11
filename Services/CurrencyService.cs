using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;
using Todo.Interface;

namespace Todo.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly HttpClient _httpClient;
        
        public CurrencyService(HttpClient httpClient) 
        {
            
            _httpClient = httpClient;
        }

       
        public async Task<string> GetCurrency()
        {
            var response = await _httpClient.GetAsync("https://www.tcmb.gov.tr/kurlar/today.xml");

            string responseContent = await response.Content.ReadAsStringAsync();
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(responseContent);

            string json = JsonConvert.SerializeXmlNode(xmlDocument);
            return json;       
        }
    }
}