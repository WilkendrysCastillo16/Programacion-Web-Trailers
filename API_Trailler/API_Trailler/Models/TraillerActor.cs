using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;


#nullable disable

namespace API_Trailler.Models
{
    public partial class TraillerActor
    {
        public int Id { get; set; }
        public int? IdTrailler { get; set; }
        public int? IdActor { get; set; }

        public Actor IdActorNavigation { get; set; }

  
        public Trailler IdTraillerNavigation { get; set; }
    }
}
