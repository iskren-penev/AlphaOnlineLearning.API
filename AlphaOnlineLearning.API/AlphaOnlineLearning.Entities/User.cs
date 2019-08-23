using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlphaOnlineLearning.Entities
{
    public class User : IdentityUser
    {
        public User()
        {
            this.UserCourses = new HashSet<UserCourse>();
        }

        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }

        [StringLength(30)]
        public string LastName { get; set; }

        public ICollection<UserCourse> UserCourses { get; set; }
    }
}
