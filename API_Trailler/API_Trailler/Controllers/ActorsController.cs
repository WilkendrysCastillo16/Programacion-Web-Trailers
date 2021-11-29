using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Trailler.Data;
using API_Trailler.Models;
using API_Trailler.Services.Interface;
using API_Trailler.Models.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace API_Trailler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly IActorServices _actorServices;
        protected ResponseDto _responseDto;
        public ActorsController(IActorServices actorServices)
        {
            _actorServices = actorServices;
            _responseDto = new ResponseDto();
        }

        // GET: api/Actor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actor>>> GetActors()
        {
            try
            {
                var listaActor = await _actorServices.GetActors();
                _responseDto.Result = listaActor;
                _responseDto.Mensaje = "Lista de Actor";
            }
            catch (Exception ex)
            {
                _responseDto.Correcto = false;
                _responseDto.ErrorMensaje = new List<string> { ex.ToString() };
            }

            return Ok(_responseDto);
        }

        // GET: api/Actor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Actor>> GetActor(int id)
        {
            var actor = await _actorServices.GetActorById(id);
            if (actor == null)
            {
                _responseDto.Correcto = false;
                _responseDto.Mensaje = "El Actor no existe";
                return NotFound(_responseDto);
            }
           _responseDto.Result = actor;
            _responseDto.Mensaje = "Informacion del Actor";

            return Ok(_responseDto);
        }

        // PUT: api/Actors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutActor(int id, ActorDto actorDto)
        {
            try
            {
                ActorDto model = await _actorServices.UpdateActor(actorDto);
                _responseDto.Result = model;
                return Ok(_responseDto);
            }
            catch (Exception ex)
            {
                _responseDto.Correcto = false;
                _responseDto.Mensaje = "Error al actualizar el Actor";
                _responseDto.ErrorMensaje = new List<string> { ex.ToString() };
                return BadRequest(_responseDto);
            }
        }

        // POST: api/Actors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Actor>> PostActor(ActorDto actorDto)
        {
            try
            {
                ActorDto model = await _actorServices.AddActor(actorDto);
                _responseDto.Result = model;

                return CreatedAtAction("GetActor", new { id = model.Id }, _responseDto);
            }
            catch (Exception ex)
            {
                _responseDto.Correcto = false;
                _responseDto.Mensaje = "Error al insertar el Actor";
                _responseDto.ErrorMensaje = new List<string> { ex.ToString() };
                return BadRequest(_responseDto);
            }
        }

        // DELETE: api/Actors/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteActor(int id)
        {
            try
            {
                bool eliminado = await _actorServices.DeleteActor(id);
                if (eliminado)
                {
                    _responseDto.Result = eliminado;
                    _responseDto.Mensaje = "Actor eliminado correctamente";
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
