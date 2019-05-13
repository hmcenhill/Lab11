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
            switch (foundMovies.Count)
            {
                case 1:
                    Console.WriteLine($"{foundMovies.Count} {foundMovies[0].Genre.ToString()} movie found:\n");
                    break;
                default:
                    Console.WriteLine($"{foundMovies.Count} {foundMovies[0].Genre.ToString()} movies found:\n");
                    break;
            }
            foreach (var movie in foundMovies)
            {
                Console.WriteLine(movie.Title);
            }

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
