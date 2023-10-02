using Canguros.Api.Helpers;

namespace Canguros.Api.Models.Responses
{
    public class CangurosResponse
    {
        public int Canguro1Distancia { get; set; }
        public int Canguro1Velocidad { get; set; }
        public int Canguro2Distancia { get; set; }
        public int Canguro2Velocidad { get; set; }
        public bool Response { get; set; }
    }
}
