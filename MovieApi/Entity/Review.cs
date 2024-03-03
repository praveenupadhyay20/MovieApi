using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieApi.Entity
{
    public class Review
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Rating { get; set; }

        [MaxLength(500)]
        public string Text { get; set; }
        public DateTime DatePosted { get; set; } = DateTime.Now;

        [MaxLength(150)]
        public string ReviewBy { get; set; }
        public Movie Movie { get; set; }
        public int MovieId { get; set; }
    }
}
