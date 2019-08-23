using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlphaOnlineLearning.Entities
{
    public class Category
    {
        public Category()
        {
            this.Courses = new HashSet<Course>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "The {0} must be between {1} and {2} characters long.")]
        public string Name { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}
