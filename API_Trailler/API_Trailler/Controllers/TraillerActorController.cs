using API_Trailler.Models;
using API_Trailler.Models.DTOs;
using API_Trailler.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Trailler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TraillerActorController : ControllerBase
    {
        private readonly ITraillerActorServices _traillerActorServices;
        protected ResponseDto _responseDto;
        public TraillerActorController(ITraillerActorServices traillerActorServices)
        {
            _traillerActorServices = traillerActorServices;
            _responseDto = new ResponseDto();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TraillerActor>>> GetTraillerActor()
        {
            try
            {
                var listaTraillerActor = await _traillerActorServices.GetTraillerActor();
                _responseDto.Result = listaTraillerActor;
                _responseDto.Mensaje = "Lista de Trailler-Actor";
                return Ok(_responseDto);
            }
            catch (Exception ex)
            {
                _responseDto.Correcto = false;
                _responseDto.ErrorMensaje = new List<string> { ex.ToString() };
                return BadRequest(_responseDto);
            }
        }

        [HttpGet("Completo")]
        public async Task<ActionResult<List<TraillerActorJoinDto>>> GetTraillerActorJoin()
        {
            try
            {
                var listaTraillerActor = await _traillerActorServices.GetTraillerActorJoin();
                _responseDto.Result = listaTraillerActor;
                _responseDto.Mensaje = "Lista de Trailler-Actor con Autores";
                return Ok(_responseDto);
            }
            catch (Exception ex)
            {
                _responseDto.Correcto = false;
                _responseDto.ErrorMensaje = new List<string> { ex.ToString() };
                return BadRequest(_responseDto);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TraillerActor>> GetTraillerActor(int id)
        {
            var trailler = await _traillerActorServices.GetTraillerActorById(id);
            if (trailler == null)
            {
                _responseDto.Correcto = false;
                _responseDto.Mensaje = "El trailler no existe";
                return NotFound(_responseDto);
            }
            _responseDto.Result = trailler;
            _responseDto.Mensaje = "Informacion del trailler";

            return Ok(_responseDto);
        }

        [HttpGet("Completo/{id}")]
        public async Task<ActionResult<TraillerActorJoinDto>> GetTraillerActorJoinById(int id)
        {
            var traillerActorDto = await _traillerActorServices.GetTraillerActorJoinById(id);
            if (traillerActorDto == null)
            {
                _responseDto.Correcto = false;
                _responseDto.Mensaje = "El trailler no existe";
                return NotFound(_responseDto);
            }
            _responseDto.Result = traillerActorDto;
            _responseDto.Mensaje = "Informacion del trailler";

            return Ok(_responseDto);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<TraillerActor>> AddTraillerActor(TraillerActorDto traillerActorDto)
        {
            try
            {
                TraillerActorDto model = await _traillerActorServices.AddTraillerActor(traillerActorDto);
                _responseDto.Result = model;

                return CreatedAtAction("GetTraillerActor", new { id = model.Id }, _responseDto);
            }
            catch (Exception ex)
            {
                _responseDto.Correcto = false;
                _responseDto.Mensaje = "Error al insertar el trailler-actor";
                _responseDto.ErrorMensaje = new List<string> { ex.ToString() };
                return BadRequest(_responseDto);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateTraillerActor(int id, TraillerActorDto traillerActorDto)
        {
            try
            {
                TraillerActorDto model = await _traillerActorServices.UpdateTraillerActor(traillerActorDto);
                _responseDto.Result = model;
                return Ok(_responseDto);
            }
            catch (Exception ex)
            {
                _responseDto.Correcto = false;
                _responseDto.Mensaje = "Error al actualizar el Trailler-Actor";
                _responseDto.ErrorMensaje = new List<string> { ex.ToString() };
                return BadRequest(_responseDto);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteTraillerActor(int id)
        {
            try
            {
                bool eliminado = await _traillerActorServices.DeleteTraillerActor(id);
                if (eliminado)
                {
                    _responseDto.Result = eliminado;
                    _responseDto.Mensaje = "Trailler eliminado correctamente";
                    return Ok(_responseDto);
                }
                else
                {
                    _responseDto.Correcto = false;
                    _responseDto.Mensaje = "Error al eliminar un cliente";
                    return BadRequest(_responseDto);
                }
            }
            catch (Exception ex)
            {
                _responseDto.Correcto = false;
                _responseDto.Result = new List<string> { ex.ToString() };
                return BadRequest(_responseDto);
            }
        }
    }
}
