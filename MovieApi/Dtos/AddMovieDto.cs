using MovieApi.Entity;

namespace MovieApi.Dtos
{
    public class AddMovieDto
    {
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Duration { get; set; }
        public string Summary { get; set; }
        public double IMDbRating { get; set; }
        public List<ActorDto> Actors { get; set; }
        public DirectorDto Director { get; set; }
        public GenreDto Genres { get; set; }
        public List<ReviewDto> Reviews { get; set; }
    }

    public class ReviewDto
    {
        public string ReviewBy { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
    }

    public class ActorDto
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Biography { get; set; }
    }

    public class DirectorDto
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Biography { get; set; }
    }

    public class GenreDto
    {
        public string Name { get; set; }
    }

}
