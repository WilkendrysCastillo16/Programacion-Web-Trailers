using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Trailler.Models.DTOs
{
    public class ResponseDto
    {
        public bool Correcto { get; set; } = true;
        public object Result { get; set; }
        public string Mensaje { get; set; }
        public List<string> ErrorMensaje { get; set; }

    }
}
