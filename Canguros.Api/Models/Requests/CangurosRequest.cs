using System.ComponentModel.DataAnnotations;

namespace Canguros.Api.Models.Requests
{
    public class CangurosRequest
    {
        [Required]
        public int Canguro1Distancia { get; set; }
        [Required]
        public int Canguro1Velocidad { get; set; }
        [Required]
        public int Canguro2Distancia { get; set; }
        [Required]
        public int Canguro2Velocidad { get; set; }
    }
}
