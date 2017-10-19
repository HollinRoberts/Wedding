using System.ComponentModel.DataAnnotations;

namespace Wedding.Models
{
    public class Login
    {
        [Required]
        [EmailAddress]
        public string Email {get;set;}
        [Required]
        [MinLength(8)]
      
        public string Password {get;set;}
       
    }
}