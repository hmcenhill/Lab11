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
                LookupMovies(movieList);
            } while (Workflow.KeepGoing("Continue?"));
        }

        private static void LookupMovies(List<Movie> movieList)
        {
            var input = GetUserInputCategory("What category are you interested in? ");
            int movieCount = 0;
            foreach (var movie in movieList)
            {
                if (movie.Genre == input)
                {
                    Console.WriteLine(movie.Title);
                    movieCount++;
                }
            }
            Console.WriteLine($"{movieCount} movie(s) found");
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
