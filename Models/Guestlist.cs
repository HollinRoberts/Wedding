using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Wedding.Models;

namespace Wedding.Models
{
    public class Guestlist
    {
        public int guestlistid {get;set;}
        public int userid {get;set;}

        public User User{get;set;}
      
        public int weddingplanid {get;set;}

        public WeddingPlan WeddingPlan{get;set;}
     
    }
}