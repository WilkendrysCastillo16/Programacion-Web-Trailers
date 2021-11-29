using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Trailler.Models.DTOs
{
    public class TraillerActorDto
    {
        public int Id { get; set; }
        public int? IdTrailler { get; set; }
        public int? IdActor { get; set; }
    }
}
