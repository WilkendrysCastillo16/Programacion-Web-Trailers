using System;
using System.Collections.Generic;

#nullable disable

namespace API_Traillers.Models
{
    public partial class LoginAdmin
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
    }
}
