using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Wedding.Models;

namespace Wedding.Models
{
    public class WeddingPlan
    {
        public int weddingplanid {get;set;}
        public string One {get;set;}  
      
        public string Two {get;set;}
    
        public DateTime Date {get;set;}
      
        public string Address {get;set;}

        public int userid{get;set;}

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime createdAt {get;set;}

        public int guestlistid {get;set;}

        public List<Guestlist> guestlist {get;set;}

        public WeddingPlan()
        {
            guestlist = new List<Guestlist>();
        }
    }
}