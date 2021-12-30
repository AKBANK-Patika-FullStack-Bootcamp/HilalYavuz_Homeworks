using homework1.Model;
using Microsoft.AspNetCore.Mvc;

namespace homework1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private List<Movie> movies = new List<Movie>();
        private Result result = new Result();


        /// <summary>
        /// Tüm film listesini döndürür.
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public List<Movie> GetMovie()
        {
            //listeyi dolduruyor
            movies = AddMovies();
            return movies;

        }


        /// <summary>
        /// Film ismine göre belirli bir filmi döndürür.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("{name}")]
        public Movie GetMovie(string name)
        {
            //listeyi dolduruyor
            movies = AddMovies();
            Movie movie_obj = new Movie();

            //karþýlaþtýrma iþlemini yapýyor.
            movie_obj = movies.FirstOrDefault(x => x.Title == name);
            return movie_obj;

        }

        /// <summary>
        /// Eklenmek istenen filmi eðer listede yoksa listeye ekler.
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        [HttpPost]
        public Result PostMovie(Movie movie)
        {
            Result result = new Result();

            movies = AddMovies();

            //verilen film bilgisi listede var mý diye bakýyor
            bool userCheck = movies.Select(x => x.Id == movie.Id && x.Title.Equals(movie.Title)).FirstOrDefault();

            if (!userCheck)
            {
                movies.Add(movie);

                result.status = 1;
                result.message = "Yeni film listeye eklendi.";
                result.movies = movies;
            }
            else
            {
                result.status = 0;
                result.message = "Bu eleman listede zaten var.";

            }

            return result;
        }


        /// <summary>
        /// Üzerinde deðiþiklik yapýlmak istenen filmi eðer listede bulunuyorsa günceller.
        /// </summary>
        /// <param name="movie_Id"></param>
        /// <param name="new_value"></param>
        /// <returns></returns>
        [HttpPut("{movie_Id}")]

        public Result UpdateMovie(int movie_Id, Movie new_value)
        {

            movies = AddMovies();
            //verilen film listede var mý diye kontrol ediyor
            Movie? old_value = movies.Find(x => x.Id == movie_Id);

            if (old_value != null)
            {
                movies.Add(new_value);
                movies.Remove(old_value);

                result.status = 1;
                result.message = "Film bilgileri baþarýyla güncellendi.";
                result.movies = movies;


            }
            else
            {
                result.status = 0;
                result.message = "Film bulunamadý.";
            }

            return result;



        }

        /// <summary>
        /// Verilen id'ye ait filmi film listesinden siliyor.
        /// </summary>
        /// <param name="movie_Id"></param>
        /// <returns></returns>
        [HttpDelete("{movie_Id}")]
        public Result DeleteMovie(int movie_Id)
        {
            movies = AddMovies();
            Movie? old_movie = movies.Find(x => x.Id == movie_Id);

            if (old_movie != null)
            {
                movies.Remove(old_movie);
                result.status = 1;
                result.message = "Kullanýcý silindi.";
                result.movies = movies;

            }
            else
            {
                result.status = 0;
                result.message = "Kullanýcý zaten silinmiþ.";
            }

            return result;
        }



        /// <summary>
        /// Film listesini doldurur.
        /// </summary>
        /// <returns>Doldurduðu listeyi döndürür.</returns>
        public List<Movie> AddMovies()
        {
            movies = new List<Movie>();

            movies.Add(new Movie { Id = 1, Title = "The Shawshank Redemption", Imdb = 9.3 });
            movies.Add(new Movie { Id = 2, Title = "Pulp Fiction", Imdb = 8.9 });
            movies.Add(new Movie { Id = 3, Title = "Fight Club", Imdb = 8.8 });
            return movies;

        }





    }
}