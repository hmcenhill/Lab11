using System;
using System.Collections.Generic;
using System.Text;

namespace Lab11
{
    public class Movie
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public float Rating { get; set; }
        public Category Genre { get; set; }

        public Movie(string title, int year, float rating, Category genre)
        {
            Title = title;
            Year = year;
            Rating = rating;
            Genre = genre;
        }
    }
}
