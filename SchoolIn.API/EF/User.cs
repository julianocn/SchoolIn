using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolIn.API.EF
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public List<Permission> Permissions { get; set; }
    }

    public class Permission
    {
        [Key]
        public int PermissionID{ get; set; }

        [Required]
        public string Key { get; set; }

        [Required]
        public string Value { get; set; }

		public int UserID { get; set; }

        public User User { get; set; }

	}
}
