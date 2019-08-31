using FantasyFootball.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FantasyFootball
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start\n\n");
            DbHelper.TestDatabase();
            //WebHelper.StartCrawlerAsync();
        }        
    }
}
