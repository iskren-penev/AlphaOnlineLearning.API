using System.ComponentModel.DataAnnotations;

namespace AlphaOnlineLearning.Entities
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(10000, ErrorMessage = "Maximum content length is 10000 symbols.")]
        public string Content { get; set; }

        public Course Course { get; set; }

        [Required]
        public int CourseId { get; set; }

        public User Author { get; set; }
    }
}
