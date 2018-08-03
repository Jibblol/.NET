using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello
{
    class Program
    {
        static void Main(string[] args)
        {
            string movie1 = "inception";
            string movie2 = "bastard";

            List<string> movieList;
            movieList = new List<string>();

            movieList.Add(movie1);
            movieList.Add(movie2);

            Console.WriteLine("Your name:");
            string name = Console.ReadLine();

            Console.WriteLine("Hello, " + name);

            Console.WriteLine("Enter the name of the movie to add to the list:");
            string movie = Console.ReadLine();

            movieList.Add(movie);
            
            Console.WriteLine("You added: " + movie);

            foreach(string s in movieList) {
                Console.WriteLine(s);
            }
        }

        public void ListMovies()
        {
            foreach(string s in movieList) {

            }
        }

    }
}
