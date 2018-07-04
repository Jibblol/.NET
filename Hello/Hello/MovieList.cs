using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello
{
    class MovieList
    {

        private List<string> movies;

        public MovieList()
        {
            movies = new List<string>();
        }

        public void AddMovie(string movie)
        {
            movies.Add(movie);
        }

    }
}
