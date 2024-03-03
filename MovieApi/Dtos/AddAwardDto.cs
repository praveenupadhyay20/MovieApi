using MovieApi.Entity;

namespace MovieApi.Dtos
{
    public class AddAwardDto
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public string Category { get; set; }
        public double IMDbRating { get; set; }
        public string Description { get; set; }
        public int MovieId { get; set; }
    }

}
