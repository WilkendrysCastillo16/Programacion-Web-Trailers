using System;
using System.Collections.Generic;

#nullable disable

namespace API_Trailler.Models
{
    public partial class TraillerActor
    {
        public int Id { get; set; }
        public int? IdTrailler { get; set; }
        public int? IdActor { get; set; }

        public virtual Actor IdActorNavigation { get; set; }
        public virtual Trailler IdTraillerNavigation { get; set; }
    }
}
