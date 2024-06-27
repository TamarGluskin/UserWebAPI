using System.ComponentModel.DataAnnotations;

namespace UsersManagementConsist.Model
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string UserPassword { get; set; }
    }
}
