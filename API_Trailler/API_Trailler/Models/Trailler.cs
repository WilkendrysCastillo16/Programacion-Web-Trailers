using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace API_Trailler.Models
{
    public partial class Trailler
    {
        public Trailler()
        {
            TraillerActors = new HashSet<TraillerActor>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public string Review { get; set; }
        public DateTime? YearTrailer { get; set; }
        public string Cover { get; set; }
        public string Link { get; set; }
        public byte? Rating { get; set; }
        
        public virtual ICollection<TraillerActor> TraillerActors { get; set; }
    }
}
