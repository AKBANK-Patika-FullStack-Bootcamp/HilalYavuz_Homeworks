
using DAL.Model;
using Entities;

namespace homework1.Controllers
{
    public class DBOperations
    {
        private MovieContext _context = new MovieContext();

        public bool AddModel(Movie _movie)
        {
            try
            {
                _context.movie.Add(_movie);
                _context.SaveChanges();
                return true;

            }catch(Exception ex)
            {
                return false;

            }
        }

        public bool DeleteModel(int Id)
        {
            try
            {
                _context.movie.Remove(FindMovie("",Id));
                _context.SaveChanges();
                return true;
                
            }
            catch (Exception exc)
            {
               Console.WriteLine(exc.Message);
                return false;
               
            }
        }
        public Movie FindMovie(string title,int id = 0)
        {
            Movie? mov = new Movie();

            if(!string.IsNullOrEmpty(title))
            {
                mov = _context.movie.FirstOrDefault(m => m.title == title);
            }else if(id > 0) {
                mov = _context.movie.FirstOrDefault(m => m.id == id);
            }
            
            
            return mov;
        }

        public List<Movie> GetMovies()
        {
            List<Movie> movies = new List<Movie>();
            movies = _context.movie.OrderBy(x => x.id).ToList();
            return movies;
        }

        public bool Updates(Movie old_value, Movie new_value)
        {
            Movie? mov = FindMovie("",old_value.id);
            try
            {
                mov.title = new_value.title;
                mov.imdb = new_value.imdb;
                mov.detail_id = new_value.detail_id;
                _context.SaveChanges();
                return true;

            }catch(Exception exc)
            {
                return false;

            }
        }
    }
}
