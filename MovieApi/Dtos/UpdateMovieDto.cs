using MovieApi.Entity;

namespace MovieApi.Dtos
{
    public class UpdateMovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Duration { get; set; }
        public string Summary { get; set; }
        public double IMDbRating { get; set; }
    }


}
