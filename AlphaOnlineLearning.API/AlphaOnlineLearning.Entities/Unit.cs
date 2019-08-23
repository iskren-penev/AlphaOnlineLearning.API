using System.ComponentModel.DataAnnotations;

namespace AlphaOnlineLearning.Entities
{
    public class Unit
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "The {0} must be between {1} and {2} characters long.")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Content URL")]
        [StringLength(500, MinimumLength = 20, ErrorMessage = "The {0} must be between {1} and {2} characters long.")]
        public string ContentUrl { get; set; }

        public int ModuleId { get; set; }

        public Module Module { get; set; }
    }
}
