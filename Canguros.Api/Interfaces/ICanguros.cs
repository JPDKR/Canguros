using Canguros.Api.Models.Requests;
using Canguros.Api.Models.Responses;
using System.ComponentModel.DataAnnotations;

namespace Canguros.Api.Interfaces
{
    public interface ICanguros
    {
        public Task<List<CangurosResponse>> GetCangurosDistanceAsync(CangurosRequest cangurosRequest);
    }
}
