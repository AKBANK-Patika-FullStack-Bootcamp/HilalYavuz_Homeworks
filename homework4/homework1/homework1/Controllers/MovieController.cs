using DAL.Model;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace homework1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
         List<Movie> movies = new List<Movie>();
         Result result = new Result();
         DBOperations dbOperations = new DBOperations();
         MovieContext context = new MovieContext();



        /// <summary>
        /// T�m film listesini d�nd�r�r.
        /// </summary>
        /// <returns></returns>
        
        [HttpGet]
        public List<Movie> GetMovie()
        {
            //listeyi dolduruyor
           

            return dbOperations.GetMovies();

        }


        /// <summary>
        /// Film ismine g�re belirli bir filmi d�nd�r�r.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("{name}")]
        public Movie GetMovie(string name)
        {
            //listeyi dolduruyor
            movies = dbOperations.GetMovies();
            Movie movie_obj = new Movie();

            //kar��la�t�rma i�lemini yap�yor.
            movie_obj = movies.FirstOrDefault(x => x.title == name);
            return movie_obj;

        }

        /// <summary>
        /// Eklenmek istenen filmi e�er listede yoksa listeye ekler.
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        [HttpPost]
        public Result PostMovie(Movie movie)
        {
            Result result = new Result();
            Movie mov = dbOperations.FindMovie(movie.title);

            

            //verilen film bilgisi listede var m� diye bak�yor
            bool movieCheck = (mov != null) ? true : false;


            if (!movieCheck)
            {
                if(dbOperations.AddModel(movie) == true)
                {
                    result.status = 1;
                    result.message = "Yeni film listeye eklendi.";


                }
                else
                {
                    result.status = 0;
                    result.message = "Hata, kullan�c� eklenemedi.";
                }

               
            }
            else
            {
                result.status = 0;
                result.message = "Bu eleman listede zaten var.";

            }

            return result;
        }


        /// <summary>
        /// �zerinde de�i�iklik yap�lmak istenen filmi e�er listede bulunuyorsa g�nceller.
        /// </summary>
        /// <param name="movie_Id"></param>
        /// <param name="new_value"></param>
        /// <returns></returns>
        [HttpPut("{movie_Id}")]

        public Result UpdateMovie(int movie_Id, Movie new_value)
        {

            movies = dbOperations.GetMovies();

            //verilen film listede var m� diye kontrol ediyor
            Movie? old_value = movies.Find(x => x.id == movie_Id);

            if (old_value != null)
            {
                dbOperations.Updates(old_value,new_value);

                result.status = 1;
                result.message = "Film bilgileri ba�ar�yla g�ncellendi.";


            }
            else
            {
                result.status = 0;
                result.message = "Film bulunamad�.";
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
            
            if (dbOperations.DeleteModel(movie_Id))
            {
               
                result.status = 1;
                result.message = "Kullan�c� silindi.";

            }
            else
            {
                result.status = 0;
                result.message = "Kullan�c� zaten silinmi�.";
            }

            return result;
        }






    }
}