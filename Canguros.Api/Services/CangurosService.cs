using Canguros.Api.Interfaces;
using Canguros.Api.Models.Requests;
using Canguros.Api.Models.Responses;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace Canguros.Api.Services
{
    public class CangurosService : ICanguros
    {
        public async Task<List<CangurosResponse>> GetCangurosDistanceAsync(CangurosRequest cangurosRequest)
        {
            if (cangurosRequest.Canguro1Distancia <= 0 || cangurosRequest.Canguro2Distancia <= 0
                || cangurosRequest.Canguro1Distancia >= 10000 || cangurosRequest.Canguro2Distancia >= 10000
                || cangurosRequest.Canguro1Velocidad <= 1 || cangurosRequest.Canguro1Velocidad >= 10000
                || cangurosRequest.Canguro2Velocidad <= 1 || cangurosRequest.Canguro2Velocidad >= 10000)
            {
                throw new Exception("Error de parámetros.");
            }

            var response = new List<CangurosResponse>();

            do
            {
                response.Add(new CangurosResponse
                {
                    Canguro1Distancia = cangurosRequest.Canguro1Distancia,
                    Canguro2Distancia = cangurosRequest.Canguro2Distancia,
                    Canguro1Velocidad = cangurosRequest.Canguro1Velocidad,
                    Canguro2Velocidad = cangurosRequest.Canguro2Velocidad,
                    Response = false
                });

                cangurosRequest.Canguro1Distancia += cangurosRequest.Canguro1Velocidad;
                cangurosRequest.Canguro2Distancia += cangurosRequest.Canguro2Velocidad;

                // Puse un límite de 2000 metros para evitar Overflow.
                // Si llega a 2000, sale del do-while.
                if (cangurosRequest.Canguro1Distancia >= 2000 || cangurosRequest.Canguro2Distancia >= 2000)
                    break;
            } while (cangurosRequest.Canguro1Distancia != cangurosRequest.Canguro2Distancia);

            var lastResponse = new CangurosResponse
            {
                Canguro1Distancia = cangurosRequest.Canguro1Distancia,
                Canguro2Distancia = cangurosRequest.Canguro2Distancia,
                Canguro1Velocidad = cangurosRequest.Canguro1Velocidad,
                Canguro2Velocidad = cangurosRequest.Canguro2Velocidad
            };

            if (cangurosRequest.Canguro1Distancia >= 2000 || cangurosRequest.Canguro2Distancia >= 2000)
                lastResponse.Response = false;
            else
                lastResponse.Response = true;

            response.Add(lastResponse);

            return response;
        }
    }
}
