using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlphaOnlineLearning.Entities
{
    public class Module
    {
        public Module()
        {
            this.Units = new HashSet<Unit>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "The {0} must be between {1} and {2} characters long.")]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public int CourseId { get; set; }

        public Course Course { get; set; }

        public ICollection<Unit> Units { get; set; }
    }
}
