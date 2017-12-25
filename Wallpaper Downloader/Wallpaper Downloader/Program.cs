using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using HtmlAgilityPack;

namespace WallpaperDownloader
{
     class Program
    {
        // This is a wallpaper downloader in c#
        // Made on 25/12/17
        // Took about 90 mins
        // Scrapes the images from https://www.wallpapaercave.com
        // Scraper Package: HtmlAgilityPack
        // First Project in c#!
        // Made by Saqlain Hussain
        public static void Main(string[] args)
        {
            
            var baseUrl = "https://www.wallpapercave.com/";
            
            HtmlAgilityPack.HtmlWeb web = new HtmlWeb();
           
            Console.WriteLine("Where would you like to download the image? (Please give full path)");

            var path = Console.ReadLine();

            Directory.SetCurrentDirectory(path);
            
            Console.WriteLine("What would you like to download from? (Tv Show,Nature,Cartoon)");

            var topic = Console.ReadLine();

            baseUrl += topic + "-wallpapers";

            var imageBaseUrl = "https://www.wallpapercave.com/";
            
            HtmlAgilityPack.HtmlDocument doc = web.Load(baseUrl);

            var imageContainers = doc.DocumentNode.SelectNodes("//img[@class='wpimg']").ToArray();

            
            
            Console.WriteLine("There are {0} wallpapers available. How many would you like?",imageContainers.Length);

            var numImages = Convert.ToInt32(Console.ReadLine());

            var i = 0;

            try
            {
                Directory.CreateDirectory(topic);
                Directory.SetCurrentDirectory(topic);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            while (i <= numImages-1)
            {
                
                    
                var src = imageContainers[i].Attributes["src"].Value;

                imageBaseUrl += src;

                using (WebClient client = new WebClient())
                {
                    Console.WriteLine(imageBaseUrl);
                    client.DownloadFile(imageBaseUrl,i.ToString()+".jpg");
                    imageBaseUrl = "https://www.wallpapercave.com/";
                }


                i++;
            }
        }
    }
}