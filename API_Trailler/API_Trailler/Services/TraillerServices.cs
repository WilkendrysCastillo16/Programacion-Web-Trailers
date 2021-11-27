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
    public class TraillerServices : ITraillerServices
    {
        private readonly dbTraillerContext _dbTraillerContext;
        private IMapper _mapper;
        public TraillerServices(dbTraillerContext dbTraillerContext, IMapper mapper)
        {
            _dbTraillerContext = dbTraillerContext;
            _mapper = mapper;
        }

        public async Task<TraillerDto> AddTrailler(TraillerDto traillerDto)
        {
            Trailler trailler = _mapper.Map<TraillerDto, Trailler>(traillerDto);

            try
            {
                await _dbTraillerContext.Traillers.AddAsync(trailler);
                await _dbTraillerContext.SaveChangesAsync();
                return _mapper.Map<Trailler, TraillerDto>(trailler);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> DeleteTrailler(int id)
        {
            try
            {
                Trailler trailler = await _dbTraillerContext.Traillers.FindAsync(id);

                if(trailler == null) { return false; }

                _dbTraillerContext.Remove(trailler);
                await _dbTraillerContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<TraillerDto> GetTraillerById(int id)
        {
            Trailler trailler = await _dbTraillerContext.Traillers.FindAsync(id);

            return _mapper.Map<TraillerDto>(trailler);
        }

        public async Task<List<TraillerDto>> GetTraillers()
        {
            List<Trailler> listaTrailler = await _dbTraillerContext.Traillers.ToListAsync();
            
            return _mapper.Map<List<TraillerDto>>(listaTrailler); 
        }

        public async Task<TraillerDto> UpdateTrailler(TraillerDto traillerDto)
        {
            Trailler trailler = _mapper.Map<TraillerDto, Trailler>(traillerDto);

            try
            {
                _dbTraillerContext.Traillers.Update(trailler);
                await _dbTraillerContext.SaveChangesAsync();
                return _mapper.Map<Trailler, TraillerDto>(trailler);
            }
            catch
            {
                throw;
            }
        }
    }
}
