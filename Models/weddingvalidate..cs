using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Wedding.Models;
using System.ComponentModel.DataAnnotations;

namespace Wedding.Models
{
    public class WeddingValidate
    {
        public int userid {get;set;}
        [Required]
        [MinLength(2)]
        public string One {get;set;}  
        [Required]
        [MinLength(2)]
        public string Two {get;set;}
        [Required]
     
        public DateTime Date {get;set;}
        [Required]
        [MinLength(2)]
        public string Address {get;set;}

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime createdAt {get;set;}
        
    }
}