using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FinalPorjectBuild.Models
{
    public class Users
    {
        public string name { get; set; }
        public int role_id { get; set; }
        public string password { get; set; }
    }
    public class UserCreate
    {
        [Required]
        [StringLength(100, ErrorMessage="You must enter a username")]
        [DataType(DataType.Text)]
        [Display(Name = "User Name")]
        public string Name { get; set; }
        
        [Required]
        public int Role_id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage="The {0} must be atleast {2} characters long", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
    public class UserLogin
    {
        [Required]
        [Display(Name = "User Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be atleast {2} characters long", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
    public class Edit
    {
        public string OldName { get; set; }

        [Display(Name= "User Name")]
        public string NewName { get; set; }

        [Required]
        [Display(Name="Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public int Phone { get; set; }
    }
}