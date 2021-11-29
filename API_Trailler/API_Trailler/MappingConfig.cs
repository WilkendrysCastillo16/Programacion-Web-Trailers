using API_Trailler.Models;
using API_Trailler.Models.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Trailler
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<TraillerDto, Trailler>();
                config.CreateMap<Trailler, TraillerDto>();

                config.CreateMap<TraillerActorDto, TraillerActor>();
                config.CreateMap<TraillerActor, TraillerActorDto>();


            });
            return mappingConfig;
        }
    }
}
