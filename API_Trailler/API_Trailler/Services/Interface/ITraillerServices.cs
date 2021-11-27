using API_Trailler.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Trailler.Services.Interface
{
    public interface ITraillerServices
    {
        Task<List<TraillerDto>> GetTraillers();
        Task<TraillerDto> GetTraillerById(int id);
        Task<TraillerDto> AddTrailler(TraillerDto traillerDto);
        Task<TraillerDto> UpdateTrailler(TraillerDto traillerDto);
        Task<bool> DeleteTrailler(int id);
    }
}
