using System.ComponentModel.DataAnnotations;

namespace Mission06_Kim.Models
{
    public class Movie // These will be the columns in the Movies table
    {
        [Key]
        [Required]
        public int MovieID { get; set; } // This is the key that is required
        public string Category { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public string Rating { get; set; }
        public bool? Edited { get; set; } // ? makes it not required
        public string? LentTo { get; set; }
        public string? Notes { get; set; }
    }

}
