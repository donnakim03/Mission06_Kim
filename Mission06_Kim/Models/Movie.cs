using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Kim.Models
{
    public class Movie // These will be the columns in the Movies table
    {
        [Key]
        [Required]
        public int MovieId { get; set; } // This is the key that is required

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        [Required(ErrorMessage = "Must enter title")]
        public string Title { get; set; }

        [Required]
        [Range(1888, int.MaxValue, ErrorMessage="The year must be greater than or equal to 1888")]
        public int Year { get; set; }
        public string? Director { get; set; }
        public string? Rating { get; set; }

        [Required]
        public bool Edited { get; set; } // ? makes it not required
        public string? LentTo { get; set; }

        [Required]
        public bool CopiedToPlex { get; set; }
        public string? Notes { get; set; }
    }

}
