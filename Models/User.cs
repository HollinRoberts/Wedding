using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Wedding.Models;

namespace Wedding.Models
{
    public class User
    {
        public int userid {get;set;}
        public string first {get;set;}  
      
        public string last {get;set;}
    
        public string email {get;set;}
      
        public string password {get;set;}

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime createdAt {get;set;}

        public int weddingplanid {get;set;}
        public WeddingPlan wedding {get;set;}
        public int guestlistid {get;set;}

        public List<Guestlist> guestlist {get;set;}

        public User()
        {
            guestlist = new List<Guestlist>();
        }
    }
}