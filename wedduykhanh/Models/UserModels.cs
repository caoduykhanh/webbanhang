using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace wedduykhanh.Models
{
    public class RegisterModels
    {
        [Required]
        public string Username { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [MinLength(6,ErrorMessage ="chieu dai toi thieu 6")]
        [Required]
        public string Pass { get; set; }
        [Required]
        [Compare("Pass",ErrorMessage = "mat khau khong hop le")]
        public string CfPass { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
    }
    public class LoginModels
    {
        public string Email { get; set; }
        public string Pass { get; set; }
    }
}