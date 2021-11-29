using API_Trailler.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Trailler.Services.Interface
{
    public interface IActorServices
    {
        Task<List<ActorDto>> GetActors();
        Task<ActorDto> GetActorById(int id);
        Task<ActorDto> AddActor(ActorDto actorDto);
        Task<ActorDto> UpdateActor(ActorDto actorDto);
        Task<bool> DeleteActor(int id);
    }
}
