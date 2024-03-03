using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieApi.Entity
{
    public class Actor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(150)]
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }

        [MaxLength(500)]
        public string Biography { get; set; }

        public List<Movie> Movies { get;}
        public List<Award> Awards { get; set; }
    }
}
