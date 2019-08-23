using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlphaOnlineLearning.Entities
{
    public class Course
    {
        public Course()
        {
            this.Comments = new HashSet<Comment>();
            this.UserCourses = new HashSet<UserCourse>();
            this.Modules = new HashSet<Module>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "The {0} must be between {1} and {2} characters long.")]
        public string Name { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 150, ErrorMessage = "The {0} must be between {1} and {2} characters long.")]
        public string Description { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<Module> Modules { get; set; }

        public ICollection<UserCourse> UserCourses { get; set; }
    }
}
