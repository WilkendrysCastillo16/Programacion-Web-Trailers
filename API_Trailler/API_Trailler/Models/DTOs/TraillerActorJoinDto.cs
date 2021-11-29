using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Trailler.Models.DTOs
{
    public class TraillerActorJoinDto
    {
        
        public Trailler trailler { get; set; }
        public List<Actor> actor { get; set; }


    }
}
