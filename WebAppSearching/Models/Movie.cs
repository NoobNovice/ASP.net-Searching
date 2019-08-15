using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppSearching.Models
{
    public class Movie
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public List<string> Cast { get; set; }
        public List<string> Genres { get; set; }
    }
}