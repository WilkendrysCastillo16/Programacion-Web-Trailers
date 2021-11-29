using API_Trailler.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Trailler.Services.Interface
{
    public interface ITraillerActorServices
    {
        Task<List<TraillerActorDto>> GetTraillerActor();
        Task<List<TraillerActorJoinDto>> GetTraillerActorJoin();
        Task<TraillerActorDto> GetTraillerActorById(int id);
        Task<TraillerActorJoinDto> GetTraillerActorJoinById(int id);
        Task<TraillerActorDto> AddTraillerActor(TraillerActorDto traillerActorDto);
        Task<TraillerActorDto> UpdateTraillerActor(TraillerActorDto traillerActorDto);
        Task<bool> DeleteTraillerActor(int id);


    }
}
