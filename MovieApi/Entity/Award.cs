using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieApi.Entity
{
    public class Award
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(150)]
        public string Name { get; set; }

        [MaxLength(150)]
        public string Category { get; set; }
        public int Year { get; set; }
        public int MovieId { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
    }
}
