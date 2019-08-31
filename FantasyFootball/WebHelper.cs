using FantasyFootball.Data.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;

namespace FantasyFootball
{
    class WebHelper
    {
        public const string WEBPAGE = "https://football.fantasysports.yahoo.com/f1/992613/playersearch?&search=";
        public const string SEARCH = "http://gatherer.wizards.com/Pages/Search/Default.aspx?page=";
        public const string SelectSetComboBoxId = "ctl00_ctl00_MainContent_Content_SearchControls_setAddText";

        public static async Task StartCrawlerAsync()
        {
            Console.WriteLine("Enter Program");

            // Specify URL of site to test here
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(WEBPAGE);
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);
            var setsDropDown = htmlDocument.GetElementbyId(SelectSetComboBoxId);
            var sets = setsDropDown.Descendants("option").ToList();
            foreach (var set in sets)
            {
                try
                {
                    int pageCount = 0;
                    string setName = set.InnerHtml;
                    if (string.IsNullOrEmpty(setName)) continue;

                    setName = setName.Replace(' ', '+');

                    while (true)
                    {
                        string webPage = $"{SEARCH}{pageCount++}&set=[%22{setName}%22]";

                        var setList = new HttpClient();
                        var setListHtml = await setList.GetStringAsync(webPage);
                        htmlDocument = new HtmlDocument();
                        htmlDocument.LoadHtml(setListHtml);

                        var cardList = htmlDocument.DocumentNode.Descendants().Where(o => o.GetAttributeValue("class", "").Equals("cardInfo")).ToList();
                        string firstCardName = cardList.First().Descendants("a").FirstOrDefault().InnerHtml.Trim();

                        foreach (var card in cardList)
                        {
                            
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }

            Console.WriteLine("Exit Program");
            return;
        }

        public static async Task<HtmlDocument> GetHtmlDocument(string url)
        {
            // Specify URL of site to test here
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            return htmlDocument;
        }

        public static void PrintDecendants(HtmlNode node)
        {
            Console.WriteLine(node.InnerHtml);

            //if (!node.HasChildNodes)
            //    return;

            foreach (HtmlNode childNode in node.Descendants())
            {
                Console.WriteLine(childNode.GetClasses());
                //PrintDecendants(childNode);
            }
        }
    }
}
