using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Trailler.Models.DTOs
{
    public class TraillerDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public string Review { get; set; }
        public DateTime? YearTrailer { get; set; }
        public string Cover { get; set; }
        public string Link { get; set; }
        public byte? Rating { get; set; }

        public virtual List<TraillerActor> TraillerActors { get; set; }
    }
}
