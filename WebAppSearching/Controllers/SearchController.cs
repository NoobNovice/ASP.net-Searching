using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppSearching.Models;
using System.Net;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace WebAppSearching.Controllers
{
    public class SearchController : Controller
    {
        private static string url = "https://raw.githubusercontent.com/prust/wikipedia-movie-data/master/movies.json";
        private static string jsonString = new WebClient().DownloadString(url);
        private static List<Movie> movies = JsonConvert.DeserializeObject<List<Movie>>(jsonString);

        //private static Dictionary<string,List<Movie>> table = SetTable();
        // GET: Search
        public ActionResult Index(string searchName)
        {
            return View(SearchMovie(searchName));
        }

        private List<Movie> SearchMovie(string searchName)
        {
            if(searchName == null || searchName == "")
            {
                return movies;
            }
            Regex pattern = new Regex(searchName.ToLower());
            List<Movie> sender = new List<Movie>();

            foreach(Movie movie in movies)
            {
                if (pattern.IsMatch(movie.Title.ToLower()))
                {
                    sender.Add(movie);
                }
            }
            return sender;
        }

        //private List<Movie> InvertKeySearch(string searchName)
        //{
            
        //}

        //private KeyValuePair<string, List<Movie>> SetTable()
        //{
        //    table = new Dictionary<string, List<Movie>>();
        //    foreach(Movie movie in movies)
        //    {
        //        string[] words = movie.Title.Split(' ');
        //        foreach(string word in words)
        //        {
        //            if (table.ContainsKey(word))
        //            {
        //                table[word].Add(movie.);
        //            }
        //        }
        //    }
        //}
    }
}