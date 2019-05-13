using System;
using System.Collections.Generic;
using System.Text;

namespace Lab11
{
    public static class MovieApp
    {
        public static void Run()
        {
            var movieList = SeedDB.LoadMovies();
            do
            {
                var foundMovies = LookupMovies(movieList);
                DisplayMovies(foundMovies);
            } while (Workflow.KeepGoing("\nContinue?"));
        }
        private static List<Movie> LookupMovies(List<Movie> movieList)
        {
            var input = GetUserInputCategory("What category are you interested in? ");
            var foundMovies = new List<Movie>();

            foreach (var movie in movieList)
            {
                if (movie.Genre == input)
                {
                    foundMovies.Add(movie);
                }
            }
            return foundMovies;
        }
        private static void DisplayMovies(List<Movie> foundMovies)
        {
            Console.Clear();
            Console.Write($"{foundMovies.Count} {foundMovies[0].Genre.ToString()} ");
            switch (foundMovies.Count)
            {
                case 1:
                    Console.Write("movie");
                    break;
                default:
                    Console.Write("movies");
                    break;
            }
            Console.Write(" found:\n\n");

            int maxTitleLength = 0, maxYearLength = 0, maxRatingLength = 0, maxCategoryLength = 0;
            foreach (var movie in foundMovies)
            {
                if (movie.Title.Length >= maxTitleLength) maxTitleLength = movie.Title.Length;
                if (movie.Year.ToString().Length >= maxYearLength) maxYearLength = movie.Year.ToString().Length;
                if (movie.Rating.ToString().Length >= maxRatingLength) maxRatingLength = movie.Rating.ToString().Length;
                if (movie.Genre.ToString().Length >= maxCategoryLength) maxCategoryLength = movie.Genre.ToString().Length;
            }
            string tableEdge = new string($"+" +
                $"{new string('-', maxTitleLength+2)}+" +
                $"{new string('-', maxYearLength + 2)}+" +
                $"{new string('-', maxRatingLength + 2)}+" +
                $"{new string('-', maxCategoryLength + 2)}+");
            Console.WriteLine(tableEdge);
            foreach (var movie in foundMovies)
            {
                Console.WriteLine($"" +
                    $"| {movie.Title}{new string(' ', maxTitleLength - movie.Title.Length)} " +
                    $"| {movie.Year}{new string(' ', maxYearLength - movie.Year.ToString().Length)} " +
                    $"| {movie.Rating}{new string(' ', maxRatingLength - movie.Rating.ToString().Length)} " +
                    $"| {movie.Genre.ToString()}{new string(' ', maxCategoryLength - movie.Genre.ToString().Length)} |");
            }
            Console.WriteLine(tableEdge);
        }
        private static Category GetUserInputCategory(string question)
        {
            Console.WriteLine(question);
            while (true)
            {
                Workflow.DisplayEnumValues(typeof(Category));

                var input = Console.ReadLine();
                if (Enum.TryParse<Category>(input, out Category result) && Enum.IsDefined(typeof(Category), result))
                {
                    return result;
                }
                Console.WriteLine("Input Error. Please try again.");
            }
        }
    }
}
