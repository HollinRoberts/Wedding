using System.ComponentModel.DataAnnotations;

namespace Wedding.Models
{
    public class regvalidate
    {
        [Required]
        [MinLength(2)]
        public string FirstName {get;set;}
        
        [Required]
        [MinLength(2)]
        public string LastName {get;set;}
    
        [Required]
        [EmailAddress]
        public string Email {get;set;}
        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password {get;set;}
        [Required]
        [MinLength(8)]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string Confirm {get;set;}

    }
}