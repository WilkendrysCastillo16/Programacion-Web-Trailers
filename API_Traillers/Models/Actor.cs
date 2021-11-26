using System;
using System.Collections.Generic;

#nullable disable

namespace API_Traillers.Models
{
    public partial class Actor
    {
        public Actor()
        {
            TraillerActors = new HashSet<TraillerActor>();
        }

        public int Id { get; set; }
        public string NameActor { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<TraillerActor> TraillerActors { get; set; }
    }
}
