using API_Trailler.Data;
using API_Trailler.Models;
using API_Trailler.Models.DTOs;
using API_Trailler.Services.Interface;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Trailler.Services
{
    public class ActorServices : IActorServices
    {
        private readonly dbTraillerContext _dbTraillerContext;
        private IMapper _mapper;
        public ActorServices(dbTraillerContext dbTraillerContext, IMapper mapper)
        {
            _dbTraillerContext = dbTraillerContext;
            _mapper = mapper;
        }

        public async Task<List<ActorDto>> GetActors()
        {
            try
            {
                List<Actor> listaActor = await _dbTraillerContext.Actors.ToListAsync();

                return _mapper.Map<List<ActorDto>>(listaActor);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ActorDto> GetActorById(int id)
        {
            try
            {
                Actor actor = await _dbTraillerContext.Actors.FindAsync(id);

                return _mapper.Map<ActorDto>(actor);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ActorDto> AddActor(ActorDto actorDto)
        {
            try
            {
                Actor actor = _mapper.Map<ActorDto, Actor>(actorDto);

                await _dbTraillerContext.Actors.AddAsync(actor);
                await _dbTraillerContext.SaveChangesAsync();

                return _mapper.Map<Actor, ActorDto>(actor);
            }
            catch
            {
                throw;
            }
        }

        public async Task<ActorDto> UpdateActor(ActorDto actorDto)
        {
            try
            {
                Actor actor = _mapper.Map<ActorDto, Actor>(actorDto);

                _dbTraillerContext.Actors.Update(actor);
                await _dbTraillerContext.SaveChangesAsync();

                return _mapper.Map<Actor, ActorDto>(actor);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> DeleteActor(int id)
        {
            try
            {
                Actor actor = await _dbTraillerContext.Actors.FindAsync(id);

                if (actor == null) { return false; }

                _dbTraillerContext.Remove(actor);
                await _dbTraillerContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
