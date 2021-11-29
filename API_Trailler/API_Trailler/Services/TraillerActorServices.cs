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
    public class TraillerActorServices : ITraillerActorServices
    {
        private readonly dbTraillerContext _dbTraillerContext;
        private IMapper _mapper;
        public TraillerActorServices(dbTraillerContext dbTraillerContext, IMapper mapper)
        {
             _dbTraillerContext = dbTraillerContext;
            _mapper = mapper;
        }

        public async Task<List<TraillerActorDto>> GetTraillerActor()
        {
            List<TraillerActor> listaTraillerActor = await _dbTraillerContext.TraillerActors.ToListAsync();

            return _mapper.Map<List<TraillerActorDto>>(listaTraillerActor);
        }

        public async Task<List<TraillerActorJoinDto>> GetTraillerActorJoin()
        {
            try
            {
                List<Trailler> trailler = await _dbTraillerContext.Traillers.ToListAsync();
                List<TraillerActor> traillerActor = await _dbTraillerContext.TraillerActors.ToListAsync();
                List<TraillerActorJoinDto> traillerConActores = new List<TraillerActorJoinDto>();

                BuscarTrailler(trailler, traillerActor, traillerConActores);

                return traillerConActores;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<TraillerActorDto> GetTraillerActorById(int id)
        {
            TraillerActor traillerActor = await _dbTraillerContext.TraillerActors.FindAsync(id);

            return _mapper.Map<TraillerActorDto>(traillerActor);
        }

        public async Task<TraillerActorJoinDto> GetTraillerActorJoinById(int id)
        {
            List<TraillerActor> traillerActor = await _dbTraillerContext.TraillerActors.ToListAsync();
            List<Trailler> trailler = new List<Trailler>();

            for(int i = 0; i < traillerActor.Count; i++)
            {
                if(traillerActor[i].Id == id)
                {
                    trailler.Add(_dbTraillerContext.Traillers.Where(t => t.Id == traillerActor[i].IdTrailler).FirstOrDefault());
                    break;
                }
            }

            var traillerFiltrado = new Trailler
            {
                Id = trailler[0].Id,
                Title = trailler[0].Title,
                Director = trailler[0].Director,
                Review = trailler[0].Review,
                YearTrailer = trailler[0].YearTrailer,
                Cover = trailler[0].Cover,
                Link = trailler[0].Link,
                Rating = trailler[0].Rating
            };

            List<Actor> listaActorFiltrado = new List<Actor>();

            BuscarActores(trailler,traillerActor,listaActorFiltrado, 0);

            var traillerActorJoinDto = new TraillerActorJoinDto { 
                    trailler = traillerFiltrado,
                    actor = listaActorFiltrado
            };

            return traillerActorJoinDto;
        }

        public async Task<TraillerActorDto> AddTraillerActor(TraillerActorDto traillerActorDto)
        {
            try
            {
                TraillerActor traillerActor = _mapper.Map<TraillerActorDto, TraillerActor>(traillerActorDto);

                await _dbTraillerContext.TraillerActors.AddAsync(traillerActor);
                await _dbTraillerContext.SaveChangesAsync();

                return _mapper.Map<TraillerActor, TraillerActorDto>(traillerActor);
            }
            catch 
            {

                throw;
            }
        }

        public async Task<TraillerActorDto> UpdateTraillerActor(TraillerActorDto traillerActorDto)
        {
            TraillerActor traillerActor = _mapper.Map<TraillerActorDto, TraillerActor>(traillerActorDto);

            try
            {
                if (traillerActor.Id > 0)
                {
                    _dbTraillerContext.TraillerActors.Update(traillerActor);
                    await _dbTraillerContext.SaveChangesAsync();
                }

                return _mapper.Map<TraillerActor, TraillerActorDto>(traillerActor);
            }
            catch
            {

                throw;
            }
        }

        public async Task<bool> DeleteTraillerActor(int id)
        {
            try
            {
                TraillerActor traillerActor = await _dbTraillerContext.TraillerActors.FindAsync(id);

                if (traillerActor == null) { return false; }

                _dbTraillerContext.Remove(traillerActor);
                await _dbTraillerContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Metodos fuera de la Interfaz

        public void BuscarActores(List<Trailler> trailler, List<TraillerActor> traillerActor, List<Actor> listaActorFiltrado, int i)
        {
            for (int j = 0; j < traillerActor.Count; j++)
            {
                if (traillerActor[j].IdTrailler == trailler[i].Id)
                {
                    var actor = _dbTraillerContext.Actors.Where(a => a.Id == traillerActor[j].IdActor && trailler[i].Id == traillerActor[j].IdTrailler).FirstOrDefault();

                    var actorFiltrado = new Actor
                    {
                        Id = actor.Id,
                        NameActor = actor.NameActor,
                        LastName = actor.LastName
                    };
                    listaActorFiltrado.Add(actorFiltrado);
                }
            }
        }

        public void BuscarTrailler(List<Trailler> trailler, List<TraillerActor> traillerActor, List<TraillerActorJoinDto> traillerConActores)
        {
            for (int i = 0; i < trailler.Count; i++)
            {
                List<Actor> listaActorFiltrado = new List<Actor>();

                var traillerFiltrado = new Trailler
                {
                    Id = trailler[i].Id,
                    Title = trailler[i].Title,
                    Director = trailler[i].Director,
                    Review = trailler[i].Review,
                    YearTrailer = trailler[i].YearTrailer,
                    Cover = trailler[i].Cover,
                    Link = trailler[i].Link,
                    Rating = trailler[i].Rating
                };

                BuscarActores(trailler, traillerActor, listaActorFiltrado, i);

                var traillerActorJoinDto = new TraillerActorJoinDto
                {
                    trailler = traillerFiltrado,
                    actor = listaActorFiltrado
                };

                traillerConActores.Add(traillerActorJoinDto);
            }
        }
    }
}
