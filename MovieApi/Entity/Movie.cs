using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieApi.Entity
{
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [MaxLength(150)]
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Duration { get; set; }
        [MaxLength(500)] 
        public string Summary { get; set; }
        public double IMDbRating { get; set; }
        public List<Actor> Actors { get; set; } = new List<Actor>();
        public Genre Genres { get; set; }
        public Director Director { get; set; }
        public List<Review> Reviews { get; set; } = new List<Review>();
        public List<Award> Awards { get; set; } = new List<Award>();
        public int DirectorId { get; set; }
        public int GenreId { get; set; }

    }
}
