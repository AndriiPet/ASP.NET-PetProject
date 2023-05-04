using System;
using System.ComponentModel.DataAnnotations;

namespace BLL.Models
{
    public class UserDto
    {
        public int UserID { get; set; }
        public string Login { get; set; }
        [StringLength(50)]
        public string Password { get; set; }
        [StringLength(40)]
        public string FirstName { get; set; }
        [StringLength(40)]
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        [StringLength(1)]
        public string Gender { get; set; }
    }
}
